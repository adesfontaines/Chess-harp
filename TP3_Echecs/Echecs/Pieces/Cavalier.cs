using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Echecs.Echecs.Enums;
using System.Threading.Tasks;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    public class Cavalier : Piece
    {
        public Cavalier(Joueur joueur) : base(joueur, TypePiece.Cavalier)
        {
        }

        public override bool Deplacer(Case destination)
        {
            if(base.Deplacer(destination))
            {
                if ((Math.Abs(destination.NumLigne - position.NumLigne) == 2 && 
                    Math.Abs(destination.NumColonne - position.NumColonne) == 1)
                    ||
                    (Math.Abs(destination.NumLigne - position.NumLigne) == 1 &&
                    Math.Abs(destination.NumColonne - position.NumColonne) == 2))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
