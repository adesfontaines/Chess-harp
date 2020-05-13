using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2_Echecs.Echecs;
using TP2_Echecs.IHM;

namespace TP2_Echecs
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            IJeu jeu = new Partie();
            Form vue = new FenetreDeJeu(jeu);
            Application.EnableVisualStyles();
            Application.Run(vue);
        }
    }
}
