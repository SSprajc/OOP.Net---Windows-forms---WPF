namespace WindowsForms
{
    partial class InitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cbPrvenstvo = new System.Windows.Forms.ComboBox();
            this.cbJezik = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.cbIzvorPodataka = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbPrvenstvo
            // 
            resources.ApplyResources(this.cbPrvenstvo, "cbPrvenstvo");
            this.cbPrvenstvo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrvenstvo.FormattingEnabled = true;
            this.cbPrvenstvo.Items.AddRange(new object[] {
            resources.GetString("cbPrvenstvo.Items"),
            resources.GetString("cbPrvenstvo.Items1")});
            this.cbPrvenstvo.Name = "cbPrvenstvo";
            // 
            // cbJezik
            // 
            resources.ApplyResources(this.cbJezik, "cbJezik");
            this.cbJezik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJezik.FormattingEnabled = true;
            this.cbJezik.Items.AddRange(new object[] {
            resources.GetString("cbJezik.Items"),
            resources.GetString("cbJezik.Items1")});
            this.cbJezik.Name = "cbJezik";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cbIzvorPodataka
            // 
            resources.ApplyResources(this.cbIzvorPodataka, "cbIzvorPodataka");
            this.cbIzvorPodataka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIzvorPodataka.FormattingEnabled = true;
            this.cbIzvorPodataka.Items.AddRange(new object[] {
            resources.GetString("cbIzvorPodataka.Items"),
            resources.GetString("cbIzvorPodataka.Items1")});
            this.cbIzvorPodataka.Name = "cbIzvorPodataka";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // InitForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbIzvorPodataka);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbJezik);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbPrvenstvo);
            this.Controls.Add(this.label1);
            this.Name = "InitForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InitForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPrvenstvo;
        private System.Windows.Forms.ComboBox cbJezik;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cbIzvorPodataka;
        private System.Windows.Forms.Label label3;
    }
}