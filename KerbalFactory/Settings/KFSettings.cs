using KerbalFactory.Views;
using KFUtil;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace KerbalFactory
{
    public class KFSettings
    {
        private const string _settingsFolder = "KerbalFactory";

        private const string _settingsFile = "KFSettings.xml";

        private const string _logFile = "KerbalFactory.log";

        private List<GamePath> _knownPaths;

        private int _currentPathIndex;

        private Size _windowSize;

        private Point _windowLoc;

        private static KFSettings _instance;

        public static KFSettings Instance
        {
            get
            {
                if (KFSettings._instance == null)
                {
                    KFSettings._instance = new KFSettings();
                }
                return KFSettings._instance;
            }
        }

        public static string ApplicationRootPath
        {
            get
            {
                return Application.StartupPath;
            }
        }

        public static string SettingsFolderPath
        {
            get
            {
                return Path.Combine(KFSettings.ApplicationRootPath, KFSettings._settingsFolder);
            }
        }

        public static string SettingsFilePath
        {
            get
            {
                return Path.Combine(KFSettings.SettingsFolderPath, KFSettings._settingsFile);
            }
        }

        public static string LogFilePath
        {
            get
            {
                return Path.Combine(KFSettings.SettingsFolderPath, KFSettings._logFile);
            }
        }

        public static string AppVersion
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo info = FileVersionInfo.GetVersionInfo(assembly.Location);
                return string.Format("{0}.{1}.{2}-{3}", info.FileMajorPart, info.FileMinorPart, info.FileBuildPart, info.FilePrivatePart);
            }
        }

        public Size WindowSize
        {
            get
            {
                return this._windowSize;
            }
            set
            {
                this._windowSize = value;
            }
        }

        public Point WindowLoc
        {
            get
            {
                return this._windowLoc;
            }
            set
            {
                this._windowLoc = value;
            }
        }

        public GamePath CurrentPath
        {
            get
            {
                if (this._knownPaths.Count > 0)
                {
                    if (this._currentPathIndex < 0 || this._currentPathIndex >= this._knownPaths.Count)
                    {
                        this._currentPathIndex = 0;
                    }
                    return this._knownPaths[this._currentPathIndex];
                }
                else
                {
                    return this.DetectPath();
                }
            }
        }

        public List<GamePath> KnownPaths
        {
            get
            {
                return this._knownPaths;
            }
        }

        public int CurrentPathIndex
        {
            get
            {
                return this._currentPathIndex;
            }
            set
            {
                this._currentPathIndex = value;
            }
        }

        private KFSettings()
        {
            this._knownPaths = new List<GamePath>();
            this._currentPathIndex = 0;
            if (MainForm.Instance != null)
            {
                this._windowLoc = MainForm.Instance.Location;
                this._windowSize = MainForm.Instance.Size;
            }
            else
            {
                this._windowLoc = new Point();
                this._windowSize = new Size();
            }
        }

        public void Load()
        {
            if (!Directory.Exists(KFSettings.SettingsFolderPath))
            {
                Directory.CreateDirectory(KFSettings.SettingsFolderPath);
            }
            if (!File.Exists(KFSettings.SettingsFilePath))
            {
                this.SaveFile(KFSettings.SettingsFilePath);
            }
            else
            {
                this.LoadFile(KFSettings.SettingsFilePath);
            }
        }

        public void Save()
        {
            if (!Directory.Exists(KFSettings.SettingsFolderPath))
            {
                Directory.CreateDirectory(KFSettings.SettingsFolderPath);
            }
            this.SaveFile(KFSettings.SettingsFilePath);
        }

        private void LoadFile(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNodeList currentIndex = doc.GetElementsByTagName("CurrentPathIndex");
            foreach (XmlNode node in currentIndex)
            {
                int index = 0;
                if (int.TryParse(node.InnerText, out index))
                {
                    this._currentPathIndex = index;
                }
            }
            XmlNodeList paths = doc.GetElementsByTagName("Path");
            foreach (XmlNode node in paths)
            {
                string fullPath = node.InnerText;
                string pathName = string.Empty;
                foreach(XmlAttribute att in node.Attributes)
                {
                    if (att.Name == "name")
                    {
                        pathName = att.Value;
                    }
                }
                this.AddPath(fullPath, pathName);
            }
            XmlNodeList size = doc.GetElementsByTagName("WindowSize");
            foreach (XmlNode node in size)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Name == "Width")
                    {
                        int width = 0;
                        if (int.TryParse(child.InnerText, out width))
                        {
                            this._windowSize.Width = width;
                        }
                    }
                    if (child.Name == "Height")
                    {
                        int height = 0;
                        if (int.TryParse(child.InnerText, out height))
                        {
                            this._windowSize.Height = height;
                        }
                    }
                }
            }
            XmlNodeList loc = doc.GetElementsByTagName("WindowLoc");
            foreach (XmlNode node in loc)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Name == "X")
                    {
                        int x = 0;
                        if (int.TryParse(child.InnerText, out x))
                        {
                            this._windowLoc.X = x;
                        }
                    }
                    if (child.Name == "Y")
                    {
                        int y = 0;
                        if (int.TryParse(child.InnerText, out y))
                        {
                            this._windowLoc.Y = y;
                        }
                    }
                }
            }
        }

        private void SaveFile(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(docNode);
            XmlNode root = doc.CreateElement("KerbalFactorySettings");
            doc.AppendChild(root);
            XmlNode currentIndex = doc.CreateElement("CurrentPathIndex");
            currentIndex.InnerText = this._currentPathIndex.ToString();
            root.AppendChild(currentIndex);
            XmlNode paths = doc.CreateElement("KspPaths");
            root.AppendChild(paths);
            foreach (GamePath path in this._knownPaths)
            {
                XmlNode pathNode = doc.CreateElement("Path");
                pathNode.InnerText = path.FullPath;
                XmlAttribute pathName = doc.CreateAttribute("name");
                pathName.Value = path.Name;
                pathNode.Attributes.Append(pathName);
                paths.AppendChild(pathNode);
            }
            XmlNode size = doc.CreateElement("WindowSize");
            root.AppendChild(size);
            XmlNode width = doc.CreateElement("Width");
            width.InnerText = this._windowSize.Width.ToString();
            size.AppendChild(width);
            XmlNode height = doc.CreateElement("Height");
            height.InnerText = this._windowSize.Height.ToString();
            size.AppendChild(height);
            XmlNode loc = doc.CreateElement("WindowLoc");
            root.AppendChild(loc);
            XmlNode x = doc.CreateElement("X");
            x.InnerText = this._windowLoc.X.ToString();
            loc.AppendChild(x);
            XmlNode y = doc.CreateElement("Y");
            y.InnerText = this._windowLoc.Y.ToString();
            loc.AppendChild(y);
            doc.Save(filePath);
        }

        public GamePath DetectPath()
        {
            string path = KFSettings.ApplicationRootPath;
            return this.AddPath(path, "auto");
        }

        public GamePath AddPath(string path, string name)
        {
            if (UrlDir.IsValidKSPPath(path))
            {
                GamePath auto = new GamePath(name, path, this.GetKSPVersion(path));
                this._knownPaths.Add(auto);
                return auto;
            }
            return null;
        }

        public void RemovePath(int index)
        {
            this._knownPaths.RemoveAt(index);
        }

        public void RenamePath(int index, string newName)
        {
            GamePath path = this._knownPaths[index];
            path.Name = newName;
        }

        public string GetKSPVersion(string gamepath)
        {
            string readmePath = Path.Combine(gamepath, "readme.txt");
            if (File.Exists(readmePath))
            {
                StreamReader readme = new StreamReader(readmePath);
                string line;
                while ((line = readme.ReadLine()) != null)
                {
                    if (line.StartsWith("Version"))
                    {
                        string[] array = line.Split(new char[]
                        {
                            ' '
                        });
                        return array[1];
                    }
                }
                readme.Close();
            }
            return string.Empty;
        }
    }
}
