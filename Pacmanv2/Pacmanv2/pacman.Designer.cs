
namespace Pacmanv2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BoardImage = new System.Windows.Forms.PictureBox();
            this.Lives = new System.Windows.Forms.ImageList(this.components);
            this.scoreText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pacman = new System.Windows.Forms.ImageList(this.components);
            this.pacmanImage = new System.Windows.Forms.PictureBox();
            this.pacmanTimer = new System.Windows.Forms.Timer(this.components);
            this.ghostImages = new System.Windows.Forms.ImageList(this.components);
            this.ghostTimer = new System.Windows.Forms.Timer(this.components);
            this.scaredTimer = new System.Windows.Forms.Timer(this.components);
            this.stateTimer = new System.Windows.Forms.Timer(this.components);
            this.homeTimer = new System.Windows.Forms.Timer(this.components);
            this.scaredGhost = new System.Windows.Forms.ImageList(this.components);
            this.turningTimer = new System.Windows.Forms.Timer(this.components);
            this.time = new System.Windows.Forms.Label();
            this.clock = new System.Windows.Forms.Timer(this.components);
            this.helpBtn = new System.Windows.Forms.Label();
            this.highscoreBtn = new System.Windows.Forms.Label();
            this.fruitTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BoardImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pacmanImage)).BeginInit();
            this.SuspendLayout();
            // 
            // BoardImage
            // 
            this.BoardImage.Image = global::Pacmanv2.Properties.Resources.Board_1;
            this.BoardImage.Location = new System.Drawing.Point(0, 50);
            this.BoardImage.Name = "BoardImage";
            this.BoardImage.Size = new System.Drawing.Size(448, 497);
            this.BoardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BoardImage.TabIndex = 0;
            this.BoardImage.TabStop = false;
            // 
            // Lives
            // 
            this.Lives.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.Lives.ImageSize = new System.Drawing.Size(16, 16);
            this.Lives.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // scoreText
            // 
            this.scoreText.ForeColor = System.Drawing.Color.White;
            this.scoreText.Location = new System.Drawing.Point(138, 23);
            this.scoreText.Name = "scoreText";
            this.scoreText.Size = new System.Drawing.Size(100, 20);
            this.scoreText.TabIndex = 2;
            this.scoreText.Text = "0";
            this.scoreText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(138, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Score";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pacman
            // 
            this.pacman.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.pacman.ImageSize = new System.Drawing.Size(27, 28);
            this.pacman.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pacmanImage
            // 
            this.pacmanImage.Image = global::Pacmanv2.Properties.Resources.pacmanClosed;
            this.pacmanImage.Location = new System.Drawing.Point(211, 413);
            this.pacmanImage.Name = "pacmanImage";
            this.pacmanImage.Size = new System.Drawing.Size(27, 28);
            this.pacmanImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pacmanImage.TabIndex = 3;
            this.pacmanImage.TabStop = false;
            // 
            // pacmanTimer
            // 
            this.pacmanTimer.Enabled = true;
            this.pacmanTimer.Interval = 150;
            this.pacmanTimer.Tick += new System.EventHandler(this.pacmanTimer_Tick);
            // 
            // ghostImages
            // 
            this.ghostImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ghostImages.ImageSize = new System.Drawing.Size(16, 16);
            this.ghostImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ghostTimer
            // 
            this.ghostTimer.Interval = 150;
            this.ghostTimer.Tick += new System.EventHandler(this.ghostTimer_Tick);
            // 
            // scaredTimer
            // 
            this.scaredTimer.Interval = 200;
            this.scaredTimer.Tick += new System.EventHandler(this.scaredTimer_Tick);
            // 
            // stateTimer
            // 
            this.stateTimer.Interval = 5000;
            this.stateTimer.Tick += new System.EventHandler(this.stateTimer_Tick);
            // 
            // homeTimer
            // 
            this.homeTimer.Interval = 5;
            this.homeTimer.Tick += new System.EventHandler(this.homeTimer_Tick);
            // 
            // scaredGhost
            // 
            this.scaredGhost.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.scaredGhost.ImageSize = new System.Drawing.Size(16, 16);
            this.scaredGhost.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // turningTimer
            // 
            this.turningTimer.Interval = 2000;
            this.turningTimer.Tick += new System.EventHandler(this.turningTimer_Tick);
            // 
            // time
            // 
            this.time.ForeColor = System.Drawing.Color.White;
            this.time.Location = new System.Drawing.Point(246, 23);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(191, 20);
            this.time.TabIndex = 2;
            this.time.Text = "Time: 00:00";
            this.time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clock
            // 
            this.clock.Interval = 1000;
            this.clock.Tick += new System.EventHandler(this.clock_Tick);
            // 
            // helpBtn
            // 
            this.helpBtn.AutoSize = true;
            this.helpBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.helpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpBtn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpBtn.Location = new System.Drawing.Point(13, 9);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(31, 13);
            this.helpBtn.TabIndex = 4;
            this.helpBtn.Tag = "menu";
            this.helpBtn.Text = "help";
            this.helpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // highscoreBtn
            // 
            this.highscoreBtn.AutoSize = true;
            this.highscoreBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.highscoreBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscoreBtn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.highscoreBtn.Location = new System.Drawing.Point(13, 30);
            this.highscoreBtn.Name = "highscoreBtn";
            this.highscoreBtn.Size = new System.Drawing.Size(62, 13);
            this.highscoreBtn.TabIndex = 4;
            this.highscoreBtn.Tag = "menu";
            this.highscoreBtn.Text = "highscore";
            this.highscoreBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.highscoreBtn.Click += new System.EventHandler(this.highscoreBtn_Click);
            // 
            // fruitTimer
            // 
            this.fruitTimer.Interval = 5000;
            this.fruitTimer.Tick += new System.EventHandler(this.fruitTimer_Tick);
            // 
            // From1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(449, 581);
            this.Controls.Add(this.highscoreBtn);
            this.Controls.Add(this.helpBtn);
            this.Controls.Add(this.pacmanImage);
            this.Controls.Add(this.time);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.scoreText);
            this.Controls.Add(this.BoardImage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "From1";
            this.Text = "Pacman";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.BoardImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pacmanImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BoardImage;
        private System.Windows.Forms.ImageList Lives;
        private System.Windows.Forms.Label scoreText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList pacman;
        private System.Windows.Forms.PictureBox pacmanImage;
        private System.Windows.Forms.Timer pacmanTimer;
        private System.Windows.Forms.ImageList ghostImages;
        private System.Windows.Forms.Timer ghostTimer;
        private System.Windows.Forms.Timer scaredTimer;
        private System.Windows.Forms.Timer stateTimer;
        private System.Windows.Forms.Timer homeTimer;
        private System.Windows.Forms.ImageList scaredGhost;
        private System.Windows.Forms.Timer turningTimer;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Timer clock;
        private System.Windows.Forms.Label helpBtn;
        private System.Windows.Forms.Label highscoreBtn;
        private System.Windows.Forms.Timer fruitTimer;
    }
}

