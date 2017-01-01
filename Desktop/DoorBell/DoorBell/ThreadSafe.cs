using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoorBell
{
    /// <summary>
    /// This class contains methods used to change some properties of UI controls
    /// </summary>
    static class ThreadSafe
    {
        public enum TextChangeMode
        {
            changeText,
            addText
        }
        private delegate void ChangeTextDelegate(Control @this, string text, TextChangeMode mode);
        public static void ChangeText(Control @this, string text, TextChangeMode mode)
        {
            if(@this.InvokeRequired)
            {
                ChangeTextDelegate textDelegate = new ChangeTextDelegate(ChangeText);
                @this.Invoke(textDelegate, new object[] { @this, text, mode });
            }
            else
            {
                switch (mode)
                {
                    case TextChangeMode.changeText:
                        @this.Text = text;
                        break;
                    case TextChangeMode.addText:
                        @this.Text += text;
                        break;
                    default:
                        throw new ArgumentException("Text Change Mode " + mode.ToString() + " is not valid");
                }
                
            }
        }
        private delegate void ChangePictureDelegate(PictureBox @this, Image image);
        public static void ChangePicture(PictureBox @this, Image image)
        {
            if(@this.InvokeRequired)
            {
                ChangePictureDelegate picDelegate = new ChangePictureDelegate(ChangePicture);
                @this.Invoke(picDelegate, new object[] { @this, image });
            }
            else
            {
                @this.Image = image;
            }
        }
        private delegate void ChangeIconDelegate(Form @this, Icon icon);
        public static void ChangeIcon(Form @this, Icon icon)
        {
            if(@this.InvokeRequired)
            {
                ChangeIconDelegate iconDelegate = new ChangeIconDelegate(ChangeIcon);
                @this.Invoke(iconDelegate, new object[] { @this, icon });
            }
            else
            {
                @this.Icon = icon;
            }
        }
    }
}
