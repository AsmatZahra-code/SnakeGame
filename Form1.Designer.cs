using System.Drawing.Printing;
using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace mySNAKEgame
{
    partial class frmSnake
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSnake));
            gamePanel = new Panel();
            pnlInstructions = new Panel();
            lblSettings = new Label();
            lblStart = new Label();
            pbOrange = new PictureBox();
            pbPineApple = new PictureBox();
            pbWatermelon = new PictureBox();
            pbGrapes = new PictureBox();
            pbCherry = new PictureBox();
            pbBanana = new PictureBox();
            pbApple = new PictureBox();
            lblFood = new Label();
            lblRules = new Label();
            lblMovement = new Label();
            lblTitle = new Label();
            pnlGameOver = new Panel();
            btnGameOverRestart = new Button();
            lblGameOverTitle = new Label();
            lblGameOverScore = new Label();
            lblPercent = new Label();
            progressBarLoad = new ProgressBar();
            pbSplash = new PictureBox();
            pbStop = new PictureBox();
            pbPause = new PictureBox();
            pbSetttings = new PictureBox();
            pbStart = new PictureBox();
            pbExit = new PictureBox();
            lblHighScore = new Label();
            cmbMode = new ComboBox();
            lblScore = new Label();
            cmbDifficulty = new ComboBox();
            btnExit = new Button();
            btnStart = new Button();
            btnPause = new Button();
            btnStop = new Button();
            btnSettings = new Button();
            gameTimer = new System.Windows.Forms.Timer(components);
            timer1 = new System.Windows.Forms.Timer(components);
            pnlIcon = new Panel();
            pbReStart = new PictureBox();
            lblDifficulty = new Label();
            lblMode = new Label();
            pnlDifficulty = new Panel();
            panel1 = new Panel();
            gamePanel.SuspendLayout();
            pnlInstructions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbOrange).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPineApple).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbWatermelon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGrapes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCherry).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBanana).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbApple).BeginInit();
            pnlGameOver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSplash).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbStop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPause).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSetttings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbExit).BeginInit();
            pnlIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbReStart).BeginInit();
            pnlDifficulty.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // gamePanel
            // 
            gamePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gamePanel.Controls.Add(pnlInstructions);
            gamePanel.Controls.Add(pnlGameOver);
            gamePanel.Controls.Add(lblPercent);
            gamePanel.Controls.Add(progressBarLoad);
            gamePanel.Controls.Add(pbSplash);
            gamePanel.Location = new Point(66, 84);
            gamePanel.Margin = new Padding(4, 3, 4, 3);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(1018, 515);
            gamePanel.TabIndex = 0;
            gamePanel.Paint += gamePanel_Paint;
            // 
            // pnlInstructions
            // 
            pnlInstructions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlInstructions.BackColor = Color.DarkSeaGreen;
            pnlInstructions.BorderStyle = BorderStyle.FixedSingle;
            pnlInstructions.Controls.Add(lblSettings);
            pnlInstructions.Controls.Add(lblStart);
            pnlInstructions.Controls.Add(pbOrange);
            pnlInstructions.Controls.Add(pbPineApple);
            pnlInstructions.Controls.Add(pbWatermelon);
            pnlInstructions.Controls.Add(pbGrapes);
            pnlInstructions.Controls.Add(pbCherry);
            pnlInstructions.Controls.Add(pbBanana);
            pnlInstructions.Controls.Add(pbApple);
            pnlInstructions.Controls.Add(lblFood);
            pnlInstructions.Controls.Add(lblRules);
            pnlInstructions.Controls.Add(lblMovement);
            pnlInstructions.Controls.Add(lblTitle);
            pnlInstructions.ForeColor = Color.DarkGreen;
            pnlInstructions.Location = new Point(255, 31);
            pnlInstructions.Name = "pnlInstructions";
            pnlInstructions.Size = new Size(480, 450);
            pnlInstructions.TabIndex = 4;
            // 
            // lblSettings
            // 
            lblSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSettings.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSettings.ForeColor = Color.DarkGreen;
            lblSettings.Location = new Point(27, 348);
            lblSettings.Name = "lblSettings";
            lblSettings.Size = new Size(439, 44);
            lblSettings.TabIndex = 12;
            lblSettings.Text = "Select difficulty: Easy / Medium / Hard\r\nChange colors via Settings\r\n\r\n";
            // 
            // lblStart
            // 
            lblStart.Dock = DockStyle.Bottom;
            lblStart.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStart.ForeColor = Color.DarkBlue;
            lblStart.Location = new Point(0, 412);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(478, 36);
            lblStart.TabIndex = 11;
            lblStart.Text = "Press any Arrow Key to start!\r\n";
            lblStart.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbOrange
            // 
            pbOrange.Image = Properties.Resources.orange;
            pbOrange.Location = new Point(293, 154);
            pbOrange.Name = "pbOrange";
            pbOrange.Size = new Size(45, 33);
            pbOrange.SizeMode = PictureBoxSizeMode.Zoom;
            pbOrange.TabIndex = 10;
            pbOrange.TabStop = false;
            // 
            // pbPineApple
            // 
            pbPineApple.Image = Properties.Resources.pineapple;
            pbPineApple.Location = new Point(245, 154);
            pbPineApple.Name = "pbPineApple";
            pbPineApple.Size = new Size(42, 33);
            pbPineApple.SizeMode = PictureBoxSizeMode.Zoom;
            pbPineApple.TabIndex = 9;
            pbPineApple.TabStop = false;
            // 
            // pbWatermelon
            // 
            pbWatermelon.Image = Properties.Resources.watermelon;
            pbWatermelon.Location = new Point(344, 154);
            pbWatermelon.Name = "pbWatermelon";
            pbWatermelon.Size = new Size(44, 33);
            pbWatermelon.SizeMode = PictureBoxSizeMode.Zoom;
            pbWatermelon.TabIndex = 8;
            pbWatermelon.TabStop = false;
            // 
            // pbGrapes
            // 
            pbGrapes.Image = Properties.Resources.purpleGrapes;
            pbGrapes.Location = new Point(202, 154);
            pbGrapes.Name = "pbGrapes";
            pbGrapes.Size = new Size(37, 33);
            pbGrapes.SizeMode = PictureBoxSizeMode.Zoom;
            pbGrapes.TabIndex = 7;
            pbGrapes.TabStop = false;
            // 
            // pbCherry
            // 
            pbCherry.Image = Properties.Resources.cherry;
            pbCherry.Location = new Point(170, 154);
            pbCherry.Name = "pbCherry";
            pbCherry.Size = new Size(26, 33);
            pbCherry.SizeMode = PictureBoxSizeMode.Zoom;
            pbCherry.TabIndex = 6;
            pbCherry.TabStop = false;
            // 
            // pbBanana
            // 
            pbBanana.BackColor = Color.Transparent;
            pbBanana.Image = Properties.Resources.bananaa;
            pbBanana.Location = new Point(135, 154);
            pbBanana.Name = "pbBanana";
            pbBanana.Size = new Size(29, 33);
            pbBanana.SizeMode = PictureBoxSizeMode.Zoom;
            pbBanana.TabIndex = 5;
            pbBanana.TabStop = false;
            // 
            // pbApple
            // 
            pbApple.BackColor = Color.Transparent;
            pbApple.Image = Properties.Resources.apple;
            pbApple.Location = new Point(94, 154);
            pbApple.Name = "pbApple";
            pbApple.Size = new Size(35, 33);
            pbApple.SizeMode = PictureBoxSizeMode.Zoom;
            pbApple.TabIndex = 4;
            pbApple.TabStop = false;
            // 
            // lblFood
            // 
            lblFood.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblFood.BackColor = Color.Transparent;
            lblFood.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFood.ForeColor = Color.DarkGreen;
            lblFood.Location = new Point(27, 210);
            lblFood.Name = "lblFood";
            lblFood.Size = new Size(459, 138);
            lblFood.TabIndex = 3;
            lblFood.Text = resources.GetString("lblFood.Text");
            // 
            // lblRules
            // 
            lblRules.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRules.ForeColor = Color.DarkRed;
            lblRules.Location = new Point(12, 116);
            lblRules.Name = "lblRules";
            lblRules.Size = new Size(346, 30);
            lblRules.TabIndex = 2;
            lblRules.Text = "⚠ Avoid walls and your own body!";
            lblRules.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMovement
            // 
            lblMovement.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMovement.Location = new Point(12, 77);
            lblMovement.Name = "lblMovement";
            lblMovement.Size = new Size(351, 30);
            lblMovement.TabIndex = 1;
            lblMovement.Text = "▶ Use Arrow Keys to move the snake.";
            lblMovement.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(0, 10, 0, 0);
            lblTitle.Size = new Size(478, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = " 🐍 Snake Game Instructions 🐍\r\n";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlGameOver
            // 
            pnlGameOver.BackColor = Color.FromArgb(200, 0, 0, 0);
            pnlGameOver.BorderStyle = BorderStyle.FixedSingle;
            pnlGameOver.Controls.Add(btnGameOverRestart);
            pnlGameOver.Controls.Add(lblGameOverTitle);
            pnlGameOver.Controls.Add(lblGameOverScore);
            pnlGameOver.Location = new Point(377, 267);
            pnlGameOver.Margin = new Padding(4, 3, 4, 3);
            pnlGameOver.Name = "pnlGameOver";
            pnlGameOver.Size = new Size(256, 161);
            pnlGameOver.TabIndex = 0;
            pnlGameOver.Visible = false;
            // 
            // btnGameOverRestart
            // 
            btnGameOverRestart.Dock = DockStyle.Bottom;
            btnGameOverRestart.Location = new Point(0, 132);
            btnGameOverRestart.Margin = new Padding(4, 3, 4, 3);
            btnGameOverRestart.Name = "btnGameOverRestart";
            btnGameOverRestart.Size = new Size(254, 27);
            btnGameOverRestart.TabIndex = 2;
            btnGameOverRestart.Text = "Restart";
            btnGameOverRestart.UseVisualStyleBackColor = true;
            btnGameOverRestart.Click += btnGameOverRestart_Click;
            // 
            // lblGameOverTitle
            // 
            lblGameOverTitle.Dock = DockStyle.Top;
            lblGameOverTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGameOverTitle.ForeColor = Color.White;
            lblGameOverTitle.Location = new Point(0, 0);
            lblGameOverTitle.Margin = new Padding(4, 0, 4, 0);
            lblGameOverTitle.Name = "lblGameOverTitle";
            lblGameOverTitle.Size = new Size(254, 46);
            lblGameOverTitle.TabIndex = 0;
            lblGameOverTitle.Text = "Game Over";
            lblGameOverTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGameOverScore
            // 
            lblGameOverScore.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblGameOverScore.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGameOverScore.ForeColor = Color.White;
            lblGameOverScore.Location = new Point(0, 0);
            lblGameOverScore.Margin = new Padding(4, 0, 4, 0);
            lblGameOverScore.Name = "lblGameOverScore";
            lblGameOverScore.Size = new Size(308, 218);
            lblGameOverScore.TabIndex = 1;
            lblGameOverScore.Text = "Score: 0";
            lblGameOverScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPercent
            // 
            lblPercent.AutoSize = true;
            lblPercent.BackColor = Color.Transparent;
            lblPercent.Dock = DockStyle.Bottom;
            lblPercent.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPercent.Location = new Point(0, 484);
            lblPercent.Margin = new Padding(4, 0, 4, 0);
            lblPercent.Name = "lblPercent";
            lblPercent.Size = new Size(33, 21);
            lblPercent.TabIndex = 2;
            lblPercent.Text = "0%";
            lblPercent.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressBarLoad
            // 
            progressBarLoad.Dock = DockStyle.Bottom;
            progressBarLoad.Location = new Point(0, 505);
            progressBarLoad.Margin = new Padding(4, 3, 4, 3);
            progressBarLoad.Name = "progressBarLoad";
            progressBarLoad.Size = new Size(1018, 10);
            progressBarLoad.TabIndex = 1;
            // 
            // pbSplash
            // 
            pbSplash.Dock = DockStyle.Fill;
            pbSplash.Image = Properties.Resources.snakeGreen;
            pbSplash.Location = new Point(0, 0);
            pbSplash.Margin = new Padding(4, 3, 4, 3);
            pbSplash.Name = "pbSplash";
            pbSplash.Size = new Size(1018, 515);
            pbSplash.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSplash.TabIndex = 0;
            pbSplash.TabStop = false;
            // 
            // pbStop
            // 
            pbStop.BackColor = Color.LightGreen;
            pbStop.Cursor = Cursors.Hand;
            pbStop.Image = Properties.Resources.stop_button;
            pbStop.Location = new Point(0, 210);
            pbStop.Margin = new Padding(10);
            pbStop.Name = "pbStop";
            pbStop.Size = new Size(40, 40);
            pbStop.SizeMode = PictureBoxSizeMode.Zoom;
            pbStop.TabIndex = 3;
            pbStop.TabStop = false;
            pbStop.Click += PbStop_Click;
            // 
            // pbPause
            // 
            pbPause.BackColor = Color.LightGreen;
            pbPause.Cursor = Cursors.Hand;
            pbPause.Image = Properties.Resources.pause;
            pbPause.Location = new Point(0, 155);
            pbPause.Margin = new Padding(10);
            pbPause.Name = "pbPause";
            pbPause.Size = new Size(40, 40);
            pbPause.SizeMode = PictureBoxSizeMode.Zoom;
            pbPause.TabIndex = 4;
            pbPause.TabStop = false;
            pbPause.Click += pbPause_Click;
            // 
            // pbSetttings
            // 
            pbSetttings.BackColor = Color.LightGreen;
            pbSetttings.Cursor = Cursors.Hand;
            pbSetttings.Image = Properties.Resources.setting;
            pbSetttings.Location = new Point(0, 263);
            pbSetttings.Margin = new Padding(10);
            pbSetttings.Name = "pbSetttings";
            pbSetttings.Size = new Size(40, 40);
            pbSetttings.SizeMode = PictureBoxSizeMode.Zoom;
            pbSetttings.TabIndex = 1;
            pbSetttings.TabStop = false;
            pbSetttings.Click += pbSetttings_Click;
            // 
            // pbStart
            // 
            pbStart.BackColor = Color.LightGreen;
            pbStart.Cursor = Cursors.Hand;
            pbStart.Image = Properties.Resources.play;
            pbStart.Location = new Point(0, 155);
            pbStart.Margin = new Padding(10);
            pbStart.Name = "pbStart";
            pbStart.Size = new Size(40, 40);
            pbStart.SizeMode = PictureBoxSizeMode.Zoom;
            pbStart.TabIndex = 0;
            pbStart.TabStop = false;
            pbStart.Click += pbStart_Click;
            // 
            // pbExit
            // 
            pbExit.BackColor = Color.LightGreen;
            pbExit.Cursor = Cursors.Hand;
            pbExit.Image = Properties.Resources.button;
            pbExit.Location = new Point(0, 314);
            pbExit.Margin = new Padding(10);
            pbExit.Name = "pbExit";
            pbExit.Size = new Size(40, 40);
            pbExit.SizeMode = PictureBoxSizeMode.Zoom;
            pbExit.TabIndex = 2;
            pbExit.TabStop = false;
            pbExit.Click += pbExit_Click;
            // 
            // lblHighScore
            // 
            lblHighScore.AutoSize = true;
            lblHighScore.BackColor = Color.Black;
            lblHighScore.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblHighScore.ForeColor = Color.WhiteSmoke;
            lblHighScore.Location = new Point(13, 50);
            lblHighScore.Margin = new Padding(4, 0, 4, 0);
            lblHighScore.Name = "lblHighScore";
            lblHighScore.Size = new Size(138, 28);
            lblHighScore.TabIndex = 7;
            lblHighScore.Text = "High Score: 0";
            // 
            // cmbMode
            // 
            cmbMode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMode.FlatStyle = FlatStyle.Popup;
            cmbMode.ForeColor = Color.SeaGreen;
            cmbMode.FormattingEnabled = true;
            cmbMode.Items.AddRange(new object[] { "Classic", "Hurdles" });
            cmbMode.Location = new Point(170, 9);
            cmbMode.Name = "cmbMode";
            cmbMode.Size = new Size(114, 23);
            cmbMode.TabIndex = 9;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Black;
            lblScore.Font = new Font("Segoe UI", 15F);
            lblScore.ForeColor = Color.White;
            lblScore.Location = new Point(13, 11);
            lblScore.Margin = new Padding(4, 0, 4, 0);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(81, 28);
            lblScore.TabIndex = 6;
            lblScore.Text = "Score: 0";
            // 
            // cmbDifficulty
            // 
            cmbDifficulty.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbDifficulty.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDifficulty.FlatStyle = FlatStyle.Popup;
            cmbDifficulty.ForeColor = Color.SeaGreen;
            cmbDifficulty.FormattingEnabled = true;
            cmbDifficulty.ItemHeight = 15;
            cmbDifficulty.Items.AddRange(new object[] { "Easy", "Medium", "Hard" });
            cmbDifficulty.Location = new Point(227, 9);
            cmbDifficulty.Margin = new Padding(10);
            cmbDifficulty.Name = "cmbDifficulty";
            cmbDifficulty.Size = new Size(128, 23);
            cmbDifficulty.TabIndex = 8;
            cmbDifficulty.PreviewKeyDown += cmbDifficulty_PreviewKeyDown;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Location = new Point(321, 9);
            btnExit.Margin = new Padding(4, 3, 4, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(95, 30);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStart.Location = new Point(762, 9);
            btnStart.Margin = new Padding(4, 3, 4, 3);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(95, 30);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnPause
            // 
            btnPause.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPause.Location = new Point(443, 9);
            btnPause.Margin = new Padding(4, 3, 4, 3);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(95, 30);
            btnPause.TabIndex = 2;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Visible = false;
            btnPause.Click += btnPause_Click;
            // 
            // btnStop
            // 
            btnStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStop.Location = new Point(659, 9);
            btnStop.Margin = new Padding(4, 3, 4, 3);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(95, 30);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSettings.Location = new Point(559, 9);
            btnSettings.Margin = new Padding(4, 3, 4, 3);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(95, 30);
            btnSettings.TabIndex = 5;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 200;
            gameTimer.Tick += gameTimer_Tick;
            // 
            // timer1
            // 
            timer1.Interval = 20;
            timer1.Tick += timer1_Tick;
            // 
            // pnlIcon
            // 
            pnlIcon.Controls.Add(pbReStart);
            pnlIcon.Controls.Add(pbStart);
            pnlIcon.Controls.Add(pbExit);
            pnlIcon.Controls.Add(pbStop);
            pnlIcon.Controls.Add(pbSetttings);
            pnlIcon.Controls.Add(pbPause);
            pnlIcon.Dock = DockStyle.Right;
            pnlIcon.Location = new Point(1108, 0);
            pnlIcon.Name = "pnlIcon";
            pnlIcon.Size = new Size(58, 633);
            pnlIcon.TabIndex = 10;
            // 
            // pbReStart
            // 
            pbReStart.BackColor = Color.LightGreen;
            pbReStart.Cursor = Cursors.Hand;
            pbReStart.Image = Properties.Resources.refresh;
            pbReStart.Location = new Point(0, 95);
            pbReStart.Margin = new Padding(10);
            pbReStart.Name = "pbReStart";
            pbReStart.Size = new Size(40, 40);
            pbReStart.SizeMode = PictureBoxSizeMode.Zoom;
            pbReStart.TabIndex = 5;
            pbReStart.TabStop = false;
            pbReStart.Click += pbReStart_Click;
            // 
            // lblDifficulty
            // 
            lblDifficulty.BackColor = Color.LightGreen;
            lblDifficulty.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDifficulty.ForeColor = Color.DarkGreen;
            lblDifficulty.Location = new Point(14, 6);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Padding = new Padding(4, 2, 4, 4);
            lblDifficulty.Size = new Size(194, 27);
            lblDifficulty.TabIndex = 11;
            lblDifficulty.Text = "Select Difficulty Level:\r\n";
            // 
            // lblMode
            // 
            lblMode.BackColor = Color.LightGreen;
            lblMode.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMode.ForeColor = Color.DarkGreen;
            lblMode.Location = new Point(3, 5);
            lblMode.Name = "lblMode";
            lblMode.Padding = new Padding(4, 2, 4, 2);
            lblMode.Size = new Size(146, 27);
            lblMode.TabIndex = 12;
            lblMode.Text = "Select Mode:\r\n";
            // 
            // pnlDifficulty
            // 
            pnlDifficulty.Controls.Add(lblDifficulty);
            pnlDifficulty.Controls.Add(cmbDifficulty);
            pnlDifficulty.Location = new Point(385, 38);
            pnlDifficulty.Name = "pnlDifficulty";
            pnlDifficulty.Size = new Size(370, 40);
            pnlDifficulty.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblMode);
            panel1.Controls.Add(cmbMode);
            panel1.Location = new Point(797, 38);
            panel1.Name = "panel1";
            panel1.Size = new Size(287, 40);
            panel1.TabIndex = 14;
            // 
            // frmSnake
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(1166, 633);
            Controls.Add(panel1);
            Controls.Add(pnlDifficulty);
            Controls.Add(pnlIcon);
            Controls.Add(btnSettings);
            Controls.Add(btnStop);
            Controls.Add(gamePanel);
            Controls.Add(btnStart);
            Controls.Add(btnPause);
            Controls.Add(btnExit);
            Controls.Add(lblHighScore);
            Controls.Add(lblScore);
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmSnake";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Snake Game - Assignment";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            gamePanel.ResumeLayout(false);
            gamePanel.PerformLayout();
            pnlInstructions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbOrange).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPineApple).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbWatermelon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGrapes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCherry).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBanana).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbApple).EndInit();
            pnlGameOver.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbSplash).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbStop).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPause).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSetttings).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbExit).EndInit();
            pnlIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbReStart).EndInit();
            pnlDifficulty.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void PbStop_Click(object sender, EventArgs e)
        {
          btnStop_Click(sender, e);
        }


        #endregion

        //  control fields
        internal System.Windows.Forms.Panel gamePanel;
        internal System.Windows.Forms.Panel pnlGameOver;
        internal System.Windows.Forms.Label lblGameOverTitle;
        internal System.Windows.Forms.Label lblGameOverScore;
        internal System.Windows.Forms.Button btnGameOverRestart;
        internal System.Windows.Forms.PictureBox pbSplash;
        internal System.Windows.Forms.ProgressBar progressBarLoad;
        internal System.Windows.Forms.Label lblPercent;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.Button btnPause;
        internal System.Windows.Forms.Button btnStop;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Button btnSettings;
        internal System.Windows.Forms.Label lblScore;
        internal System.Windows.Forms.Label lblHighScore;
        internal System.Windows.Forms.ComboBox cmbDifficulty;
        internal System.Windows.Forms.Timer gameTimer;
        internal System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.ComboBox cmbMode;
        private PictureBox pbPause;
        private PictureBox pbStop;
        private PictureBox pbExit;
        private PictureBox pbSetttings;
        private PictureBox pbStart;
        private Panel pnlIcon;
        private Panel pnlInstructions;
        private Label lblTitle;
        private Label lblMovement;
        private Label lblFood;
        private Label lblRules;
        private PictureBox pbBanana;
        private PictureBox pbApple;
        private PictureBox pbOrange;
        private PictureBox pbPineApple;
        private PictureBox pbWatermelon;
        private PictureBox pbGrapes;
        private PictureBox pbCherry;
        private Label lblStart;
        private Label lblSettings;
        private Label lblDifficulty;
        private Label lblMode;
        private Panel pnlDifficulty;
        private Panel panel1;
        private PictureBox pbReStart;
    }
}
