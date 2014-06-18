using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace eZet.EveLib.Core.Util {
    public static class FileAsync {
        public static async Task<string> ReadAllTextAsync(string filePath) {
            using (var sourceStream = new FileStream(filePath,
                FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true)) {
                var sb = new StringBuilder();
                var buffer = new byte[0x1000];
                int numRead;
                while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) != 0) {
                    string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }
                return sb.ToString();
            }
        }

        public static async Task<string[]> ReadAllLinesAsync(string filePath) {
            string data = await ReadAllTextAsync(filePath).ConfigureAwait(false);
            return data.Split(new[] {"\r\n", "\n"}, StringSplitOptions.RemoveEmptyEntries);
        }

        public static async Task WriteAllTextAsync(string filePath, string text) {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);
            using (var sourceStream = new FileStream(filePath,
                FileMode.Create, FileAccess.Write, FileShare.None, 4096, true)) {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length).ConfigureAwait(false);
            }
        }

        public static Task WriteAllLinesAsync(string filePath, IEnumerable<string> lines) {
            var sb = new StringBuilder();
            foreach (string line in lines) {
                sb.AppendLine(line);
            }
            return WriteAllTextAsync(filePath, sb.ToString());
        }
    }
}