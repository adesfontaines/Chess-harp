using ChessSharp.Chess.Enums;
using System;

namespace ChessSharp.Chess
{
    public class Knight : Piece
    {
        public Knight(Player player) : base(player, TypePiece.Knight)
        {
        }

        public override bool Move(Tile destination)
        {
            if (base.Move(destination))
            {
                if ((Math.Abs(destination.Line - position.Line) == 2 &&
                    Math.Abs(destination.Column - position.Column) == 1)
                    ||
                    (Math.Abs(destination.Line - position.Line) == 1 &&
                    Math.Abs(destination.Column - position.Column) == 2))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
