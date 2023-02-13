using ChessSharp.Chess.Enums;
using System;

namespace ChessSharp.Chess
{

    public class Bishop : Piece
    {
        public Bishop(Player player) : base(player, TypePiece.Bishop)
        {
        }

        public override bool Move(Tile destination)
        {
            if (base.Move(destination))
            {
                if ((Math.Abs(position.Column - destination.Column) == Math.Abs(position.Line - destination.Line)) &&
                    (destination.Column != position.Column &&
                    destination.Line != position.Line))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
