using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.Echecs.Enums;

namespace TP2_Echecs.IHM
{

    public class StatusPartie
    {
        public EtatPartie etat { get; private set; }
        public CouleurCamp couleur { get; private set; }

        private StatusPartie(EtatPartie etat, CouleurCamp couleur)
        {
            this.etat = etat;
            this.couleur = couleur;
        }

        public static StatusPartie Reset = new StatusPartie(EtatPartie.Reset, CouleurCamp.Blanche);
        public static StatusPartie TraitBlancs = new StatusPartie(EtatPartie.Trait, CouleurCamp.Blanche);
        public static StatusPartie TraitNoirs = new StatusPartie(EtatPartie.Trait, CouleurCamp.Noire);
        public static StatusPartie EchecBlancs = new StatusPartie(EtatPartie.Echec, CouleurCamp.Blanche);
        public static StatusPartie EchecNoirs = new StatusPartie(EtatPartie.Echec, CouleurCamp.Noire);
        public static StatusPartie MatBlancs = new StatusPartie(EtatPartie.Mat, CouleurCamp.Blanche);
        public static StatusPartie MatNoirs = new StatusPartie(EtatPartie.Mat, CouleurCamp.Noire);
        public static StatusPartie Pause = new StatusPartie(EtatPartie.Pause, CouleurCamp.Noire);
    }
}
