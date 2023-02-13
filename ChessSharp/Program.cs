using ChessSharp.Chess;
using ChessSharp.IHM;
using System;
using System.Windows.Forms;

namespace ChessSharp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            IGame jeu = new Game();
            Form vue = new GameWindow(jeu);
            Application.EnableVisualStyles();
            Application.Run(vue);
        }
    }
}
