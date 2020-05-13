using System;
using TP2_Echecs.Echecs.Enums;

namespace TP2_Echecs.Echecs
{
    public class Dame : Piece
    {
        public Dame(Joueur joueur) : base(joueur, TypePiece.Dame) { }

        public override bool Deplacer(Case destination)
        {
            if(base.Deplacer(destination))
            {
                
                if ((Math.Abs(position.NumColonne - destination.NumColonne) == Math.Abs(position.NumLigne - destination.NumLigne)) &&
                    (destination.NumColonne != position.NumColonne &&
                    destination.NumLigne != position.NumLigne) ||
                    position.NumColonne == destination.NumColonne ||
                    position.NumLigne == destination.NumLigne)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
