
using System.Diagnostics;

namespace eZet.Eve.EveLib.Util {
    public static class Logger {

        public static void Log(string message) {
            Debug.WriteLine(message);
        }
    }
}
