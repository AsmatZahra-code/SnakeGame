using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text;

namespace mySNAKEgame
{
    public partial class frmSnake : Form
    {
        private bool IsInDesignMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        // ---------- Game state ----------
        private List<Point> snake = new List<Point>();
        private List<Point> hurdles = new List<Point>();
        private const int hurdleCount = 8;
        private Point food;

        // ---------- Food Types ----------
        private enum FoodKind { Normal, Special, Toxic, Gold, Mystery, SpeedUp, SpeedDown }
        private FoodKind foodKind = FoodKind.Normal;

        // ---------- Grid variables ----------
        private int cellSize = 20;
        private int gameWidth;
        private int gameHeight;

        // ---------- Directions ----------

        private int direction = 0;
        private int nextDirection = 0;

        // ---------- Score Tracking Variables ----------
        private int score = 0;
        private int highScore = 0;

        
        private Random rand = new Random();

        // ---------- Timing ----------
        private int baseInterval = 200;
        private int effectTicksRemaining = 0;
        private int effectIntervalBackup = -1;

        // ---------- Visuals ----------
        private Color snakeColor = Color.Green;
        private Color backgroundColor = Color.LightGray;
        private Color gridLineColor = Color.FromArgb(60, Color.LightSlateGray);

        // ---------- Game flags ----------
        private bool isRunning = false;
        private bool isPaused = false;
        private Dictionary<string, Image> foodImages;
        // ---------- Settings Panel ----------
        private Panel pnlSettings;
        private Button btnSnakeColorPick;
        private Button btnBackgroundColorPick;
        private Button btnCloseSettings;
        private Label lblSnakeColor;
        private Label lblBackgroundColor;

        // ---------- Snake head ----------
        private Image snakeHeadImage = mySNAKEgame.Properties.Resources.head;

        // ----------  sounds ----------
        private void PlayEatSound() => Console.Beep(800, 80);
        private void PlayGameOverSound() => Console.Beep(300, 400);

        // ---------- Settings panel ----------
        private void CreateSettingsPanel()
        {
            pnlSettings = new Panel
            {
                Size = new Size(250, 150),
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(this.Width / 2 - 125, this.Height / 2 - 75),
                Visible = false
            };

            // Snake Color Label
            lblSnakeColor = new Label
            {
                Text = "Snake Color:",
                Location = new Point(10, 20),
                AutoSize = true
            };
            pnlSettings.Controls.Add(lblSnakeColor);

            // Snake Color Button
            btnSnakeColorPick = new Button
            {
                Text = "Change",
                Location = new Point(120, 15),
                Size = new Size(100, 25)
            };
            btnSnakeColorPick.Click += BtnSnakeColorPick_Click;
            pnlSettings.Controls.Add(btnSnakeColorPick);

            // Background Color Label
            lblBackgroundColor = new Label
            {
                Text = "Background Color:",
                Location = new Point(10, 60),
                AutoSize = true
            };
            pnlSettings.Controls.Add(lblBackgroundColor);

            // Background Color Button
            btnBackgroundColorPick = new Button
            {
                Text = "Change",
                Location = new Point(120, 55),
                Size = new Size(100, 25)
            };
            btnBackgroundColorPick.Click += BtnBackgroundColorPick_Click;
            pnlSettings.Controls.Add(btnBackgroundColorPick);

            // Close Button
            btnCloseSettings = new Button
            {
                Text = "Close",
                Location = new Point(70, 100),
                Size = new Size(100, 30)
            };
            btnCloseSettings.Click += BtnCloseSettings_Click;
            pnlSettings.Controls.Add(btnCloseSettings);

            this.Controls.Add(pnlSettings);
        }

        // ---------- Snake body Color change ----------
        private void BtnSnakeColorPick_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.Color = snakeColor;
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    snakeColor = cd.Color;
                    gamePanel.Invalidate();
                }
            }
        }

        // ---------- BackGround Color change ----------
        private void BtnBackgroundColorPick_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.Color = backgroundColor;
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    backgroundColor = cd.Color;
                    gamePanel.Invalidate();
                }
            }
        }

        // ---------- Close Settings button ----------
        private void BtnCloseSettings_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = false;
        }

        // ---------- Generation of hurdles ----------
        private void GenerateHurdles()
        {
            hurdles.Clear();
            int placed = 0;
            while (placed < hurdleCount)
            {
                Point p = new Point(rand.Next(2, gameWidth - 2), rand.Next(2, gameHeight - 2));
                if (IsCellOccupiedBySnake(p) || p == food || hurdles.Contains(p)) continue;
                if (Math.Abs(p.X - gameWidth / 2) < 3 && Math.Abs(p.Y - gameHeight / 2) < 3) continue;
                hurdles.Add(p);
                placed++;
            }
        }

        // ---------- Main form snake ----------
        public frmSnake()
        {
            InitializeComponent();
            KeyPreview = true;
            if (IsInDesignMode) return;

            // ---------- Food images ----------
            foodImages = new Dictionary<string, Image>()
            {
                { "normal", Properties.Resources.apple },
                { "special", Properties.Resources.bananaa },
                { "toxic", Properties.Resources.cherry },
                { "gold", Properties.Resources.purpleGrapes },
                { "mystery", Properties.Resources.pineapple },
                { "speedup", Properties.Resources.orange },
                { "speeddown", Properties.Resources.watermelon }
            };

            // ---------- Double buffering ----------
            typeof(Panel).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null,
                gamePanel,
                new object[] { true });
            this.DoubleBuffered = true;

            // ---------- Button hover ----------
            btnStart.MouseEnter += (s, e) => btnStart.BackColor = Color.LightGreen;
            btnStart.MouseLeave += (s, e) => btnStart.BackColor = SystemColors.Control;
            btnPause.MouseEnter += (s, e) => btnPause.BackColor = Color.LightBlue;
            btnPause.MouseLeave += (s, e) => btnPause.BackColor = SystemColors.Control;
            btnStop.MouseEnter += (s, e) => btnStop.BackColor = Color.LightCoral;
            btnStop.MouseLeave += (s, e) => btnStop.BackColor = SystemColors.Control;
            btnExit.MouseEnter += (s, e) => btnExit.BackColor = Color.LightGray;
            btnExit.MouseLeave += (s, e) => btnExit.BackColor = SystemColors.Control;
            btnSettings.MouseEnter += (s, e) => btnSettings.BackColor = Color.LightYellow;
            btnSettings.MouseLeave += (s, e) => btnSettings.BackColor = SystemColors.Control;

            CreateSettingsPanel();
        }

        // ---------- Init Game ----------
        private void InitGame()
        {
            gameWidth = Math.Max(20, gamePanel.Width / cellSize);
            gameHeight = Math.Max(20, gamePanel.Height / cellSize);

            snake.Clear();
            int sx = gameWidth / 2;
            int sy = gameHeight / 2;
            snake.Add(new Point(sx, sy));
            snake.Add(new Point(sx - 1, sy));
            snake.Add(new Point(sx - 2, sy));

            direction = 0; nextDirection = 0; score = 0;
            lblScore.Text = "Score: 0";

            effectTicksRemaining = 0; effectIntervalBackup = -1;
            baseInterval = GetBaseIntervalFromDifficulty();
            gameTimer.Interval = baseInterval;

            pnlGameOver.Visible = false;
            lblScore.Visible = true;
            lblHighScore.Visible = true;
            isRunning = true; isPaused = false;
            GenerateFood();
            gameTimer.Start();
            if (cmbMode.SelectedIndex == 1) GenerateHurdles();
        }

        // ---------- Difficulty levels ----------
        private int GetBaseIntervalFromDifficulty()
        {
            string diff = cmbDifficulty.SelectedItem?.ToString() ?? "Easy";
            return diff switch
            {
                "Easy" => 200,
                "Medium" => 120,
                "Hard" => 60,
                _ => 200
            };
        }

        // ---------- Key movements ----------
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (pnlInstructions.Visible)
            {
                pnlInstructions.Visible = false;
                pbSplash.Visible = false;
                InitGame();
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Up: if (direction != 1) nextDirection = 3; break;
                case Keys.Down: if (direction != 3) nextDirection = 1; break;
                case Keys.Left: if (direction != 0) nextDirection = 2; break;
                case Keys.Right: if (direction != 2) nextDirection = 0; break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down ||
                keyData == Keys.Left || keyData == Keys.Right)
            {
                Form1_KeyDown(this, new KeyEventArgs(keyData));
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // ---------- Game loop ----------
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!isRunning || isPaused) return;

            if (Math.Abs(direction - nextDirection) != 2)
                direction = nextDirection;

            StepMove();
            CheckCollision();

            if (effectTicksRemaining > 0)
            {
                effectTicksRemaining--;
                if (effectTicksRemaining == 0 && effectIntervalBackup > 0)
                {
                    gameTimer.Interval = effectIntervalBackup;
                    effectIntervalBackup = -1;
                }
            }

            int level = 1 + (score / 50);
            if (level > 1)
            {
                int newInterval = Math.Max(20, (int)(gameTimer.Interval * 0.97));
                gameTimer.Interval = newInterval;
            }

            gamePanel.Invalidate();
        }

        // ---------- Step / Food ----------
        private void StepMove()
        {
            if (snake.Count == 0) return;
            Point head = snake[0];
            Point newHead = head;

            switch (direction)
            {
                case 0: newHead.X += 1; break;
                case 1: newHead.Y += 1; break;
                case 2: newHead.X -= 1; break;
                case 3: newHead.Y -= 1; break;
            }

            snake.Insert(0, newHead);

            if (newHead == food)
            {
                ApplyFoodEffect(foodKind);
                GenerateFood();
                PlayEatSound();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }
        }

        // ---------- Food Effects ----------
        private void ApplyFoodEffect(FoodKind kind)
        {
            switch (kind)
            {
                case FoodKind.Normal:
                    score += 10;
                    break;
                case FoodKind.Special:
                    score += 20;
                    break;
                case FoodKind.Toxic:
                    score -= 15;
                    if (snake.Count > 1) snake.RemoveAt(snake.Count - 1);
                    else GameOver();
                    break;
                case FoodKind.Gold:
                    score += 50;
                    // Grow by 2
                    snake.Add(new Point(snake[snake.Count - 1].X, snake[snake.Count - 1].Y));
                    snake.Add(new Point(snake[snake.Count - 1].X, snake[snake.Count - 1].Y));
                    break;
                case FoodKind.Mystery:
                    int mr = rand.Next(100);
                    if (mr < 60) score += 30;
                    else if (mr < 80) score -= 10;
                    else if (mr < 90) ApplyTemporarySpeed((int)(gameTimer.Interval * 0.5), 40);
                    else ApplyTemporarySpeed((int)(gameTimer.Interval * 1.8), 40);
                    break;
                case FoodKind.SpeedUp:
                    score += 10;
                    ApplyTemporarySpeed((int)(gameTimer.Interval * 0.5), 40);
                    break;
                case FoodKind.SpeedDown:
                    score += 10;
                    ApplyTemporarySpeed((int)(gameTimer.Interval * 1.8), 40);
                    break;
            }

            if (score > highScore) highScore = score;
            lblScore.Text = "Score: " + score;
            lblHighScore.Text = "High Score: " + highScore;
        }

        private void ApplyTemporarySpeed(int newInterval, int ticks)
        {
            if (effectIntervalBackup == -1) effectIntervalBackup = gameTimer.Interval;
            gameTimer.Interval = Math.Max(20, newInterval);
            effectTicksRemaining = ticks;
        }

        // ---------- Generate Food ----------
        private void GenerateFood()
        {
            int attempts = 0;
            Point candidate;
            do
            {
                candidate = new Point(rand.Next(0, gameWidth), rand.Next(0, gameHeight));
                attempts++;
                if (attempts > 1000) break;
            } while (IsCellOccupiedBySnake(candidate) || hurdles.Contains(candidate));

            food = candidate;

            int r = rand.Next(100);
            if (r < 40) foodKind = FoodKind.Normal;
            else if (r < 55) foodKind = FoodKind.Special;
            else if (r < 65) foodKind = FoodKind.Toxic;
            else if (r < 75) foodKind = FoodKind.Gold;
            else if (r < 90) foodKind = FoodKind.Mystery;
            else if (r < 95) foodKind = FoodKind.SpeedUp;
            else foodKind = FoodKind.SpeedDown;
        }

        private bool IsCellOccupiedBySnake(Point p)
        {
            foreach (var s in snake) if (s == p) return true;
            return false;
        }

        // ---------- Collision ----------
        private void CheckCollision()
        {
            if (snake.Count == 0) return;
            Point head = snake[0];

            if (cmbMode.SelectedIndex == 1 && hurdles.Contains(head))
            { GameOver(); return; }

            if (head.X < 0 || head.Y < 0 || head.X >= gameWidth || head.Y >= gameHeight)
            { GameOver(); return; }

            for (int i = 1; i < snake.Count; i++)
                if (snake[i] == head) { GameOver(); return; }


        }

        private void GameOver()
        {
            gameTimer.Stop();
            isRunning = false;
            pnlGameOver.Visible = true;
            lblGameOverScore.Text = $"Score: {score}";
            if (score > highScore)
            {
                highScore = score;
                lblHighScore.Text = "High Score: " + highScore;
            }
            PlayGameOverSound();

            // Update icons after game over
            pbPause.Visible = false; // hide pause
            pbStart.Visible = true;  // show play
        }

        // ---------- Drawing ----------
        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Preserve exact food colors when scaling
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            // Clear background
            g.Clear(backgroundColor);

            // Optional grid
            using (Pen pen = new Pen(gridLineColor))
            {
                for (int x = 0; x <= gameWidth; x++)
                    g.DrawLine(pen, x * cellSize, 0, x * cellSize, gameHeight * cellSize);
                for (int y = 0; y <= gameHeight; y++)
                    g.DrawLine(pen, 0, y * cellSize, gameWidth * cellSize, y * cellSize);
            }

            // Draw hurdles
            using (Brush hb = new SolidBrush(Color.DarkRed))
                foreach (var h in hurdles)
                    g.FillRectangle(hb, h.X * cellSize, h.Y * cellSize, cellSize, cellSize);

            // Draw snake body (excluding head and tail)
            using (Brush sb = new SolidBrush(snakeColor))
            {
                for (int i = snake.Count - 2; i >= 1; i--)
                {
                    var p = snake[i];
                    g.FillRectangle(sb, p.X * cellSize, p.Y * cellSize, cellSize, cellSize);
                }

                // Draw tail as triangle
                if (snake.Count > 1)
                {
                    var tail = snake[snake.Count - 1];
                    var beforeTail = snake[snake.Count - 2];
                    Point[] triangle = new Point[3];

                    if (tail.X < beforeTail.X) // left
                    {
                        triangle[0] = new Point(tail.X * cellSize + cellSize, tail.Y * cellSize);
                        triangle[1] = new Point(tail.X * cellSize + cellSize, tail.Y * cellSize + cellSize);
                        triangle[2] = new Point(tail.X * cellSize, tail.Y * cellSize + cellSize / 2);
                    }
                    else if (tail.X > beforeTail.X) // right
                    {
                        triangle[0] = new Point(tail.X * cellSize, tail.Y * cellSize);
                        triangle[1] = new Point(tail.X * cellSize, tail.Y * cellSize + cellSize);
                        triangle[2] = new Point(tail.X * cellSize + cellSize, tail.Y * cellSize + cellSize / 2);
                    }
                    else if (tail.Y < beforeTail.Y) // up
                    {
                        triangle[0] = new Point(tail.X * cellSize, tail.Y * cellSize + cellSize);
                        triangle[1] = new Point(tail.X * cellSize + cellSize, tail.Y * cellSize + cellSize);
                        triangle[2] = new Point(tail.X * cellSize + cellSize / 2, tail.Y * cellSize);
                    }
                    else if (tail.Y > beforeTail.Y) // down
                    {
                        triangle[0] = new Point(tail.X * cellSize, tail.Y * cellSize);
                        triangle[1] = new Point(tail.X * cellSize + cellSize, tail.Y * cellSize);
                        triangle[2] = new Point(tail.X * cellSize + cellSize / 2, tail.Y * cellSize + cellSize);
                    }
                    g.FillPolygon(sb, triangle);
                }
            }

            // Draw food **before** head background so colors stay exact
            string fkey = foodKind.ToString().ToLower();
            if (foodImages.ContainsKey(fkey))
            {
                g.DrawImage(foodImages[fkey],
                    food.X * cellSize,
                    food.Y * cellSize,
                    cellSize,
                    cellSize
                );
            }

            // Draw head background
            if (snake.Count > 0)
            {
                var head = snake[0];
                int headSize = (int)(cellSize * 1.2f);

                using (Brush bg = new SolidBrush(Color.DarkKhaki))
                {
                    g.FillRectangle(bg,
                        head.X * cellSize - (headSize - cellSize) / 2,
                        head.Y * cellSize - (headSize - cellSize) / 2,
                        headSize,
                        headSize
                    );
                }

                // Draw head image on top
                g.DrawImage(
                    snakeHeadImage,
                    new Rectangle(
                        head.X * cellSize - (headSize - cellSize) / 2,
                        head.Y * cellSize - (headSize - cellSize) / 2,
                        headSize,
                        headSize
                    )
                );
            }
        }

      
        // Start button / Play icon
        private void btnStart_Click(object sender, EventArgs e)
        {
            pbStart.Visible = false;  // hide play icon
            pbPause.Visible = true;   // show pause icon

            pbSplash.Visible = false;
            progressBarLoad.Visible = false;
            lblPercent.Visible = false;
            pnlInstructions.Visible = false;
            pnlGameOver.Visible = false;

            InitGame();

            // Enable Restart button now that the game is running
            pbReStart.Visible = true;
            pbReStart.Enabled = true;
        }
        
        // Pause button / Pause icon
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (!isRunning) return;

            isPaused = !isPaused;
            gameTimer.Enabled = !isPaused;

            pbPause.Visible = !isPaused;
            pbStart.Visible = isPaused;
        }
        
        // Stop button / Stop icon
        private void btnStop_Click(object sender, EventArgs e)
        {
            gameTimer.Stop();
            hurdles.Clear();
            isRunning = false;
            snake.Clear();
            gamePanel.Invalidate();
            score = 0;
            lblScore.Text = "Score: 0";
            pnlGameOver.Visible = false;

            pbStart.Visible = true;  // hide play icon
            pbPause.Visible = false;

        }
        
        // Exit button
        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
        
        // Settings button
        private void btnSettings_Click(object sender, EventArgs e)
        {

            pnlSettings.Visible = true;
            pnlSettings.BringToFront();
        }
       
        // Show game controls
        private void ShowGameControls()
        {
            pbReStart.Visible = true;
            pbStart.Visible = true;
            pbStop.Visible = true;
            pbSetttings.Visible = true;
            pbExit.Visible = true;
            pbPause.Visible = true;

            cmbDifficulty.Visible = true;
            cmbMode.Visible = true;
            lblDifficulty.Visible = true;
            lblMode.Visible = true;
        }
        
        // Progress bar timer tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBarLoad.Value < progressBarLoad.Maximum)
            {
                progressBarLoad.Value += 1;
                lblPercent.Text = progressBarLoad.Value + "%";
            }
            else
            {
                timer1.Stop();
                progressBarLoad.Visible = false;
                lblPercent.Visible = false;
                pnlInstructions.Visible = true;   // show instructions

                ShowGameControls();               // reveal buttons / combo
            }
        }
        
        // Form load event
        private void Form1_Load(object sender, EventArgs e)
        {
            if (IsInDesignMode) return;



            // ====  hide controls until later ====
            //pbRestart.Visible = false;
            pbReStart.Visible = false;
            pbReStart.Enabled = false;
            pbStart.Visible = false;
            pbStop.Visible = false;
            pbSetttings.Visible = false;
            pbExit.Visible = false;
            pbPause.Visible = false;
            btnStart.Visible = false;
            btnPause.Visible = false;
            btnStop.Visible = false;
            btnExit.Visible = false;
            btnSettings.Visible = false;
            lblScore.Visible = false;
            lblHighScore.Visible = false;
            cmbDifficulty.Visible = false;
            cmbMode.Visible = false;
            lblMode.Visible = false;
            lblDifficulty.Visible = false;

            progressBarLoad.Value = 0;
            lblPercent.Text = "0%";
            timer1.Interval = 20;
            timer1.Start();

            pnlGameOver.Visible = false;
            pnlGameOver.Location = new Point(gamePanel.Width / 2 - pnlGameOver.Width / 2,
                                            gamePanel.Height / 2 - pnlGameOver.Height / 2);

            pnlInstructions.Visible = false;   // will be shown after progress finishes
        }
       
        // Game over restart button
        private void btnGameOverRestart_Click(object sender, EventArgs e)
        {
            pnlGameOver.Visible = false;
            InitGame();

            // Show Pause icon, hide Play icon
            pbPause.Visible = true;
            pbStart.Visible = false;
        }
        
        // Combo box key down event to allow arrow key navigation
        private void cmbDifficulty_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                e.IsInputKey = true;
        }


        // ---------- Picture Box Click Events ----------
        private void pbStart_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                btnStart_Click(sender, e); // Start new game
            }
            else if (isPaused)
            {
                isPaused = false;
                gameTimer.Enabled = true;
                pbStart.Visible = false;
                pbPause.Visible = true;
            }
        }
        private void pbPause_Click(object sender, EventArgs e)
        {
            btnPause_Click(sender, e);
        }
        private void pbStop_Click(object sender, EventArgs e)
        {
            btnStop_Click(sender, e);
        }
        private void pbSetttings_Click(object sender, EventArgs e)
        {
            btnSettings_Click(sender, e);
        }
        private void pbExit_Click(object sender, EventArgs e)
        {
            btnExit_Click(sender, e);
        }

        private void pbReStart_Click(object sender, EventArgs e)
        {
            pnlGameOver.Visible = false;
            InitGame();
            // Show Pause icon, hide Play icon
            pbPause.Visible = true;
            pbStart.Visible = false;
        }


    }

}

