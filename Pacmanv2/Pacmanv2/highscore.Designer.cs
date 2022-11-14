namespace Pacmanv2
{
    partial class highscore
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
            this.highscoreList = new System.Windows.Forms.ListView();
            this.number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scoreCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sortAlph = new System.Windows.Forms.Label();
            this.sortAlphRev = new System.Windows.Forms.Label();
            this.sortScore = new System.Windows.Forms.Label();
            this.sortScoreRev = new System.Windows.Forms.Label();
            this.sortTimeRev = new System.Windows.Forms.Label();
            this.sortTime = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // highscoreList
            // 
            this.highscoreList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.number,
            this.nameCol,
            this.scoreCol,
            this.timeCol});
            this.highscoreList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscoreList.FullRowSelect = true;
            this.highscoreList.GridLines = true;
            this.highscoreList.HideSelection = false;
            this.highscoreList.Location = new System.Drawing.Point(12, 30);
            this.highscoreList.Name = "highscoreList";
            this.highscoreList.Size = new System.Drawing.Size(257, 250);
            this.highscoreList.TabIndex = 0;
            this.highscoreList.UseCompatibleStateImageBehavior = false;
            this.highscoreList.View = System.Windows.Forms.View.Details;
            // 
            // number
            // 
            this.number.Text = "";
            // 
            // nameCol
            // 
            this.nameCol.Tag = "head";
            this.nameCol.Text = "Name";
            this.nameCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // scoreCol
            // 
            this.scoreCol.Tag = "head";
            this.scoreCol.Text = "Score";
            this.scoreCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timeCol
            // 
            this.timeCol.Tag = "head";
            this.timeCol.Text = "Time";
            this.timeCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sortAlph
            // 
            this.sortAlph.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.sortAlph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sortAlph.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortAlph.Location = new System.Drawing.Point(292, 30);
            this.sortAlph.Name = "sortAlph";
            this.sortAlph.Size = new System.Drawing.Size(170, 30);
            this.sortAlph.TabIndex = 6;
            this.sortAlph.Text = "Sort name A-Z";
            this.sortAlph.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sortAlph.Click += new System.EventHandler(this.sortAlph_Click);
            // 
            // sortAlphRev
            // 
            this.sortAlphRev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.sortAlphRev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sortAlphRev.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortAlphRev.Location = new System.Drawing.Point(468, 30);
            this.sortAlphRev.Name = "sortAlphRev";
            this.sortAlphRev.Size = new System.Drawing.Size(170, 30);
            this.sortAlphRev.TabIndex = 7;
            this.sortAlphRev.Text = "Sort Name Z - A";
            this.sortAlphRev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sortAlphRev.Click += new System.EventHandler(this.sortAlphRev_Click);
            // 
            // sortScore
            // 
            this.sortScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.sortScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sortScore.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortScore.Location = new System.Drawing.Point(292, 77);
            this.sortScore.Name = "sortScore";
            this.sortScore.Size = new System.Drawing.Size(170, 30);
            this.sortScore.TabIndex = 8;
            this.sortScore.Text = "Sort Score ";
            this.sortScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sortScore.Click += new System.EventHandler(this.sortScore_Click);
            // 
            // sortScoreRev
            // 
            this.sortScoreRev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.sortScoreRev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sortScoreRev.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortScoreRev.Location = new System.Drawing.Point(468, 77);
            this.sortScoreRev.Name = "sortScoreRev";
            this.sortScoreRev.Size = new System.Drawing.Size(170, 30);
            this.sortScoreRev.TabIndex = 9;
            this.sortScoreRev.Text = "Sort Score ";
            this.sortScoreRev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sortScoreRev.Click += new System.EventHandler(this.sortScoreRev_Click);
            // 
            // sortTimeRev
            // 
            this.sortTimeRev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.sortTimeRev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sortTimeRev.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortTimeRev.Location = new System.Drawing.Point(468, 124);
            this.sortTimeRev.Name = "sortTimeRev";
            this.sortTimeRev.Size = new System.Drawing.Size(170, 30);
            this.sortTimeRev.TabIndex = 10;
            this.sortTimeRev.Text = "Sort Time ";
            this.sortTimeRev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sortTimeRev.Click += new System.EventHandler(this.sortTimeRev_Click);
            // 
            // sortTime
            // 
            this.sortTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.sortTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sortTime.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortTime.Location = new System.Drawing.Point(292, 124);
            this.sortTime.Name = "sortTime";
            this.sortTime.Size = new System.Drawing.Size(170, 30);
            this.sortTime.TabIndex = 11;
            this.sortTime.Text = "Sort Time ";
            this.sortTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sortTime.Click += new System.EventHandler(this.sortTime_Click);
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.close.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.close.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Location = new System.Drawing.Point(438, 253);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(68, 30);
            this.close.TabIndex = 12;
            this.close.Text = "Close";
            this.close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // highscore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(659, 292);
            this.Controls.Add(this.close);
            this.Controls.Add(this.sortTime);
            this.Controls.Add(this.sortTimeRev);
            this.Controls.Add(this.sortScoreRev);
            this.Controls.Add(this.sortScore);
            this.Controls.Add(this.sortAlphRev);
            this.Controls.Add(this.sortAlph);
            this.Controls.Add(this.highscoreList);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "highscore";
            this.Text = "highscore";
            this.Load += new System.EventHandler(this.highscore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView highscoreList;
        private System.Windows.Forms.ColumnHeader number;
        private System.Windows.Forms.ColumnHeader nameCol;
        private System.Windows.Forms.ColumnHeader scoreCol;
        private System.Windows.Forms.ColumnHeader timeCol;
        private System.Windows.Forms.Label sortAlph;
        private System.Windows.Forms.Label sortAlphRev;
        private System.Windows.Forms.Label sortScore;
        private System.Windows.Forms.Label sortScoreRev;
        private System.Windows.Forms.Label sortTimeRev;
        private System.Windows.Forms.Label sortTime;
        private System.Windows.Forms.Label close;
    }
}