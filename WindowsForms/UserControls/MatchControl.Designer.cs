namespace WindowsForms.UserControls
{
    partial class MatchControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHome = new System.Windows.Forms.Label();
            this.lblHomeGoals = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAwayGoals = new System.Windows.Forms.Label();
            this.lblAway = new System.Windows.Forms.Label();
            this.lblStadium = new System.Windows.Forms.Label();
            this.lblVisitors = new System.Windows.Forms.Label();
            this.lblStage = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHome
            // 
            this.lblHome.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHome.AutoSize = true;
            this.lblHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHome.Location = new System.Drawing.Point(89, 22);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(74, 24);
            this.lblHome.TabIndex = 0;
            this.lblHome.Text = "Domaći";
            // 
            // lblHomeGoals
            // 
            this.lblHomeGoals.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHomeGoals.AutoSize = true;
            this.lblHomeGoals.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomeGoals.Location = new System.Drawing.Point(169, 22);
            this.lblHomeGoals.Name = "lblHomeGoals";
            this.lblHomeGoals.Size = new System.Drawing.Size(21, 24);
            this.lblHomeGoals.TabIndex = 2;
            this.lblHomeGoals.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(186, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = ":";
            // 
            // lblAwayGoals
            // 
            this.lblAwayGoals.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAwayGoals.AutoSize = true;
            this.lblAwayGoals.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAwayGoals.Location = new System.Drawing.Point(196, 22);
            this.lblAwayGoals.Name = "lblAwayGoals";
            this.lblAwayGoals.Size = new System.Drawing.Size(21, 24);
            this.lblAwayGoals.TabIndex = 4;
            this.lblAwayGoals.Text = "0";
            // 
            // lblAway
            // 
            this.lblAway.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAway.AutoSize = true;
            this.lblAway.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAway.Location = new System.Drawing.Point(223, 22);
            this.lblAway.Name = "lblAway";
            this.lblAway.Size = new System.Drawing.Size(52, 24);
            this.lblAway.TabIndex = 5;
            this.lblAway.Text = "Gosti";
            // 
            // lblStadium
            // 
            this.lblStadium.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblStadium.AutoSize = true;
            this.lblStadium.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStadium.Location = new System.Drawing.Point(252, 128);
            this.lblStadium.Name = "lblStadium";
            this.lblStadium.Size = new System.Drawing.Size(53, 16);
            this.lblStadium.TabIndex = 6;
            this.lblStadium.Text = "Stadion";
            // 
            // lblVisitors
            // 
            this.lblVisitors.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVisitors.AutoSize = true;
            this.lblVisitors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisitors.Location = new System.Drawing.Point(34, 79);
            this.lblVisitors.Name = "lblVisitors";
            this.lblVisitors.Size = new System.Drawing.Size(31, 16);
            this.lblVisitors.TabIndex = 7;
            this.lblVisitors.Text = "Broj";
            // 
            // lblStage
            // 
            this.lblStage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblStage.AutoSize = true;
            this.lblStage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStage.Location = new System.Drawing.Point(252, 79);
            this.lblStage.Name = "lblStage";
            this.lblStage.Size = new System.Drawing.Size(37, 16);
            this.lblStage.TabIndex = 8;
            this.lblStage.Text = "Faza";
            // 
            // lblLocation
            // 
            this.lblLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(34, 128);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(58, 16);
            this.lblLocation.TabIndex = 9;
            this.lblLocation.Text = "Lokacija";
            // 
            // MatchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblStage);
            this.Controls.Add(this.lblVisitors);
            this.Controls.Add(this.lblStadium);
            this.Controls.Add(this.lblAway);
            this.Controls.Add(this.lblAwayGoals);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblHomeGoals);
            this.Controls.Add(this.lblHome);
            this.Name = "MatchControl";
            this.Size = new System.Drawing.Size(383, 163);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Label lblHomeGoals;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAwayGoals;
        private System.Windows.Forms.Label lblAway;
        private System.Windows.Forms.Label lblStadium;
        private System.Windows.Forms.Label lblVisitors;
        private System.Windows.Forms.Label lblStage;
        private System.Windows.Forms.Label lblLocation;
    }
}
