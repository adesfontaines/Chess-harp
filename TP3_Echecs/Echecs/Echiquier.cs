using System;
using TP2_Echecs.Echecs.Enums;

namespace TP2_Echecs.Echecs
{
    public class Echiquier : ICloneable
    {
        public Case[,] Cases;

        bool flipped;

        public Echiquier()
        {
            Cases = new Case[8, 8];
            InitializeCases(Cases);
        }

        private void InitializeCases(Case[,] Cases)
        {
            int compteur = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (compteur % 2 == 0)
                    {
                        Cases[i, j] = new Case(j, i, CouleurCamp.Blanche);
                    }
                    else
                    {
                        Cases[i, j] = new Case(j, i, CouleurCamp.Noire);
                    }
                }
                compteur++;
            }
        }

        public void Flip()
        {
            
            Case[,] newCases = new Case[8, 8];
            InitializeCases(newCases);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Piece c = Cases[i, j].linkedPiece;

                    if (c != null)
                    {
                        c.numColonne = i;
                        c.numLigne = j;
                        newCases[j, i].Link(c);
                    }
                }
            }

            flipped = !flipped;

            Cases = newCases;
        }

        public object Clone()
        {
            Echiquier e = new Echiquier();
            return e;
        }
    }
}
