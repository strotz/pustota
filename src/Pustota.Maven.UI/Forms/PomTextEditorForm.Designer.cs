namespace Pustota.Maven.UI.Forms
{
	partial class PomTextEditorForm
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
			this.PomEditorTextBox = new System.Windows.Forms.RichTextBox();
			this._pomTextEditorMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._pomTextEditorStatusStrip = new System.Windows.Forms.StatusStrip();
			this._projectToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.pomTextEditorToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this._pomTextEditorMenuStrip.SuspendLayout();
			this._pomTextEditorStatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// PomEditorTextBox
			// 
			this.PomEditorTextBox.AcceptsTab = true;
			this.PomEditorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.PomEditorTextBox.AutoWordSelection = true;
			this.PomEditorTextBox.BulletIndent = 4;
			this.PomEditorTextBox.DetectUrls = false;
			this.PomEditorTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PomEditorTextBox.Location = new System.Drawing.Point(0, 27);
			this.PomEditorTextBox.Name = "PomEditorTextBox";
			this.PomEditorTextBox.Size = new System.Drawing.Size(879, 384);
			this.PomEditorTextBox.TabIndex = 0;
			this.PomEditorTextBox.Text = "";
			this.PomEditorTextBox.TextChanged += new System.EventHandler(this.PomEditorTextBoxTextChanged);
			// 
			// _pomTextEditorMenuStrip
			// 
			this._pomTextEditorMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.fileToolStripMenuItem});
			this._pomTextEditorMenuStrip.Location = new System.Drawing.Point(0, 0);
			this._pomTextEditorMenuStrip.Name = "_pomTextEditorMenuStrip";
			this._pomTextEditorMenuStrip.Size = new System.Drawing.Size(879, 24);
			this._pomTextEditorMenuStrip.TabIndex = 1;
			this._pomTextEditorMenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.saveToolStripMenuItem,
				this.reloadToolStripMenuItem,
				this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.saveToolStripMenuItem.Text = "Apply Changes";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// reloadToolStripMenuItem
			// 
			this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
			this.reloadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.reloadToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.reloadToolStripMenuItem.Text = "Reload";
			this.reloadToolStripMenuItem.Click += new System.EventHandler(this.ReloadToolStripMenuItemClick);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItemClick);
			// 
			// _pomTextEditorStatusStrip
			// 
			this._pomTextEditorStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this._projectToolStripStatusLabel,
				this.pomTextEditorToolStripStatusLabel});
			this._pomTextEditorStatusStrip.Location = new System.Drawing.Point(0, 414);
			this._pomTextEditorStatusStrip.Name = "_pomTextEditorStatusStrip";
			this._pomTextEditorStatusStrip.Size = new System.Drawing.Size(879, 22);
			this._pomTextEditorStatusStrip.TabIndex = 2;
			this._pomTextEditorStatusStrip.Text = "statusStrip1";
			// 
			// _projectToolStripStatusLabel
			// 
			this._projectToolStripStatusLabel.Name = "_projectToolStripStatusLabel";
			this._projectToolStripStatusLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this._projectToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
			this._projectToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pomTextEditorToolStripStatusLabel
			// 
			this.pomTextEditorToolStripStatusLabel.Name = "pomTextEditorToolStripStatusLabel";
			this.pomTextEditorToolStripStatusLabel.Size = new System.Drawing.Size(118, 17);
			this.pomTextEditorToolStripStatusLabel.Text = "toolStripStatusLabel1";
			// 
			// PomTextEditorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(879, 436);
			this.Controls.Add(this._pomTextEditorStatusStrip);
			this.Controls.Add(this.PomEditorTextBox);
			this.Controls.Add(this._pomTextEditorMenuStrip);
			this.MainMenuStrip = this._pomTextEditorMenuStrip;
			this.Name = "PomTextEditorForm";
			this.Text = "PomTextEditor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PomTextEditorFormFormClosing);
			this._pomTextEditorMenuStrip.ResumeLayout(false);
			this._pomTextEditorMenuStrip.PerformLayout();
			this._pomTextEditorStatusStrip.ResumeLayout(false);
			this._pomTextEditorStatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox PomEditorTextBox;
		private System.Windows.Forms.MenuStrip _pomTextEditorMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.StatusStrip _pomTextEditorStatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel _projectToolStripStatusLabel;
		private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel pomTextEditorToolStripStatusLabel;
	}
}