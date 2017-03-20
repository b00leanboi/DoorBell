using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoorBell
{
    public partial class MainWindow : Form, IView
    {
        #region Fields
        private Presenter presenter;
        public Icon appIcon
        {
            get
            {
                return this.Icon;
            }

            set
            {
                this.Icon = value;
            }
        }

        public byte checkConnectionTime
        {
            get
            {
                return (byte)checkConnectionNUD.Value;
            }

            set
            {
                checkConnectionNUD.Value = value;
            }
        }
        public string logBox
        {
            get
            {
                return logTextBox.Text;
            }

            set
            {
                logTextBox.Text = value;
            }
        }

        public bool playError
        {
            get
            {
                return playErrorCheckBox.Checked;
            }

            set
            {
                playErrorCheckBox.Checked = value;
            }
        }

        public int port
        {
            get
            {
                return (int)portNUD.Value;
            }

            set
            {
                portNUD.Value = value;
            }
        }

        public bool showCONNTEST
        {
            get
            {
                return showConntestCheckBox.Checked;
            }

            set
            {
                showConntestCheckBox.Checked = value;
            }
        }

        public string triesLabelText
        {
            get
            {
                return triesLabel.Text;
            }

            set
            {
                triesLabel.Text = value;
            }
        }

        public byte triesNumber
        {
            get
            {
                return (byte)triesInputNUD.Value;
            }

            set
            {
                triesInputNUD.Value = value;
            }
        }

        public string statusLabelText
        {
            get
            {
                return statLbl.Text;
            }

            set
            {
                statLbl.Text = value;
            }
        }
        public Label statusLabel
        {
            get
            {
                return statLbl;
            }
        }
        public Image statusPic
        {
            set
            {
                statusPicture.Image = value;
            }
        }
        public PictureBox statusPictureControl
        {
            get
            {
                return statusPicture;
            }
        }
        public RichTextBox logBoxControl
        {
            get
            {
                return logTextBox;
            }
        }
        public string saveButtonText
        {
            get
            {
                return saveSettingsBtn.Text;
            }
            set
            {
                saveSettingsBtn.Text = value;
            }
        }
        public bool saveButtonEnabled
        {
            get
            {
                return saveSettingsBtn.Enabled;
            }
            set
            {
                saveSettingsBtn.Enabled = value;
            }
        }

        public FormWindowState windowState
        {
            get
            {
                return this.WindowState;
            }
            set
            {
                this.WindowState = value;
            }
        }

        Icon IView.notifyIcon
        {
            get
            {
                return notifyIcon.Icon;
            }

            set
            {
                notifyIcon.Icon = value;
            }
        }

        public bool notifyIconVisible
        {
            get
            {
                return notifyIcon.Visible;
            }

            set
            {
                notifyIcon.Visible = value;
            }
        }
        #endregion
        #region Events
        public event EventHandler ringSoundButtonClicked;
        public event EventHandler errorSoundButtonClicked;
        public event EventHandler saveSettingsButtonClicked;

        public event EventHandler settingsChanged;
        public event EventHandler<ByteValueArg> checkConnectionTimeValueChanged;
        public event EventHandler<ByteValueArg> triesNumberValueChanged;
        public event EventHandler<BoolValueArg> showCONNTESTValueChanged;
        public event EventHandler<BoolValueArg> playErrorValueChanged;
        public event EventHandler<IntValueArg> portChanged;

        public event EventHandler notifyIconDoubleClicked;

        public event EventHandler<FormResizeArg> windowResized;
        public event EventHandler windowClosing;

        public event EventHandler<StartupEventArgs> startupSettingChanged;

        #endregion
        public MainWindow()
        {
            InitializeComponent();
            presenter = new Presenter(this);
        }
        #region FormMethods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeout">Timeout is in ms</param>
        public void ShowBalloonTip(int timeout)
        {
            notifyIcon.ShowBalloonTip(timeout);
        }

        private void ringSoundButton_Click(object sender, EventArgs e)
        {
            ringSoundButtonClicked.Invoke(this, EventArgs.Empty);
        }

        private void errorSoundButton_Click(object sender, EventArgs e)
        {
            errorSoundButtonClicked.Invoke(this, EventArgs.Empty);
        }

        private void saveSettingsBtn_Click(object sender, EventArgs e)
        {
            saveSettingsButtonClicked.Invoke(this, EventArgs.Empty);
        }

        private void checkConnectionNUD_ValueChanged(object sender, EventArgs e)
        {
            checkConnectionTimeValueChanged.Invoke(this, new ByteValueArg(checkConnectionTime));
            settingsChanged.Invoke(this, EventArgs.Empty);
        }

        private void triesInputNUD_ValueChanged(object sender, EventArgs e)
        {
            triesNumberValueChanged.Invoke(this, new ByteValueArg(triesNumber));
            settingsChanged.Invoke(this, EventArgs.Empty);
        }

        private void showConntestCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            showCONNTESTValueChanged.Invoke(this, new BoolValueArg(showCONNTEST));
            settingsChanged.Invoke(this, EventArgs.Empty);
        }

        private void playErrorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            playErrorValueChanged.Invoke(this, new BoolValueArg(playError));
            settingsChanged.Invoke(this, EventArgs.Empty);
        }

        private void portNUD_ValueChanged(object sender, EventArgs e)
        {
            portChanged.Invoke(this, new IntValueArg(port));
            settingsChanged.Invoke(this, EventArgs.Empty);
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            notifyIconDoubleClicked.Invoke(this, EventArgs.Empty);
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            windowResized.Invoke(this, new FormResizeArg(windowState));
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            windowClosing.Invoke(this, EventArgs.Empty);
        }

        public void ShowMainWindow()
        {
            this.Show();
        }

        public void HideMainWindow()
        {
            this.Hide();
        }
        private void startupCurrentRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (startupCurrentRadio.Checked)
                startupSettingChanged.Invoke(this, new StartupEventArgs(StartupManager.Mode.CurrentUser));
        }

        private void startupAllRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (startupAllRadio.Checked)
                startupSettingChanged.Invoke(this, new StartupEventArgs(StartupManager.Mode.AllUsers));
        }

        private void startupOffRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (startupOffRadio.Checked)
                startupSettingChanged.Invoke(this, new StartupEventArgs(StartupManager.Mode.Off));
        }
        #endregion
    }
}
