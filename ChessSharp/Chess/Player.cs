using ChessSharp.Chess.Enums;
using System;
using System.Collections.Generic;

namespace ChessSharp.Chess
{
    public class Player : ICloneable
    {
        public PlayerColor couleur;

        public int Score;

        public Game partie;
        public List<Piece> pieces = new List<Piece>(16);

        public Player(Game game, PlayerColor color)
        {
            this.couleur = color;
            this.partie = game;
            this.Score = 0;
            pieces.Add(new Queen(this));
            pieces.Add(new King(this));

            for (int i = 0; i < 2; i++)
            {
                pieces.Add(new Bishop(this));
                pieces.Add(new Knight(this));
                pieces.Add(new Rook(this));
            }

            for (int i = 0; i < 8; i++)
            {
                pieces.Add(new Pawn(this));
            }

        }

        public void InitPieces(Chessboard chessboard)
        {
            if (couleur == PlayerColor.Black)
            {
                chessboard.Tiles[0, 0].Link(pieces[4]);
                chessboard.Tiles[1, 0].Link(pieces[3]);
                chessboard.Tiles[2, 0].Link(pieces[2]);

                chessboard.Tiles[3, 0].Link(pieces[0]);
                chessboard.Tiles[4, 0].Link(pieces[1]);

                chessboard.Tiles[5, 0].Link(pieces[5]);
                chessboard.Tiles[6, 0].Link(pieces[6]);
                chessboard.Tiles[7, 0].Link(pieces[7]);

                for (int i = 0; i < 8; i++)
                {
                    chessboard.Tiles[i, 1].Link(pieces[8 + i]);
                }
            }
            else
            {
                chessboard.Tiles[0, 7].Link(pieces[4]);
                chessboard.Tiles[1, 7].Link(pieces[3]);
                chessboard.Tiles[2, 7].Link(pieces[2]);

                chessboard.Tiles[3, 7].Link(pieces[0]);
                chessboard.Tiles[4, 7].Link(pieces[1]);

                chessboard.Tiles[5, 7].Link(pieces[5]);
                chessboard.Tiles[6, 7].Link(pieces[6]);
                chessboard.Tiles[7, 7].Link(pieces[7]);

                for (int i = 0; i < 8; i++)
                {
                    chessboard.Tiles[i, 6].Link(pieces[8 + i]);
                }

            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
