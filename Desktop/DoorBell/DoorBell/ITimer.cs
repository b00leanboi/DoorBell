using System;
namespace DoorBell
{
    interface ITimer
    {
        void StartTimer(double timerInterval, byte checksToMake);
        void StopTimer();
        void ChangeInterval(double timerInterval);
        void ChangeNumberOfChecks(byte checks);
    }
}
