using ChessSharp.Chess;
using ChessSharp.Chess.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace ChessSharp.IHM
{
    public partial class GameWindow : Form, IEvents
    {
        #region Attributs

        // référence sur la façade du << moteur de jeu >>
        IGame jeu;

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
        Dictionary<PieceInfo, Cursor> curseurs = new Dictionary<PieceInfo, Cursor>();

        // gestion du drag & drop
        Color picFromBackupColor;
        PictureBox picFrom, picTo;
        Image imgFrom;
        List<Point> availableMoves;

        // status de la partie
        StatusPartie status;
        SoundPlayer moveSound;

        // chronomètres des jouers
        Stopwatch tempsBlancs = new Stopwatch();
        Stopwatch tempsNoirs = new Stopwatch();

        // Historique des coups
        List<Snapshot> MoveHistory;
        int historyIndex = 0;

        #endregion

        #region Constructeur

        public GameWindow(IGame jeu)
        {
            InitializeComponent();
            BringToFront();
            // initialisation de l'association
            this.jeu = jeu;
            this.jeu.vue = this;

            // initialisation de l'IHM
            CreateChessboard();

            // Preload sound effect
            moveSound = new SoundPlayer(@"../../IHM/Sounds/move.wav");

            // initialisation de l'état
            status = StatusPartie.Reset;

            // commencer une nouvelle partie
            StartGame();
        }

        #endregion

        #region Interface IEvenements

        public void ActualiserCase(int x, int y, PieceInfo info)
        {
            if (info == null)
                carreaux[x, y].Image = null;
            else if (info.couleur == PlayerColor.White)
                carreaux[x, y].Image = piecesBlanches[(int)info.type];
            else
                carreaux[x, y].Image = piecesNoires[(int)info.type];
        }

        public void ActualiserCaptures(List<PieceInfo> pieces)
        {
            int idx_noirs = 0;
            int idx_blancs = 0;

            foreach (PieceInfo p in pieces)
            {
                if (p.couleur == PlayerColor.White)
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
                if (status.couleur == PlayerColor.White)
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

        void StartGame()
        {
            // reset des chronomètres
            tempsBlancs.Reset();
            tempsNoirs.Reset();

            tbrUndoMove.Enabled = false;
            //tbrUndoAllMoves.Enabled = false;
            //tbrRedoAllMoves.Enabled = false;
            tbrRedoMove.Enabled = false;

            // commencer une partie
            jeu.CommencerPartie();

            MoveHistory = new List<Snapshot>();

            lvwMoveHistory.Items.Clear();
            lblWhitesCaptures.Text = "0";
            lblBlacksCaptures.Text = "0";

            Game p = (Game)jeu;
            MoveHistory.Add(new Snapshot
            {
                BlackScore = 0,
                WhiteScore = 0,
                HistoryItems = new List<string[]>(),
                partie = new Game(p)

            });
        }

        void MovePiece(int x_depart, int y_depart, int x_arrivee, int y_arrivee, bool makeMove = true)
        {

            if (jeu.MovePiece(x_depart, y_depart, x_arrivee, y_arrivee))
            {
                moveSound.Play();
                string[] row =
                { $"{lvwMoveHistory.Items.Count + 1}.",
                $"{PieceStringFormatPosition(x_depart,y_depart)} to " +
                $"{PieceStringFormatPosition(x_arrivee,y_arrivee)}" };

                lvwMoveHistory.Items.Add(new ListViewItem(row));

                List<string[]> newList = new List<string[]>();

                foreach (ListViewItem item in lvwMoveHistory.Items)
                {
                    string[] subrow = { item.SubItems[0].Text,
                    item.SubItems[1].Text};

                    newList.Add(subrow);
                }

                Game p = (Game)jeu;

                if (historyIndex < MoveHistory.Count - 1)
                {
                    MoveHistory.RemoveRange(historyIndex, MoveHistory.Count - 1 - historyIndex);
                    tbrRedoMove.Enabled = false;
                    //tbrRedoAllMoves.Enabled = false;
                }

                MoveHistory.Add(new Snapshot()
                {
                    HistoryItems = newList,
                    BlackScore = int.Parse(lblBlackScore.Text),
                    WhiteScore = int.Parse(lblWhiteScore.Text),
                    partie = new Game(p)
                });
                historyIndex++;

                RefreshScoreAndTakenPieces();

                tbrUndoMove.Enabled = true;
                //tbrUndoAllMoves.Enabled = true;
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
            lblBlackScore.Text = ((Game)jeu).noirs.Score.ToString();
            lblWhiteScore.Text = ((Game)jeu).blancs.Score.ToString();

            ActualiserCaptures(((Game)jeu).Captures);
        }

        #endregion

        #region Fonctions de l'IHM

        void CreateChessboard()
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
            piecesBlanches[0].Tag = PieceInfo.RoiBlanc;
            piecesBlanches[1].Tag = PieceInfo.DameBlanche;
            piecesBlanches[2].Tag = PieceInfo.TourBlanche;
            piecesBlanches[3].Tag = PieceInfo.FouBlanc;
            piecesBlanches[4].Tag = PieceInfo.CavalierBlanc;
            piecesBlanches[5].Tag = PieceInfo.PionBlanc;
            piecesNoires[0].Tag = PieceInfo.RoiNoir;
            piecesNoires[1].Tag = PieceInfo.DameNoire;
            piecesNoires[2].Tag = PieceInfo.TourNoire;
            piecesNoires[3].Tag = PieceInfo.FouNoir;
            piecesNoires[4].Tag = PieceInfo.CavalierNoir;
            piecesNoires[5].Tag = PieceInfo.PionNoir;

            // création de la liste des curseurs 
            string strPath = "../../IHM/Cursors/";
            curseurs.Add(PieceInfo.RoiBlanc, new Cursor(strPath + "WhiteKing.cur"));
            curseurs.Add(PieceInfo.DameBlanche, new Cursor(strPath + "WhiteQueen.cur"));
            curseurs.Add(PieceInfo.TourBlanche, new Cursor(strPath + "WhiteRook.cur"));
            curseurs.Add(PieceInfo.FouBlanc, new Cursor(strPath + "WhiteBishop.cur"));
            curseurs.Add(PieceInfo.CavalierBlanc, new Cursor(strPath + "WhiteKnight.cur"));
            curseurs.Add(PieceInfo.PionBlanc, new Cursor(strPath + "WhitePawn.cur"));
            curseurs.Add(PieceInfo.RoiNoir, new Cursor(strPath + "BlackKing.cur"));
            curseurs.Add(PieceInfo.DameNoire, new Cursor(strPath + "BlackQueen.cur"));
            curseurs.Add(PieceInfo.TourNoire, new Cursor(strPath + "BlackRook.cur"));
            curseurs.Add(PieceInfo.FouNoir, new Cursor(strPath + "BlackBishop.cur"));
            curseurs.Add(PieceInfo.CavalierNoir, new Cursor(strPath + "BlackKnight.cur"));
            curseurs.Add(PieceInfo.PionNoir, new Cursor(strPath + "BlackPawn.cur"));
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
            PieceInfo piece = imgFrom.Tag as PieceInfo;

            // terminer si la partie n'est pas active ou si la couleur de la piece selectionnée ne corresponde pas à la couleur du joueur qui joue dans ce tours
            if (status.etat == EtatPartie.Reset || status.etat == EtatPartie.Mat || status.couleur != piece.couleur)
                return;

            // calculer les indices des carreaux de départ et arrivée
            int idxFrom = Convert.ToInt32(picFrom.Tag);

            // transformer les indices lineaires en numeros de rangée et colonne
            int x1 = idxFrom % 8;        // colonne du carreau de départ
            int y1 = (idxFrom - x1) / 8; // rangée du carreau de départ

            availableMoves = ((Game)jeu).AvailableMoves(((Game)jeu).echiquier.Tiles[x1, y1].linkedPiece);
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
            MovePiece(x1, y1, x2, y2);
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
            picFrom.BorderStyle = BorderStyle.Fixed3D;

            // Affiche les coups possibles
            foreach (Point kvp in availableMoves)
            {
                carreaux[kvp.X, kvp.Y].BackColor = Color.Yellow;
                if (carreaux[kvp.X, kvp.Y].Image != null)
                {
                    carreaux[kvp.X, kvp.Y].BackColor = Color.DarkRed;
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
            pnlEdging.Cursor = curseurs[imgFrom.Tag as PieceInfo];

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
                if (status.couleur == PlayerColor.White)
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
            //tbrResumePlay.Enabled = true;
            //tbrPausePlay.Enabled = false;
        }

        private void ResumePlay()
        {
            tempsBlancs.Start();
            tempsNoirs.Start();
            timer.Start();
            jeu.ResumePlay();
            pnlEdging.Enabled = true;
            //tbrResumePlay.Enabled = false;
            //tbrPausePlay.Enabled = true;
        }

        private void Open(object sender, EventArgs e)
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
            ((Game)jeu).echiquier.Flip();

            ((Game)jeu).ClearCheckboard();

            foreach (Piece item in ((Game)jeu).blancs.pieces)
            {
                ActualiserCase(item.numLigne, item.numColonne, item.info);
            }

            foreach (Piece item in ((Game)jeu).noirs.pieces)
            {
                ActualiserCase(item.numLigne, item.numColonne, item.info);
            }

        }
        private void LoadHistory(int historyIndex)
        {
            Snapshot s = MoveHistory.ElementAt(historyIndex);
            jeu.LoadHistory(s);

            lvwMoveHistory.Items.Clear();
            ((Game)jeu).ClearCheckboard();

            lblWhiteScore.Text = s.WhiteScore.ToString();
            lblBlackScore.Text = s.BlackScore.ToString();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Piece p = ((Game)jeu).echiquier.Tiles[i, j].linkedPiece;
                    if (p != null)
                        jeu.vue.ActualiserCase(i, j, p.info);
                }
            }

            foreach (string[] item in s.HistoryItems)
                lvwMoveHistory.Items.Add(new ListViewItem(item));
        }

        private void New(object sender, EventArgs e)
        {
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
            StartGame();
        }
        private void Undo(object sender, EventArgs e)
        {
            tbrRedoMove.Enabled = true;
            //tbrRedoAllMoves.Enabled = true;

            historyIndex--;
            LoadHistory(historyIndex);
            if (historyIndex == 0)
            {
                tbrUndoMove.Enabled = false;
                //tbrUndoAllMoves.Enabled = false;
            }

            RefreshScoreAndTakenPieces();
        }

        private void Redo(object sender, EventArgs e)
        {
            //tbrUndoAllMoves.Enabled = true;
            tbrUndoMove.Enabled = true;

            historyIndex++;
            LoadHistory(historyIndex);

            if (MoveHistory.Count - 1 == historyIndex)
            {
                tbrRedoMove.Enabled = false;
                //tbrRedoAllMoves.Enabled = false;
            }

            RefreshScoreAndTakenPieces();

        }

        //private void UndoAll()
        //{
        //    tbrUndoMove.Enabled = false;
        //    tbrUndoAllMoves.Enabled = false;

        //    historyIndex = 0;
        //    LoadHistory(historyIndex);

        //    tbrRedoMove.Enabled = true;
        //    tbrRedoAllMoves.Enabled = true;
        //}

        //private void RedoAll()
        //{
        //    tbrRedoMove.Enabled = false;
        //    tbrRedoAllMoves.Enabled = false;

        //    historyIndex = MoveHistory.Count - 1;
        //    LoadHistory(historyIndex);

        //    tbrUndoMove.Enabled = true;
        //    tbrUndoAllMoves.Enabled = true;
        //}

        private void Save(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Chess save (*.sav)|*.sav"
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

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            RenderClocks();
        }

        #endregion

    }
}