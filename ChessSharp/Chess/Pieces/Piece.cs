using ChessSharp.Chess.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace ChessSharp.Chess
{
    abstract public class Piece
    {
        // attributs
        public PieceInfo info;

        // associations
        public Player joueur;
        public Tile position;

        public int numLigne;
        public int numColonne;

        public int moves = 0;
        public List<Point> availableMoves;
        internal bool ignoreInCheckPath;

        // methodes
        public Piece(Player joueur, TypePiece type)
        {
            this.joueur = joueur;
            info = PieceInfo.GetInfo(joueur.couleur, type);
        }

        public virtual bool Move(Tile destination)
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
