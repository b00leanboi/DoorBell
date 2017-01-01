using System;
using System.Windows.Forms;
using WMPLib;
namespace DoorBell
{
    class SoundControl
    {
        public event EventHandler<StringValueArg> ringSoundPathChanged;
        public string ringSoundPath
        {
            get;
            set;
        }
        public event EventHandler<StringValueArg> errorSoundPathChanged;
        public string errorSoundPath
        {
            get;
            set;
        }
        private WindowsMediaPlayer player = new WindowsMediaPlayer();

        public enum Sounds
        {
            ring,
            error
        }

        public void PlaySound(Sounds sound)
        {
            if (sound == Sounds.ring)
            {
                player.URL = ringSoundPath;
            }
            else
            {
                player.URL = errorSoundPath;
            }
            player.controls.play();
        }
        public void ChooseRingSound(object sender, EventArgs args)
        {
            ChooseSound(Sounds.ring);
        }
        public void ChooseErrorSound(object sender, EventArgs args)
        {
            ChooseSound(Sounds.error);
        }
        private void ChooseSound(Sounds sound)
        {
            using (var form = new OpenFileDialog())
            {
                form.Multiselect = false;
                form.Filter = "All Files (*.*)|*.*";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (sound == Sounds.ring)
                    {
                        ringSoundPath = form.FileName;
                        ringSoundPathChanged.Invoke(this, new StringValueArg(ringSoundPath));
                    }
                    else
                    {
                        errorSoundPath = form.FileName;
                        errorSoundPathChanged.Invoke(this, new StringValueArg(errorSoundPath));
                    }
                }
            }
        }
    }
}
