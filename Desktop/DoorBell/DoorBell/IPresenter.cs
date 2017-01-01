using System;
using static DoorBell.SoundControl;
namespace DoorBell
{
    interface IPresenter : ITimer
    {
        void UpdateConnectionStatus(object o, MessageEventArgs a);
     
        #region Settings
        void SaveSettings(object o, EventArgs a);
        void LoadSettings();
        #endregion

        #region Sound
        void PlayRingSound(object o, ConnectionArgs a);
        void PlayErrorSound(object o, ConnectionArgs a);
        void ChangeRingPathInSettings(object o, StringValueArg a);
        void ChangeErrorPathInSettings(object o, StringValueArg a);
        #endregion

        #region UDP
        void StartUDP();
        void StopUDP(object o, EventArgs a);
        void ChangeUDPPort(int port);
        #endregion

        #region MainWindow
        void SetRingIcon(object o, ConnectionArgs a);
        void SetErrorIcon(object o, ConnectionArgs a);
        void SetAliveIcon(object o, ConnectionArgs a);
        void SetRingLabel(object o, ConnectionArgs a);
        void SetErrorLabel(object o, ConnectionArgs a);
        void SetAliveLabel(object o, ConnectionArgs a);
        void SetRingBulb(object o, ConnectionArgs a);
        void SetErrorBulb(object o, ConnectionArgs a);
        void SetAliveBulb(object o, ConnectionArgs a);
        void Log(object o, MessageEventArgs a);
        void ChangeCheckConnectionTime();
        void ChangeTriesNumber();
        void ChangeCONNTESTChecked();
        void ChangePlayDeadChecked();
        void ChangePort();
        void ChangeTriesNumberLabel();
        #endregion

    }
}