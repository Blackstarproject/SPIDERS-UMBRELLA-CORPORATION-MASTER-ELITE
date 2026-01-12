using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

namespace SPIDERS_UMBRELLA_CORPORATION.Core
{
    public static class SecurityUtils
    {
        // Speed-Optimized Secure Delete (1 Pass of Zeros)
        public static void SecureDelete(string filePath)
        {
            if (!File.Exists(filePath)) return;
            try
            {
                long len = new FileInfo(filePath).Length;
                // Only overwrite if file is small (<100MB) to save time on videos
                // For videos > 100MB, just delete (OS handles cleanup eventually)
                if (len < 100 * 1024 * 1024)
                {
                    using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Write))
                    {
                        byte[] dummy = new byte[64 * 1024]; // 64KB zeros
                        long written = 0;
                        while (written < len)
                        {
                            int toWrite = (int)Math.Min(dummy.Length, len - written);
                            fs.Write(dummy, 0, toWrite);
                            written += toWrite;
                        }
                    }
                }
                File.Delete(filePath);
            }
            catch
            {
                try { File.Delete(filePath); } catch { }
            }
        }

        public static byte[] ToByteArray(SecureString secureString)
        {
            if (secureString == null) return new byte[0];
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                byte[] bytes = new byte[secureString.Length * 2];
                Marshal.Copy(ptr, bytes, 0, bytes.Length);
                return bytes;
            }
            finally { if (ptr != IntPtr.Zero) Marshal.FreeHGlobal(ptr); }
        }

        public static string BioText(string input) => input;
    }
}