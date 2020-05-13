using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.Echecs.Enums;

namespace TP2_Echecs.Echecs
{

    public class InfoPiece
    {
        public TypePiece type { get; private set; }
        public CouleurCamp couleur { get; private set; }

        private InfoPiece(TypePiece type, CouleurCamp couleur)
        {
            this.type = type;
            this.couleur = couleur;
        }

        public static InfoPiece RoiBlanc = new InfoPiece(TypePiece.Roi, CouleurCamp.Blanche);
        public static InfoPiece DameBlanche = new InfoPiece(TypePiece.Dame, CouleurCamp.Blanche);
        public static InfoPiece TourBlanche = new InfoPiece(TypePiece.Tour, CouleurCamp.Blanche);
        public static InfoPiece FouBlanc = new InfoPiece(TypePiece.Fou, CouleurCamp.Blanche);
        public static InfoPiece CavalierBlanc = new InfoPiece(TypePiece.Cavalier, CouleurCamp.Blanche);
        public static InfoPiece PionBlanc = new InfoPiece(TypePiece.Pion, CouleurCamp.Blanche);
        public static InfoPiece RoiNoir = new InfoPiece(TypePiece.Roi, CouleurCamp.Noire);
        public static InfoPiece DameNoire = new InfoPiece(TypePiece.Dame, CouleurCamp.Noire);
        public static InfoPiece TourNoire = new InfoPiece(TypePiece.Tour, CouleurCamp.Noire);
        public static InfoPiece FouNoir = new InfoPiece(TypePiece.Fou, CouleurCamp.Noire);
        public static InfoPiece CavalierNoir = new InfoPiece(TypePiece.Cavalier, CouleurCamp.Noire);
        public static InfoPiece PionNoir = new InfoPiece(TypePiece.Pion, CouleurCamp.Noire);

        public static InfoPiece GetInfo(CouleurCamp couleurCamp, TypePiece type)
        {
            switch (type)
            {
                case TypePiece.Roi: return couleurCamp == CouleurCamp.Blanche ? RoiBlanc : RoiNoir;
                case TypePiece.Dame: return couleurCamp == CouleurCamp.Blanche ? DameBlanche : DameNoire;
                case TypePiece.Tour: return couleurCamp == CouleurCamp.Blanche ? TourBlanche : TourNoire;
                case TypePiece.Fou: return couleurCamp == CouleurCamp.Blanche ? FouBlanc : FouNoir;
                case TypePiece.Cavalier: return couleurCamp == CouleurCamp.Blanche ? CavalierBlanc : CavalierNoir;
                case TypePiece.Pion: return couleurCamp == CouleurCamp.Blanche ? PionBlanc : PionNoir;
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
