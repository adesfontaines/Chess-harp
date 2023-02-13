using ChessSharp.Chess;

namespace ChessSharp.IHM
{
    public interface IGame
    {
        IEvents vue { get; set; }

        void CommencerPartie();

        bool MovePiece(int x_depart, int y_depart, int x_arrivee, int y_arrivee, bool forceMove = false);
        void PausePlay();
        void ResumePlay();
        void LoadHistory(Snapshot s);
    }
}
