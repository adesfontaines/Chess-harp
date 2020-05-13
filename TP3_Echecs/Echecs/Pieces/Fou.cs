using System;
using TP2_Echecs.Echecs.Enums;

namespace TP2_Echecs.Echecs
{

    public class Fou : Piece
    {
        public Fou(Joueur joueur) : base(joueur, TypePiece.Fou)
        {
        }

        public override bool Deplacer(Case destination)
        {   
            if (base.Deplacer(destination))
            {
                if ((Math.Abs(position.NumColonne - destination.NumColonne) == Math.Abs(position.NumLigne - destination.NumLigne)) &&
                    (destination.NumColonne != position.NumColonne &&
                    destination.NumLigne != position.NumLigne))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
