using System;
using System.Windows.Forms;
using System.ComponentModel;
using static DoorBell.SoundControl;
namespace DoorBell
{
    class Presenter : IPresenter
    {
        private readonly IView mainWindow;
        private Settings settings;
        private bool firstRun;

        private ConnectionTimer connTimer = new ConnectionTimer();
        private RingTimer ringTimer = new RingTimer(2000);
        private UDP udp;
        private SoundControl soundControl = new SoundControl();
       
        #region Constructor
        public Presenter(IView mainWindow)
        {
            this.mainWindow = mainWindow;
            LoadSettings();
            AddMethodsToFormEvents();
            AddMethodsToSoundEvents();

            if(firstRun)
            {
                GetSettings();
            }
            else
            {
                ApplySettings();
                StartUDP();
                AddMethodsToUDPEvent();
                AddMethodsToConnectionsEvents();
                StartTimer((settings.checkConnection * 60 * 1000), settings.triesNumber);
                SetUnsavedSettings(false);
            }         
        }
        private void GetSettings()
        {
            settings.checkConnection = mainWindow.checkConnectionTime;
            settings.triesNumber = mainWindow.triesNumber;
            settings.showCONNTESTmsg = mainWindow.showCONNTEST;
            settings.playError = mainWindow.playError;
            settings.port = mainWindow.port;
        }
        private void ApplySettings()
        {
            mainWindow.checkConnectionTime = settings.checkConnection;
            mainWindow.triesNumber = settings.triesNumber;
            mainWindow.showCONNTEST = settings.showCONNTESTmsg;
            mainWindow.playError = settings.playError;
            mainWindow.port = settings.port;
            soundControl.ringSoundPath = settings.ringSoundPath;
            soundControl.errorSoundPath = settings.errorSoundPath;
            UpdateTriesNumberText(this, EventArgs.Empty);
        }
        private void UpdateTriesNumberText(object o, EventArgs args)
        {
            mainWindow.triesLabelText = triesNumberText();
        }
        private string triesNumberText()
        {
            return string.Format("tries ({0} min)", (mainWindow.checkConnectionTime * mainWindow.triesNumber));
        }
        #region Events
        private void AddMethodsToUDPEvent()
        {
            udp.MessageReceived += Log;
            udp.MessageReceived += UpdateConnectionStatus;
        }
        private void AddMethodsToFormEvents()
        {
            mainWindow.ringSoundButtonClicked += soundControl.ChooseRingSound;
            mainWindow.errorSoundButtonClicked += soundControl.ChooseErrorSound;
            mainWindow.saveSettingsButtonClicked += SaveSettings;

            mainWindow.settingsChanged += SettingsChanged;
            mainWindow.checkConnectionTimeValueChanged += UpdateTriesNumberText;
            mainWindow.checkConnectionTimeValueChanged += settings.ChangeCheckConnection;
            mainWindow.triesNumberValueChanged += UpdateTriesNumberText;
            mainWindow.triesNumberValueChanged += settings.ChangeTriesNumber;
            mainWindow.showCONNTESTValueChanged += settings.ChangeShowCONNTEST;
            mainWindow.playErrorValueChanged += settings.ChangePlayError;
            mainWindow.portChanged += settings.ChangePort;

            mainWindow.windowClosing += StopUDP;
        }
        private void AddMethodsToConnectionsEvents()
        {
            ConnectionStatus.ringChanged += PlayRingSound;
            ConnectionStatus.ringChanged += SetRingBulb;
            ConnectionStatus.ringChanged += SetRingIcon;
            ConnectionStatus.ringChanged += SetRingLabel;
            ConnectionStatus.ringChanged += StartRingTimer;

            ConnectionStatus.errorChanged += PlayErrorSound;
            ConnectionStatus.errorChanged += SetErrorBulb;
            ConnectionStatus.errorChanged += SetErrorIcon;
            ConnectionStatus.errorChanged += SetErrorLabel;

            ConnectionStatus.aliveChanged += SetAliveBulb;
            ConnectionStatus.aliveChanged += SetAliveIcon;
            ConnectionStatus.aliveChanged += SetAliveLabel;
            ConnectionStatus.aliveChanged += PlayErrorSound;
            ConnectionStatus.aliveChanged += SetErrorBulb;
            ConnectionStatus.aliveChanged += SetErrorIcon;
            ConnectionStatus.aliveChanged += SetErrorLabel;
        }
        private void AddMethodsToSoundEvents()
        {
            soundControl.ringSoundPathChanged += ChangeRingPathInSettings;
            soundControl.errorSoundPathChanged += ChangeErrorPathInSettings;
        }
        #endregion
        #endregion

        #region Settings
        public void SaveSettings(object sender, EventArgs a)
        {
            bool getNewPath = shouldGetNewPath();
            if (SettingsOperations.SaveSettings(settings, getNewPath))
                SetUnsavedSettings(false);
        }
        private bool shouldGetNewPath()
        {
            DialogResult result = MessageBox.Show("Would you like to use new path (file)?", "Saving", 
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                                                  MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }
        public void LoadSettings()
        {
            settings = SettingsOperations.LoadSettings();
            if (settings == null)
            {
                settings = new Settings();
                firstRun = true;
            }
            else
                firstRun = false;
        }
        private void SettingsChanged(object o, EventArgs a)
        {
            SetUnsavedSettings(true);
        }
        private void SetUnsavedSettings(bool unsaved)
        {
            if(unsaved)
            {
                mainWindow.saveButtonEnabled = true;
                mainWindow.saveButtonText = "Save Settings";
            }
            else
            {
                mainWindow.saveButtonEnabled = false;
                mainWindow.saveButtonText = "Saved";
            }
           
        }
        #endregion

        #region Sound
        public void PlayRingSound(object o, ConnectionArgs a)
        {
            if(a.newState)
                soundControl.PlaySound(Sounds.ring);
        }

        public void PlayErrorSound(object o, ConnectionArgs a)
        {
            if(settings.playError)
            {
                if (a.property == ConnectionStatus.Property.alive)
                {
                    if (!a.newState)
                    {
                        soundControl.PlaySound(Sounds.error);
                    }
                }
                else
                {
                    soundControl.PlaySound(Sounds.error);
                }
            }
            
               
        }

        public void ChangeRingPathInSettings(object o, StringValueArg a)
        {
            settings.ringSoundPath = a.value;
        }
        public void ChangeErrorPathInSettings(object o, StringValueArg a)
        {
            settings.errorSoundPath = a.value;
        }
        #endregion Sound

        #region UDP
        public void StartUDP()
        {
            udp = new UDP(settings.port);
            mainWindow.statusLabelText = "WAITING...";
        }
        public void StopUDP(object o, EventArgs a)
        {
            if (udp != null)
                udp.CloseClient();
        }
        public void ChangeUDPPort(int port)
        {
            if (udp != null)
            {
                udp.run = false;
                Cursor.Current = Cursors.WaitCursor;
                while (udp.isRunning) ;
                Cursor.Current = Cursors.Default;
                udp.CloseClient();
            }
            udp = new UDP(port);
        }
        #endregion

        #region RingTimer
        public void StartRingTimer(object o, ConnectionArgs a)
        {
            if(a.newState)
                ringTimer.StartTimer();
        }
        #endregion

        #region MainWindow
        public void SetRingIcon(object o, ConnectionArgs a)
        {
            if(a.newState)
                ThreadSafe.ChangeIcon((Form)mainWindow, Properties.Resources.notifyIconBlue);
        }

        public void SetErrorIcon(object o, ConnectionArgs a)
        {
            if(a.property == ConnectionStatus.Property.alive)
            {
                if (!a.newState)
                    ThreadSafe.ChangeIcon((Form)mainWindow, Properties.Resources.notifyIconRed);
            }
            else if(a.property == ConnectionStatus.Property.error)
            {
                if(a.newState)
                    ThreadSafe.ChangeIcon((Form)mainWindow, Properties.Resources.notifyIconRed);
            }
        }

        public void SetAliveIcon(object o, ConnectionArgs a)
        {
            if(a.property == ConnectionStatus.Property.alive && a.newState)
                ThreadSafe.ChangeIcon((Form)mainWindow, Properties.Resources.notifyIconGreen);
        }

        public void SetRingLabel(object o, ConnectionArgs a)
        {
            if(a.newState)
                ThreadSafe.ChangeText(mainWindow.statusLabel, "RING", ThreadSafe.TextChangeMode.changeText);
        }

        public void SetErrorLabel(object o, ConnectionArgs a)
        {
            if(a.property == ConnectionStatus.Property.alive)
            {
                if(!a.newState)
                    ThreadSafe.ChangeText(mainWindow.statusLabel, "ERROR", ThreadSafe.TextChangeMode.changeText);
            }
            else if(a.property == ConnectionStatus.Property.error)
            {
                if (a.newState)
                    ThreadSafe.ChangeText(mainWindow.statusLabel, "ERROR", ThreadSafe.TextChangeMode.changeText);
            }                
        }

        public void SetAliveLabel(object o, ConnectionArgs a)
        {
            if(a.newState)
                ThreadSafe.ChangeText(mainWindow.statusLabel, "ALIVE", ThreadSafe.TextChangeMode.changeText);
        }

        public void SetRingBulb(object o, ConnectionArgs a)
        {
            if(a.newState)
                ThreadSafe.ChangePicture(mainWindow.statusPictureControl, Properties.Resources.notifyBlue);
        }

        public void SetErrorBulb(object o, ConnectionArgs a)
        {
            if (a.property == ConnectionStatus.Property.alive)
            {
                if (!a.newState)
                    ThreadSafe.ChangePicture(mainWindow.statusPictureControl, Properties.Resources.notifyRed);
            }
            else if (a.property == ConnectionStatus.Property.error)
            {
                if(a.newState)
                    ThreadSafe.ChangePicture(mainWindow.statusPictureControl, Properties.Resources.notifyRed);
            }         
        }

        public void SetAliveBulb(object o, ConnectionArgs a)
        {
            if(a.property == ConnectionStatus.Property.alive && a.newState)
                    ThreadSafe.ChangePicture(mainWindow.statusPictureControl, Properties.Resources.notifyGreen);
        }

        public void Log(object o, MessageEventArgs a)
        {
            string message = string.Format("{0}:\t{1}\n", DateTime.Now.ToLongTimeString(), a.message);
            ThreadSafe.ChangeText(mainWindow.logBoxControl, message, ThreadSafe.TextChangeMode.addText);
        }

        public void ChangeCheckConnectionTime()
        {
            mainWindow.checkConnectionTime = settings.checkConnection;
        }

        public void ChangeTriesNumber()
        {
            mainWindow.triesNumber = settings.triesNumber;
        }

        public void ChangeCONNTESTChecked()
        {
            mainWindow.showCONNTEST = settings.showCONNTESTmsg;
        }

        public void ChangePlayDeadChecked()
        {
            mainWindow.playError = settings.playError;
        }

        public void ChangePort()
        {
            mainWindow.port = settings.port;
        }

        public void ChangeTriesNumberLabel()
        {
            mainWindow.triesLabelText = string.Format("({0} minutes)", settings.triesNumber * settings.checkConnection);
        }
        #endregion

        #region Timer
        public void StartTimer(double timerInterval, byte checksToMake)
        {
            connTimer.StartTimer(timerInterval, checksToMake);
        }

        public void StopTimer()
        {
            connTimer.StopTimer();
        }
        public void ChangeInterval(double timerInterval)
        {
            connTimer.ChangeInterval(timerInterval);
        }

        public void ChangeNumberOfChecks(byte checks)
        {
            connTimer.ChangeNumberOfChecks(checks);
        }
        #endregion

        public void UpdateConnectionStatus(object o, MessageEventArgs a)
        {
            string message = a.message.ToUpper();
            if (message.Contains("RING"))
                ConnectionStatus.Set(ConnectionStatus.Property.ring, true, ConnectionStatus.ChangeReasons.ringOn);
            else if (message.Contains("ERROR"))
                ConnectionStatus.Set(ConnectionStatus.Property.error, true, ConnectionStatus.ChangeReasons.errorReceived, message);
            else
                ConnectionStatus.Set(ConnectionStatus.Property.alive, true, ConnectionStatus.ChangeReasons.messageReceived, message);
        }      
    }
}