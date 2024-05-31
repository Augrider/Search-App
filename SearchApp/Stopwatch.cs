using System;
using System.Windows.Forms;

namespace SearchApp
{
    class Stopwatch
    {
        private System.Diagnostics.Stopwatch stopwatch;
        private Timer resultUpdateTimer;


        public Stopwatch(Timer resultUpdateTimer)
        {
            stopwatch=new System.Diagnostics.Stopwatch();
            this.resultUpdateTimer=resultUpdateTimer;
        }


        public void Start() 
        {
            stopwatch.Start();
            resultUpdateTimer.Start();
        }

        public void Pause() 
        {
            stopwatch.Stop();
            resultUpdateTimer.Stop();
        }

        public void Stop() 
        {
            stopwatch.Reset();
            resultUpdateTimer.Stop();
        }


        public string GetElapsed()
        {
            var elapsed = stopwatch.Elapsed;
            return string.Format("{0}:{1}", Math.Floor(elapsed.TotalHours), elapsed.ToString("mm\\:ss"));
        } 
    }
}
