using System;
using TP2_Echecs.Echecs.Enums;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    class Pion : Piece
    {
        public Pion(Joueur joueur) : base(joueur, TypePiece.Pion)
        {
        }

        public override bool Deplacer(Case destination)
        {
            bool validMove = false;

            if (base.Deplacer(destination))
            {
                if (destination.linkedPiece == null)
                {

                    if (destination.NumColonne == position.NumColonne &&
                        Math.Abs(destination.NumLigne - position.NumLigne) == 1)
                    {
                        if (info.couleur == CouleurCamp.Blanche
                        && (destination.NumLigne < position.NumLigne))
                        {
                            validMove = true;
                        }
                        else if (info.couleur == CouleurCamp.Noire && destination.NumLigne > position.NumLigne)
                        {
                            validMove = true;
                        }
                    }
                    else if (Math.Abs(destination.NumLigne - position.NumLigne) == 2 
                    && position.NumColonne == destination.NumColonne 
                    && moves == 0)
                    {
                        if (info.couleur == CouleurCamp.Blanche
                            && (destination.NumLigne < position.NumLigne)
                            || destination.NumLigne > position.NumLigne)
                        {
                            validMove = true;
                        }
                    }
                }
                else if (Math.Abs(destination.NumLigne - position.NumLigne) == 1 && Math.Abs(destination.NumColonne - position.NumColonne) == 1)
                {
                    if (info.couleur == CouleurCamp.Blanche
                        && (destination.NumLigne < position.NumLigne)
                        || destination.NumLigne > position.NumLigne)
                    {
                        validMove = true;
                    }
                }
            }

            return validMove;
        }

        public Piece Promouvoir(TypePiece piece)
        {
            switch (piece)
            {
                case TypePiece.Dame:
                    return new Dame(joueur);
                case TypePiece.Tour:
                    return new Tour(joueur);
                case TypePiece.Fou:
                    return new Fou(joueur);
                case TypePiece.Cavalier:
                    return new Cavalier(joueur);
            }
            return this;
        }
    }
}