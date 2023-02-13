using ChessSharp.Chess.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace ChessSharp.Chess
{

    public class PieceInfo
    {
        public TypePiece type { get; private set; }
        public PlayerColor couleur { get; private set; }

        private PieceInfo(TypePiece type, PlayerColor couleur)
        {
            this.type = type;
            this.couleur = couleur;
        }

        public static PieceInfo RoiBlanc = new PieceInfo(TypePiece.King, PlayerColor.White);
        public static PieceInfo DameBlanche = new PieceInfo(TypePiece.Queen, PlayerColor.White);
        public static PieceInfo TourBlanche = new PieceInfo(TypePiece.Tower, PlayerColor.White);
        public static PieceInfo FouBlanc = new PieceInfo(TypePiece.Bishop, PlayerColor.White);
        public static PieceInfo CavalierBlanc = new PieceInfo(TypePiece.Knight, PlayerColor.White);
        public static PieceInfo PionBlanc = new PieceInfo(TypePiece.Pawn, PlayerColor.White);
        public static PieceInfo RoiNoir = new PieceInfo(TypePiece.King, PlayerColor.Black);
        public static PieceInfo DameNoire = new PieceInfo(TypePiece.Queen, PlayerColor.Black);
        public static PieceInfo TourNoire = new PieceInfo(TypePiece.Tower, PlayerColor.Black);
        public static PieceInfo FouNoir = new PieceInfo(TypePiece.Bishop, PlayerColor.Black);
        public static PieceInfo CavalierNoir = new PieceInfo(TypePiece.Knight, PlayerColor.Black);
        public static PieceInfo PionNoir = new PieceInfo(TypePiece.Pawn, PlayerColor.Black);

        public static PieceInfo GetInfo(PlayerColor couleurCamp, TypePiece type)
        {
            switch (type)
            {
                case TypePiece.King: return couleurCamp == PlayerColor.White ? RoiBlanc : RoiNoir;
                case TypePiece.Queen: return couleurCamp == PlayerColor.White ? DameBlanche : DameNoire;
                case TypePiece.Tower: return couleurCamp == PlayerColor.White ? TourBlanche : TourNoire;
                case TypePiece.Bishop: return couleurCamp == PlayerColor.White ? FouBlanc : FouNoir;
                case TypePiece.Knight: return couleurCamp == PlayerColor.White ? CavalierBlanc : CavalierNoir;
                case TypePiece.Pawn: return couleurCamp == PlayerColor.White ? PionBlanc : PionNoir;
                default: return null;
            }
        }

        public List<Point> AvailableMoves()
        {
            List<Point> availableMoves = new List<Point>
            {
                new Point(0, 0),
                new Point(1, 1),
                new Point(2, 2),
                new Point(2, 3)
            };
            return availableMoves;
        }
    }
}
