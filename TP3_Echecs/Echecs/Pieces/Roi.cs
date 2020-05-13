using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.Echecs.Enums;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    public class Roi : Piece
    {
        public Roi(Joueur joueur) : base(joueur, TypePiece.Roi)
        {
        }

        public override bool Deplacer(Case destination)
        {
            if (base.Deplacer(destination))
            {
                if (position.NumColonne == destination.NumColonne &&
                    Math.Abs(position.NumLigne - destination.NumLigne) == 1)
                {
                    return true;
                }
                else if (position.NumLigne == destination.NumLigne &&
                        Math.Abs(position.NumColonne - destination.NumColonne) == 1)
                {
                    return true;
                }
                else if (destination.NumColonne != position.NumColonne &&
                        Math.Abs(destination.NumColonne - position.NumColonne) == 1 &&
                        destination.NumLigne != position.NumLigne &&
                        Math.Abs(destination.NumLigne - position.NumLigne) == 1) 
                {
                    return true;
                }
            }

            return false;
        }
    }
}
