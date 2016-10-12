namespace KFUtil
{
    public class PDebug
    {
        public enum DebugLevel
        {
            None = 0,
            Error = 1,
            Warning = 2,
            General = 4,
            PartInit = 8,
            FieldInit = 16,
            ModuleLoader = 32,
            PartLoader = 64,
            GameSettings = 128,
            ResourceNetwork = 256,
            ConfigNode = 512,
            GameDatabase = 1024,
            Everything = 1073741823
        }

        public static PDebug.DebugLevel debugLevel = PDebug.DebugLevel.Error | PDebug.DebugLevel.Warning | PDebug.DebugLevel.General;

        public static void Log(object msg, PDebug.DebugLevel level)
        {
            if ((PDebug.debugLevel & level) != PDebug.DebugLevel.None)
            {
                Debug.Log(msg);
            }
        }

        public static void Log(object msg)
        {
            PDebug.General(msg);
        }

        public static void General(object msg)
        {
            if ((PDebug.debugLevel & PDebug.DebugLevel.General) != PDebug.DebugLevel.None)
            {
                Debug.Log(msg);
            }
        }

        public static void Warning(object msg)
        {
            if ((PDebug.debugLevel & PDebug.DebugLevel.Warning) != PDebug.DebugLevel.None)
            {
                Debug.LogWarning(msg);
            }
        }

        public static void Error(object msg)
        {
            if ((PDebug.debugLevel & PDebug.DebugLevel.Error) != PDebug.DebugLevel.None)
            {
                Debug.LogError(msg);
            }
        }
    }
}
