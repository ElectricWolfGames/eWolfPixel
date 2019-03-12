using System.Collections.Generic;
using System.IO;

namespace eWolfPixelStandard.Helpers
{
    public static class FileHelper
    {
        public static List<string> GetAllFiles(string projectPath)
        {
            List<string> files = new List<string>();
            var filesRaw = Directory.GetFiles(projectPath, "*", SearchOption.AllDirectories);
            foreach (string filename in filesRaw)
            {
                if (string.IsNullOrWhiteSpace(filename))
                    continue;

                files.Add(filename);
            }

            return files;
        }

        public static List<string> GetAllDirectories(string projectPath)
        {
            List<string> files = new List<string>();
            var filesRaw = Directory.GetDirectories(projectPath, "*", SearchOption.AllDirectories);
            foreach (string filename in filesRaw)
            {
                if (string.IsNullOrWhiteSpace(filename))
                    continue;

                files.Add(filename);
            }

            return files;
        }
    }
}
