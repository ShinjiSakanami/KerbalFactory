using KerbalFactory.Views;
using KFUtil;
using System;
using System.Globalization;
using System.IO;

namespace KerbalFactory
{
    public class KFLogHandler : ILogHandler
    {
        public KFLogHandler()
        {
            string directory = KFSettings.SettingsFolderPath;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string version = KFSettings.AppVersion;
            string time = DateTime.Now.ToString("F", CultureInfo.InvariantCulture);
            string text = KFLogHandler.FormatMessage(Logger.LogType.Log, string.Concat(new string[]
            {
                "***** Log initiated for KerbalFactory ",
                version,
                " *****",
                Environment.NewLine,
                Environment.NewLine,
                "Log started: ",
                time,
                Environment.NewLine,
                Environment.NewLine
            }));
            this.WriteLog(text, false);
        }

        public void LogException(Exception exception, object context)
        {
            if (MainForm.Instance != null)
            {
                string text = string.Concat(new string[] {
                    exception.Message,
                    Environment.NewLine,
                    exception.StackTrace
                });
                this.WriteLog(text);
            }
        }

        public void LogFormat(Logger.LogType logType, object context, string format, params object[] args)
        {
            string msg = String.Format(format, args);
            string text = KFLogHandler.FormatMessage(logType, msg);
            if (MainForm.Instance != null)
            {
                if (logType == Logger.LogType.Error)
                {
                    MainForm.Instance.AddMessage(msg, false);
                }
                if (logType == Logger.LogType.Warning)
                {
                    MainForm.Instance.AddMessage(msg, false);
                }
            }
            this.WriteLog(text);
        }

        public static string FormatMessage(Logger.LogType logType, string message)
        {
            string time = DateTime.Now.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture);
            string type = "LOG";
            if (logType == Logger.LogType.Warning)
            {
                type = "WRN";
            }
            if (logType == Logger.LogType.Error)
            {
                type = "ERR";
            }
            if (logType == Logger.LogType.Exception)
            {
                type = "EXC";
            }
            string text = String.Concat(new string[]
            {
                "[",
                type,
                " ",
                time,
                "] ",
                message
            });
            return text;
        }

        public void WriteLog(string message, bool append = true)
        {
            string file = KFSettings.LogFilePath;
            using (StreamWriter writer = new StreamWriter(file, append))
            {
                writer.WriteLine(message);
            }
        }
    }
}
