using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Pustota.Maven.Editor
{
	partial class PomAdvancedEditor : Form
	{
		//private readonly ProjectView _projectView;
		private readonly IProjectsRepository _projectsRepository;
		private IEnumerable<string> _artifactIds;
		private IEnumerable<string> _groupIds;

		public PomAdvancedEditor(/*ProjectView proj, IProjectsRepository projectsRepo*/)
		{
			InitializeComponent();
			//IntPtr h = tabControlCommon.Handle;
			//_projectView = proj;
			//_projectsRepository = projectsRepo;
			//FillGeneralData();
			//PopulateSuperTabs();
			//FillAutocompleteSources();
		}

		private void FillAutocompleteSources()
		{
			_artifactIds = _projectsRepository.AllProjects.Where(p => !string.IsNullOrEmpty(p.ArtifactId)).Select(p => p.ArtifactId).Distinct();
			_groupIds = _projectsRepository.AllProjects.Where(p => !string.IsNullOrEmpty(p.GroupId)).Select(p => p.GroupId).Distinct();
		}

		private void FillGeneralData()
		{
			//textBoxArtifactID.DataBindings.Add(new Binding("Text", _projectView, "ArtifactId", false, DataSourceUpdateMode.OnPropertyChanged));
			//textBoxGroupID.DataBindings.Add(new Binding("Text", _projectView, "GroupId", false, DataSourceUpdateMode.OnPropertyChanged));
			//textBoxName.DataBindings.Add(new Binding("Text", _projectView, "Name", false, DataSourceUpdateMode.OnPropertyChanged));
			//textBoxVersion.DataBindings.Add(new Binding("Text", _projectView, "Version", false, DataSourceUpdateMode.OnPropertyChanged));
			//checkBoxIsSnapshot.DataBindings.Add(new Binding("Checked", _projectView, "IsSnapshot", false, DataSourceUpdateMode.OnPropertyChanged));
		}

		private void PopulateSuperTabs()
		{
			//PopulateTab("Dependencies", tabCommon, _projectView.Dependencies, null, () => new Dependency());
			//PopulateTab("Modules", tabCommon, _projectView.Modules, null, () => new Module());
			//PopulateTab("Parent", tabCommon, _projectView.Parent, null, () => new ParentReference());
			//PopulateTab("Properties", tabCommon, _projectView.Properties, null, () => new Property());

			//foreach (Profile profile in _projectView.Profiles)
			//{
			//	PopulateSuperTab(tabControlCommon, profile, false);
			//}
		}

		//private void PopulateSuperTab(TabControl tabControl, Profile profile, bool selected)
		//{
		//	TabPage newtabPage = new TabPage(profile.Id)
		//	{
		//		Dock = DockStyle.Fill,
		//		Tag = profile
		//	};

		//	TabControl profileTab = new TabControl
		//	{
		//		Dock = DockStyle.Fill,
		//		Alignment = TabAlignment.Left
		//	};

		//	newtabPage.Controls.Add(profileTab);
		//	tabControl.TabPages.Insert(tabControl.TabPages.Count - 1, newtabPage);
		//	if (selected) tabControl.SelectedTab = newtabPage;
		//	PopulateTab("Dependencies", profileTab, profile.Dependencies, null, () => new Dependency());
		//	PopulateTab("Modules", profileTab, profile.Modules, null, () => new Module());
		//	PopulateTab("Properties", profileTab, profile.Properties, null, () => new Property());
		//}

		//private void PopulateTab(string title, Control tabControl, object items, object tag, Func<object> addNewDelegate)
		//{
		//	TabPage tabPage = new TabPage(title)
		//		{
		//			Dock = DockStyle.Fill,
		//			Tag = tag
		//		};
		//	tabControl.Controls.Add(tabPage);
			
		//	BindingSource bindingSource = new BindingSource { DataSource = items, RaiseListChangedEvents = true, AllowNew = true};
		//	bindingSource.ListChanged += (o, e) =>
		//		{
		//			_projectView.MarkChanged();
		//			_projectView.UpdateViews();
		//		};
		//	EditorControl control = title == "Parent" ? new EditorControl(bindingSource, 1, addNewDelegate) : new EditorControl(bindingSource, int.MaxValue, addNewDelegate);
		//	control.EditingControlShowing += DataGridViewDependenciesEditingControlShowing;
		//	control.Location = tabPage.Location;
		//	control.Dock = DockStyle.Fill;
		//	tabPage.Controls.Add(control);
		//}

		//private void RemoveTabProfile(TabPage selectedTab)
		//{
		//		var selectedProfile = selectedTab.Tag as Profile;
		//		if (selectedProfile == null) return;
		//		_projectView.Profiles.Remove(selectedProfile);
		//		var indexOfRemoved = tabControlCommon.TabPages.IndexOf(selectedTab);
		//		tabControlCommon.TabPages.Remove(selectedTab);
		//		if (indexOfRemoved == tabControlCommon.TabPages.Count - 1)
		//			--indexOfRemoved;
		//		tabControlCommon.SelectedTab = tabControlCommon.TabPages[indexOfRemoved];
		//}

		private void ToolStripMenuItemTabRenameClick(object sender, EventArgs e)
		{
			//using (VersionDialog dialog = new VersionDialog())
			//{
			//	var selectedTab = tabControlCommon.SelectedTab;
			//	var profile = selectedTab.Tag as Profile;
			//	if (dialog.ShowDialog() == DialogResult.OK)
			//	{
			//		if (profile != null)
			//		{
			//			profile.Id = dialog.Version;
			//			selectedTab.Text = dialog.Version;
			//		}
			//	}
			//}
		}

		private void TabControlCommonMouseClick(object sender, MouseEventArgs e)
		{
			//for (int i = 0; i < tabControlCommon.TabCount; i++)
			//{
			//	if (tabControlCommon.GetTabRect(i).Contains(e.Location) && tabControlCommon.TabPages[i] != tabPageAddNew)
			//	{
			//		tabControlCommon.SelectedTab = tabControlCommon.TabPages[i];
			//		if (e.Button == MouseButtons.Right)
			//		{
			//			contextMenuStripTabs.Show(tabControlCommon, e.Location);
			//		}
			//		if (e.Button == MouseButtons.Middle)
			//		{
			//			RemoveTabProfile(tabControlCommon.SelectedTab);
			//		}
			//	}
			//}
		}

		private void ToolStripMenuItemTabRemoveClick(object sender, EventArgs e)
		{
			//RemoveTabProfile(tabControlCommon.SelectedTab);
		}

		private void TabControlCommonSelectedIndexChanged(object sender, EventArgs e)
		{
			//if (tabControlCommon.SelectedTab == tabPageAddNew)
			//{
			//	var profile = new Profile();
			//	_projectView.Profiles.Add(profile);
			//	PopulateSuperTab(tabControlCommon, profile, true);
			//}
		}

		//private void DataGridViewDependenciesEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		//{
		//	var textBox = (TextBox) e.Control;
		//	textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		//	textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
		//	var header = ((DataGridView) sender).CurrentCell.OwningColumn.HeaderText;
		//	if (header == "ArtifactId")
		//		textBox.AutoCompleteCustomSource.AddRange(_artifactIds.Take(10).ToArray());
		//	if (header == "GroupId")
		//		textBox.AutoCompleteCustomSource.AddRange(_groupIds.Take(10).ToArray());
		//}
	}
}
