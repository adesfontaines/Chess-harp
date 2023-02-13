using ChessSharp.Chess.Enums;
using System;

namespace ChessSharp.Chess
{
    public class Queen : Piece
    {
        public Queen(Player joueur) : base(joueur, TypePiece.Queen) { }

        public override bool Move(Tile destination)
        {
            if (base.Move(destination))
            {

                if ((Math.Abs(position.Column - destination.Column) == Math.Abs(position.Line - destination.Line)) &&
                    (destination.Column != position.Column &&
                    destination.Line != position.Line) ||
                    position.Column == destination.Column ||
                    position.Line == destination.Line)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
