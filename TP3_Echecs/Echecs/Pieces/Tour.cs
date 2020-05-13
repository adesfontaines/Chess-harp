using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.Echecs.Enums;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    public class Tour : Piece
    {
        public Tour(Joueur joueur) : base(joueur, TypePiece.Tour)
        {
        }

        public override bool Deplacer(Case destination)
        {
            if(base.Deplacer(destination))
            {
                if (position.NumColonne == destination.NumColonne ||
                    position.NumLigne == destination.NumLigne)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
