using ChessSharp.Chess;
using System.Collections.Generic;

namespace ChessSharp.IHM
{
    public interface IEvents
    {
        void ActualiserPartie(StatusPartie status);

        void ActualiserCase(int x, int y, PieceInfo info);

        void ActualiserCaptures(List<PieceInfo> pieces);
    }

}
