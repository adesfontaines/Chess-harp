using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.Echecs.Enums;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    public class Joueur : ICloneable
    {
        // attributs
        public CouleurCamp couleur;

        public int Score;
        // associations
        public Partie partie;
        public List<Piece> pieces = new List<Piece>(16);

        // methodes
        public Joueur(Partie partie, CouleurCamp couleur)
        {
            this.couleur = couleur;
            this.partie = partie;
            this.Score = 0;
            pieces.Add(new Dame(this));
            pieces.Add(new Roi(this));

            for (int i = 0; i < 2; i++)
            {
                pieces.Add(new Fou(this));
                pieces.Add(new Cavalier(this));
                pieces.Add(new Tour(this));
            }

            for (int i = 0; i < 8; i++)
            {
                pieces.Add(new Pion(this));
            }

        }

        public void PlacerPieces(Echiquier echiquier)
        {
            if (couleur == CouleurCamp.Noire)
            {
                echiquier.Cases[0, 0].Link(pieces[4]);
                echiquier.Cases[1, 0].Link(pieces[3]);
                echiquier.Cases[2, 0].Link(pieces[2]);
                
                echiquier.Cases[3, 0].Link(pieces[0]);
                echiquier.Cases[4, 0].Link(pieces[1]);

                echiquier.Cases[5, 0].Link(pieces[5]);
                echiquier.Cases[6, 0].Link(pieces[6]);
                echiquier.Cases[7, 0].Link(pieces[7]);

                for (int i = 0; i < 8; i++)
                {
                    echiquier.Cases[i, 1].Link(pieces[8 + i]);
                }
            }
            else
            {
                echiquier.Cases[0, 7].Link(pieces[4]);
                echiquier.Cases[1, 7].Link(pieces[3]);
                echiquier.Cases[2, 7].Link(pieces[2]);

                echiquier.Cases[3, 7].Link(pieces[0]);
                echiquier.Cases[4, 7].Link(pieces[1]);

                echiquier.Cases[5, 7].Link(pieces[5]);
                echiquier.Cases[6, 7].Link(pieces[6]);
                echiquier.Cases[7, 7].Link(pieces[7]);

                for (int i = 0; i < 8; i++)
                {
                    echiquier.Cases[i, 6].Link(pieces[8 + i]);
                }

            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
