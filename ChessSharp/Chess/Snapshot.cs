using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChessSharp.Chess
{
    public class Snapshot
    {
        public TimeSpan totalTime;

        public TimeSpan blackTime;
        public TimeSpan whiteTime;

        public int BlackScore, WhiteScore;

        public Game partie;
        List<ListViewItem> history;

        public List<string[]> HistoryItems { get; internal set; }
    }
}
