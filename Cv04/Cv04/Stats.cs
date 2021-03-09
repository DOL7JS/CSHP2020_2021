using System;
using System.Collections.Generic;
using System.Text;

namespace Cv04
{
    public delegate void UpdatedStatsEventHandler(object sender, EventArgs e);
    class Stats
    {
        public int Correct { get; private set; }
        public int Missed { get; private set; }
        public int Accurancy { get; private set; }

        public event UpdatedStatsEventHandler UpdatedStats;
        public Stats() {
            Correct = 0;
            Missed = 0;
            Accurancy = 0;
        }
        private void OnUpdatedStats()
        {
            UpdatedStats?.Invoke(this, new EventArgs());
        }
        public void Update(bool correctKey) {
            if (correctKey)
            {
                Correct++;
            }
            else {
                Missed++;
            }
            if (Correct != 0) { 
                Accurancy = (Correct / (Missed+Correct)) * 100;
            }
            OnUpdatedStats();
        }

    }
}
