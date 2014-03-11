using System.Diagnostics;

namespace eZet.EveLib.Core.Util {
    public static class Logger {
        public static void Log(string message) {
            Debug.WriteLine(message);
        }
    }
}