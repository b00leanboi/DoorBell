using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace DoorBell
{
    class SettingsOperations
    {
        private static readonly string dataLocPath = "DataLocation.xml";
        private static string dataPath;

        public static bool SaveSettings(Settings data, bool getNewPath)
        {
            bool saved = false;

            XmlRootAttribute dataRootAtt = new XmlRootAttribute();
            dataRootAtt.IsNullable = true;

            string dataPath = GetDataPath();
            if (dataPath == null || getNewPath)
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = "XML Files (*.xml)|*.xml";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        Stream file = dialog.OpenFile();
                        SaveFile(file, data);
                        saved = true;
                    }
                }
            }
            else
            {
                Stream file = File.Open(dataPath, FileMode.Open);
                SaveFile(file, data);
                saved = true;
            }
            return saved;
        }
        private static void SaveFile(Stream file, Settings data)
        {          
            if (file != null)
            {
                XmlSerializer dataSer = new XmlSerializer(typeof(Settings));
                dataSer.Serialize(file, data);
            }
            file.Close();
        }
        private static void SaveLocation(string path)
        {
            /*--- XML DATA LOCATION FILE ---*/
            XMLDataLoc dataLoc = new XMLDataLoc(path);
            XmlSerializer locSer = new XmlSerializer(typeof(XMLDataLoc));
            FileStream locFile;
            try
            {
                locFile = File.Open(dataLocPath, FileMode.OpenOrCreate);
            }
            catch (IOException)
            {
                MessageBox.Show("This file is used by a different process\n" + dataLocPath, "File in use", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            locSer.Serialize(locFile, dataLoc);
            locFile.Close();
        }
        /// <summary>
        /// Loads user's data
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sound"></param>
        /// <returns>Null if data does not exist</returns>
        public static Settings LoadSettings()
        {
            /*--- DATA LOCATION FILE ---*/
            if (!File.Exists(dataLocPath))
            {
                MessageBox.Show("Data location file does not exist");
                return null;
            }

            /*--- DATA FILE ---*/
            dataPath = GetDataPath();
            if (dataPath == null)
                return null;

            if (!File.Exists(dataPath))
            {
                MessageBox.Show(dataPath + " not found. If you keep getting that message, report it.",
                                dataPath + " Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return GetData(dataPath);
        }
        private static string GetDataPath()
        {
            FileStream locFile;
            try
            {
                locFile = File.Open(dataLocPath, FileMode.Open);
            }
            catch (IOException)
            {
                MessageBox.Show("This file is used by a different process:\n" + dataLocPath, "File in use", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            XmlSerializer locSer = new XmlSerializer(typeof(XMLDataLoc));
            XMLDataLoc dataLoc;
            try
            {
                dataLoc = (XMLDataLoc)locSer.Deserialize(locFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString());
                locFile.Close();
                return null;
            }
            locFile.Close();
            return dataLoc.path;
        }
        private static Settings GetData(string path)
        {
            FileStream dataFile;
            try
            {
                dataFile = File.Open(path, FileMode.Open);
            }
            catch (IOException)
            {
                MessageBox.Show("This file is used by a different process\n" + dataLocPath, "File in use", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            XmlSerializer dataSer = new XmlSerializer(typeof(Settings));
            Settings data = (Settings)dataSer.Deserialize(dataFile);
            dataFile.Close();
            return data;
        }
    }
    [XmlRoot("DataLocation")]
    public class XMLDataLoc
    {
        [XmlElement("SettingsLocation")]
        public string path { get; set; }

        public XMLDataLoc()
        {
            //XML class must have a parameterless constructor
        }
        public XMLDataLoc(string path)
        {
            this.path = path;
        }
    }
}