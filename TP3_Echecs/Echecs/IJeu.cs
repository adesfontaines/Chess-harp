using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.Echecs;

namespace TP2_Echecs.IHM
{
    public interface IJeu
    {
        IEvenements vue { get; set; }

        void CommencerPartie();

        bool DeplacerPiece(int x_depart, int y_depart, int x_arrivee, int y_arrivee, bool forceMove = false);
        void PausePlay();
        void ResumePlay();
        void LoadHistory(Snapshot s);
    }
}
