using System.Diagnostics;

namespace PasswordGenerator.Utils
{
    internal static class ProcessHelper
    {
        public static void StartWithShell(string fileName)
        {
            var info = new ProcessStartInfo(fileName) {
                UseShellExecute = true
            };

            Process.Start(info);
        }
    }
}
