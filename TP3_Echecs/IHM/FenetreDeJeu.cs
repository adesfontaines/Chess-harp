using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TP2_Echecs.Echecs;
using TP2_Echecs.Echecs.Enums;

namespace TP2_Echecs.IHM
{
    public partial class FenetreDeJeu : Form, IEvenements
    {
        #region Attributs

        // référence sur la façade du << moteur de jeu >>
        IJeu jeu;

        // graphisme des carreaux de l'échiquier
        const int RANGEES = 8;
        const int COLONNES = 8;
        const int CARREAU_TAILLE = 42;
        Color CARREAU_NOIR = Color.FromArgb(189, 117, 53);
        Color CARREAU_BLANC = Color.FromArgb(229, 197, 105);

        // visualisation de l'échiquier
        PictureBox[,] carreaux = new PictureBox[COLONNES, RANGEES];

        // visualisation des captures
        const int CAPTURES = 15;
        PictureBox[] captures_blancs = new PictureBox[CAPTURES];
        PictureBox[] captures_noirs = new PictureBox[CAPTURES];

        // liste des pieces
        List<Bitmap> piecesBlanches = new List<Bitmap>();
        List<Bitmap> piecesNoires = new List<Bitmap>();

        // liste des curseurs
        Dictionary<InfoPiece, Cursor> curseurs = new Dictionary<InfoPiece, Cursor>();

        // gestion du drag & drop
        Color picFromBackupColor;
        PictureBox picFrom, picTo;
        Image imgFrom;
        List<Point> availableMoves;

        // status de la partie
        StatusPartie status;

        // chronomètres des jouers
        Stopwatch tempsBlancs = new Stopwatch();
        Stopwatch tempsNoirs = new Stopwatch();

        // Historique des coups
        List<Snapshot> MoveHistory;
        int historyIndex = 0;

        #endregion

        #region Constructeur

        public FenetreDeJeu(IJeu jeu)
        {
            InitializeComponent();
            BringToFront();
            // initialisation de l'association
            this.jeu = jeu;
            this.jeu.vue = this;

            // initialisation de l'IHM
            CreationEchiquier();

            // initialisation de l'état
            status = StatusPartie.Reset;

            // commencer une nouvelle partie
            CommencerPartie();
        }

        #endregion

        #region Interface IEvenements

        public void ActualiserCase(int x, int y, InfoPiece info)
        {
            if (info == null)
                carreaux[x, y].Image = null;
            else if (info.couleur == CouleurCamp.Blanche)
                carreaux[x, y].Image = piecesBlanches[(int)info.type];
            else
                carreaux[x, y].Image = piecesNoires[(int)info.type];
        }

        public void ActualiserCaptures(List<InfoPiece> pieces)
        {
            int idx_noirs = 0;
            int idx_blancs = 0;

            foreach (InfoPiece p in pieces)
            {
                if (p.couleur == CouleurCamp.Blanche)
                    captures_noirs[idx_noirs++].Image = piecesBlanches[(int)p.type];
                else
                    captures_blancs[idx_blancs++].Image = piecesNoires[(int)p.type];
            }

            lblBlacksCaptures.Text = idx_noirs.ToString();
            lblWhitesCaptures.Text = idx_blancs.ToString();

        }

        public void ActualiserPartie(StatusPartie status)
        {
            this.status = status;

            if (status.etat == EtatPartie.Pause)
                return;
            // arreter les chronomètres
            tempsBlancs.Stop();
            tempsNoirs.Stop();

            // demarrer le chronomètre du joueur actif
            if (status.etat != EtatPartie.Reset && status.etat != EtatPartie.Mat)
            {
                if (status.couleur == CouleurCamp.Blanche)
                    tempsBlancs.Start();
                else
                    tempsNoirs.Start();
            }

            // actualiser les etiquettes des chronomètres
            RenderClockLabels(status);
            // demarrer/arreter le timer de l'IHM
            if (status.etat == EtatPartie.Reset || status.etat == EtatPartie.Mat)
                timer.Stop();
            else
            {
                if (!timer.Enabled)
                    timer.Start();
            }

        }

        #endregion

        #region Interface IJeu

        void CommencerPartie()
        {
            // reset des chronomètres
            tempsBlancs.Reset();
            tempsNoirs.Reset();

            tbrUndoMove.Enabled = false;
            tbrUndoAllMoves.Enabled = false;
            tbrRedoAllMoves.Enabled = false;
            tbrRedoMove.Enabled = false;

            // commencer une partie
            jeu.CommencerPartie();

            MoveHistory = new List<Snapshot>();

            lvwMoveHistory.Items.Clear();
            lblWhitesCaptures.Text = "0";
            lblBlacksCaptures.Text = "0";

            Partie p = (Partie)jeu;
            MoveHistory.Add(new Snapshot
            {
                BlackScore = 0,
                WhiteScore = 0,
                HistoryItems = new List<string[]>(),
                partie = new Partie(p)

            });
        }

        void DeplacerPiece(int x_depart, int y_depart, int x_arrivee, int y_arrivee, bool makeMove = true)
        {
            if(jeu.DeplacerPiece(x_depart, y_depart, x_arrivee, y_arrivee))
            {
                string[] row = 
                { lvwMoveHistory.Items.Count.ToString(), (tempsBlancs.Elapsed + tempsNoirs.Elapsed).ToString(@"hh\:mm\:ss"), 
                $"{PieceStringFormatPosition(x_depart,y_depart)} to " +
                $"{PieceStringFormatPosition(x_arrivee,y_arrivee)}" };

                lvwMoveHistory.Items.Add(new ListViewItem(row));

                List<string[]> newList = new List<string[]>();

                foreach (ListViewItem item in lvwMoveHistory.Items)
                {
                    string[] subrow = { item.SubItems[0].Text,
                    item.SubItems[1].Text,
                    item.SubItems[2].Text};

                    newList.Add(subrow);
                }

                Partie p = (Partie)jeu;

                if (historyIndex < MoveHistory.Count - 1)
                {
                    MoveHistory.RemoveRange(historyIndex, MoveHistory.Count - 1 - historyIndex);
                    tbrRedoMove.Enabled = false;
                    tbrRedoAllMoves.Enabled = false;
                }

                MoveHistory.Add(new Snapshot()
                {
                    HistoryItems = newList,
                    BlackScore = int.Parse(lblBlackScore.Text),
                    WhiteScore = int.Parse(lblWhiteScore.Text),
                    partie = new Partie(p)
                });

                historyIndex++;

                RefreshScoreAndTakenPieces();

                tbrUndoMove.Enabled = true;
                tbrUndoAllMoves.Enabled = true;
            }
        }

        private string PieceStringFormatPosition(int x_depart, int y_depart)
        {
            string x = Math.Abs(y_depart - 8).ToString();
            Char c = (Char)((true ? 65 : 97) + (x_depart));

            return x + c;
        }

        private void RefreshScoreAndTakenPieces()
        {
            lblBlackScore.Text = ((Partie)jeu).noirs.Score.ToString();
            lblWhiteScore.Text = ((Partie)jeu).blancs.Score.ToString();

            ActualiserCaptures(((Partie)jeu).Captures);
        }

        #endregion

        #region Fonctions de l'IHM

        void CreationEchiquier()
        {
            // création des carreaux pour l'échiquier
            int idx = 0;
            bool blanc;
            for (int y = 0; y < RANGEES; y++)
            {
                blanc = y % 2 == 0 ? true : false;

                for (int x = 0; x < COLONNES; x++)
                {
                    carreaux[x, y] = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.CenterImage,
                        Size = new Size(CARREAU_TAILLE, CARREAU_TAILLE),
                        Left = x * CARREAU_TAILLE + 2,
                        Top = y * CARREAU_TAILLE + 1,
                        Tag = idx++,
                        BackColor = blanc ? CARREAU_BLANC : CARREAU_NOIR
                    };
                    blanc = !blanc;

                    carreaux[x, y].MouseDown += carreau_MouseDown;
                    carreaux[x, y].DragEnter += carreau_DragEnter;
                    carreaux[x, y].DragDrop += carreau_DragDrop;
                    carreaux[x, y].GiveFeedback += carreau_GiveFeedback;
                    carreaux[x, y].AllowDrop = true;

                    pnlEdging.Controls.Add(carreaux[x, y]);
                }
            }

            // création des carreaux pour les piéces capturées
            for (int i = 0; i < CAPTURES; i++)
            {
                captures_blancs[i] = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Size = new Size(CARREAU_TAILLE, CARREAU_TAILLE),
                    Left = i * (CARREAU_TAILLE + 1) + 1,
                    Top = 384,
                    BackColor = SystemColors.ControlDark,
                    Tag = i
                };

                captures_noirs[i] = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Size = new Size(CARREAU_TAILLE, CARREAU_TAILLE),
                    Left = i * (CARREAU_TAILLE + 1) + 1,
                    Top = 384 + CARREAU_TAILLE + 1,
                    BackColor = SystemColors.ControlDark,
                    Tag = i
                };

                pnlMain.Controls.Add(captures_blancs[i]);
                pnlMain.Controls.Add(captures_noirs[i]);
            }

            // initialisation des images pour les pièces blanches
            piecesBlanches.Add(Properties.Resources.King_White);
            piecesBlanches.Add(Properties.Resources.Queen_White);
            piecesBlanches.Add(Properties.Resources.Rook_White);
            piecesBlanches.Add(Properties.Resources.Bishop_White);
            piecesBlanches.Add(Properties.Resources.Knight_White);
            piecesBlanches.Add(Properties.Resources.Pawn_White);

            // initialisation des images pour les pièces noires
            piecesNoires.Add(Properties.Resources.King_Black);
            piecesNoires.Add(Properties.Resources.Queen_Black);
            piecesNoires.Add(Properties.Resources.Rook_Black);
            piecesNoires.Add(Properties.Resources.Bishop_Black);
            piecesNoires.Add(Properties.Resources.Knight_Black);
            piecesNoires.Add(Properties.Resources.Pawn_Black);

            // associations images-pièces
            piecesBlanches[0].Tag = InfoPiece.RoiBlanc;
            piecesBlanches[1].Tag = InfoPiece.DameBlanche;
            piecesBlanches[2].Tag = InfoPiece.TourBlanche;
            piecesBlanches[3].Tag = InfoPiece.FouBlanc;
            piecesBlanches[4].Tag = InfoPiece.CavalierBlanc;
            piecesBlanches[5].Tag = InfoPiece.PionBlanc;
            piecesNoires[0].Tag = InfoPiece.RoiNoir;
            piecesNoires[1].Tag = InfoPiece.DameNoire;
            piecesNoires[2].Tag = InfoPiece.TourNoire;
            piecesNoires[3].Tag = InfoPiece.FouNoir;
            piecesNoires[4].Tag = InfoPiece.CavalierNoir;
            piecesNoires[5].Tag = InfoPiece.PionNoir;

            // création de la liste des curseurs 
            string strPath = "../../IHM/Cursors/";
            curseurs.Add(InfoPiece.RoiBlanc, new Cursor(strPath + "WhiteKing.cur"));
            curseurs.Add(InfoPiece.DameBlanche, new Cursor(strPath + "WhiteQueen.cur"));
            curseurs.Add(InfoPiece.TourBlanche, new Cursor(strPath + "WhiteRook.cur"));
            curseurs.Add(InfoPiece.FouBlanc, new Cursor(strPath + "WhiteBishop.cur"));
            curseurs.Add(InfoPiece.CavalierBlanc, new Cursor(strPath + "WhiteKnight.cur"));
            curseurs.Add(InfoPiece.PionBlanc, new Cursor(strPath + "WhitePawn.cur"));
            curseurs.Add(InfoPiece.RoiNoir, new Cursor(strPath + "BlackKing.cur"));
            curseurs.Add(InfoPiece.DameNoire, new Cursor(strPath + "BlackQueen.cur"));
            curseurs.Add(InfoPiece.TourNoire, new Cursor(strPath + "BlackRook.cur"));
            curseurs.Add(InfoPiece.FouNoir, new Cursor(strPath + "BlackBishop.cur"));
            curseurs.Add(InfoPiece.CavalierNoir, new Cursor(strPath + "BlackKnight.cur"));
            curseurs.Add(InfoPiece.PionNoir, new Cursor(strPath + "BlackPawn.cur"));
        }

        void carreau_MouseDown(object sender, MouseEventArgs e)
        {

            // sauvegarder le carreau de départ
            picFrom = sender as PictureBox;
            imgFrom = picFrom.Image;

            // terminer s'il n'y a pas de pièce sur le carreau
            if (imgFrom == null)
                return;

            // informations sur la pièce contenue dans le carreau
            InfoPiece piece = imgFrom.Tag as InfoPiece;

            // terminer si la partie n'est pas active ou si la couleur de la piece selectionnée ne corresponde pas à la couleur du joueur qui joue dans ce tours
            if (status.etat == EtatPartie.Reset || status.etat == EtatPartie.Mat || status.couleur != piece.couleur)
                return;

            // calculer les indices des carreaux de départ et arrivée
            int idxFrom = Convert.ToInt32(picFrom.Tag);

            // transformer les indices lineaires en numeros de rangée et colonne
            int x1 = idxFrom % 8;        // colonne du carreau de départ
            int y1 = (idxFrom - x1) / 8; // rangée du carreau de départ

            availableMoves = ((Partie)jeu).AvailableMoves(((Partie)jeu).echiquier.Cases[x1, y1].linkedPiece);
            DisplayHints();
            // demarrer le Drag & Drop
            picFrom.DoDragDrop(imgFrom, DragDropEffects.Move);

            // remettre le curseur
            pnlEdging.Cursor = Cursors.Default;

            // remettre l'image sur le carreau de départ
            picFrom.Image = imgFrom;
            picFrom.BorderStyle = BorderStyle.None;

            // terminer s'il n'y a pas de carreau cible
            if (picTo == null)
            {
                ResetHintColors();
                return;
            }

            // calculer les indices des carreaux de départ et arrivée
            int idxTo = Convert.ToInt32(picTo.Tag);

            // transformer les indices lineaires en numeros de rangée et colonne
            int x2 = idxTo % 8;          // colonne du carreau d'arrivée
            int y2 = (idxTo - x2) / 8;   // rangée du carreau d'arrivée

            // reset du carreau cible
            picTo = null;

            // invoquer l'operation << DeplacerPiece >>
            DeplacerPiece(x1, y1, x2, y2);
        }

        void carreau_DragDrop(object sender, DragEventArgs e)
        {
            // sauvegarder le carreau cible
            picTo = sender as PictureBox;

            ResetHintColors();
        }

        void DisplayHints()
        {
            // marquer le carreau de départ
            Color c = picFrom.BackColor;
            picFromBackupColor = Color.FromArgb(c.R, c.G, c.B);
            picFrom.BackColor = Color.Gray;

            // Affiche les coups possibles
            foreach (Point kvp in availableMoves)
            {
                carreaux[kvp.X, kvp.Y].BackColor = Color.Yellow;
                if (carreaux[kvp.X, kvp.Y].Image != null)
                {
                    carreaux[kvp.X, kvp.Y].BackColor = Color.Red;
                }
            }
        }
        void ResetHintColors()
        {
            picFrom.BackColor = picFromBackupColor;
            foreach (Point kvp in availableMoves)
            {
                bool blanc = kvp.X % 2 == 0 ? true : false;

                if (blanc)
                {
                    blanc = kvp.Y % 2 == 0 ? true : false;
                }
                else
                {
                    blanc = kvp.Y % 2 == 0 ? false : true;
                }
                carreaux[kvp.X, kvp.Y].BackColor = blanc ? CARREAU_BLANC : CARREAU_NOIR;
            }
        }
        void carreau_DragEnter(object sender, DragEventArgs e)
        {
            // autoriser le drop                
            e.Effect = DragDropEffects.Move;

            // changer le curseur
            pnlEdging.Cursor = curseurs[imgFrom.Tag as InfoPiece];

            // effacer l'image du carreau de départ
            picFrom.Image = null;
            picFrom.Refresh();
        }

        void carreau_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        void RenderClocks()
        {
            lblWhiteClock.Text = SpanToString(tempsBlancs.Elapsed);
            lblBlackClock.Text = SpanToString(tempsNoirs.Elapsed);
            lblWhiteClock.Refresh();
            lblBlackClock.Refresh();
        }

        void RenderClockLabels(StatusPartie status)
        {
            if (status.etat != EtatPartie.Pause)
            {
                // selectionner l'etiquette du joueur actif
                Label lab1, lab2;
                if (status.couleur == CouleurCamp.Blanche)
                {
                    lab1 = lblWhiteClock;
                    lab2 = lblBlackClock;
                }
                else
                {
                    lab1 = lblBlackClock;
                    lab2 = lblWhiteClock;
                }

                // souligner le chronomètre du joueur actif
                lab1.BorderStyle = BorderStyle.FixedSingle;
                lab2.BorderStyle = BorderStyle.None;
                lab1.BackColor = status.etat == EtatPartie.Mat ? Color.Red : (status.etat == EtatPartie.Echec ? Color.Orange : Color.LightGray);
                lab2.BackColor = Color.FromName(KnownColor.Control.ToString());
            }
        }

        string SpanToString(TimeSpan span)
        {
            return span.Hours.ToString().PadLeft(2, '0')
                   + ":"
                   + span.Minutes.ToString().PadLeft(2, '0')
                   + ":"
                   + span.Seconds.ToString().PadLeft(2, '0');
        }

        private void tbr_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Tag.ToString())
            {
                case "New":
                    // création des carreaux pour les piéces capturées
                    for (int i = 0; i < CAPTURES; i++)
                    {
                        captures_blancs[i].Image = null;
                        captures_blancs[i].Refresh();
                        captures_blancs[i].Update();

                        captures_noirs[i].Image = null;
                        captures_noirs[i].Refresh();
                        captures_noirs[i].Update();
                    }
                    status = StatusPartie.Reset;
                    CommencerPartie();
                    break;

                case "Open":
                    Open();
                    break;

                case "Save":
                    Save();
                    break;

                case "UndoMove":
                    Undo();
                    break;

                case "RedoMove":
                    Redo();
                    break;

                case "UndoAllMoves":
                    UndoAll();
                    break;

                case "RedoAllMoves":
                    RedoAll();
                    break;

                case "FlipBoard":
                    Flipboard();
                    break;

                case "Think":
                    // TODO
                    break;

                case "MoveNow":
                    
                    // TODO
                    break;

                case "ResumePlay":
                    ResumePlay();
                    break;

                case "PausePlay":
                    PausePlay();
                    break;
            }
        }

        #region Toolbar
        private void PausePlay()
        {
            PictureBox fade = new PictureBox
            {
                Size = new Size(CARREAU_TAILLE * 8, CARREAU_TAILLE * 8),
                BackColor = Color.FromArgb(150, 0, 0, 0),
                Left = 0,
                Top = 0
            };
            pnlEdging.Controls.Add(fade);

            timer.Stop(); 
            tempsBlancs.Stop();
            tempsNoirs.Stop();
            jeu.PausePlay();
            pnlEdging.Enabled = false;
            tbrResumePlay.Enabled = true;
            tbrPausePlay.Enabled = false;
        }

        private void ResumePlay()
        {
            tempsBlancs.Start();
            tempsNoirs.Start();
            timer.Start();
            jeu.ResumePlay();
            pnlEdging.Enabled = true;
            tbrResumePlay.Enabled = false;
            tbrPausePlay.Enabled = true;
        }

        private void Open()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Sauvegarde (*.sav)|*.sav"
            };

            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
            }
        }

        private void Flipboard()
        {
            ((Partie)jeu).echiquier.Flip();

            ((Partie)jeu).ClearCheckboard();

            foreach (Piece item in ((Partie)jeu).blancs.pieces)
            {
                ActualiserCase(item.numLigne, item.numColonne, item.info);
            }

            foreach (Piece item in ((Partie)jeu).noirs.pieces)
            {
                ActualiserCase(item.numLigne, item.numColonne, item.info);
            }

        }
        private void LoadHistory(int historyIndex)
        {
            Snapshot s = MoveHistory.ElementAt(historyIndex);
            jeu.LoadHistory(s);
            
            lvwMoveHistory.Items.Clear();
            ((Partie)jeu).ClearCheckboard();

            lblWhiteScore.Text = s.WhiteScore.ToString();
            lblBlackScore.Text = s.BlackScore.ToString();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Piece p = ((Partie)jeu).echiquier.Cases[i, j].linkedPiece;
                    if (p != null)
                        jeu.vue.ActualiserCase(i, j, p.info);
                }
            }

            foreach(string[] item in s.HistoryItems)
                lvwMoveHistory.Items.Add(new ListViewItem(item));
        }
        private void Undo()
        {
            tbrRedoMove.Enabled = true;
            tbrRedoAllMoves.Enabled = true;

            historyIndex--;
            LoadHistory(historyIndex);
            if (historyIndex == 0)
            {
                tbrUndoMove.Enabled = false;
                tbrUndoAllMoves.Enabled = false;
            }

            RefreshScoreAndTakenPieces();
        }

        private void Redo()
        {
            tbrUndoAllMoves.Enabled = true;
            tbrUndoMove.Enabled = true;

            historyIndex++;
            LoadHistory(historyIndex);

            if (MoveHistory.Count - 1 == historyIndex)
            {
                tbrRedoMove.Enabled = false;
                tbrRedoAllMoves.Enabled = false;
            }

            RefreshScoreAndTakenPieces();

        }

        private void UndoAll()
        {
            tbrUndoMove.Enabled = false;
            tbrUndoAllMoves.Enabled = false;

            historyIndex = 0;
            LoadHistory(historyIndex);

            tbrRedoMove.Enabled = true;
            tbrRedoAllMoves.Enabled = true;
        }

        private void RedoAll()
        {
            tbrRedoMove.Enabled = false;
            tbrRedoAllMoves.Enabled = false;

            historyIndex = MoveHistory.Count - 1;
            LoadHistory(historyIndex);

            tbrUndoMove.Enabled = true;
            tbrUndoAllMoves.Enabled = true;
        }

        private void Save()
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Sauvegarde (*.sav)|*.sav"
            };
            DialogResult result = sfd.ShowDialog();

            if (result == DialogResult.OK)
            {
            }
        }
        #endregion


        private void pnlEdging_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            RenderClocks();
        }

        #endregion

    }
}