using ChessSharp.Chess.Enums;

namespace ChessSharp.Chess
{
    public class Tile
    {
        // attributs
        public int Line;
        public int Column;
        public PlayerColor color;

        // associations
        public Piece linkedPiece;

        public Tile(int numLigne, int numColonne, PlayerColor color)
        {
            this.Line = numLigne;
            this.Column = numColonne;
            this.color = color;
        }

        // methodes
        public void Link(Piece newPiece)
        {
            // 1. Deconnecter newPiece de l'ancienne case
            newPiece.position = this;

            newPiece.numLigne = Line;
            newPiece.numColonne = Column;
            Unlink(linkedPiece);

            // 2. Connecter newPiece à cette case
            linkedPiece = newPiece;
        }

        public void Unlink(Piece newPiece)
        {
            linkedPiece = null;
        }
    }
}
