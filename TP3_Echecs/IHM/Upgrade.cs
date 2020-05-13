using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2_Echecs.Echecs.Enums;

namespace TP2_Echecs.IHM
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
            choosenPiece = TypePiece.Tour;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            choosenPiece = TypePiece.Fou;
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            choosenPiece = TypePiece.Cavalier;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            choosenPiece = TypePiece.Dame;
            this.Close();
        }
    }
}
