
namespace WindowsForms
{
    partial class FavouriteTeamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavouriteTeamForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cbTim = new System.Windows.Forms.ComboBox();
            this.btnNastavi = new System.Windows.Forms.Button();
            this.pbTim = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbTim
            // 
            resources.ApplyResources(this.cbTim, "cbTim");
            this.cbTim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTim.FormattingEnabled = true;
            this.cbTim.Name = "cbTim";
            // 
            // btnNastavi
            // 
            resources.ApplyResources(this.btnNastavi, "btnNastavi");
            this.btnNastavi.Name = "btnNastavi";
            this.btnNastavi.UseVisualStyleBackColor = true;
            this.btnNastavi.Click += new System.EventHandler(this.btnNastavi_Click);
            // 
            // pbTim
            // 
            resources.ApplyResources(this.pbTim, "pbTim");
            this.pbTim.Name = "pbTim";
            // 
            // FavouriteTeamForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbTim);
            this.Controls.Add(this.btnNastavi);
            this.Controls.Add(this.cbTim);
            this.Controls.Add(this.label1);
            this.Name = "FavouriteTeamForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FavTeam_FormClosing);
            this.Load += new System.EventHandler(this.FavouriteTeamForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTim;
        private System.Windows.Forms.Button btnNastavi;
        private System.Windows.Forms.ProgressBar pbTim;
    }
}