using System;
using System.Drawing;
using System.Windows.Forms;
namespace DoorBell
{
    interface IView
    {
        byte checkConnectionTime { get; set; }
        byte triesNumber { get; set; }
        bool showCONNTEST { get; set; }
        bool playError { get; set; }
        int port { get; set; }
        string logBox { get; set; }
        string triesLabelText { get; set; }
        string statusLabelText { get; set; }
        Image statusPic { set; }
        Icon appIcon { get; set; }
        Label statusLabel { get; }
        RichTextBox logBoxControl { get; }
        PictureBox statusPictureControl { get; }
        string saveButtonText { get; set; }
        bool saveButtonEnabled { get; set; }

        event EventHandler ringSoundButtonClicked;
        event EventHandler errorSoundButtonClicked;
        event EventHandler saveSettingsButtonClicked;

        event EventHandler settingsChanged;
        event EventHandler<ByteValueArg> checkConnectionTimeValueChanged;
        event EventHandler<ByteValueArg> triesNumberValueChanged;
        event EventHandler<BoolValueArg> showCONNTESTValueChanged;
        event EventHandler<BoolValueArg> playErrorValueChanged;
        event EventHandler<IntValueArg> portChanged;

        event EventHandler windowClosing;
    }
}
