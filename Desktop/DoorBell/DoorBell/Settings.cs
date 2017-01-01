using System;
using System.Xml.Serialization;

namespace DoorBell
{
    [XmlRoot("Data")]
    public class Settings
    {
        public Settings()
        {
            //XML class must have a parameterless constructor
        }

        [XmlElement("CheckConnection")]
        public byte checkConnection { get; set; }
        [XmlElement("DeadConnectionAfterTries")]
        public byte triesNumber { get; set; }
        [XmlElement("RingSoundPath")]
        public string ringSoundPath { get; set; }
        [XmlElement("ErrorSoundPath")]
        public string errorSoundPath { get; set; }
        [XmlElement("ShowCONNTESTMessage")]
        public bool showCONNTESTmsg { get; set; }
        [XmlElement("PlayDeadSound")]
        public bool playError { get; set; }
        [XmlElement("Port")]
        public int port { get; set; }

        #region ValueChangeMethods
        public void ChangeCheckConnection(object sender, ByteValueArg arg)
        {
            checkConnection = arg.value;
        }
        public void ChangeTriesNumber(object sender, ByteValueArg arg)
        {
            triesNumber = arg.value;
        }
        public void ChangeRingSoundPath(object sender, StringValueArg arg)
        {
            ringSoundPath = arg.value;
        }
        public void ChangeErrorSoundPath(object sender, StringValueArg arg)
        {
            errorSoundPath = arg.value;
        }
        public void ChangeShowCONNTEST(object sender, BoolValueArg arg)
        {
            showCONNTESTmsg = arg.value;
        }
        public void ChangePlayError(object sender, BoolValueArg arg)
        {
            playError = arg.value;
        }
        public void ChangePort(object sender, IntValueArg arg)
        {
            port = arg.value;
        }
        #endregion
    }
}