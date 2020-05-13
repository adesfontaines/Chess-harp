using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.Echecs;

namespace TP2_Echecs.IHM
{
    public interface IEvenements
    {
        void ActualiserPartie(StatusPartie status);

        void ActualiserCase(int x, int y, InfoPiece info);

        void ActualiserCaptures(List<InfoPiece> pieces);
    }
    
}
