using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.Echecs.Enums;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    abstract public class Piece
    {
        // attributs
        public InfoPiece info;

        // associations
        public Joueur joueur;
        public Case position;

        public int numLigne;
        public int numColonne;

        public int moves = 0;
        public List<Point> availableMoves;
        internal bool ignoreInCheckPath;

        // methodes
        public Piece(Joueur joueur, TypePiece type)
        {
			this.joueur = joueur;
            info = InfoPiece.GetInfo(joueur.couleur, type);
        }

        public virtual bool Deplacer(Case destination)
        {
            if (destination.linkedPiece != null)
            {
                if (destination.linkedPiece.info.couleur == info.couleur)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
