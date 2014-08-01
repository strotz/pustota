namespace Pustota.Maven.Editor
{
	partial class PomAdvancedEditor
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
			this.textBoxArtifactID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxGroupID = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxVersion = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.checkBoxIsSnapshot = new System.Windows.Forms.CheckBox();
			this.tabControlCommon = new System.Windows.Forms.TabControl();
			this.tabPageProfilesCommon = new System.Windows.Forms.TabPage();
			this.tabCommon = new System.Windows.Forms.TabControl();
			this.tabPageAddNew = new System.Windows.Forms.TabPage();
			this.contextMenuStripTabs = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItemTabRename = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemTabRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControlCommon.SuspendLayout();
			this.tabPageProfilesCommon.SuspendLayout();
			this.contextMenuStripTabs.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxArtifactID
			// 
			this.textBoxArtifactID.Location = new System.Drawing.Point(66, 30);
			this.textBoxArtifactID.Name = "textBoxArtifactID";
			this.textBoxArtifactID.Size = new System.Drawing.Size(195, 20);
			this.textBoxArtifactID.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "ArtifactID";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "GroupID";
			// 
			// textBoxGroupID
			// 
			this.textBoxGroupID.Location = new System.Drawing.Point(66, 59);
			this.textBoxGroupID.Name = "textBoxGroupID";
			this.textBoxGroupID.Size = new System.Drawing.Size(195, 20);
			this.textBoxGroupID.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Version";
			// 
			// textBoxVersion
			// 
			this.textBoxVersion.Location = new System.Drawing.Point(66, 87);
			this.textBoxVersion.Name = "textBoxVersion";
			this.textBoxVersion.Size = new System.Drawing.Size(104, 20);
			this.textBoxVersion.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 123);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Name";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(66, 116);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(195, 20);
			this.textBoxName.TabIndex = 8;
			// 
			// checkBoxIsSnapshot
			// 
			this.checkBoxIsSnapshot.AutoSize = true;
			this.checkBoxIsSnapshot.Location = new System.Drawing.Point(176, 90);
			this.checkBoxIsSnapshot.Name = "checkBoxIsSnapshot";
			this.checkBoxIsSnapshot.Size = new System.Drawing.Size(85, 17);
			this.checkBoxIsSnapshot.TabIndex = 9;
			this.checkBoxIsSnapshot.Text = "SNAPSHOT";
			this.checkBoxIsSnapshot.UseVisualStyleBackColor = true;
			// 
			// tabControlCommon
			// 
			this.tabControlCommon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlCommon.Controls.Add(this.tabPageProfilesCommon);
			this.tabControlCommon.Controls.Add(this.tabPageAddNew);
			this.tabControlCommon.ItemSize = new System.Drawing.Size(50, 18);
			this.tabControlCommon.Location = new System.Drawing.Point(12, 176);
			this.tabControlCommon.Multiline = true;
			this.tabControlCommon.Name = "tabControlCommon";
			this.tabControlCommon.SelectedIndex = 0;
			this.tabControlCommon.Size = new System.Drawing.Size(1000, 401);
			this.tabControlCommon.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
			this.tabControlCommon.TabIndex = 11;
			this.tabControlCommon.SelectedIndexChanged += new System.EventHandler(this.TabControlCommonSelectedIndexChanged);
			this.tabControlCommon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TabControlCommonMouseClick);
			// 
			// tabPageProfilesCommon
			// 
			this.tabPageProfilesCommon.Controls.Add(this.tabCommon);
			this.tabPageProfilesCommon.Location = new System.Drawing.Point(4, 22);
			this.tabPageProfilesCommon.Name = "tabPageProfilesCommon";
			this.tabPageProfilesCommon.Size = new System.Drawing.Size(992, 375);
			this.tabPageProfilesCommon.TabIndex = 0;
			this.tabPageProfilesCommon.Text = "Common";
			this.tabPageProfilesCommon.UseVisualStyleBackColor = true;
			// 
			// tabCommon
			// 
			this.tabCommon.Alignment = System.Windows.Forms.TabAlignment.Left;
			this.tabCommon.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabCommon.Location = new System.Drawing.Point(0, 0);
			this.tabCommon.Multiline = true;
			this.tabCommon.Name = "tabCommon";
			this.tabCommon.SelectedIndex = 0;
			this.tabCommon.Size = new System.Drawing.Size(992, 375);
			this.tabCommon.TabIndex = 0;
			//this.tabCommon.SelectedIndexChanged += new System.EventHandler(this.TabSelectedIndexChanged);
			//this.tabCommon.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabCommon_Selected);
			// 
			// tabPageAddNew
			// 
			this.tabPageAddNew.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tabPageAddNew.Location = new System.Drawing.Point(4, 22);
			this.tabPageAddNew.Name = "tabPageAddNew";
			this.tabPageAddNew.Size = new System.Drawing.Size(992, 375);
			this.tabPageAddNew.TabIndex = 1;
			this.tabPageAddNew.Text = "+";
			this.tabPageAddNew.UseVisualStyleBackColor = true;
			// 
			// contextMenuStripTabs
			// 
			this.contextMenuStripTabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.toolStripMenuItemTabRename,
				this.toolStripMenuItemTabRemove});
			this.contextMenuStripTabs.Name = "contextMenuStripTabs";
			this.contextMenuStripTabs.Size = new System.Drawing.Size(118, 48);
			// 
			// toolStripMenuItemTabRename
			// 
			this.toolStripMenuItemTabRename.Name = "toolStripMenuItemTabRename";
			this.toolStripMenuItemTabRename.Size = new System.Drawing.Size(117, 22);
			this.toolStripMenuItemTabRename.Text = "Rename";
			this.toolStripMenuItemTabRename.Click += new System.EventHandler(this.ToolStripMenuItemTabRenameClick);
			// 
			// toolStripMenuItemTabRemove
			// 
			this.toolStripMenuItemTabRemove.Name = "toolStripMenuItemTabRemove";
			this.toolStripMenuItemTabRemove.Size = new System.Drawing.Size(117, 22);
			this.toolStripMenuItemTabRemove.Text = "Remove";
			this.toolStripMenuItemTabRemove.Click += new System.EventHandler(this.ToolStripMenuItemTabRemoveClick);
			// 
			// PomAdvancedEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 589);
			this.Controls.Add(this.tabControlCommon);
			this.Controls.Add(this.checkBoxIsSnapshot);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBoxVersion);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxGroupID);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxArtifactID);
			this.Name = "PomAdvancedEditor";
			this.Text = "PomAdvancedEditor";
			this.tabControlCommon.ResumeLayout(false);
			this.tabPageProfilesCommon.ResumeLayout(false);
			this.contextMenuStripTabs.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxArtifactID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxGroupID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxVersion;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.CheckBox checkBoxIsSnapshot;
		private System.Windows.Forms.TabControl tabControlCommon;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripTabs;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTabRename;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTabRemove;
		private System.Windows.Forms.TabPage tabPageAddNew;
		private System.Windows.Forms.TabPage tabPageProfilesCommon;
		private System.Windows.Forms.TabControl tabCommon;
	}
}