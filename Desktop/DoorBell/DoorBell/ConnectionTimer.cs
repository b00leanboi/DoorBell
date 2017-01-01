using System;
using System.Timers;
using static DoorBell.ConnectionStatus;

namespace DoorBell
{
    class ConnectionTimer : ITimer
    {
        private Timer timer;
        private byte checksMade = 0;
        private byte checksToMake;

        public void StartTimer(double timerInteval, byte checksToMake)
        {
            if (timer == null)
            {
                timer = new Timer(timerInteval);
                timer.Elapsed += CheckConnection;
            }
            else
                timer.Interval = timerInteval;

            this.checksToMake = checksToMake;

            timer.Start();
        }
        public void StopTimer()
        {
            timer.Stop();
        }
        public void ChangeInterval(double timerInterval)
        {
            timer.Interval = timerInterval;
        }
        public void ChangeNumberOfChecks(byte checks)
        {
            checksToMake = checks;
        }
        private void CheckConnection(object sender, EventArgs e)
        {
            if (!ConnectionStatus.alive)
                if (checksMade >= (checksToMake - 1))
                    ConnectionStatus.Set(Property.alive, false, ChangeReasons.timeout);
                else
                    checksMade++;
            else
                checksMade = 0;
            ConnectionStatus.Set(Property.alive, false, ChangeReasons.timerCheck);
        }
    }
}
