using ChessSharp.Chess.Enums;
using System;
using System.Windows.Forms;

namespace ChessSharp.IHM
{
    public partial class Upgrade : Form
    {
        public TypePiece choosenPiece;

        public Upgrade()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            choosenPiece = TypePiece.Tower;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            choosenPiece = TypePiece.Bishop;
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            choosenPiece = TypePiece.Knight;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            choosenPiece = TypePiece.Queen;
            this.Close();
        }
    }
}
