
namespace WindowsForms
{
    partial class FavouritePlayersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavouritePlayersForm));
            this.flpIgraci = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRangListPosjetitelja = new System.Windows.Forms.Button();
            this.btnRangListaIgraca = new System.Windows.Forms.Button();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.btnPostavke = new System.Windows.Forms.Button();
            this.flpNajdraziIgraci = new System.Windows.Forms.FlowLayoutPanel();
            this.pbIgraci = new System.Windows.Forms.ProgressBar();
            this.cmsPlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dodajUFavoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urediSlikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFavPlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ukloniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urediSlikuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPlayer.SuspendLayout();
            this.cmsFavPlayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpIgraci
            // 
            resources.ApplyResources(this.flpIgraci, "flpIgraci");
            this.flpIgraci.AllowDrop = true;
            this.flpIgraci.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpIgraci.Name = "flpIgraci";
            this.flpIgraci.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpSviIgraciDD);
            this.flpIgraci.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpSviIgraci_DragEnter);
            // 
            // btnRangListPosjetitelja
            // 
            resources.ApplyResources(this.btnRangListPosjetitelja, "btnRangListPosjetitelja");
            this.btnRangListPosjetitelja.Name = "btnRangListPosjetitelja";
            this.btnRangListPosjetitelja.UseVisualStyleBackColor = true;
            this.btnRangListPosjetitelja.Click += new System.EventHandler(this.btnRangListPosjetitelja_Click);
            // 
            // btnRangListaIgraca
            // 
            resources.ApplyResources(this.btnRangListaIgraca, "btnRangListaIgraca");
            this.btnRangListaIgraca.Name = "btnRangListaIgraca";
            this.btnRangListaIgraca.UseVisualStyleBackColor = true;
            this.btnRangListaIgraca.Click += new System.EventHandler(this.btnRangListaIgraca_Click);
            // 
            // btnSpremi
            // 
            resources.ApplyResources(this.btnSpremi, "btnSpremi");
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // btnPostavke
            // 
            resources.ApplyResources(this.btnPostavke, "btnPostavke");
            this.btnPostavke.Name = "btnPostavke";
            this.btnPostavke.UseVisualStyleBackColor = true;
            this.btnPostavke.Click += new System.EventHandler(this.btnPostavke_Click);
            // 
            // flpNajdraziIgraci
            // 
            resources.ApplyResources(this.flpNajdraziIgraci, "flpNajdraziIgraci");
            this.flpNajdraziIgraci.AllowDrop = true;
            this.flpNajdraziIgraci.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpNajdraziIgraci.Name = "flpNajdraziIgraci";
            this.flpNajdraziIgraci.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpNajdraziIgraciDD);
            this.flpNajdraziIgraci.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpNajdraziIgraci_DragEnter);
            // 
            // pbIgraci
            // 
            resources.ApplyResources(this.pbIgraci, "pbIgraci");
            this.pbIgraci.Name = "pbIgraci";
            this.pbIgraci.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // cmsPlayer
            // 
            resources.ApplyResources(this.cmsPlayer, "cmsPlayer");
            this.cmsPlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajUFavoriteToolStripMenuItem,
            this.urediSlikuToolStripMenuItem});
            this.cmsPlayer.Name = "cmsPlayer";
            this.cmsPlayer.Opened += new System.EventHandler(this.cmsPlayer_Opened);
            // 
            // dodajUFavoriteToolStripMenuItem
            // 
            resources.ApplyResources(this.dodajUFavoriteToolStripMenuItem, "dodajUFavoriteToolStripMenuItem");
            this.dodajUFavoriteToolStripMenuItem.Name = "dodajUFavoriteToolStripMenuItem";
            this.dodajUFavoriteToolStripMenuItem.Click += new System.EventHandler(this.dodajUFavorite_Clicked);
            // 
            // urediSlikuToolStripMenuItem
            // 
            resources.ApplyResources(this.urediSlikuToolStripMenuItem, "urediSlikuToolStripMenuItem");
            this.urediSlikuToolStripMenuItem.Name = "urediSlikuToolStripMenuItem";
            this.urediSlikuToolStripMenuItem.Click += new System.EventHandler(this.urediSliku_Clicked);
            // 
            // cmsFavPlayer
            // 
            resources.ApplyResources(this.cmsFavPlayer, "cmsFavPlayer");
            this.cmsFavPlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ukloniToolStripMenuItem,
            this.urediSlikuToolStripMenuItem1});
            this.cmsFavPlayer.Name = "cmsFavPlayer";
            this.cmsFavPlayer.Opened += new System.EventHandler(this.cmsFavPlayer_Opened);
            // 
            // ukloniToolStripMenuItem
            // 
            resources.ApplyResources(this.ukloniToolStripMenuItem, "ukloniToolStripMenuItem");
            this.ukloniToolStripMenuItem.Name = "ukloniToolStripMenuItem";
            this.ukloniToolStripMenuItem.Click += new System.EventHandler(this.ukloniIzFav_Clicked);
            // 
            // urediSlikuToolStripMenuItem1
            // 
            resources.ApplyResources(this.urediSlikuToolStripMenuItem1, "urediSlikuToolStripMenuItem1");
            this.urediSlikuToolStripMenuItem1.Name = "urediSlikuToolStripMenuItem1";
            this.urediSlikuToolStripMenuItem1.Click += new System.EventHandler(this.urediSliku_Clicked);
            // 
            // FavouritePlayersForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRangListPosjetitelja);
            this.Controls.Add(this.pbIgraci);
            this.Controls.Add(this.flpNajdraziIgraci);
            this.Controls.Add(this.btnPostavke);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.btnRangListaIgraca);
            this.Controls.Add(this.flpIgraci);
            this.Name = "FavouritePlayersForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FavouritePlayers_FormClosing);
            this.Load += new System.EventHandler(this.FavouritePlayersForm_Load);
            this.cmsPlayer.ResumeLayout(false);
            this.cmsFavPlayer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpIgraci;
        private System.Windows.Forms.Button btnRangListPosjetitelja;
        private System.Windows.Forms.Button btnRangListaIgraca;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.Button btnPostavke;
        private System.Windows.Forms.FlowLayoutPanel flpNajdraziIgraci;
        private System.Windows.Forms.ProgressBar pbIgraci;
        private System.Windows.Forms.ContextMenuStrip cmsPlayer;
        private System.Windows.Forms.ToolStripMenuItem dodajUFavoriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urediSlikuToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsFavPlayer;
        private System.Windows.Forms.ToolStripMenuItem ukloniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urediSlikuToolStripMenuItem1;
    }
}