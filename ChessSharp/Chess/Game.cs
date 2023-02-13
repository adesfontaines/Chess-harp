using ChessSharp.Chess.Enums;
using ChessSharp.IHM;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ChessSharp.Chess
{
    public class Game : IGame
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

        public IEvents vue { get; set; }
        public List<PieceInfo> Captures { get; internal set; }


        /* attributs */

        StatusPartie _status = StatusPartie.Reset;

        /* associations */

        IEvents _vue;
        public Player blancs;
        public Player noirs;
        public Chessboard echiquier;

        /* methodes */

        public Game()
        {

        }

        public Game(Game p)
        {
            blancs = (Player)p.blancs.Clone();
            noirs = (Player)p.noirs.Clone();

            blancs.partie = this;
            noirs.partie = this;

            _status = p._status;

            Captures = p.Captures;
            echiquier = (Chessboard)p.echiquier.Clone();

            foreach (Piece item in blancs.pieces)
            {
                echiquier.Tiles[item.numColonne, item.numLigne].Link(item);
            }
            foreach (Piece item in noirs.pieces)
            {
                echiquier.Tiles[item.numColonne, item.numLigne].Link(item);
            }
        }

        public void CommencerPartie()
        {
            // creation des joueurs
            blancs = new Player(this, PlayerColor.White);
            noirs = new Player(this, PlayerColor.Black);

            // creation de l'echiquier
            echiquier = new Chessboard();

            // Création de la liste des pieces capturés
            Captures = new List<PieceInfo>();

            ClearCheckboard();
            // Placement des pieces
            blancs.InitPieces(echiquier);
            noirs.InitPieces(echiquier);

            // Actualise les blancs
            vue.ActualiserCase(0, 0, PieceInfo.TourNoire);
            vue.ActualiserCase(1, 0, PieceInfo.CavalierNoir);
            vue.ActualiserCase(2, 0, PieceInfo.FouNoir);

            vue.ActualiserCase(3, 0, PieceInfo.DameNoire);
            vue.ActualiserCase(4, 0, PieceInfo.RoiNoir);
            vue.ActualiserCase(5, 0, PieceInfo.FouNoir);
            vue.ActualiserCase(6, 0, PieceInfo.CavalierNoir);
            vue.ActualiserCase(7, 0, PieceInfo.TourNoire);

            for (int i = 0; i < 8; i++)
            {
                vue.ActualiserCase(i, 1, PieceInfo.PionNoir);
            }

            // Actualise les noirs
            vue.ActualiserCase(0, 7, PieceInfo.TourBlanche);
            vue.ActualiserCase(1, 7, PieceInfo.CavalierBlanc);
            vue.ActualiserCase(2, 7, PieceInfo.FouBlanc);

            vue.ActualiserCase(3, 7, PieceInfo.DameBlanche);
            vue.ActualiserCase(4, 7, PieceInfo.RoiBlanc);
            vue.ActualiserCase(5, 7, PieceInfo.FouBlanc);
            vue.ActualiserCase(6, 7, PieceInfo.CavalierBlanc);
            vue.ActualiserCase(7, 7, PieceInfo.TourBlanche);

            for (int i = 0; i < 8; i++)
            {
                vue.ActualiserCase(i, 6, PieceInfo.PionBlanc);
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

        public bool CanMove(Tile depart, Tile destination, out Piece specialPiece)
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
            if (piece.info.type == TypePiece.Pawn)
            {
                // Prise en passant
                if (Math.Abs(destination.Column - piece.numColonne) == 1 && Math.Abs(destination.Line - piece.numLigne) == 1)
                {
                    Pawn enpassantTarget = null;

                    int lineoffset = 0;
                    if (destination.Line == 2 && piece.info.couleur == PlayerColor.White)
                    {
                        lineoffset = 1;
                    }
                    else if (destination.Line == 5 && piece.info.couleur == PlayerColor.Black)
                    {
                        lineoffset = -1;
                    }

                    if (echiquier.Tiles[destination.Column, destination.Line + lineoffset].linkedPiece != null)
                    {
                        if (typeof(Pawn) == echiquier.Tiles[destination.Column, destination.Line + lineoffset].linkedPiece.GetType())
                        {
                            enpassantTarget = (Pawn)echiquier.Tiles[destination.Column, destination.Line + lineoffset].linkedPiece;
                        }

                        if (enpassantTarget != null && enpassantTarget.moves == 1)
                        {
                            destination.linkedPiece = enpassantTarget;
                            isSpecialMove = true;
                        }
                    }
                }
            }
            else if (piece.info.type == TypePiece.King && piece.moves == 0 && destination.linkedPiece == null
            && (destination.Line == 0 || destination.Line == 7))
            {
                specialPiece = piece.joueur.pieces.Find(x => x.info.type == TypePiece.Tower
                && x.moves == 0
                && Math.Abs(x.numColonne - destination.Column) == 1);
            }

            #endregion

            // Vérification des obstacles et des types de mouvements
            if (!piece.Move(destination) && !isSpecialMove && specialPiece == null || !CheckPath(piece, destination))
                return false;

            return true;
        }
        public bool MovePiece(int x_depart, int y_depart, int x_arrivee, int y_arrivee, bool forceMove)
        {
            // case de départ
            Tile depart = echiquier.Tiles[x_depart, y_depart];

            // Case d'arrivée
            Tile destination = echiquier.Tiles[x_arrivee, y_arrivee];

            // Pièce de départ
            Piece piece = depart.linkedPiece;
            Piece specialPiece;

            if (depart == destination || (!CanMove(depart, destination, out specialPiece)))
                return false;

            piece.moves++;

            // Check Promotion
            if (piece.info.type == TypePiece.Pawn && destination.Line == 0 && piece.info.couleur == PlayerColor.White
            || destination.Line == 7 && piece.info.couleur == PlayerColor.Black)
            {
                Upgrade upgradeDial = new Upgrade
                {
                    StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
                };
                upgradeDial.ShowDialog();
                piece = ((Pawn)piece).Promouvoir(upgradeDial.choosenPiece);
                piece.position = destination;
            }
            if (specialPiece != null)
            {
                MovePiece(specialPiece.numColonne,
                            specialPiece.numLigne,
                            specialPiece.numColonne + ((destination.Column - specialPiece.numColonne) * 2),
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
                roi = noirs.pieces.Find(x => x.info.type == TypePiece.King);
            else
                roi = blancs.pieces.Find(x => x.info.type == TypePiece.King);

            echec = CheckDanger(CaseFromPiece(roi), roi.info.couleur);
            mat = echec && AvailableMoves(roi).Count == 0;

            ChangerEtat(echec, mat);

            return true;
        }

        private Tile CaseFromPiece(Piece p)
        {
            return echiquier.Tiles[p.numColonne, p.numLigne];
        }

        private void TakePiece(Piece piece)
        {
            #region Score
            Captures.Add(piece.info);

            if (piece.info.couleur == PlayerColor.White)
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

        private bool CheckDanger(Tile destination, PlayerColor couleur)
        {
            List<Point> moves = new List<Point>();
            if (couleur == PlayerColor.Black)
            {
                moves = AvailableMoves(PlayerColor.White, true);
            }
            else
            {
                moves = AvailableMoves(PlayerColor.Black, true);
            }

            if (moves.Exists(x => x.X == destination.Column && x.Y == destination.Line))
            {
                return true;
            }

            return false;
        }

        private bool CheckPath(Piece piece, Tile destination)
        {
            if (piece.info.type == TypePiece.Knight)
                return true;

            if (piece.position.Column == destination.Column)
            {
                int min = Math.Min(piece.position.Line, destination.Line);
                int max = Math.Max(piece.position.Line, destination.Line);
                for (int i = min + 1; i < max; i++)
                {
                    Piece linkedPiece = echiquier.Tiles[piece.position.Column, i].linkedPiece;
                    if (linkedPiece != null && !linkedPiece.ignoreInCheckPath)
                    {
                        if (!echiquier.Tiles[piece.position.Column, i].linkedPiece.ignoreInCheckPath)
                        {
                            return false;
                        }
                    }
                }
            }
            else if (piece.position.Line == destination.Line)
            {
                int min = Math.Min(piece.position.Column, destination.Column);
                int max = Math.Max(piece.position.Column, destination.Column);
                for (int i = min + 1; i < max; i++)
                {
                    Piece linkedPiece = echiquier.Tiles[i, piece.position.Line].linkedPiece;
                    if (linkedPiece != null && !linkedPiece.ignoreInCheckPath)
                        return false;
                }
            }
            else if (piece.position.Column != destination.Column &&
                    piece.position.Line != destination.Line)
            {
                int difCol = 1;
                int difLine = 1;

                if (destination.Line < piece.position.Line)
                {
                    difLine = -1;
                }

                if (destination.Column < piece.position.Column)
                {
                    difCol = -1;
                }

                int distanceX = Math.Abs(destination.Column - piece.position.Column);
                int distanceY = Math.Abs(destination.Line - piece.position.Line);

                for (int i = 1; i < distanceX; i++)
                {
                    if (echiquier.Tiles[piece.position.Column + difCol * i, piece.position.Line + difLine * i].linkedPiece != null)
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
                if (status.couleur == PlayerColor.Black)
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
            Tile currentCase = echiquier.Tiles[p.numColonne, p.numLigne];
            Piece specialPiece;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Piece linkedPiece = echiquier.Tiles[i, j].linkedPiece;
                    if (linkedPiece != null && p.info.couleur == linkedPiece.info.couleur)
                    {
                        continue;
                    }
                    if (CanMove(currentCase, echiquier.Tiles[i, j], out specialPiece))
                    {
                        moves.Add(new Point(i, j));
                    }
                }
            }

            if (p.info.type == TypePiece.King)
            {
                // Vérification de la non mise en échec lors du déplacement du roi.
                if (!ignoreEchec)
                {
                    Point[] tmpMoves = new Point[moves.Count];
                    p.ignoreInCheckPath = true;

                    moves.CopyTo(tmpMoves);
                    foreach (Point m in tmpMoves)
                    {
                        if (CheckDanger(echiquier.Tiles[m.X, m.Y], p.info.couleur))
                        {
                            moves.Remove(m);
                        }
                    }

                    p.ignoreInCheckPath = false;
                }
            }

            return moves;
        }

        public List<Point> AvailableMoves(PlayerColor couleur, bool ignoreEchec = false)
        {
            List<Point> result = new List<Point>();

            if (couleur == PlayerColor.White)
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
