namespace ChessSharp.IHM
{
    partial class GameWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.imgToolMenus = new System.Windows.Forms.ImageList(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbrUndoMove = new System.Windows.Forms.ToolStripButton();
            this.tbrRedoMove = new System.Windows.Forms.ToolStripButton();
            this.lvwMoveHistory = new System.Windows.Forms.ListView();
            this.lvcMoveNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvcMove = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBlacksCaptures = new System.Windows.Forms.Label();
            this.lblWhitesCaptures = new System.Windows.Forms.Label();
            this.lblBlackClock = new System.Windows.Forms.Label();
            this.lblBlackPosition = new System.Windows.Forms.Label();
            this.lblBlackScore = new System.Windows.Forms.Label();
            this.lblBlackPoints = new System.Windows.Forms.Label();
            this.lblWhiteClock = new System.Windows.Forms.Label();
            this.lblWhitePosition = new System.Windows.Forms.Label();
            this.lblWhiteScore = new System.Windows.Forms.Label();
            this.lblWhitePoints = new System.Windows.Forms.Label();
            this.lblPlayerClocks = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.imgTiles = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.pnlEdging = new System.Windows.Forms.Panel();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgToolMenus
            // 
            this.imgToolMenus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgToolMenus.ImageStream")));
            this.imgToolMenus.TransparentColor = System.Drawing.Color.Transparent;
            this.imgToolMenus.Images.SetKeyName(0, "");
            this.imgToolMenus.Images.SetKeyName(1, "");
            this.imgToolMenus.Images.SetKeyName(2, "");
            this.imgToolMenus.Images.SetKeyName(3, "");
            this.imgToolMenus.Images.SetKeyName(4, "");
            this.imgToolMenus.Images.SetKeyName(5, "");
            this.imgToolMenus.Images.SetKeyName(6, "");
            this.imgToolMenus.Images.SetKeyName(7, "");
            this.imgToolMenus.Images.SetKeyName(8, "");
            this.imgToolMenus.Images.SetKeyName(9, "");
            this.imgToolMenus.Images.SetKeyName(10, "");
            this.imgToolMenus.Images.SetKeyName(11, "");
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.tableLayoutPanel1);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.lblBlacksCaptures);
            this.pnlMain.Controls.Add(this.lblWhitesCaptures);
            this.pnlMain.Controls.Add(this.lblBlackClock);
            this.pnlMain.Controls.Add(this.lblBlackPosition);
            this.pnlMain.Controls.Add(this.lblBlackScore);
            this.pnlMain.Controls.Add(this.lblBlackPoints);
            this.pnlMain.Controls.Add(this.lblWhiteClock);
            this.pnlMain.Controls.Add(this.lblWhitePosition);
            this.pnlMain.Controls.Add(this.lblWhiteScore);
            this.pnlMain.Controls.Add(this.lblWhitePoints);
            this.pnlMain.Controls.Add(this.lblPlayerClocks);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(6);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1029, 778);
            this.pnlMain.TabIndex = 34;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.77833F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.22167F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 52);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1029, 726);
            this.tableLayoutPanel1.TabIndex = 158;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.pnlEdging);
            this.panel5.Controls.Add(this.label21);
            this.panel5.Controls.Add(this.label20);
            this.panel5.Controls.Add(this.label19);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(763, 720);
            this.panel5.TabIndex = 159;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 12.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(619, 668);
            this.label21.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 41);
            this.label21.TabIndex = 157;
            this.label21.Text = "h";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(542, 668);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(36, 41);
            this.label20.TabIndex = 156;
            this.label20.Text = "g";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 12.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(465, 668);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 41);
            this.label19.TabIndex = 155;
            this.label19.Text = "f";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(388, 668);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(34, 41);
            this.label18.TabIndex = 154;
            this.label18.Text = "e";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 598);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 41);
            this.label13.TabIndex = 142;
            this.label13.Text = "1";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(311, 668);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 41);
            this.label17.TabIndex = 153;
            this.label17.Text = "d";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 520);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 41);
            this.label6.TabIndex = 143;
            this.label6.Text = "2";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(234, 668);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 41);
            this.label16.TabIndex = 152;
            this.label16.Text = "c";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 443);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 41);
            this.label7.TabIndex = 144;
            this.label7.Text = "3";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(157, 668);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 41);
            this.label15.TabIndex = 151;
            this.label15.Text = "b";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 365);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 41);
            this.label8.TabIndex = 145;
            this.label8.Text = "4";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(80, 668);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 41);
            this.label14.TabIndex = 150;
            this.label14.Text = "a";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 287);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 41);
            this.label9.TabIndex = 146;
            this.label9.Text = "5";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 55);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 41);
            this.label12.TabIndex = 149;
            this.label12.Text = "8";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 210);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 41);
            this.label10.TabIndex = 147;
            this.label10.Text = "6";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 132);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 41);
            this.label11.TabIndex = 148;
            this.label11.Text = "7";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lvwMoveHistory, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(772, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(254, 720);
            this.tableLayoutPanel2.TabIndex = 160;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbrUndoMove,
            this.tbrRedoMove});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 651);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(254, 69);
            this.toolStrip1.TabIndex = 35;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbrUndoMove
            // 
            this.tbrUndoMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbrUndoMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrUndoMove.Name = "tbrUndoMove";
            this.tbrUndoMove.Size = new System.Drawing.Size(40, 63);
            this.tbrUndoMove.Text = "◁";
            this.tbrUndoMove.ToolTipText = "Undo";
            // 
            // tbrRedoMove
            // 
            this.tbrRedoMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbrRedoMove.Image = ((System.Drawing.Image)(resources.GetObject("tbrRedoMove.Image")));
            this.tbrRedoMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrRedoMove.Name = "tbrRedoMove";
            this.tbrRedoMove.Size = new System.Drawing.Size(40, 63);
            this.tbrRedoMove.Text = "▷";
            this.tbrRedoMove.ToolTipText = "Redo";
            // 
            // lvwMoveHistory
            // 
            this.lvwMoveHistory.BackColor = System.Drawing.SystemColors.Window;
            this.lvwMoveHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwMoveHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvcMoveNo,
            this.lvcMove});
            this.lvwMoveHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwMoveHistory.HideSelection = false;
            this.lvwMoveHistory.Location = new System.Drawing.Point(6, 6);
            this.lvwMoveHistory.Margin = new System.Windows.Forms.Padding(6);
            this.lvwMoveHistory.Name = "lvwMoveHistory";
            this.lvwMoveHistory.Scrollable = false;
            this.lvwMoveHistory.Size = new System.Drawing.Size(242, 639);
            this.lvwMoveHistory.TabIndex = 39;
            this.lvwMoveHistory.UseCompatibleStateImageBehavior = false;
            this.lvwMoveHistory.View = System.Windows.Forms.View.Details;
            // 
            // lvcMoveNo
            // 
            this.lvcMoveNo.Text = "#";
            this.lvcMoveNo.Width = 19;
            // 
            // lvcMove
            // 
            this.lvcMove.Text = "Move";
            this.lvcMove.Width = 150;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1012, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 42);
            this.label5.TabIndex = 136;
            this.label5.Text = "Black";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(821, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 42);
            this.label3.TabIndex = 135;
            this.label3.Text = "White";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBlacksCaptures
            // 
            this.lblBlacksCaptures.BackColor = System.Drawing.Color.Transparent;
            this.lblBlacksCaptures.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBlacksCaptures.CausesValidation = false;
            this.lblBlacksCaptures.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlacksCaptures.Location = new System.Drawing.Point(1181, 790);
            this.lblBlacksCaptures.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBlacksCaptures.Name = "lblBlacksCaptures";
            this.lblBlacksCaptures.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBlacksCaptures.Size = new System.Drawing.Size(77, 78);
            this.lblBlacksCaptures.TabIndex = 134;
            this.lblBlacksCaptures.Text = "0";
            this.lblBlacksCaptures.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWhitesCaptures
            // 
            this.lblWhitesCaptures.BackColor = System.Drawing.Color.Transparent;
            this.lblWhitesCaptures.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWhitesCaptures.CausesValidation = false;
            this.lblWhitesCaptures.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhitesCaptures.Location = new System.Drawing.Point(1181, 709);
            this.lblWhitesCaptures.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWhitesCaptures.Name = "lblWhitesCaptures";
            this.lblWhitesCaptures.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblWhitesCaptures.Size = new System.Drawing.Size(77, 78);
            this.lblWhitesCaptures.TabIndex = 133;
            this.lblWhitesCaptures.Text = "0";
            this.lblWhitesCaptures.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBlackClock
            // 
            this.lblBlackClock.BackColor = System.Drawing.Color.Transparent;
            this.lblBlackClock.CausesValidation = false;
            this.lblBlackClock.ForeColor = System.Drawing.Color.Black;
            this.lblBlackClock.Location = new System.Drawing.Point(1017, 64);
            this.lblBlackClock.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBlackClock.Name = "lblBlackClock";
            this.lblBlackClock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBlackClock.Size = new System.Drawing.Size(176, 42);
            this.lblBlackClock.TabIndex = 130;
            this.lblBlackClock.Text = ":";
            this.lblBlackClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBlackPosition
            // 
            this.lblBlackPosition.BackColor = System.Drawing.Color.Transparent;
            this.lblBlackPosition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBlackPosition.CausesValidation = false;
            this.lblBlackPosition.Location = new System.Drawing.Point(1017, 212);
            this.lblBlackPosition.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBlackPosition.Name = "lblBlackPosition";
            this.lblBlackPosition.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBlackPosition.Size = new System.Drawing.Size(176, 42);
            this.lblBlackPosition.TabIndex = 128;
            this.lblBlackPosition.Text = "0";
            this.lblBlackPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBlackScore
            // 
            this.lblBlackScore.BackColor = System.Drawing.Color.Transparent;
            this.lblBlackScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBlackScore.CausesValidation = false;
            this.lblBlackScore.Location = new System.Drawing.Point(1017, 123);
            this.lblBlackScore.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBlackScore.Name = "lblBlackScore";
            this.lblBlackScore.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBlackScore.Size = new System.Drawing.Size(176, 42);
            this.lblBlackScore.TabIndex = 127;
            this.lblBlackScore.Text = "0";
            this.lblBlackScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBlackPoints
            // 
            this.lblBlackPoints.BackColor = System.Drawing.Color.Transparent;
            this.lblBlackPoints.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBlackPoints.CausesValidation = false;
            this.lblBlackPoints.Location = new System.Drawing.Point(1017, 168);
            this.lblBlackPoints.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBlackPoints.Name = "lblBlackPoints";
            this.lblBlackPoints.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBlackPoints.Size = new System.Drawing.Size(176, 42);
            this.lblBlackPoints.TabIndex = 125;
            this.lblBlackPoints.Text = "0";
            this.lblBlackPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWhiteClock
            // 
            this.lblWhiteClock.BackColor = System.Drawing.Color.Transparent;
            this.lblWhiteClock.CausesValidation = false;
            this.lblWhiteClock.ForeColor = System.Drawing.Color.Black;
            this.lblWhiteClock.Location = new System.Drawing.Point(826, 64);
            this.lblWhiteClock.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWhiteClock.Name = "lblWhiteClock";
            this.lblWhiteClock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblWhiteClock.Size = new System.Drawing.Size(176, 42);
            this.lblWhiteClock.TabIndex = 124;
            this.lblWhiteClock.Text = ":";
            this.lblWhiteClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWhitePosition
            // 
            this.lblWhitePosition.BackColor = System.Drawing.Color.Transparent;
            this.lblWhitePosition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWhitePosition.CausesValidation = false;
            this.lblWhitePosition.Location = new System.Drawing.Point(826, 212);
            this.lblWhitePosition.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWhitePosition.Name = "lblWhitePosition";
            this.lblWhitePosition.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblWhitePosition.Size = new System.Drawing.Size(176, 42);
            this.lblWhitePosition.TabIndex = 122;
            this.lblWhitePosition.Text = "0";
            this.lblWhitePosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWhiteScore
            // 
            this.lblWhiteScore.BackColor = System.Drawing.Color.Transparent;
            this.lblWhiteScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWhiteScore.CausesValidation = false;
            this.lblWhiteScore.Location = new System.Drawing.Point(826, 123);
            this.lblWhiteScore.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWhiteScore.Name = "lblWhiteScore";
            this.lblWhiteScore.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblWhiteScore.Size = new System.Drawing.Size(176, 42);
            this.lblWhiteScore.TabIndex = 121;
            this.lblWhiteScore.Text = "0";
            this.lblWhiteScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWhitePoints
            // 
            this.lblWhitePoints.BackColor = System.Drawing.Color.Transparent;
            this.lblWhitePoints.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWhitePoints.CausesValidation = false;
            this.lblWhitePoints.Location = new System.Drawing.Point(826, 168);
            this.lblWhitePoints.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWhitePoints.Name = "lblWhitePoints";
            this.lblWhitePoints.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblWhitePoints.Size = new System.Drawing.Size(176, 42);
            this.lblWhitePoints.TabIndex = 119;
            this.lblWhitePoints.Text = "0";
            this.lblWhitePoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayerClocks
            // 
            this.lblPlayerClocks.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerClocks.Location = new System.Drawing.Point(724, 64);
            this.lblPlayerClocks.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPlayerClocks.Name = "lblPlayerClocks";
            this.lblPlayerClocks.Size = new System.Drawing.Size(88, 44);
            this.lblPlayerClocks.TabIndex = 118;
            this.lblPlayerClocks.Text = "Clock";
            this.lblPlayerClocks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(724, 212);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 44);
            this.label2.TabIndex = 116;
            this.label2.Text = "Position";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(738, 123);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 44);
            this.label4.TabIndex = 115;
            this.label4.Text = "Score";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(738, 168);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 44);
            this.label1.TabIndex = 114;
            this.label1.Text = "Points";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 333;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // imgTiles
            // 
            this.imgTiles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTiles.ImageStream")));
            this.imgTiles.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTiles.Images.SetKeyName(0, "");
            this.imgTiles.Images.SetKeyName(1, "");
            // 
            // toolStrip2
            // 
            this.toolStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripButton3});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(1029, 57);
            this.toolStrip2.TabIndex = 35;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.AutoSize = false;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem4});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(65, 33);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(312, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(315, 40);
            this.toolStripMenuItem4.Text = "Quit";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(74, 34);
            this.toolStripButton3.Text = "About";
            // 
            // pnlEdging
            // 
            this.pnlEdging.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlEdging.BackColor = System.Drawing.Color.Brown;
            this.pnlEdging.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEdging.Location = new System.Drawing.Point(50, 34);
            this.pnlEdging.Margin = new System.Windows.Forms.Padding(6);
            this.pnlEdging.Name = "pnlEdging";
            this.pnlEdging.Size = new System.Drawing.Size(626, 630);
            this.pnlEdging.TabIndex = 35;
            this.pnlEdging.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlEdging_MouseMove);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("testToolStripMenuItem.Image")));
            this.testToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.testToolStripMenuItem.Text = "New game";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.New);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1029, 778);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "GameWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ChessSharp";
            this.pnlMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgToolMenus;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ListView lvwMoveHistory;
        private System.Windows.Forms.ColumnHeader lvcMoveNo;
        private System.Windows.Forms.ColumnHeader lvcMove;
        private System.Windows.Forms.Label lblBlacksCaptures;
        private System.Windows.Forms.Label lblWhitesCaptures;
        private System.Windows.Forms.Label lblBlackClock;
        private System.Windows.Forms.Label lblBlackPosition;
        private System.Windows.Forms.Label lblBlackScore;
        private System.Windows.Forms.Label lblBlackPoints;
        private System.Windows.Forms.Label lblWhiteClock;
        private System.Windows.Forms.Label lblWhitePosition;
        private System.Windows.Forms.Label lblWhiteScore;
        private System.Windows.Forms.Label lblWhitePoints;
        private System.Windows.Forms.Label lblPlayerClocks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ImageList imgTiles;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbrUndoMove;
        private System.Windows.Forms.ToolStripButton tbrRedoMove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Panel pnlEdging;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
    }
}