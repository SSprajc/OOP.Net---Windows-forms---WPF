namespace WindowsForms.UserControls
{
    partial class PlayerStatsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerStatsControl));
            this.pbPlayerPicture = new System.Windows.Forms.PictureBox();
            this.lblIme = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGolovi = new System.Windows.Forms.Label();
            this.lblZutiKartoni = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPojavljivanja = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPlayerPicture
            // 
            resources.ApplyResources(this.pbPlayerPicture, "pbPlayerPicture");
            this.pbPlayerPicture.Name = "pbPlayerPicture";
            this.pbPlayerPicture.TabStop = false;
            // 
            // lblIme
            // 
            resources.ApplyResources(this.lblIme, "lblIme");
            this.lblIme.Name = "lblIme";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblGolovi
            // 
            resources.ApplyResources(this.lblGolovi, "lblGolovi");
            this.lblGolovi.Name = "lblGolovi";
            // 
            // lblZutiKartoni
            // 
            resources.ApplyResources(this.lblZutiKartoni, "lblZutiKartoni");
            this.lblZutiKartoni.Name = "lblZutiKartoni";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // lblPojavljivanja
            // 
            resources.ApplyResources(this.lblPojavljivanja, "lblPojavljivanja");
            this.lblPojavljivanja.Name = "lblPojavljivanja";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // PlayerStatsControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblPojavljivanja);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblZutiKartoni);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblGolovi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.pbPlayerPicture);
            this.Name = "PlayerStatsControl";
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlayerPicture;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGolovi;
        private System.Windows.Forms.Label lblZutiKartoni;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPojavljivanja;
        private System.Windows.Forms.Label label7;
    }
}
