using System;
using System.Collections.Generic;
using System.Drawing;
using TP2_Echecs.Echecs.Enums;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    public class Partie : IJeu
    {
        private StatusPartie previousStatus;

        StatusPartie status
        {
            get { return _status; }
            set
            {
                _status = value;
                vue.ActualiserPartie(_status);
            }
        }

        public IEvenements vue { get; set; }
        public List<InfoPiece> Captures { get; internal set; }


        /* attributs */

        StatusPartie _status = StatusPartie.Reset;

        /* associations */

        IEvenements _vue;
        public Joueur blancs;
        public Joueur noirs;
        public Echiquier echiquier;

        /* methodes */

        public Partie()
        {

        }

        public Partie(Partie p)
        {
            blancs = (Joueur)p.blancs.Clone();
            noirs = (Joueur)p.noirs.Clone();

            blancs.partie = this;
            noirs.partie = this;

            _status = p._status;

            Captures = p.Captures;
            echiquier = (Echiquier)p.echiquier.Clone();

            foreach (Piece item in blancs.pieces)
            {
                echiquier.Cases[item.numColonne, item.numLigne].Link(item);
            }
            foreach (Piece item in noirs.pieces)
            {
                echiquier.Cases[item.numColonne, item.numLigne].Link(item);
            }
        }

        public void CommencerPartie()
        {
            // creation des joueurs
            blancs = new Joueur(this, CouleurCamp.Blanche);
            noirs = new Joueur(this, CouleurCamp.Noire);

            // creation de l'echiquier
            echiquier = new Echiquier();

            // Création de la liste des pieces capturés
            Captures = new List<InfoPiece>();

            ClearCheckboard();
            // Placement des pieces
            blancs.PlacerPieces(echiquier);
            noirs.PlacerPieces(echiquier);

            // Actualise les blancs
            vue.ActualiserCase(0, 0, InfoPiece.TourNoire);
            vue.ActualiserCase(1, 0, InfoPiece.CavalierNoir);
            vue.ActualiserCase(2, 0, InfoPiece.FouNoir);

            vue.ActualiserCase(3, 0, InfoPiece.DameNoire);
            vue.ActualiserCase(4, 0, InfoPiece.RoiNoir);
            vue.ActualiserCase(5, 0, InfoPiece.FouNoir);
            vue.ActualiserCase(6, 0, InfoPiece.CavalierNoir);
            vue.ActualiserCase(7, 0, InfoPiece.TourNoire);

            for (int i = 0; i < 8; i++)
            {
                vue.ActualiserCase(i, 1, InfoPiece.PionNoir);
            }

            // Actualise les noirs
            vue.ActualiserCase(0, 7, InfoPiece.TourBlanche);
            vue.ActualiserCase(1, 7, InfoPiece.CavalierBlanc);
            vue.ActualiserCase(2, 7, InfoPiece.FouBlanc);

            vue.ActualiserCase(3, 7, InfoPiece.DameBlanche);
            vue.ActualiserCase(4, 7, InfoPiece.RoiBlanc);
            vue.ActualiserCase(5, 7, InfoPiece.FouBlanc);
            vue.ActualiserCase(6, 7, InfoPiece.CavalierBlanc);
            vue.ActualiserCase(7, 7, InfoPiece.TourBlanche);

            for (int i = 0; i < 8; i++)
            {
                vue.ActualiserCase(i, 6, InfoPiece.PionBlanc);
            }

            // initialisation de l'état
            status = StatusPartie.TraitBlancs;
        }

        public void ClearCheckboard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    vue.ActualiserCase(i, j, null);
                }
            }
        }

        public bool CanMove(Case depart, Case destination, out Piece specialPiece)
        {
            // Init special piece
            specialPiece = null;
            // Piece de départ
            Piece piece = depart.linkedPiece;

            // En cas de coup spécial
            bool isSpecialMove = false;

            if (piece == null)
                return false;

            #region Prises spéciales
            // Cas du pion (Prise en passant)
            if (piece.info.type == TypePiece.Pion)
            {
                // Prise en passant
                if (Math.Abs(destination.NumColonne - piece.numColonne) == 1 && Math.Abs(destination.NumLigne - piece.numLigne) == 1)
                {
                    Pion enpassantTarget = null;

                    int lineoffset = 0;
                    if (destination.NumLigne == 2 && piece.info.couleur == CouleurCamp.Blanche)
                    {
                        lineoffset = 1;
                    }
                    else if (destination.NumLigne == 5 && piece.info.couleur == CouleurCamp.Noire)
                    {
                        lineoffset = -1;
                    }

                    if (echiquier.Cases[destination.NumColonne, destination.NumLigne + lineoffset].linkedPiece != null)
                    {
                        if (typeof(Pion) == echiquier.Cases[destination.NumColonne, destination.NumLigne + lineoffset].linkedPiece.GetType())
                        {
                            enpassantTarget = (Pion)echiquier.Cases[destination.NumColonne, destination.NumLigne + lineoffset].linkedPiece;
                        }

                        if (enpassantTarget != null && enpassantTarget.moves == 1)
                        {
                            destination.linkedPiece = enpassantTarget;
                            isSpecialMove = true;
                        }
                    }
                }
            }
            else if (piece.info.type == TypePiece.Roi && piece.moves == 0 && destination.linkedPiece == null
            && (destination.NumLigne == 0 || destination.NumLigne == 7))
            {
                specialPiece = piece.joueur.pieces.Find(x => x.info.type == TypePiece.Tour
                && x.moves == 0
                && Math.Abs(x.numColonne - destination.NumColonne) == 1);
            }

            #endregion

            // Vérification des obstacles et des types de mouvements
            if (!piece.Deplacer(destination) && !isSpecialMove && specialPiece == null || !CheckPath(piece, destination))
                return false;

            return true;
        }
        public bool DeplacerPiece(int x_depart, int y_depart, int x_arrivee, int y_arrivee, bool forceMove)
        {
            // case de départ
            Case depart = echiquier.Cases[x_depart, y_depart];

            // Case d'arrivée
            Case destination = echiquier.Cases[x_arrivee, y_arrivee];

            // Pièce de départ
            Piece piece = depart.linkedPiece;
            Piece specialPiece;

            if (depart == destination || (!CanMove(depart, destination, out specialPiece)))
                return false;

            piece.moves++;

            // Check Promotion
            if (destination.NumLigne == 0 && piece.info.couleur == CouleurCamp.Blanche
            || destination.NumLigne == 7 && piece.info.couleur == CouleurCamp.Noire)
            {
                Upgrade upgradeDial = new Upgrade
                {
                    StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
                };
                upgradeDial.ShowDialog();
                piece = ((Pion)piece).Promouvoir(upgradeDial.choosenPiece);
                piece.position = destination;
            }
            if(specialPiece != null)
            {
                DeplacerPiece(specialPiece.numColonne,
                            specialPiece.numLigne,
                            specialPiece.numColonne + ((destination.NumColonne - specialPiece.numColonne) * 2),
                            specialPiece.numLigne, true);
            }

            if (destination.linkedPiece != null)
            {
                TakePiece(destination.linkedPiece);
            }

            // Actualisation des cases
            vue.ActualiserCase(x_depart, y_depart, null);
            vue.ActualiserCase(x_arrivee, y_arrivee, piece.info);

            // Changement d'état des cases
            destination.Link(piece);
            depart.Unlink(piece);


            bool echec;
            bool mat;
            Piece roi;
            // Vérification de l'echec et du mat adverse
            if (status == StatusPartie.TraitBlancs)
                roi = noirs.pieces.Find(x => x.info.type == TypePiece.Roi);
            else
                roi = blancs.pieces.Find(x => x.info.type == TypePiece.Roi);

            echec = CheckDanger(CaseFromPiece(roi), roi.info.couleur);
            mat = echec && AvailableMoves(roi).Count == 0;

            ChangerEtat(echec, mat);

            return true;
        }

        private Case CaseFromPiece(Piece p)
        {
            return echiquier.Cases[p.numColonne, p.numLigne];
        }

        private void TakePiece(Piece piece)
        {
            #region Score
            Captures.Add(piece.info);

            if (piece.info.couleur == CouleurCamp.Blanche)
            {
                noirs.Score += 10;
                noirs.pieces.Remove(piece);
                noirs.Score += 100;
            }
            else
            {
                blancs.Score += 10;
                blancs.pieces.Remove(piece);
                blancs.Score += 100;
            }

            vue.ActualiserCase(piece.numColonne, piece.numLigne, null);

            #endregion
        }

        private bool CheckDanger(Case destination, CouleurCamp couleur)
        {
            List<Point> moves = new List<Point>();
            if (couleur == CouleurCamp.Noire)
            {
                moves = AvailableMoves(CouleurCamp.Blanche, true);
            }
            else
            {
                moves = AvailableMoves(CouleurCamp.Noire, true);
            }

            if (moves.Exists(x => x.X == destination.NumColonne && x.Y == destination.NumLigne))
            {
                return true;
            }

            return false;
        }

        private bool CheckPath(Piece piece, Case destination)
        {
            if (piece.info.type == TypePiece.Cavalier)
                return true;

            if (piece.position.NumColonne == destination.NumColonne)
            {
                int min = Math.Min(piece.position.NumLigne, destination.NumLigne);
                int max = Math.Max(piece.position.NumLigne, destination.NumLigne);
                for (int i = min + 1; i < max; i++)
                {
                    Piece linkedPiece = echiquier.Cases[piece.position.NumColonne, i].linkedPiece;
                    if (linkedPiece != null && !linkedPiece.ignoreInCheckPath)
                    {
                        if (!echiquier.Cases[piece.position.NumColonne, i].linkedPiece.ignoreInCheckPath)
                        {
                            return false;
                        }
                    }
                }
            }
            else if (piece.position.NumLigne == destination.NumLigne)
            {
                int min = Math.Min(piece.position.NumColonne, destination.NumColonne);
                int max = Math.Max(piece.position.NumColonne, destination.NumColonne);
                for (int i = min + 1; i < max; i++)
                {
                    Piece linkedPiece = echiquier.Cases[i, piece.position.NumLigne].linkedPiece;
                    if (linkedPiece != null && !linkedPiece.ignoreInCheckPath)
                        return false;
                }
            }
            else if (piece.position.NumColonne != destination.NumColonne &&
                    piece.position.NumLigne != destination.NumLigne)
            {
                int difCol = 1;
                int difLine = 1;

                if (destination.NumLigne < piece.position.NumLigne)
                {
                    difLine = -1;
                }

                if (destination.NumColonne < piece.position.NumColonne)
                {
                    difCol = -1;
                }

                int distanceX = Math.Abs(destination.NumColonne - piece.position.NumColonne);
                int distanceY = Math.Abs(destination.NumLigne - piece.position.NumLigne);

                for (int i = 1; i < distanceX; i++)
                {
                    if (echiquier.Cases[piece.position.NumColonne + difCol * i, piece.position.NumLigne + difLine * i].linkedPiece != null)
                        return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        void ChangerEtat(bool echec = false, bool mat = false)
        {
            if (echec)
            {
                if (status.couleur == CouleurCamp.Noire)
                {
                    status = StatusPartie.EchecBlancs;
                }
                else
                {
                    status = StatusPartie.EchecNoirs;
                }
            }
            else if (mat)
            {
                if (status == StatusPartie.TraitNoirs || status == StatusPartie.EchecNoirs)
                {
                    status = StatusPartie.MatNoirs;
                }
                else
                {
                    status = StatusPartie.MatBlancs;
                }
            }
            else
            {
                if (status == StatusPartie.TraitBlancs)
                {
                    status = StatusPartie.TraitNoirs;
                }
                else
                {
                    status = StatusPartie.TraitBlancs;
                }

            }

        }

        public void PausePlay()
        {
            previousStatus = status;
            status = StatusPartie.Pause;
        }

        public void ResumePlay()
        {
            status = previousStatus;
        }

        public void LoadHistory(Snapshot s)
        {
            echiquier = s.partie.echiquier;
            blancs = s.partie.blancs;
            noirs = s.partie.noirs;
            Captures = s.partie.Captures;
            previousStatus = s.partie.previousStatus;
            status = s.partie.status;
        }

        public List<Point> AvailableMoves(Piece p, bool ignoreEchec = false)
        {
            if (p.availableMoves != null)
                return p.availableMoves;

            List<Point> moves = new List<Point>();
            Case currentCase = echiquier.Cases[p.numColonne, p.numLigne];
            Piece specialPiece;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Piece linkedPiece = echiquier.Cases[i, j].linkedPiece;
                    if (linkedPiece != null && p.info.couleur == linkedPiece.info.couleur)
                    {
                        continue;
                    }
                    if (CanMove(currentCase, echiquier.Cases[i, j], out specialPiece))
                    {
                        moves.Add(new Point(i, j));
                    }
                }
            }

            if (p.info.type == TypePiece.Roi)
            {
                // Vérification de la non mise en échec lors du déplacement du roi.
                if (!ignoreEchec)
                {
                    Point[] tmpMoves = new Point[moves.Count];
                    p.ignoreInCheckPath = true;

                    moves.CopyTo(tmpMoves);
                    foreach (Point m in tmpMoves)
                    {
                        if (CheckDanger(echiquier.Cases[m.X, m.Y], p.info.couleur))
                        {
                            moves.Remove(m);
                        }
                    }

                    p.ignoreInCheckPath = false;
                }
            }

            return moves;
        }

        public List<Point> AvailableMoves(CouleurCamp couleur, bool ignoreEchec = false)
        {
            List<Point> result = new List<Point>();

            if (couleur == CouleurCamp.Blanche)
            {
                foreach (Piece p in blancs.pieces)
                {
                    result.AddRange(AvailableMoves(p, ignoreEchec));
                }
            }
            else
            {
                foreach (Piece p in noirs.pieces)
                {
                    result.AddRange(AvailableMoves(p, ignoreEchec));
                }
            }

            return result;
        }
    }
}
