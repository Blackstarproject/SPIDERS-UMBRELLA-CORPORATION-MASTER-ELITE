// SPIDERS UMBRELLA CORPORATION: CREATED BY: JUSTIN LINWOOD ROSS | COPYRIGHT 2026 | GITHUB SOFTWARE REPOSITORY |
// MIT License: Copyright(c) 2026 (Rythorian) JUSTIN LINWOOD ROSS
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

// Also known as the "Umbrella Security Protocol," considered sophisticated, hybrid software.
// It combines a highly stylized, game-inspired user interface theme From the movie: RESIDENT EVIL
// ("The Red Queen") is a Military-Grade Cryptographic/Backend.
// Below is a structured breakdown of how this creepy application functions, split into it's Visual Design (Frontend) and Security Architecture (Backend).
// 1. Custom GDI+ Rendering & Math...(Headache Stuff):
// Instead of using standard images, the application draws its controls mathematically in real-time using GDI+(Graphics Device Interface).
// DNA Helix Spinner:
// This is not a GIF:
// (For the Record)...The code calculates the sine and cosine waves to draw two intertwining strands of "DNA." When you switch between
// Encrypt/Decrypt, the color shifts dynamically (Red for T-Virus/Lock, Cyan for Antidote/Unlock). This was no easy task...
// Sonar Radar:
// A custom control that draws a sweeping line and fades "blips" (representing files found) to simulate a radar screen scanning the file system.
// EKG Monitor:
// This represents system "heartbeat" or CPU activity. It basically draws a jagged line that spikes whenever the RedQueenController processes a file,
// giving you visual feedback on the encryption speed.
// 2. The Particle System:
// The background IS NOT STATIC >>> Form1.cs contains a physics engine that spawns "particles" (floating nodes).
// The Logic Factor:
// Each particle has an X/Y coordinate and a velocity vector.
// Interaction:
// They bounce off the screen edges.
// Visuals:
// These are rendered with transparency (Alpha channels), creating a depth effect behind the console logs.
// 3. "Bio-Text" Logging:
// The Logging System (consoleList) mimics a terminal booting up. It prefixes every message with a timestamp and uses terminology like,
// "SUBJECTS IDENTIFIED."
// instead of something boring such as "Files Found," or "DEPLOYING T-VIRUS" instead of "Encrypting..."
// II. Security Architecture: (The Cryptographic Core)
// Underneath the game-like visuals lies UmbrellaCrypto.cs, a serious encryption engine. It uses the Encrypt-then-MAC approach, which is the gold standard
// for secure file processing.
// 4. The Cipher:
// AES-256 (CBC Mode) What it is:
// Advanced Encryption Standard with a 256-bit key. This is the same standard used by governments for Top Secret data.
// Mode:
// It uses CBC (Cipher Block Chaining). This means every block of data depends on the previous one. If you encrypt the same file twice, the output will
// look completely different every time because of the IV (Initialization Vector).
// The IV:
// A random 16-byte value generated for every single file. This prevents "pattern analysis" (where an attacker could guess the content of a file by looking
// at repeating patterns in the encrypted code).
// 5. Key Derivation...
// PBKDF2The Problem: Humans pick weak passwords, so how do you get around this issue?
// The Solution:
// The app uses Rfc2898DeriveBytes (PBKDF2). It takes your password and runs it through a mathematical blender 600,000 times,
// which is referred to as (Iterations).
// Result:
// Even if your password is "password123", the derived encryption key is a complex, scrambled 32-byte string. This makes "brute force" attacks
// (guessing passwords) agonizingly slow for hackers.
// 6. Data Integrity...
// HMAC-SHA256The Vulnerability: Encryption hides data, but it doesn't prove the data hasn't been tampered with. A virus or hacker could flip a few bits in
// the encrypted file, which would cause the decryption to crash or output garbage.
// The Best Fix:
// This app calculates a Hash-based Message Authentication Code (HMAC) of the encrypted data.
// Verification:
// When you decrypt, the system first calculates the hash of the file on disk. If it doesn't match the hash stored in the file header, it rejects the file
// immediately ("Integrity Check Failed"). This guarantees that if a file decrypts, it is 100% identical to the original.4. Secure DeletionAfter a file is
// encrypted, the original must be removed. Simply deleting it is unsafe because data recovery tools can "undelete" it.
// Method:
// The SecurityUtils.SecureDelete function physically overwrites the file's location on the hard drive with zeros (for files under 100MB) before deleting it.
// This incinerates the digital footprint.III. Performance & Logic (The "Red Queen" Controller)
// 7. Streaming vs. LoadingOld Way:
// Loading a 4GB movie into RAM causes the computer to freeze.
// A New Way (Stream-Based Fun):
// This application opens a "pipe" to the file. It reads 80KB of data, encrypts it, writes it to disk, and grabs the next 80KB. This allows it to encrypt
// files of ANY SIZE >>> (even 100GB+) while using almost no RAM.
// 8. Parallel Processing: (Multi-Threading)..."The RedQueenController" uses (Parallel.ForEach.).
// This detects how many cores your CPU has (e.g., 8 cores) and it spins up very distinct encryption threads for each splendid core.
// Result: (EXAMPLE)
// It can encrypt 8 songs simultaneously, drastically reducing the total wait time for your "My Music" folder.
// 9. Smart Scanning: (Junction Handling)...
// The "HiveScanner", is designed to be resilient as hell...Windows contains "trap doors" called Junction Points (like "My Music" inside "My Documents",
// which isn't a real folder but a redirect).
// Standard scanners crash here as usual. Your scanner actively detects these permission errors, ignores the stupid trap, and routes directly to
// the real storage paths, ensuring no file is missed and the app never crashes....
// 10. File Header Structure:
// When you lock a file, the new.
// NOW FOR THE >>> T_VIRUS file is structured like this:
// ComponentSizePurposeMaster Salt32 BytesEnsures the batch is unique....IV16 BytesEnsures this specific file's encryption is unique.
// 11. HMAC Tag32 Bytes:
// The security seal. If this is broken, the file is corrupt. PayloadVariableThe actual encrypted music or video data.
// Is this a "Real World Application"? Yes. In fact, it performs a genuine, secure function that protects data against forensic analysis.
// You could genuinely use this to protect trade secrets, personal diaries, or financial records.
// Who is the Consumer?
// Note: The average Windows user may feel (too risky, too scary) soley based off the "Resident Evil" movie.
// (The Developer), I'm a Cyber-Security Worker, and a "Power User" who wanted to design a custom, specific encryption tool that doesn't rely on
// "Big Tech" backdoors.
// Visualizing the Architecture: I wanted you to pitch this as a product, but this application is still in an early stage of development for me and future
// updates & design.
// I had this application evaluated from https://replit.com/ (RATED BY STARS) this is how it compares to the market...for now:
// 1. SPIDERS UMBRELLA CORPORATION: (Red Queen)
// 2. BitLocker: (Windows)
// 3. WinRAR: (Password)
// ⭐⭐⭐⭐⭐ Encryption Strength: (AES-256)
// ⭐⭐⭐⭐⭐⭐⭐⭐ Speed
// ⭐⭐⭐⭐ (Multi-core)
// ⭐⭐⭐⭐⭐ (Kernel)
// ⭐⭐⭐ User Friendly
// ⭐⭐ (Complex/Scary)
// ⭐⭐⭐⭐⭐⭐⭐⭐⭐ Recoverability
// ⭐ (Zero Recovery)
// ⭐⭐⭐⭐⭐ (Cloud Key)
// ⭐ Plausible Deniability
// ⭐⭐⭐ (Custom Ext)

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPIDERS_UMBRELLA_CORPORATION.Core;

namespace SPIDERS_UMBRELLA_CORPORATION.UI
{
    public partial class Form1 : Form
    {
        private readonly RedQueenController _controller;

        // Visual Systems
        private class Particle { public float X, Y, VX, VY, Alpha; }
        private readonly List<Particle> _particles = new List<Particle>();
        private readonly Random _rnd = new Random();
        private Timer _glitchTimer;
        private Timer _masterTimer;
        private float _hexOffset = 0;
        private readonly Queue<Point> _cursorTrail = new Queue<Point>();

        // Window Dragging
        private bool _dragging;
        private Point _dragStart;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            _controller = new RedQueenController(
                LogMessage,
                () => { if (InvokeRequired) Invoke(new Action(() => sonarRadar.AddBlip())); else sonarRadar.AddBlip(); },
                () => { if (InvokeRequired) Invoke(new Action(() => ekgMonitor.TriggerSpike())); else ekgMonitor.TriggerSpike(); }
            );

            SetupVisualSystems();
            LogMessage(SecurityUtils.BioText("SYSTEM INITIALIZED. WAITING FOR INPUT..."), false);
        }

        private void SetupVisualSystems()
        {
            _masterTimer = new Timer { Interval = 16 };
            _masterTimer.Tick += (s, e) => { UpdateParticles(); Invalidate(); };
            _masterTimer.Start();

            // Background chatter
            _glitchTimer = new Timer { Interval = 3000 };
            _glitchTimer.Tick += (s, e) => {
                // Only log random chatter if NOT encrypting (to avoid clutter)
                if (btnEncrypt.Enabled && _rnd.Next(10) > 7)
                    LogMessage("...SYSTEM STABLE...", true);
            };
            _glitchTimer.Start();

            for (int i = 0; i < 50; i++) SpawnParticle();
        }

        private void SpawnParticle()
        {
            _particles.Add(new Particle
            {
                X = _rnd.Next(Width),
                Y = _rnd.Next(Height),
                VX = (float)(_rnd.NextDouble() - 0.5),
                VY = (float)(_rnd.NextDouble() - 0.5),
                Alpha = _rnd.Next(50, 200)
            });
        }

        private void UpdateParticles()
        {
            _hexOffset += 0.5f;
            foreach (var p in _particles)
            {
                p.X += p.VX; p.Y += p.VY;
                if (p.X < 0 || p.X > Width) p.VX *= -1;
                if (p.Y < 0 || p.Y > Height) p.VY *= -1;
            }
        }

        private void LogMessage(string msg, bool isError)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => LogMessage(msg, isError)));
                return;
            }
            string prefix = DateTime.Now.ToString("HH:mm:ss") + " >> ";
            consoleList.Items.Add(prefix + msg);
            consoleList.TopIndex = consoleList.Items.Count - 1;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen gridPen = new Pen(Color.FromArgb(20, 255, 0, 0), 1))
            {
                for (int x = 0; x < Width; x += 50)
                    for (int y = 0; y < Height; y += 50)
                        g.DrawRectangle(gridPen, x + (_hexOffset % 50), y, 40, 40);
            }

            foreach (var p in _particles)
            {
                using (Brush b = new SolidBrush(Color.FromArgb((int)p.Alpha, 255, 0, 0)))
                    g.FillEllipse(b, p.X, p.Y, 3, 3);
            }

            Point[] trail = _cursorTrail.ToArray();
            if (trail.Length > 1)
            {
                using (Pen p = new Pen(Color.Red, 2))
                    g.DrawLines(p, trail);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            _cursorTrail.Enqueue(e.Location);
            if (_cursorTrail.Count > 20) _cursorTrail.Dequeue();
            base.OnMouseMove(e);
        }

        private async void BtnEncrypt_Click(object sender, EventArgs e)
        {
            dnaSpinner.HelixColor = Color.Red;
            await RunProtocol(true);
        }

        private async void BtnDecrypt_Click(object sender, EventArgs e)
        {
            dnaSpinner.HelixColor = Color.Cyan;
            await RunProtocol(false);
        }

        private async Task RunProtocol(bool encrypt)
        {
            // Pause background chatter so we can see what's happening
            _glitchTimer.Stop();

            using (var pwdDialog = new PasswordDialog())
            {
                if (pwdDialog.ShowDialog(this) != DialogResult.OK)
                {
                    _glitchTimer.Start();
                    return;
                }

                btnEncrypt.Enabled = false;
                btnDecrypt.Enabled = false;

                SecureString pass = pwdDialog.Password;

                if (pass == null || pass.Length == 0)
                {
                    LogMessage("AUTHORIZATION REJECTED.", true);
                    btnEncrypt.Enabled = true;
                    btnDecrypt.Enabled = true;
                    _glitchTimer.Start();
                    return;
                }

                // Run the Controller
                await _controller.ExecuteProtocolAsync(pass, encrypt);

                pass.Dispose();
                btnEncrypt.Enabled = true;
                btnDecrypt.Enabled = true;
                _glitchTimer.Start();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e) => Application.Exit();

        // Window Dragging Logic
        private void Header_MouseDown(object sender, MouseEventArgs e) { _dragging = true; _dragStart = e.Location; }
        private void Header_MouseUp(object sender, MouseEventArgs e) { _dragging = false; }
        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - _dragStart.X, p.Y - _dragStart.Y);
            }
        }
    }
}