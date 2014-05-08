namespace Pustota.Maven.Editor
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this._treePoms = new System.Windows.Forms.TreeView();
			this.projectImages = new System.Windows.Forms.ImageList(this.components);
			this.ProjectContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editAsTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.advancedEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this._lStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this._pomPropertiesEditor = new System.Windows.Forms.PropertyGrid();
			this._horizSplit = new System.Windows.Forms.SplitContainer();
			this._verticalSplit = new System.Windows.Forms.SplitContainer();
			this._listPoms = new System.Windows.Forms.ListView();
			this.GroupColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ArtifactColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.VersionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._projectPanel = new System.Windows.Forms.Panel();
			this._cbSnapshot = new System.Windows.Forms.CheckBox();
			this._errorsList = new System.Windows.Forms.ListView();
			this.ImageColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.NumberColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.MessageColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DetailsColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Project = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.FullPathColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._errorsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.errorImages = new System.Windows.Forms.ImageList(this.components);
			this._mainMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openProjectFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._miOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
			this._miReload = new System.Windows.Forms.ToolStripMenuItem();
			this._miSaveProject = new System.Windows.Forms.ToolStripMenuItem();
			this._miSaveTree = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._miTreeMode = new System.Windows.Forms.ToolStripMenuItem();
			this._miListMode = new System.Windows.Forms.ToolStripMenuItem();
			this._miShowErrors = new System.Windows.Forms.ToolStripMenuItem();
			this._miMultiselect = new System.Windows.Forms.ToolStripMenuItem();
			this._miEnableMultiselect = new System.Windows.Forms.ToolStripMenuItem();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectDependenciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectDirectDependenciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectSubtreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectPluginUsagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._miSnapshotIcons = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._miValidate = new System.Windows.Forms.ToolStripMenuItem();
			this._miPropagateToDependencies = new System.Windows.Forms.ToolStripMenuItem();
			this._miPropagateToSubtree = new System.Windows.Forms.ToolStripMenuItem();
			this._miVersionOperations = new System.Windows.Forms.ToolStripMenuItem();
			this.addSNAPSHOTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeSNAPSHOTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.setVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.propagateVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.externalReferencesManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cascadeSwitchToSnapshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.releaseAllSnapshotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ProjectContextMenuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._horizSplit)).BeginInit();
			this._horizSplit.Panel1.SuspendLayout();
			this._horizSplit.Panel2.SuspendLayout();
			this._horizSplit.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._verticalSplit)).BeginInit();
			this._verticalSplit.Panel1.SuspendLayout();
			this._verticalSplit.Panel2.SuspendLayout();
			this._verticalSplit.SuspendLayout();
			this._projectPanel.SuspendLayout();
			this._mainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// _treePoms
			// 
			this._treePoms.Dock = System.Windows.Forms.DockStyle.Fill;
			this._treePoms.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
			this._treePoms.FullRowSelect = true;
			this._treePoms.HideSelection = false;
			this._treePoms.HotTracking = true;
			this._treePoms.ImageKey = "None";
			this._treePoms.ImageList = this.projectImages;
			this._treePoms.Location = new System.Drawing.Point(0, 0);
			this._treePoms.Name = "_treePoms";
			this._treePoms.SelectedImageIndex = 0;
			this._treePoms.ShowNodeToolTips = true;
			this._treePoms.Size = new System.Drawing.Size(572, 415);
			this._treePoms.TabIndex = 0;
			this._treePoms.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeItemChecked);
			this._treePoms.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.DrawTreeNode);
			this._treePoms.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AfterProjectSelectInTree);
			this._treePoms.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreePomsNodeMouseClick);
			this._treePoms.DoubleClick += new System.EventHandler(this.TreeDoubleClick);
			// 
			// projectImages
			// 
			this.projectImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("projectImages.ImageStream")));
			this.projectImages.TransparentColor = System.Drawing.Color.Transparent;
			this.projectImages.Images.SetKeyName(0, "Group");
			this.projectImages.Images.SetKeyName(1, "CsProj");
			this.projectImages.Images.SetKeyName(2, "WixProj");
			this.projectImages.Images.SetKeyName(3, "CppProj");
			this.projectImages.Images.SetKeyName(4, "PassoloProj");
			this.projectImages.Images.SetKeyName(5, "None");
			this.projectImages.Images.SetKeyName(6, "release");
			this.projectImages.Images.SetKeyName(7, "snapshot");
			this.projectImages.Images.SetKeyName(8, "CsPublic");
			this.projectImages.Images.SetKeyName(9, "CsTestProject");
			this.projectImages.Images.SetKeyName(10, "CSBuild");
			this.projectImages.Images.SetKeyName(11, "Binary");
			this.projectImages.Images.SetKeyName(12, "VcTest");
			this.projectImages.Images.SetKeyName(13, "MavenPlugins");
			this.projectImages.Images.SetKeyName(14, "Root");
			this.projectImages.Images.SetKeyName(15, "MiceTest");
			this.projectImages.Images.SetKeyName(16, "SuperPom");
			this.projectImages.Images.SetKeyName(17, "CsAssembly");
			// 
			// ProjectContextMenuStrip
			// 
			this.ProjectContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editAsTextToolStripMenuItem,
            this.advancedEditorToolStripMenuItem});
			this.ProjectContextMenuStrip.Name = "ProjectContextMenuStrip";
			this.ProjectContextMenuStrip.ShowImageMargin = false;
			this.ProjectContextMenuStrip.Size = new System.Drawing.Size(137, 48);
			this.ProjectContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ProjectTreeMenuOpening);
			// 
			// editAsTextToolStripMenuItem
			// 
			this.editAsTextToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.editAsTextToolStripMenuItem.Name = "editAsTextToolStripMenuItem";
			this.editAsTextToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.editAsTextToolStripMenuItem.Text = "Edit as text";
			this.editAsTextToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.editAsTextToolStripMenuItem.Click += new System.EventHandler(this.EditAsTextToolStripMenuItemClick);
			// 
			// advancedEditorToolStripMenuItem
			// 
			this.advancedEditorToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.advancedEditorToolStripMenuItem.Name = "advancedEditorToolStripMenuItem";
			this.advancedEditorToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.advancedEditorToolStripMenuItem.Text = "Advanced editor";
			this.advancedEditorToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.advancedEditorToolStripMenuItem.Click += new System.EventHandler(this.AdvancedEditorToolStripMenuItemClick);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lStatus});
			this.statusStrip.Location = new System.Drawing.Point(0, 615);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(1205, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// _lStatus
			// 
			this._lStatus.Name = "_lStatus";
			this._lStatus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this._lStatus.Size = new System.Drawing.Size(1190, 17);
			this._lStatus.Spring = true;
			this._lStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _pomPropertiesEditor
			// 
			this._pomPropertiesEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._pomPropertiesEditor.HelpVisible = false;
			this._pomPropertiesEditor.Location = new System.Drawing.Point(0, 0);
			this._pomPropertiesEditor.Name = "_pomPropertiesEditor";
			this._pomPropertiesEditor.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
			this._pomPropertiesEditor.Size = new System.Drawing.Size(621, 338);
			this._pomPropertiesEditor.TabIndex = 3;
			this._pomPropertiesEditor.ToolbarVisible = false;
			this._pomPropertiesEditor.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PropertyValueChanged);
			// 
			// _horizSplit
			// 
			this._horizSplit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._horizSplit.Dock = System.Windows.Forms.DockStyle.Fill;
			this._horizSplit.Location = new System.Drawing.Point(0, 24);
			this._horizSplit.Name = "_horizSplit";
			this._horizSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// _horizSplit.Panel1
			// 
			this._horizSplit.Panel1.Controls.Add(this._verticalSplit);
			// 
			// _horizSplit.Panel2
			// 
			this._horizSplit.Panel2.Controls.Add(this._errorsList);
			this._horizSplit.Size = new System.Drawing.Size(1205, 591);
			this._horizSplit.SplitterDistance = 419;
			this._horizSplit.TabIndex = 4;
			// 
			// _verticalSplit
			// 
			this._verticalSplit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._verticalSplit.Dock = System.Windows.Forms.DockStyle.Fill;
			this._verticalSplit.Location = new System.Drawing.Point(0, 0);
			this._verticalSplit.Name = "_verticalSplit";
			// 
			// _verticalSplit.Panel1
			// 
			this._verticalSplit.Panel1.Controls.Add(this._treePoms);
			this._verticalSplit.Panel1.Controls.Add(this._listPoms);
			// 
			// _verticalSplit.Panel2
			// 
			this._verticalSplit.Panel2.Controls.Add(this._projectPanel);
			this._verticalSplit.Panel2.Controls.Add(this._pomPropertiesEditor);
			this._verticalSplit.Size = new System.Drawing.Size(1205, 419);
			this._verticalSplit.SplitterDistance = 576;
			this._verticalSplit.TabIndex = 4;
			// 
			// _listPoms
			// 
			this._listPoms.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this._listPoms.AllowColumnReorder = true;
			this._listPoms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.GroupColumn,
            this.ArtifactColumn,
            this.VersionColumn});
			this._listPoms.Dock = System.Windows.Forms.DockStyle.Fill;
			this._listPoms.FullRowSelect = true;
			this._listPoms.HideSelection = false;
			this._listPoms.Location = new System.Drawing.Point(0, 0);
			this._listPoms.MultiSelect = false;
			this._listPoms.Name = "_listPoms";
			this._listPoms.OwnerDraw = true;
			this._listPoms.ShowItemToolTips = true;
			this._listPoms.Size = new System.Drawing.Size(572, 415);
			this._listPoms.SmallImageList = this.projectImages;
			this._listPoms.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this._listPoms.TabIndex = 1;
			this._listPoms.UseCompatibleStateImageBehavior = false;
			this._listPoms.View = System.Windows.Forms.View.Details;
			this._listPoms.Visible = false;
			this._listPoms.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.DrawListColumnHeader);
			this._listPoms.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.DrawListItem);
			this._listPoms.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.DrawListSubItem);
			this._listPoms.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListItemChecked);
			this._listPoms.SelectedIndexChanged += new System.EventHandler(this.AfterProjectSelectInList);
			this._listPoms.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListPomsMouseClick);
			// 
			// GroupColumn
			// 
			this.GroupColumn.Text = "Group";
			this.GroupColumn.Width = 200;
			// 
			// ArtifactColumn
			// 
			this.ArtifactColumn.Text = "Artifact";
			this.ArtifactColumn.Width = 150;
			// 
			// VersionColumn
			// 
			this.VersionColumn.Text = "Version";
			this.VersionColumn.Width = 100;
			// 
			// _projectPanel
			// 
			this._projectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._projectPanel.Controls.Add(this._cbSnapshot);
			this._projectPanel.Location = new System.Drawing.Point(3, 344);
			this._projectPanel.Name = "_projectPanel";
			this._projectPanel.Size = new System.Drawing.Size(620, 71);
			this._projectPanel.TabIndex = 4;
			// 
			// _cbSnapshot
			// 
			this._cbSnapshot.AutoSize = true;
			this._cbSnapshot.Enabled = false;
			this._cbSnapshot.Location = new System.Drawing.Point(3, 3);
			this._cbSnapshot.Name = "_cbSnapshot";
			this._cbSnapshot.Size = new System.Drawing.Size(85, 17);
			this._cbSnapshot.TabIndex = 1;
			this._cbSnapshot.Text = "SNAPSHOT";
			this._cbSnapshot.UseVisualStyleBackColor = true;
			this._cbSnapshot.Click += new System.EventHandler(this.SnapshotChanged);
			// 
			// _errorsList
			// 
			this._errorsList.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this._errorsList.AllowColumnReorder = true;
			this._errorsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ImageColumn,
            this.NumberColumn,
            this.MessageColumn,
            this.DetailsColumn,
            this.Project,
            this.FullPathColumn});
			this._errorsList.ContextMenuStrip = this._errorsContextMenuStrip;
			this._errorsList.Dock = System.Windows.Forms.DockStyle.Fill;
			this._errorsList.FullRowSelect = true;
			this._errorsList.GridLines = true;
			this._errorsList.HideSelection = false;
			this._errorsList.Location = new System.Drawing.Point(0, 0);
			this._errorsList.Name = "_errorsList";
			this._errorsList.Size = new System.Drawing.Size(1201, 164);
			this._errorsList.SmallImageList = this.errorImages;
			this._errorsList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this._errorsList.TabIndex = 0;
			this._errorsList.UseCompatibleStateImageBehavior = false;
			this._errorsList.View = System.Windows.Forms.View.Details;
			this._errorsList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ErrorsListColumnClick);
			this._errorsList.SelectedIndexChanged += new System.EventHandler(this.SelectedErrorChanged);
			this._errorsList.DoubleClick += new System.EventHandler(this.SelectedErrorChanged);
			this._errorsList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ErrorsListKeyDown);
			// 
			// ImageColumn
			// 
			this.ImageColumn.Text = "";
			this.ImageColumn.Width = 25;
			// 
			// NumberColumn
			// 
			this.NumberColumn.Text = "#";
			this.NumberColumn.Width = 30;
			// 
			// MessageColumn
			// 
			this.MessageColumn.Text = "Message";
			this.MessageColumn.Width = 375;
			// 
			// DetailsColumn
			// 
			this.DetailsColumn.Text = "Details";
			this.DetailsColumn.Width = 533;
			// 
			// Project
			// 
			this.Project.Text = "Project";
			this.Project.Width = 229;
			// 
			// FullPathColumn
			// 
			this.FullPathColumn.Text = "Path";
			this.FullPathColumn.Width = 300;
			// 
			// _errorsContextMenuStrip
			// 
			this._errorsContextMenuStrip.Name = "errorsContextMenuStrip";
			this._errorsContextMenuStrip.ShowImageMargin = false;
			this._errorsContextMenuStrip.Size = new System.Drawing.Size(36, 4);
			this._errorsContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ErrorsContextMenuStripOpening);
			// 
			// errorImages
			// 
			this.errorImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("errorImages.ImageStream")));
			this.errorImages.TransparentColor = System.Drawing.Color.Transparent;
			this.errorImages.Images.SetKeyName(0, "Fixed");
			this.errorImages.Images.SetKeyName(1, "Info");
			this.errorImages.Images.SetKeyName(2, "Error");
			this.errorImages.Images.SetKeyName(3, "Warning");
			// 
			// _mainMenu
			// 
			this._mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
			this._mainMenu.Location = new System.Drawing.Point(0, 0);
			this._mainMenu.Name = "_mainMenu";
			this._mainMenu.Size = new System.Drawing.Size(1205, 24);
			this._mainMenu.TabIndex = 5;
			this._mainMenu.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectFileToolStripMenuItem,
            this._miOpenFolder,
            this._miReload,
            this._miSaveProject,
            this._miSaveTree,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openProjectFileToolStripMenuItem
			// 
			this.openProjectFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openProjectFileToolStripMenuItem.Image")));
			this.openProjectFileToolStripMenuItem.Name = "openProjectFileToolStripMenuItem";
			this.openProjectFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openProjectFileToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
			this.openProjectFileToolStripMenuItem.Text = "Open Project File";
			this.openProjectFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFile);
			// 
			// _miOpenFolder
			// 
			this._miOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("_miOpenFolder.Image")));
			this._miOpenFolder.Name = "_miOpenFolder";
			this._miOpenFolder.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
			this._miOpenFolder.Size = new System.Drawing.Size(249, 22);
			this._miOpenFolder.Text = "Open Projects Tree";
			this._miOpenFolder.Click += new System.EventHandler(this.OpenTree);
			// 
			// _miReload
			// 
			this._miReload.Enabled = false;
			this._miReload.Image = ((System.Drawing.Image)(resources.GetObject("_miReload.Image")));
			this._miReload.Name = "_miReload";
			this._miReload.Size = new System.Drawing.Size(249, 22);
			this._miReload.Text = "Reload Projects Tree";
			this._miReload.Click += new System.EventHandler(this.ReloadAll);
			// 
			// _miSaveProject
			// 
			this._miSaveProject.Enabled = false;
			this._miSaveProject.Image = ((System.Drawing.Image)(resources.GetObject("_miSaveProject.Image")));
			this._miSaveProject.Name = "_miSaveProject";
			this._miSaveProject.ShortcutKeyDisplayString = "";
			this._miSaveProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this._miSaveProject.Size = new System.Drawing.Size(249, 22);
			this._miSaveProject.Text = "Save Project";
			this._miSaveProject.Click += new System.EventHandler(this.SaveProject);
			// 
			// _miSaveTree
			// 
			this._miSaveTree.Enabled = false;
			this._miSaveTree.Image = ((System.Drawing.Image)(resources.GetObject("_miSaveTree.Image")));
			this._miSaveTree.Name = "_miSaveTree";
			this._miSaveTree.ShortcutKeyDisplayString = "";
			this._miSaveTree.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
			this._miSaveTree.Size = new System.Drawing.Size(249, 22);
			this._miSaveTree.Text = "Save Projects Tree";
			this._miSaveTree.Click += new System.EventHandler(this.SaveTree);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.AppExit);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miTreeMode,
            this._miListMode,
            this._miShowErrors,
            this._miMultiselect,
            this._miSnapshotIcons});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// _miTreeMode
			// 
			this._miTreeMode.Checked = true;
			this._miTreeMode.CheckState = System.Windows.Forms.CheckState.Checked;
			this._miTreeMode.Name = "_miTreeMode";
			this._miTreeMode.Size = new System.Drawing.Size(230, 22);
			this._miTreeMode.Text = "Tree View";
			this._miTreeMode.Click += new System.EventHandler(this.ToggleProjectsView);
			// 
			// _miListMode
			// 
			this._miListMode.Name = "_miListMode";
			this._miListMode.Size = new System.Drawing.Size(230, 22);
			this._miListMode.Text = "List View";
			this._miListMode.Click += new System.EventHandler(this.ToggleProjectsView);
			// 
			// _miShowErrors
			// 
			this._miShowErrors.Checked = true;
			this._miShowErrors.CheckOnClick = true;
			this._miShowErrors.CheckState = System.Windows.Forms.CheckState.Checked;
			this._miShowErrors.Name = "_miShowErrors";
			this._miShowErrors.Size = new System.Drawing.Size(230, 22);
			this._miShowErrors.Text = "Show Errors";
			this._miShowErrors.Click += new System.EventHandler(this.ToggleErrors);
			// 
			// _miMultiselect
			// 
			this._miMultiselect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miEnableMultiselect,
            this.selectAllToolStripMenuItem,
            this.selectNoneToolStripMenuItem,
            this.selectDependenciesToolStripMenuItem,
            this.selectDirectDependenciesToolStripMenuItem,
            this.selectSubtreeToolStripMenuItem,
            this.selectPluginUsagesToolStripMenuItem});
			this._miMultiselect.Enabled = false;
			this._miMultiselect.Name = "_miMultiselect";
			this._miMultiselect.Size = new System.Drawing.Size(230, 22);
			this._miMultiselect.Text = "Multiselect";
			// 
			// _miEnableMultiselect
			// 
			this._miEnableMultiselect.CheckOnClick = true;
			this._miEnableMultiselect.Name = "_miEnableMultiselect";
			this._miEnableMultiselect.Size = new System.Drawing.Size(216, 22);
			this._miEnableMultiselect.Text = "Enable";
			this._miEnableMultiselect.Click += new System.EventHandler(this.ToggleMultiselect);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.selectAllToolStripMenuItem.Text = "Select All";
			this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAll);
			// 
			// selectNoneToolStripMenuItem
			// 
			this.selectNoneToolStripMenuItem.Name = "selectNoneToolStripMenuItem";
			this.selectNoneToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.selectNoneToolStripMenuItem.Text = "Select None";
			this.selectNoneToolStripMenuItem.Click += new System.EventHandler(this.SelectNone);
			// 
			// selectDependenciesToolStripMenuItem
			// 
			this.selectDependenciesToolStripMenuItem.Name = "selectDependenciesToolStripMenuItem";
			this.selectDependenciesToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.selectDependenciesToolStripMenuItem.Text = "Select Dependencies";
			this.selectDependenciesToolStripMenuItem.Click += new System.EventHandler(this.SelectDependencies);
			// 
			// selectDirectDependenciesToolStripMenuItem
			// 
			this.selectDirectDependenciesToolStripMenuItem.Name = "selectDirectDependenciesToolStripMenuItem";
			this.selectDirectDependenciesToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.selectDirectDependenciesToolStripMenuItem.Text = "Select Direct Dependencies";
			this.selectDirectDependenciesToolStripMenuItem.Click += new System.EventHandler(this.SelectDirectDependencies);
			// 
			// selectSubtreeToolStripMenuItem
			// 
			this.selectSubtreeToolStripMenuItem.Name = "selectSubtreeToolStripMenuItem";
			this.selectSubtreeToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.selectSubtreeToolStripMenuItem.Text = "Select Subtree";
			this.selectSubtreeToolStripMenuItem.Click += new System.EventHandler(this.SelectSubtreeSubtree);
			// 
			// selectPluginUsagesToolStripMenuItem
			// 
			this.selectPluginUsagesToolStripMenuItem.Name = "selectPluginUsagesToolStripMenuItem";
			this.selectPluginUsagesToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.selectPluginUsagesToolStripMenuItem.Text = "Select Plugin Usages";
			this.selectPluginUsagesToolStripMenuItem.Click += new System.EventHandler(this.SelectPluginUsages);
			// 
			// _miSnapshotIcons
			// 
			this._miSnapshotIcons.CheckOnClick = true;
			this._miSnapshotIcons.Name = "_miSnapshotIcons";
			this._miSnapshotIcons.Size = new System.Drawing.Size(230, 22);
			this._miSnapshotIcons.Text = "Show Snapshot/Release Icons";
			this._miSnapshotIcons.Click += new System.EventHandler(this.ToggleSnapshotIcons);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miValidate,
            this._miPropagateToDependencies,
            this._miPropagateToSubtree,
            this._miVersionOperations,
            this.externalReferencesManagerToolStripMenuItem,
            this.cascadeSwitchToSnapshotToolStripMenuItem,
            this.releaseAllSnapshotsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// _miValidate
			// 
			this._miValidate.Enabled = false;
			this._miValidate.Image = ((System.Drawing.Image)(resources.GetObject("_miValidate.Image")));
			this._miValidate.Name = "_miValidate";
			this._miValidate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this._miValidate.Size = new System.Drawing.Size(238, 22);
			this._miValidate.Text = "Validate";
			this._miValidate.Click += new System.EventHandler(this.Validate);
			// 
			// _miPropagateToDependencies
			// 
			this._miPropagateToDependencies.Enabled = false;
			this._miPropagateToDependencies.Name = "_miPropagateToDependencies";
			this._miPropagateToDependencies.Size = new System.Drawing.Size(238, 22);
			this._miPropagateToDependencies.Text = "Propagate Version to all usages";
			this._miPropagateToDependencies.Click += new System.EventHandler(this.PropagateVersionToAllUsages);
			// 
			// _miPropagateToSubtree
			// 
			this._miPropagateToSubtree.Enabled = false;
			this._miPropagateToSubtree.Name = "_miPropagateToSubtree";
			this._miPropagateToSubtree.Size = new System.Drawing.Size(238, 22);
			this._miPropagateToSubtree.Text = "Propagate Version to Subtree";
			this._miPropagateToSubtree.Click += new System.EventHandler(this.PropagateVersionToSubtree);
			// 
			// _miVersionOperations
			// 
			this._miVersionOperations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSNAPSHOTToolStripMenuItem,
            this.removeSNAPSHOTToolStripMenuItem,
            this.setVersionToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.propagateVersionToolStripMenuItem});
			this._miVersionOperations.Enabled = false;
			this._miVersionOperations.Name = "_miVersionOperations";
			this._miVersionOperations.Size = new System.Drawing.Size(238, 22);
			this._miVersionOperations.Text = "Bulk Version Operations";
			// 
			// addSNAPSHOTToolStripMenuItem
			// 
			this.addSNAPSHOTToolStripMenuItem.Name = "addSNAPSHOTToolStripMenuItem";
			this.addSNAPSHOTToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.addSNAPSHOTToolStripMenuItem.Text = "Add SNAPSHOT";
			this.addSNAPSHOTToolStripMenuItem.Click += new System.EventHandler(this.AddSnapshotToAllSelectedNodes);
			// 
			// removeSNAPSHOTToolStripMenuItem
			// 
			this.removeSNAPSHOTToolStripMenuItem.Name = "removeSNAPSHOTToolStripMenuItem";
			this.removeSNAPSHOTToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.removeSNAPSHOTToolStripMenuItem.Text = "Remove SNAPSHOT";
			this.removeSNAPSHOTToolStripMenuItem.Click += new System.EventHandler(this.RemoveSnapshotToAllSelectedNodes);
			// 
			// setVersionToolStripMenuItem
			// 
			this.setVersionToolStripMenuItem.Name = "setVersionToolStripMenuItem";
			this.setVersionToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.setVersionToolStripMenuItem.Text = "Set Version";
			this.setVersionToolStripMenuItem.Click += new System.EventHandler(this.SetVersionToAllSelectedNodes);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 22);
			this.toolStripMenuItem2.Text = "+ 1.0.0";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.VersionIncrementFirstNumberClick);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(181, 22);
			this.toolStripMenuItem3.Text = "+ 0.1.0";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.VersionIncrementSecondNumberClick);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(181, 22);
			this.toolStripMenuItem4.Text = "+ 0.0.1";
			this.toolStripMenuItem4.Click += new System.EventHandler(this.VersionIncrementThirdNumberClick);
			// 
			// propagateVersionToolStripMenuItem
			// 
			this.propagateVersionToolStripMenuItem.Name = "propagateVersionToolStripMenuItem";
			this.propagateVersionToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.propagateVersionToolStripMenuItem.Text = "Propagate Version";
			this.propagateVersionToolStripMenuItem.Click += new System.EventHandler(this.PropagateVersionOfAllSelectedNodes);
			// 
			// externalReferencesManagerToolStripMenuItem
			// 
			this.externalReferencesManagerToolStripMenuItem.Enabled = false;
			this.externalReferencesManagerToolStripMenuItem.Name = "externalReferencesManagerToolStripMenuItem";
			this.externalReferencesManagerToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
			this.externalReferencesManagerToolStripMenuItem.Text = "External Reference Manager";
			this.externalReferencesManagerToolStripMenuItem.Click += new System.EventHandler(this.ExternalReferencesManagerToolStripMenuItemClick);
			// 
			// cascadeSwitchToSnapshotToolStripMenuItem
			// 
			this.cascadeSwitchToSnapshotToolStripMenuItem.Name = "cascadeSwitchToSnapshotToolStripMenuItem";
			this.cascadeSwitchToSnapshotToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
			this.cascadeSwitchToSnapshotToolStripMenuItem.Text = "Cascade switch to snapshot";
			this.cascadeSwitchToSnapshotToolStripMenuItem.Click += new System.EventHandler(this.CascadeSwitchToSnapshotOnClick);
			// 
			// releaseAllSnapshotsToolStripMenuItem
			// 
			this.releaseAllSnapshotsToolStripMenuItem.Name = "releaseAllSnapshotsToolStripMenuItem";
			this.releaseAllSnapshotsToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
			this.releaseAllSnapshotsToolStripMenuItem.Text = "Release all snapshots";
			this.releaseAllSnapshotsToolStripMenuItem.Click += new System.EventHandler(this.ReleaseAllSnapshotsOnClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1205, 637);
			this.Controls.Add(this._horizSplit);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this._mainMenu);
			this.MainMenuStrip = this._mainMenu;
			this.MinimumSize = new System.Drawing.Size(500, 500);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Maven Projects Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosingHandler);
			this.ProjectContextMenuStrip.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this._horizSplit.Panel1.ResumeLayout(false);
			this._horizSplit.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this._horizSplit)).EndInit();
			this._horizSplit.ResumeLayout(false);
			this._verticalSplit.Panel1.ResumeLayout(false);
			this._verticalSplit.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this._verticalSplit)).EndInit();
			this._verticalSplit.ResumeLayout(false);
			this._projectPanel.ResumeLayout(false);
			this._projectPanel.PerformLayout();
			this._mainMenu.ResumeLayout(false);
			this._mainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView _treePoms;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.PropertyGrid _pomPropertiesEditor;
		private System.Windows.Forms.SplitContainer _horizSplit;
		private System.Windows.Forms.ListView _errorsList;
		private System.Windows.Forms.SplitContainer _verticalSplit;
		private System.Windows.Forms.ColumnHeader NumberColumn;
		private System.Windows.Forms.ColumnHeader MessageColumn;
		private System.Windows.Forms.ColumnHeader DetailsColumn;
		private System.Windows.Forms.ColumnHeader Project;
		private System.Windows.Forms.MenuStrip _mainMenu;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _miOpenFolder;
		private System.Windows.Forms.ToolStripMenuItem _miReload;
		private System.Windows.Forms.ToolStripMenuItem _miSaveProject;
		private System.Windows.Forms.ToolStripMenuItem _miSaveTree;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _miTreeMode;
		private System.Windows.Forms.ToolStripMenuItem _miListMode;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _miValidate;
		private System.Windows.Forms.ToolStripMenuItem _miPropagateToDependencies;
		private System.Windows.Forms.ToolStripMenuItem _miPropagateToSubtree;
		private System.Windows.Forms.ToolStripMenuItem _miShowErrors;
		private System.Windows.Forms.ImageList projectImages;
		private System.Windows.Forms.ToolStripStatusLabel _lStatus;
		private System.Windows.Forms.ListView _listPoms;
		private System.Windows.Forms.ColumnHeader GroupColumn;
		private System.Windows.Forms.ColumnHeader ArtifactColumn;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader VersionColumn;
		private System.Windows.Forms.ImageList errorImages;
		private System.Windows.Forms.ColumnHeader ImageColumn;
		private System.Windows.Forms.ToolStripMenuItem _miVersionOperations;
		private System.Windows.Forms.ToolStripMenuItem _miMultiselect;
		private System.Windows.Forms.Panel _projectPanel;
		private System.Windows.Forms.CheckBox _cbSnapshot;
		private System.Windows.Forms.ToolStripMenuItem _miSnapshotIcons;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _miEnableMultiselect;
		private System.Windows.Forms.ToolStripMenuItem selectDependenciesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectDirectDependenciesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addSNAPSHOTToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeSNAPSHOTToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem selectSubtreeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem propagateVersionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openProjectFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem setVersionToolStripMenuItem;
		  private System.Windows.Forms.ContextMenuStrip _errorsContextMenuStrip;
		private System.Windows.Forms.ColumnHeader FullPathColumn;
		private System.Windows.Forms.ContextMenuStrip ProjectContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem editAsTextToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem advancedEditorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem externalReferencesManagerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectPluginUsagesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cascadeSwitchToSnapshotToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem releaseAllSnapshotsToolStripMenuItem;
	}
}

