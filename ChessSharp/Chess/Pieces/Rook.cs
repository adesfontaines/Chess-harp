using ChessSharp.Chess.Enums;

namespace ChessSharp.Chess
{
    public class Rook : Piece
    {
        public Rook(Player player) : base(player, TypePiece.Tower)
        {
        }

        public override bool Move(Tile destination)
        {
            if (base.Move(destination))
            {
                if (position.Column == destination.Column ||
                    position.Line == destination.Line)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
