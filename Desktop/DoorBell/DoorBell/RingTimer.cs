using System;
using System.Timers;
using static DoorBell.ConnectionStatus;

namespace DoorBell
{
    class RingTimer
    {
        private Timer timer;

        /// <summary>
        /// Interval is given in ms
        /// </summary>
        /// <param name="interval"></param>
        public RingTimer(double interval)
        {
            timer = new Timer(interval);
            timer.Elapsed += IntervalElapsed;
            timer.AutoReset = false;
        }
        public void StartTimer()
        {
            timer.Start();
        }
        private void IntervalElapsed(object sender, ElapsedEventArgs args)
        {
            ConnectionStatus.Set(Property.ring, false, ChangeReasons.ringOff);
        }      
    }
}
