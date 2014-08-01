namespace Pustota.Maven.UI.Forms
{
	partial class ExternalReferenceManagerForm
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.buttonDeleteMavenExternal = new System.Windows.Forms.Button();
			this.buttonAddMavenExternal = new System.Windows.Forms.Button();
			this.dataGridViewMavenExternal = new System.Windows.Forms.DataGridView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewMavenExternal)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(721, 388);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.buttonDeleteMavenExternal);
			this.tabPage1.Controls.Add(this.buttonAddMavenExternal);
			this.tabPage1.Controls.Add(this.dataGridViewMavenExternal);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(713, 362);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "MavenExternal";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// buttonDeleteMavenExternal
			// 
			this.buttonDeleteMavenExternal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonDeleteMavenExternal.Location = new System.Drawing.Point(85, 336);
			this.buttonDeleteMavenExternal.Name = "buttonDeleteMavenExternal";
			this.buttonDeleteMavenExternal.Size = new System.Drawing.Size(75, 23);
			this.buttonDeleteMavenExternal.TabIndex = 2;
			this.buttonDeleteMavenExternal.Text = "Delete";
			this.buttonDeleteMavenExternal.UseVisualStyleBackColor = true;
			this.buttonDeleteMavenExternal.Click += new System.EventHandler(this.ButtonDeleteMavenExternalClick);
			// 
			// buttonAddMavenExternal
			// 
			this.buttonAddMavenExternal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonAddMavenExternal.Location = new System.Drawing.Point(4, 336);
			this.buttonAddMavenExternal.Name = "buttonAddMavenExternal";
			this.buttonAddMavenExternal.Size = new System.Drawing.Size(75, 23);
			this.buttonAddMavenExternal.TabIndex = 1;
			this.buttonAddMavenExternal.Text = "Add";
			this.buttonAddMavenExternal.UseVisualStyleBackColor = true;
			this.buttonAddMavenExternal.Click += new System.EventHandler(this.ButtonAddMavenExternalClick);
			// 
			// dataGridViewMavenExternal
			// 
			this.dataGridViewMavenExternal.AllowUserToAddRows = false;
			this.dataGridViewMavenExternal.AllowUserToDeleteRows = false;
			this.dataGridViewMavenExternal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewMavenExternal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewMavenExternal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewMavenExternal.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewMavenExternal.Name = "dataGridViewMavenExternal";
			this.dataGridViewMavenExternal.Size = new System.Drawing.Size(713, 330);
			this.dataGridViewMavenExternal.TabIndex = 0;
			this.dataGridViewMavenExternal.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DataGridViewMavenExternalRowPrePaint);
//			this.dataGridViewMavenExternal.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridViewMavenExternalRowValidating);
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(713, 362);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "PomIgnore";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// ExternalReferenceManagerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(721, 388);
			this.Controls.Add(this.tabControl1);
			this.Name = "ExternalReferenceManagerForm";
			this.Text = "ExternalReferencesManagerForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExternalReferenceManagerFormFormClosing);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewMavenExternal)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button buttonDeleteMavenExternal;
		private System.Windows.Forms.Button buttonAddMavenExternal;
		private System.Windows.Forms.DataGridView dataGridViewMavenExternal;
	}
}