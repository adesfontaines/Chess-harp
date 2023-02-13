using ChessSharp.Chess.Enums;
using System;

namespace ChessSharp.Chess
{
    class Pawn : Piece
    {
        public Pawn(Player joueur) : base(joueur, TypePiece.Pawn)
        {
        }

        public override bool Move(Tile destination)
        {
            bool validMove = false;

            if (base.Move(destination))
            {
                if (destination.linkedPiece == null)
                {

                    if (destination.Column == position.Column &&
                        Math.Abs(destination.Line - position.Line) == 1)
                    {
                        if (info.couleur == PlayerColor.White
                        && (destination.Line < position.Line))
                        {
                            validMove = true;
                        }
                        else if (info.couleur == PlayerColor.Black && destination.Line > position.Line)
                        {
                            validMove = true;
                        }
                    }
                    else if (Math.Abs(destination.Line - position.Line) == 2
                    && position.Column == destination.Column
                    && moves == 0)
                    {
                        if (info.couleur == PlayerColor.White
                            && (destination.Line < position.Line)
                            || destination.Line > position.Line)
                        {
                            validMove = true;
                        }
                    }
                }
                else if (Math.Abs(destination.Line - position.Line) == 1 && Math.Abs(destination.Column - position.Column) == 1)
                {
                    if (info.couleur == PlayerColor.White
                        && (destination.Line < position.Line)
                        || destination.Line > position.Line)
                    {
                        validMove = true;
                    }
                }
            }

            return validMove;
        }

        public Piece Promouvoir(TypePiece piece)
        {
            switch (piece)
            {
                case TypePiece.Queen:
                    return new Queen(joueur);
                case TypePiece.Tower:
                    return new Rook(joueur);
                case TypePiece.Bishop:
                    return new Bishop(joueur);
                case TypePiece.Knight:
                    return new Knight(joueur);
            }
            return this;
        }
    }
}