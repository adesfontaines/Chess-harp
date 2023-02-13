using ChessSharp.Chess.Enums;
using System;

namespace ChessSharp.Chess
{
    public class Chessboard : ICloneable
    {
        public Tile[,] Tiles;

        bool flipped;

        public Chessboard()
        {
            Tiles = new Tile[8, 8];
            InitializeCases(Tiles);
        }

        private void InitializeCases(Tile[,] Cases)
        {
            int compteur = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (compteur % 2 == 0)
                    {
                        Cases[i, j] = new Tile(j, i, PlayerColor.White);
                    }
                    else
                    {
                        Cases[i, j] = new Tile(j, i, PlayerColor.Black);
                    }
                }
                compteur++;
            }
        }

        public void Flip()
        {

            Tile[,] newCases = new Tile[8, 8];
            InitializeCases(newCases);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Piece c = Tiles[i, j].linkedPiece;

                    if (c != null)
                    {
                        c.numColonne = i;
                        c.numLigne = j;
                        newCases[j, i].Link(c);
                    }
                }
            }

            flipped = !flipped;

            Tiles = newCases;
        }

        public object Clone()
        {
            Chessboard e = new Chessboard();
            return e;
        }
    }
}
