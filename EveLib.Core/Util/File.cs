using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace eZet.EveLib.Core.Util {
    public static class FileAsync {

        public static async Task<string> ReadAllTextAsync(string filePath) {
            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true)) {
                StringBuilder sb = new StringBuilder();

                byte[] buffer = new byte[0x1000];
                int numRead;
                while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) != 0) {
                    string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }
                return sb.ToString();
            }
        }

        public static async Task<string[]> ReadAllLinesAsync(string filePath) {
            var data = await ReadAllTextAsync(filePath).ConfigureAwait(false);
            return data.Split(new string[] {"\r\n", "\n"}, StringSplitOptions.RemoveEmptyEntries);
        }

        public static async Task WriteAllTextAsync(string filePath, string text) {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);
            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true)) {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length).ConfigureAwait(false);
            }
        }

        public static Task WriteAllLinesAsync(string filePath, IEnumerable<string> lines) {
            var sb = new StringBuilder();
            foreach (var line in lines) {
                sb.AppendLine(line);
            }
            return WriteAllTextAsync(filePath, sb.ToString());
        }

        

    }
}
