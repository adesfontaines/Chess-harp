using TP2_Echecs.Echecs.Enums;

namespace TP2_Echecs.Echecs
{
    public class Case
    {
        // attributs
        public int NumLigne;
        public int NumColonne;
        public CouleurCamp couleur;

        // associations
        public Piece linkedPiece;

        public Case(int numLigne, int numColonne, CouleurCamp color)
        {
            this.NumLigne = numLigne;
            this.NumColonne = numColonne;
            couleur = color;
        }

        // methodes
        public void Link(Piece newPiece)
        {
            // 1. Deconnecter newPiece de l'ancienne case
            newPiece.position = this;

            newPiece.numLigne = NumLigne;
            newPiece.numColonne = NumColonne;
            Unlink(linkedPiece);

            // 2. Connecter newPiece à cette case
            linkedPiece = newPiece;
        }

        public void Unlink(Piece newPiece)
        {
            linkedPiece = null;
        }
    }
}
