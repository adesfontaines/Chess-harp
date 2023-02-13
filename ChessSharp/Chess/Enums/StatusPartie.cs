using ChessSharp.Chess.Enums;

namespace ChessSharp.IHM
{

    public class StatusPartie
    {
        public EtatPartie etat { get; private set; }
        public PlayerColor couleur { get; private set; }

        private StatusPartie(EtatPartie etat, PlayerColor couleur)
        {
            this.etat = etat;
            this.couleur = couleur;
        }

        public static StatusPartie Reset = new StatusPartie(EtatPartie.Reset, PlayerColor.White);
        public static StatusPartie TraitBlancs = new StatusPartie(EtatPartie.Trait, PlayerColor.White);
        public static StatusPartie TraitNoirs = new StatusPartie(EtatPartie.Trait, PlayerColor.Black);
        public static StatusPartie EchecBlancs = new StatusPartie(EtatPartie.Echec, PlayerColor.White);
        public static StatusPartie EchecNoirs = new StatusPartie(EtatPartie.Echec, PlayerColor.Black);
        public static StatusPartie MatBlancs = new StatusPartie(EtatPartie.Mat, PlayerColor.White);
        public static StatusPartie MatNoirs = new StatusPartie(EtatPartie.Mat, PlayerColor.Black);
        public static StatusPartie Pause = new StatusPartie(EtatPartie.Pause, PlayerColor.Black);
    }
}
