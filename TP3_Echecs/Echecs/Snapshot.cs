using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_Echecs.Echecs
{
    public class Snapshot
    {
        public TimeSpan totalTime;

        public TimeSpan blackTime;
        public TimeSpan whiteTime;

        public int BlackScore, WhiteScore;

        public Partie partie;
        List<ListViewItem> history;

        public List<string[]> HistoryItems { get; internal set; }
    }
}
