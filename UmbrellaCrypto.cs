using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;

namespace SPIDERS_UMBRELLA_CORPORATION.Core
{
    public class UmbrellaCrypto
    {
        private const int SaltSize = 32;
        private const int IvSize = 16;
        private const int KeySize = 32;
        private const int MacKeySize = 32;
        private const int MacSize = 32;
        private const int Iterations = 600000;
        private const string Extension = ".T_VIRUS";
        private const int BufferSize = 81920;

        public void DeriveKeys(SecureString password, byte[] salt, out byte[] encKey, out byte[] macKey)
        {
            byte[] passBytes = SecurityUtils.ToByteArray(password);
            try
            {
                using (var kdf = new Rfc2898DeriveBytes(passBytes, salt, Iterations))
                {
                    encKey = kdf.GetBytes(KeySize);
                    macKey = kdf.GetBytes(MacKeySize);
                }
            }
            finally { Array.Clear(passBytes, 0, passBytes.Length); }
        }

        public bool EncryptFile(string sourceFile, byte[] encKey, byte[] macKey, byte[] masterSalt)
        {
            if (sourceFile.EndsWith(Extension, StringComparison.OrdinalIgnoreCase)) return false;

            string outFile = sourceFile + Extension;
            byte[] iv = GenerateRandomBytes(IvSize);

                     // Fast Encrypt
            using (var fsOut = new FileStream(outFile, FileMode.Create))
            {
                     // Write Header: [Salt] [IV] [TagPlaceholder]
                fsOut.Write(masterSalt, 0, SaltSize);
                fsOut.Write(iv, 0, IvSize);
                fsOut.Write(new byte[MacSize], 0, MacSize);

                using (var aes = Aes.Create())
                {
                    aes.Key = encKey; aes.IV = iv; aes.Mode = CipherMode.CBC; aes.Padding = PaddingMode.PKCS7;
                    using (var cs = new CryptoStream(fsOut, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using (var fsIn = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
                    {
                        fsIn.CopyTo(cs);
                    }
                }
            }

                      // Calculate HMAC
            using (var hmac = new HMACSHA256(macKey))
            using (var fsRead = new FileStream(outFile, FileMode.Open, FileAccess.ReadWrite))
            {
                         // Authenticate IV
                byte[] ivCheck = new byte[IvSize];
                fsRead.Position = SaltSize;
                fsRead.Read(ivCheck, 0, IvSize);
                hmac.TransformBlock(ivCheck, 0, IvSize, ivCheck, 0);

                         // Authenticate Ciphertext (Skip tag placeholder)
                fsRead.Position = SaltSize + IvSize + MacSize;
                byte[] buf = new byte[BufferSize];
                int read;
                while ((read = fsRead.Read(buf, 0, buf.Length)) > 0)
                {
                    hmac.TransformBlock(buf, 0, read, buf, 0);
                }
                hmac.TransformFinalBlock(new byte[0], 0, 0);

                            // Write Tag
                fsRead.Position = SaltSize + IvSize;
                fsRead.Write(hmac.Hash, 0, MacSize);
            }

            SecurityUtils.SecureDelete(sourceFile);
            return true;
        }

        public bool DecryptFile(string sourceFile, SecureString password, ref byte[] cachedSalt, ref byte[] cachedEncKey, ref byte[] cachedMacKey)
        {
            if (!sourceFile.EndsWith(Extension, StringComparison.OrdinalIgnoreCase)) return false;

            try
            {
                using (var fsIn = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
                {
                    byte[] salt = new byte[SaltSize];
                    if (fsIn.Read(salt, 0, SaltSize) < SaltSize) return false;

                    // Cache Check: Only re-derive keys if salt (batch) changes
                    if (cachedSalt == null || !SafeEquals(salt, cachedSalt))
                    {
                        DeriveKeys(password, salt, out cachedEncKey, out cachedMacKey);
                        cachedSalt = salt;
                    }

                    byte[] iv = new byte[IvSize];
                    fsIn.Read(iv, 0, IvSize);

                    byte[] tag = new byte[MacSize];
                    fsIn.Read(tag, 0, MacSize);

                    // Verify HMAC
                    long ciphertextStart = fsIn.Position;
                    using (var hmac = new HMACSHA256(cachedMacKey))
                    {
                        hmac.TransformBlock(iv, 0, IvSize, iv, 0);
                        byte[] buf = new byte[BufferSize];
                        int read;
                        while ((read = fsIn.Read(buf, 0, buf.Length)) > 0)
                        {
                            hmac.TransformBlock(buf, 0, read, buf, 0);
                        }
                        hmac.TransformFinalBlock(new byte[0], 0, 0);

                        if (!SafeEquals(tag, hmac.Hash))
                            throw new Exception("Integrity Check Failed");
                    }

                    // Decrypt
                    fsIn.Position = ciphertextStart;
                    string outFile = sourceFile.Substring(0, sourceFile.Length - Extension.Length);

                    using (var aes = Aes.Create())
                    {
                        aes.Key = cachedEncKey; aes.IV = iv; aes.Mode = CipherMode.CBC; aes.Padding = PaddingMode.PKCS7;
                        using (var fsOut = new FileStream(outFile, FileMode.Create))
                        using (var cs = new CryptoStream(fsIn, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            cs.CopyTo(fsOut);
                        }
                    }
                }
                File.Delete(sourceFile);
                return true;
            }
            catch { return false; }
        }

        public byte[] GenerateRandomBytes(int len)
        {
            byte[] b = new byte[len];
            using (var rng = new RNGCryptoServiceProvider()) rng.GetBytes(b);
            return b;
        }

        private bool SafeEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length) return false;
            int diff = 0;
            for (int i = 0; i < a.Length; i++) diff |= a[i] ^ b[i];
            return diff == 0;
        }
    }
}