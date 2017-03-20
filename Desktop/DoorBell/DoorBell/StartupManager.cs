using Microsoft.Win32;
using System;
using System.Security;
using System.Windows.Forms;
namespace DoorBell
{
    public class StartupManager
    {
        private static string subkeyPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private static string name = "DoorBell";
        private static string value = "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\"";

        public enum Mode
        {
            AllUsers,
            CurrentUser,
            Off //This is used at MainWindow event when radio button changes
        }
        public static void AddToStartup(Mode mode)
        {
            if (mode == Mode.Off)
                throw new ArgumentException("Invalid argument for AddToStartup method - Off.");
            if (mode == Mode.AllUsers)
            {
                try
                {
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(subkeyPath, true))
                    {
                        key.SetValue(name, value);
                    }
                }
                catch(SecurityException)
                {
                    MessageBox.Show("You do not have right to access the register. \nTry running the app as an administrator.",
                                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }               
            }
            else
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(subkeyPath, true))
                {
                    key.SetValue(name, value);
                }
            }
        }
        public static void RemoveFromStartup(Mode mode)
        {
            if (mode == Mode.Off)
                throw new ArgumentException("Invalid argument for RemoveFromStartup method - Off.");

            if(mode == Mode.AllUsers)
            {
                using(RegistryKey key = Registry.LocalMachine.OpenSubKey(subkeyPath, true))
                {
                    key.DeleteValue(name, false);
                }
            }
            else
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(subkeyPath, true))
                {
                    key.DeleteValue(name, false);
                }
            }
        }
    }
    //This class is used for radio change events of the main window.
    public class StartupEventArgs : EventArgs
    {
        public StartupManager.Mode modeSelected;
        
        public StartupEventArgs(StartupManager.Mode mode)
        {
            modeSelected = mode;
        }
    }
}
