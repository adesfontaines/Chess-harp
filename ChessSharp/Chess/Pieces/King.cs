using ChessSharp.Chess.Enums;
using System;

namespace ChessSharp.Chess
{
    public class King : Piece
    {
        public King(Player joueur) : base(joueur, TypePiece.King)
        {
        }

        public override bool Move(Tile destination)
        {
            if (base.Move(destination))
            {
                if (position.Column == destination.Column &&
                    Math.Abs(position.Line - destination.Line) == 1)
                {
                    return true;
                }
                else if (position.Line == destination.Line &&
                        Math.Abs(position.Column - destination.Column) == 1)
                {
                    return true;
                }
                else if (destination.Column != position.Column &&
                        Math.Abs(destination.Column - position.Column) == 1 &&
                        destination.Line != position.Line &&
                        Math.Abs(destination.Line - position.Line) == 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
