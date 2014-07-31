using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Pustota.Maven.Editor.Externals;
using Pustota.Maven.Editor.Models;
using Pustota.Maven.Editor.Resources;
using Pustota.Maven.Editor.ViewModels;

namespace Pustota.Maven.Editor
{
	partial class MainForm : Form
	{
		// private Project _currentProject;
		// private ProjectNode _currentProjectNode;

		private readonly List<ContextAction> _actionsList;
		private ErrorListColumnSorter _errorListColumnSorter;

		private readonly SolutionManagement _solutionManagement;
		private ISolution _solution;

		//private readonly ProjectViewMap _views;

		public MainForm()
		{
			//_views = new ProjectViewMap();
			_solutionManagement = new SolutionManagement(); // REVIEW: DI?

			//_actionsList = GetActions();
			InitializeComponent();
			//InitializeSorter();
		}

		private void ShowWarning(string message)
		{
			MessageBox.Show(message);
		}

		private void ShowError(string caption, string message)
		{
			MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		//public IProjectsRepository ProjectsRepo
		//{
		//	get
		//	{
		//		// REVIEW: workaround for now
		//		if (_solution == null)
		//		{
		//			Debug.Assert(true, "Solution is NULL");
		//			return null;
		//		}
		//		return _solution.ProjectsRepository; 
				
		//	}
		//}

		//public Project CurrentProject { get { return _currentProject; } }

		//public ProjectView CurrentProjectView
		//{
		//	get
		//	{
		//		return _pomPropertiesEditor.SelectedObject as ProjectView;
		//	}
		//	private set
		//	{
		//		if (value == null)
		//		{
		//			_currentProject = null;
		//			_currentProjectNode = null;
		//			_cbSnapshot.Enabled = false;
		//		}
		//		else
		//		{
		//			_currentProject = value.Project;
		//			_currentProjectNode = value.ProjectNode;

		//			_cbSnapshot.Enabled = value.Project.HasSpecificVersion;
		//			_cbSnapshot.Checked = value.IsSnapshot;

		//			_lStatus.Text = 
		//				string.Format("{0}:{1} ({2}) {3}",
		//					value.Project.GroupId,
		//					value.Project.ArtifactId, 
		//					value.ProjectNode.Version,
		//					value.ProjectNode.FullPath);
		//		}
		//		_pomPropertiesEditor.SelectedObject = value;
		//	}
		//}

		//public bool Multiselect
		//{
		//	get
		//	{
		//		return _listPoms.CheckBoxes;
		//	}
		//	set
		//	{
		//		_listPoms.BeginUpdate();
		//		_treePoms.BeginUpdate();
		//		_listPoms.CheckBoxes = _treePoms.CheckBoxes = value;
		//		_miVersionOperations.Enabled = value;
		//		_listPoms.EndUpdate();
		//		_treePoms.EndUpdate();
		//	}
		//}

		//private void RefreshUI()
		//{
		//	_views.Clean();

		//	PopulateTree();
		//	PopulateList();
		//	ActivateControls();
		//}

		//private void RefreshPropertyGrid()
		//{
		//	CurrentProjectView = CurrentProjectView; //refresh editing controls
		//}

		//private void InitializeSorter()
		//{
		//	_errorListColumnSorter = new ErrorListColumnSorter();
		//	_errorsList.ListViewItemSorter = _errorListColumnSorter;
		//}

		//private void ActivateControls()
		//{
		//	_miSaveProject.Enabled = true;
		//	_miSaveTree.Enabled = true;
		//	_miValidate.Enabled = true;
		//	_miReload.Enabled = true;
		//	_miPropagateToDependencies.Enabled = true;
		//	_miPropagateToSubtree.Enabled = true;
		//	_miSnapshotIcons.Checked = false;
		//	_miMultiselect.Enabled = true;
		//	externalReferencesManagerToolStripMenuItem.Enabled = true;
		//}

		//private void PopulateTree()
		//{
		//	var rootNodes = ProjectsRepo != null ? ProjectsRepo.GetRootProjects().ToArray() : new ProjectNode[] { };

		//	_treePoms.BeginUpdate();
		//	_treePoms.Nodes.Clear();

		//	foreach (var projectNode in rootNodes)
		//	{
		//		_treePoms.Nodes.Add(CreateSubtree(projectNode));
		//	}

		//	_treePoms.EndUpdate();
			
		//	if (_treePoms.Nodes.Count != 0)
		//	{
		//		_treePoms.SelectedNode = _treePoms.Nodes[0];
		//	}
		//}

		//private TreeNode CreateSubtree(ProjectNode projectNode)
		//{
		//	var result = _views.GetProjectView(projectNode).CreateTreeNode();

		//	foreach (var moduleNode in ProjectsRepo.GetProjectModules(projectNode))
		//	{
		//		result.Nodes.Add(CreateSubtree(moduleNode));
		//	}
		//	return result;
		//}

		//private void PopulateList()
		//{
		//	var projectNodes = ProjectsRepo != null ? ProjectsRepo.AllProjectNodes : new ProjectNode[] { };

		//	_listPoms.BeginUpdate();
		//	_listPoms.Items.Clear();

		//	foreach (ProjectNode node in projectNodes)
		//	{
		//		_listPoms.Items.Add(_views.GetProjectView(node).CreateListItem());
		//	}
		//	_listPoms.EndUpdate();

		//	if (_listPoms.Items.Count != 0)
		//	{
		//		_listPoms.SelectedIndices.Clear();
		//		_listPoms.SelectedIndices.Add(0);
		//		_listPoms.TopItem = _listPoms.Items[0];
		//	}
		//}

		//private void SelectProjectInTreeAndList(Project prj)
		//{
		//	SelectProjectInTree(prj);
		//	SelectProjectInList(prj);
		//}

		//private void SelectProjectInList(Project prj)
		//{
		//	//this project is already selected in the list
		//	if (_listPoms.SelectedItems.Count != 0 && ((ProjectView)_listPoms.SelectedItems[0].Tag).FullPath == prj.FullPath)
		//		return;
		//	_listPoms.SelectedItems.Clear();
		//	foreach (ListViewItem item in _listPoms.Items)
		//	{
		//		ProjectView prjView = item.Tag as ProjectView;
		//		if (prjView != null && prjView.FullPath == prj.FullPath)
		//		{
		//			item.Selected = true;
		//			item.Focused = true;
		//			_listPoms.EnsureVisible(item.Index);
		//			break;
		//		}
		//	}
		//}

		//private void SelectProjectInTree(Project prj)
		//{
		//	//this project is already selected in the tree
		//	if (_treePoms.SelectedNode != null && ((ProjectView)_treePoms.SelectedNode.Tag).FullPath == prj.FullPath)
		//		return;
		//	Queue<TreeNode> nodes = new Queue<TreeNode>(_treePoms.Nodes.OfType<TreeNode>());
		//	while (nodes.Count != 0)
		//	{
		//		TreeNode node = nodes.Dequeue();
		//		ProjectView prjView = node.Tag as ProjectView;
		//		if (prjView != null && prjView.FullPath == prj.FullPath)
		//		{
		//			_treePoms.SelectedNode = node;
		//		}
		//		else
		//		{
		//			foreach (TreeNode child in node.Nodes)
		//				nodes.Enqueue(child);
		//		}
		//	}
		//}

		//private void UpdateAllProjectViews()
		//{
		//	_listPoms.BeginUpdate();
		//	_treePoms.BeginUpdate();

		//	foreach (var prjView in _views.AllViews)
		//	{
		//		prjView.UpdateViews();
		//	}

		//	RefreshPropertyGrid();
		//	_listPoms.EndUpdate();
		//	_treePoms.EndUpdate();
		//}

		//private void SearchAndSelect(SearchOptions searchOptions)
		//{
		//	_listPoms.BeginUpdate();
		//	_treePoms.BeginUpdate();

		//	try
		//	{

		//		var selected = _views.AllViews.Where(v => v.Checked).Select(v => v.ProjectNode);
		//		var selector = new DependencySelector(ProjectsRepo, searchOptions);
		//		var nodesToSelect = selector.SelectUsages(selected);

		//		foreach (var node in nodesToSelect)
		//		{
		//			ProjectView view = _views.GetProjectView(node);
		//			view.Checked = true;
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		Trace.WriteLine(ex);
		//		ShowError("Search failed", ex.Message);
		//	}
		//	finally
		//	{
		//		_listPoms.EndUpdate();
		//		_treePoms.EndUpdate();
		//	}
		//}

		//private void SetSnapshotToAllSelectedNodes(bool value)
		//{
		//	_listPoms.BeginUpdate();
		//	_treePoms.BeginUpdate();

		//	foreach (var prjView in _views.AllViews)
		//	{
		//		if (prjView.Checked && prjView.Project.HasSpecificVersion)
		//			prjView.IsSnapshot = value;
		//	}

		//	_listPoms.EndUpdate();
		//	_treePoms.EndUpdate();

		//	RefreshPropertyGrid();
		//	UpdateAllProjectViews();
		//}

		//#region owner draw

		//private void DrawTreeNode(object sender, DrawTreeNodeEventArgs e)
		//{
		//	if ((e.State & TreeNodeStates.Selected) != 0)
		//	{
		//		Rectangle bounds = e.Bounds;
		//		bounds.Width = (int)(bounds.Width * 1.1);
		//		bounds.X += 1;

		//		e.Graphics.FillRectangle(SystemBrushes.MenuHighlight, bounds);

		//		TreeView tree = ((TreeView)sender);
		//		Font nodeFont = tree.Font;
		//		e.Graphics.DrawString(e.Node.Text, nodeFont, SystemBrushes.HighlightText, bounds.Location);
		//	}
		//	else
		//	{
		//		e.DrawDefault = true;
		//	}
		//}

		//private void DrawListItem(object sender, DrawListViewItemEventArgs e)
		//{
		//	ListView list = (ListView)sender;
		//	if (list.SelectedIndices.Contains(e.ItemIndex))
		//	{
		//		e.Graphics.FillRectangle(SystemBrushes.MenuHighlight, e.Bounds);
		//	}
		//	else
		//	{
		//		e.DrawDefault = true;
		//	}
		//}

		//private void DrawListSubItem(object sender, DrawListViewSubItemEventArgs e)
		//{
		//	ListView list = (ListView)sender;
		//	if (list.SelectedIndices.Contains(e.ItemIndex))
		//	{
		//		var bounds = e.Bounds;
		//		bounds.X += 5;

		//		if (e.ColumnIndex == 0 && list.CheckBoxes)
		//		{
		//			var cbLocation = bounds.Location;
		//			cbLocation.X -= 1;
		//			cbLocation.Y += 1;

		//			var checkState = e.Item.Checked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal;
		//			CheckBoxRenderer.DrawCheckBox(e.Graphics, cbLocation, checkState);
		//			bounds.X += CheckBoxRenderer.GetGlyphSize(e.Graphics, checkState).Width;
		//		}

		//		if (e.ColumnIndex == 0)
		//		{
		//			var image = projectImages.Images[e.Item.ImageKey];
		//			if (image != null)
		//			{
		//				e.Graphics.DrawImage(image, bounds.Location);
		//				bounds.X += image.Width;
		//			}
		//		}
		//		e.Graphics.DrawString(e.SubItem.Text, list.Font, SystemBrushes.HighlightText, bounds);
		//	}
		//	else
		//	{
		//		e.DrawDefault = true;
		//	}
		//}

		//private void DrawListColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		//{
		//	e.DrawDefault = true;
		//}

		//#endregion

		//#region event handlers
		//private void OpenTree(object sender, EventArgs e)
		//{
		//	FolderBrowserDialog dialog = new FolderBrowserDialog();

		//	if (dialog.ShowDialog() != DialogResult.OK) return;
		//	try
		//	{
		//		_solution = _solutionManagement.OpenSolution(dialog.SelectedPath);  
		//	}
		//	catch (Exception ex)
		//	{
		//		ShowError(ex.ToString(), ErrorsResources.ErrorLoadingProjectTree);
		//	}
		//	RefreshUI();
		//}

		//private void OpenFile(object sender, EventArgs e)
		//{
		//	OpenFileDialog dialog = new OpenFileDialog
		//	{
		//		Filter = CommonResources.POMFilesFilter
		//	};

		//	if (dialog.ShowDialog() != DialogResult.OK) return;
		//	try
		//	{
		//		_solution = _solutionManagement.OpenSolution(dialog.FileName);
		//	}
		//	catch (Exception ex)
		//	{
		//		ShowError(ex.ToString(), ErrorsResources.ErrorLoadingProjectTree);
		//	}
		//	RefreshUI();
		//}


		//private void ReloadAll(object sender, EventArgs e)
		//{
		//	if (ProjectsRepo.Changed)
		//	{
		//		var result = MessageBox.Show(MessageResources.ProceedReloading,
		//			CommonResources.TitleUnsavedChanges, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

		//		if (result != DialogResult.OK)
		//			return;
		//	}

		//	try
		//	{
		//		// REVIEW: this has to be done differently
		//		_solution.Reload();
		//	}
		//	catch (Exception ex)
		//	{
		//		ShowError(ex.ToString(), ErrorsResources.ErrorLoadingProjectTree);
		//	}
		//	RefreshUI();
		//	_errorsList.Items.Clear();
		//}

		//private void AfterProjectSelectInTree(object sender, TreeViewEventArgs e)
		//{
		//	CurrentProjectView = (ProjectView)e.Node.Tag;
		//	SelectProjectInList(CurrentProject);
		//}

		//private void AfterProjectSelectInList(object sender, EventArgs e)
		//{
		//	if (_listPoms.SelectedItems.Count == 0)
		//		return;

		//	CurrentProjectView = (ProjectView)_listPoms.SelectedItems[0].Tag;
		//	SelectProjectInTree(CurrentProject);
		//}

		//private void CleanErrorListAfterSaveProject()
		//{
		//	if (_errorsList.SelectedItems.Count != 1) return;
		//	var currentError = _errorsList.SelectedItems.Cast<ListViewItem>().FirstOrDefault(
		//			l =>
		//			{
		//				var validationError = (ValidationError)l.Tag;
		//				return
		//					validationError.Source == CurrentProject && validationError.Level == ErrorLevel.Fixed;
		//			});
		//	if (currentError != null)
		//		currentError.Remove();
		//}

		//private void CleanErrorListAfterSaveTree()
		//{
		//	foreach (var error in _errorsList.Items.Cast<ListViewItem>().Where(l => ((ValidationError)l.Tag).Level == ErrorLevel.Fixed))
		//	{
		//		error.Remove();
		//	}
		//}

		//private void SaveProject(object sender, EventArgs e)
		//{
		//	try
		//	{
		//		if (!IsProjectSelected(_errorsList.SelectedItems)) 
		//			return;

		//		var loader = new ProjectLoader(); // REVIEW: DI
		//		loader.SaveProject(CurrentProject, CurrentProject.FullPath);
		//		CurrentProject.Changed = false;

		//		CleanErrorListAfterSaveProject();
		//	}
		//	catch (Exception ex)
		//	{
		//		ShowError(ex.ToString(), ErrorsResources.ErrorSavingProjects);
		//	}
		//}

		//private bool IsProjectSelected(ListView.SelectedListViewItemCollection selected)
		//{
		//	//if (_errorsList.SelectedItems.Count != 1) return false;
		//	var selectedItem = selected.Cast<ListViewItem>().FirstOrDefault();
		//	if (selectedItem == null)
		//		return true;
		//	ValidationError warning = selectedItem.Tag as ValidationError;
		//	if (warning == null)
		//		return false;
		//	if (warning.Source == null || warning.Source as Project == null)
		//		return false;
		//	return true;
		//}

		//private void SaveTree(object sender, EventArgs e)
		//{
		//	try
		//	{
		//		ProjectsRepo.SaveChangedProjects();
		//		CleanErrorListAfterSaveTree();
		//	}
		//	catch (Exception ex)
		//	{
		//		ShowError(ex.ToString(), ErrorsResources.ErrorSavingProjects);
		//	}
		//}

		//private void PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		//{
		//	((ProjectView)_pomPropertiesEditor.SelectedObject).MarkChanged();
		//	RefreshPropertyGrid();
		//}

		//private void Validate(object sender, EventArgs e)
		//{
		//	_errorsList.Items.Clear();

		//	var errors = _solution.Validate(); 

		//	int index = 1;
		//	foreach (var warning in errors)
		//	{
		//		ListViewItem item = new ListViewItem { ImageKey = warning.Level.ToString(), Tag = warning };
		//		item.SubItems.Add(index.ToString(CultureInfo.InvariantCulture));
		//		item.SubItems.Add(warning.Message);
		//		item.SubItems.Add(warning.Details);

		//		if (warning.Source != null)
		//		{
		//			item.SubItems.Add(warning.Source.Title);
		//			item.SubItems.Add(warning.Source.FullPath);
		//		}
		//		else
		//		{
		//			item.SubItems.Add("Global error");
		//			item.SubItems.Add("");
		//		}
		//		//warning.Fixes.Any() 
		//		_errorsList.Items.Add(item);
		//		index++;
		//	}
		//}

		//private void PropagateVersionToAllUsages(object sender, EventArgs e)
		//{
		//	ProjectsRepo.PropagateVersionToAllUsages(_currentProjectNode);
		//	UpdateAllProjectViews();
		//}

		//private void PropagateVersionToSubtree(object sender, EventArgs e)
		//{
		//	ProjectsRepo.PropagateVersionToSubtree(_currentProjectNode);
		//	UpdateAllProjectViews();
		//}

		//private void ToggleErrors(object sender, EventArgs e)
		//{
		//	_horizSplit.Panel2Collapsed = !_horizSplit.Panel2Collapsed;
		//}

		//private void SelectedErrorChanged(object sender, EventArgs e)
		//{
		//	var selectedItem = _errorsList.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
		//	if (selectedItem == null)
		//		return;
		//	ValidationError warning = selectedItem.Tag as ValidationError;
		//	if (warning == null)
		//		return;
		//	if (warning.Source == null || warning.Source as Project == null)
		//		return;
		//	SelectProjectInTreeAndList((Project)warning.Source);
		//}

		//private void ToggleProjectsView(object sender, EventArgs e)
		//{
		//	var toolStripMenuItem = sender as ToolStripMenuItem;
		//	if (toolStripMenuItem != null && toolStripMenuItem.Checked)
		//		return;

		//	_miListMode.Checked = !_miListMode.Checked;
		//	_miTreeMode.Checked = !_miTreeMode.Checked;
		//	_listPoms.Visible = !_listPoms.Visible;
		//	_treePoms.Visible = !_treePoms.Visible;

		//	if (_miListMode.Checked)
		//		_listPoms.Focus();
		//	else
		//		_treePoms.Focus();
		//}

		//private void AppExit(object sender, EventArgs e)
		//{
		//	Application.Exit();
		//}

		//private void ToggleSnapshotIcons(object sender, EventArgs e)
		//{
		//	_listPoms.BeginUpdate();
		//	_treePoms.BeginUpdate();
		//	foreach (var prjView in _views.AllViews)
		//	{
		//		prjView.ShowSnapshotIcon = _miSnapshotIcons.Checked;
		//	}
		//	_listPoms.EndUpdate();
		//	_treePoms.EndUpdate();
		//}

		//private void ListItemChecked(object sender, ItemCheckedEventArgs e)
		//{
		//	((ProjectView)e.Item.Tag).Checked = e.Item.Checked;
		//}

		//private void TreeItemChecked(object sender, TreeViewEventArgs e)
		//{
		//	((ProjectView)e.Node.Tag).Checked = e.Node.Checked;
		//}

		//private void ToggleMultiselect(object sender, EventArgs e)
		//{
		//	Multiselect = !Multiselect;
		//}

		//private void TreeDoubleClick(object sender, EventArgs e)
		//{
		//	if (_treePoms.SelectedNode != null)
		//	{
		//		//selected item already changed its state
		//		if (_treePoms.SelectedNode.IsExpanded)
		//		{
		//			_treePoms.SelectedNode.ExpandAll();
		//		}
		//	}
		//}

		//private void SnapshotChanged(object sender, EventArgs e)
		//{
		//	if (CurrentProjectView != null)
		//	{
		//		CurrentProjectView.IsSnapshot = !CurrentProjectView.IsSnapshot;

		//		UpdateAllProjectViews();

		//		RefreshPropertyGrid();
		//	}
		//}

		//private void SelectAll(object sender, EventArgs e)
		//{
		//	if (Multiselect)
		//	{
		//		_listPoms.BeginUpdate();
		//		_treePoms.BeginUpdate();
		//		foreach (var prjView in _views.AllViews)
		//		{
		//			prjView.Checked = true;
		//		}
		//		_listPoms.EndUpdate();
		//		_treePoms.EndUpdate();
		//	}
		//}

		//private void SelectNone(object sender, EventArgs e)
		//{
		//	if (Multiselect)
		//	{
		//		_listPoms.BeginUpdate();
		//		_treePoms.BeginUpdate();
		//		foreach (var prjView in _views.AllViews)
		//		{
		//			prjView.Checked = false;
		//		}
		//		_listPoms.EndUpdate();
		//		_treePoms.EndUpdate();
		//	}
		//}

		//private void SelectDependencies(object sender, EventArgs e)
		//{
		//	if (!Multiselect)
		//	{
		//		ShowWarning("Multiselect mode has to be enabled");
		//		return;
		//	}

		//	var searchOptions = new SearchOptions
		//	{
		//		LookForDependent = true
		//	};
		//	SearchAndSelect(searchOptions);
		//}

		//private void SelectDirectDependencies(object sender, EventArgs e)
		//{
		//	if (!Multiselect)
		//	{
		//		ShowWarning("Multiselect mode has to be enabled");
		//		return;
		//	}

		//	var searchOptions = new SearchOptions
		//	{
		//		LookForDependent = true,
		//		OnlyDirectUsages = true
		//	};
		//	SearchAndSelect(searchOptions);
		//}

		//private void SelectPluginUsages(object sender, EventArgs e)
		//{
		//	if (!Multiselect)
		//	{
		//		ShowWarning("Multiselect mode has to be enabled");
		//		return;
		//	}

		//	var searchOptions = new SearchOptions
		//	{
		//		LookForPlugin = true,
		//	};
		//	SearchAndSelect(searchOptions);
		//}

		//private void SelectSubtreeSubtree(object sender, EventArgs e)
		//{
		//	if (CurrentProjectView == null)
		//		return;

		//	_listPoms.BeginUpdate();
		//	_treePoms.BeginUpdate();

		//	CurrentProjectView.Checked = true;
		//	Queue<TreeNode> nodes = new Queue<TreeNode>(CurrentProjectView.CreateTreeNode().Nodes.Cast<TreeNode>());
		//	while (nodes.Count != 0)
		//	{
		//		var node = nodes.Dequeue();
		//		foreach (var child in node.Nodes.Cast<TreeNode>())
		//		{
		//			nodes.Enqueue(child);
		//		}

		//		((ProjectView)node.Tag).Checked = true;
		//	}
		//	_listPoms.EndUpdate();
		//	_treePoms.EndUpdate();
		//}

		//private void PropagateVersionOfAllSelectedNodes(object sender, EventArgs e)
		//{
		//	_listPoms.BeginUpdate();
		//	_treePoms.BeginUpdate();

		//	foreach (var prjView in _views.AllViews.Where(v => v.Checked))
		//	{
		//		ProjectsRepo.PropagateVersionToAllUsages(prjView.ProjectNode);
		//	}

		//	_listPoms.EndUpdate();
		//	_treePoms.EndUpdate();

		//	UpdateAllProjectViews();
		//}

		//private void SetVersionToAllSelectedNodes(object sender, EventArgs e)
		//{
		//	if (!Multiselect)
		//	{
		//		ShowWarning("Multiselect mode has to be enabled");
		//		return;
		//	}

		//	VersionDialog dialog = new VersionDialog();
		//	if (dialog.ShowDialog() != DialogResult.OK)
		//		return;

		//	_listPoms.BeginUpdate();
		//	_treePoms.BeginUpdate();

		//	foreach (var prjView in _views.AllViews.Where(v => v.Checked))
		//	{
		//		prjView.Version = dialog.Version;
		//	}

		//	_listPoms.EndUpdate();
		//	_treePoms.EndUpdate();

		//	RefreshPropertyGrid();
		//	UpdateAllProjectViews();
		//}

		//private void FormClosingHandler(object sender, FormClosingEventArgs e)
		//{
		//	if (_solution != null && _solution.Changed)
		//	{
		//		var result = MessageBox.Show(MessageResources.DoYouWantToQuit,
		//			CommonResources.TitleUnsavedChanges, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

		//		if (result != DialogResult.OK)
		//		{
		//			e.Cancel = true;
		//		}
		//	}
		//}
		//#endregion

		//private void ErrorsContextMenuStripOpening(object sender, System.ComponentModel.CancelEventArgs e)
		//{
		//	if (_errorsList.SelectedItems.Count <= 0)
		//	{
		//		e.Cancel = true;
		//		return;
		//	}

		//	if (_errorsList.SelectedItems.Count == 1)
		//	{
		//		if (!HasFixes(_errorsList.SelectedItems))
		//		{
		//			e.Cancel = true;
		//			return;
		//		}
		//		BuildFixesMenuForSingleItem(_errorsList.SelectedItems[0]);
		//		return;
		//	}

		//	if (!HasFixes(_errorsList.SelectedItems))
		//	{
		//		e.Cancel = true;
		//		return;
		//	}
		//	BuildFixAllMenu();
		//}

		//private void BuildFixAllMenu()
		//{
		//	_errorsContextMenuStrip.SuspendLayout();
		//	_errorsContextMenuStrip.Items.Clear();

		//	var button = new ToolStripButton
		//	{
		//		DisplayStyle = ToolStripItemDisplayStyle.Text,
		//		TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
		//		Text = MessageResources.FixAll,
		//		Width = 150,
		//		Name = "errorFixAll",
		//		AutoSize = true,
		//	};
		//	button.Click += (senderr, er) =>
		//	{
		//		if (ShouldBeConfirmed(_errorsList.SelectedItems))
		//		{
		//			var result = MessageBox.Show(MessageResources.ThereAreSomeFixesToBeAppliedPermanently, CommonResources.PermanentChanges, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

		//			if (result != DialogResult.OK)
		//			{
		//				return;
		//			}
		//		}
		//		foreach (ListViewItem selected in _errorsList.SelectedItems)
		//		{
		//			var fixes = GetFixesForItem(selected);

		//			Fix fix = fixes.SingleOrDefault();
		//			if (fix == null)
		//			{
		//				continue;
		//			}

		//			ValidationError error = (ValidationError)selected.Tag;
		//			error.Level = ErrorLevel.Fixed;
		//			fix.Do();
		//			if (fix.ShouldBeConfirmed)
		//				selected.Remove();
		//			else
		//			{
		//				selected.BackColor = Color.LightGreen;
		//				selected.ImageKey = ErrorLevel.Fixed.ToString();
		//			}

		//		}
		//	};
		//	_errorsContextMenuStrip.Items.Add(button);
		//	_errorsContextMenuStrip.ResumeLayout();
		//}

		//private bool ShouldBeConfirmed(IEnumerable selectedListViewItemCollection)
		//{
		//	return selectedListViewItemCollection.Cast<ListViewItem>().Any(ve =>
		//																		{
		//																			var error = (ValidationError)ve.Tag;
		//																			var fixes = error.Fixes;
		//																			return fixes.Count() == 1 && fixes.First().ShouldBeConfirmed;
		//																		});
		//}

		//private bool HasFixes(IEnumerable selectedListViewItemCollection)
		//{
		//	return selectedListViewItemCollection.Cast<ListViewItem>().Any(lvi =>
		//		{
		//			var validationError = lvi.Tag as ValidationError;
		//			return validationError != null && validationError.Fixes.Any();
		//		});
		//}

		//private IEnumerable<Fix> GetFixesForItem(ListViewItem item)
		//{
		//	if (item == null) yield break;
		//	ValidationError error = item.Tag as ValidationError;
		//	if (error != null)
		//	{
		//		foreach (var fix in error.Fixes)
		//		{
		//			yield return fix;
		//		}
		//	}
		//}

		//private void BuildFixesMenuForSingleItem(ListViewItem item)
		//{
		//	_errorsContextMenuStrip.SuspendLayout();
		//	_errorsContextMenuStrip.Items.Clear();
		//	var fixes = GetFixesForItem(item);
		//	ValidationError error = item.Tag as ValidationError;
		//	if (error == null) return;

		//	int counter = 1;
		//	foreach (Fix fix in fixes)
		//	{
		//		Fix currentFix = fix;
		//		var button = new ToolStripButton
		//		{
		//			DisplayStyle = ToolStripItemDisplayStyle.Text,
		//			TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
		//			Text = fix.Title,
		//			Name = "errorFix" + (counter++),
		//			AutoSize = true,
		//			Tag = currentFix,
		//		};
		//		button.Width = TextRenderer.MeasureText(button.Text, button.Font).Width;

		//		button.Click += (senderr, er) =>
		//		{
		//			if (currentFix.ShouldBeConfirmed)
		//			{
		//				var result = MessageBox.Show(MessageResources.WillBeAppliedPermanently, CommonResources.PermanentChanges, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

		//				if (result != DialogResult.OK)
		//				{
		//					return;
		//				}
		//			}

		//			currentFix.Do();
		//			//very substentially refresh UI, because anything including project tree might have changed
		//			var currentProject = CurrentProject;
		//			RefreshUI();
		//			SelectProjectInList(currentProject);
		//			SelectProjectInTree(currentProject);
		//			error.Level = ErrorLevel.Fixed;
		//			if (currentFix.ShouldBeConfirmed)
		//				item.Remove();
		//			else
		//			{
		//				item.BackColor = Color.LightGreen;
		//				item.ImageKey = ErrorLevel.Fixed.ToString();
		//			}
		//		};
		//		_errorsContextMenuStrip.Items.Add(button);
		//	}
		//	_errorsContextMenuStrip.ResumeLayout();
		//}

		//private void ErrorsListKeyDown(object sender, KeyEventArgs e)
		//{
		//	if (e.KeyCode == Keys.A && e.Control)
		//	{
		//		_errorsList.MultiSelect = true;
		//		foreach (ListViewItem item in _errorsList.Items)
		//		{
		//			item.Selected = true;
		//		}
		//	}
		//}

		//private void ErrorsListColumnClick(object sender, ColumnClickEventArgs e)
		//{
		//	if (sender as ListView == null) return;
		//	if (e.Column == _errorListColumnSorter.SortColumn)
		//	{
		//		_errorListColumnSorter.Order = _errorListColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
		//	}
		//	else
		//	{
		//		_errorListColumnSorter.SortColumn = e.Column;
		//		_errorListColumnSorter.Order = SortOrder.Ascending;
		//	}
		//	((ListView)sender).Sort();
		//}


		//private void EditAsTextToolStripMenuItemClick(object sender, EventArgs e)
		//{
		//	var proj = ProjectsRepo.FindFirstProject(_currentProject);

		//	Debug.Assert(proj == _currentProject, "Duplicate projects are found out");
		//	using (PomTextEditorForm form = new PomTextEditorForm((Project)proj))
		//	{
		//		form.ShowDialog();
		//	}
		//	RefreshPropertyGrid();
		//}

		//private void TreePomsNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		//{
		//	if (e.Button == MouseButtons.Right)
		//	{
		//		_treePoms.SelectedNode = e.Node;
		//		ProjectContextMenuStrip.Show(_treePoms, e.Location);
		//	}
		//	else
		//	{
		//		_treePoms.SelectedNode = e.Node;
		//	}
		//}

		//private void ListPomsMouseClick(object sender, MouseEventArgs e)
		//{
		//	if (e.Button == MouseButtons.Right)
		//	{
		//		ProjectContextMenuStrip.Show(_listPoms, e.Location);
		//	}
		//}

		//private void AdvancedEditorToolStripMenuItemClick(object sender, EventArgs e)
		//{
		//	var proj = ProjectsRepo.FindFirstProject(_currentProject);
		//	Debug.Assert(proj == _currentProject, "Duplicate projects are found out");
		//	using (PomAdvancedEditor form = new PomAdvancedEditor(CurrentProjectView, ProjectsRepo))
		//	{
		//		form.ShowDialog();
		//	}
		//	RefreshPropertyGrid();
		//}

		//private void ExternalReferencesManagerToolStripMenuItemClick(object sender, EventArgs e)
		//{
		//	using (ExternalReferenceManagerForm form = new 
		//		ExternalReferenceManagerForm(_solution))
		//	{
		//		form.ShowDialog();
		//	}
		//}

		//private void ProjectTreeMenuOpening(object sender, System.ComponentModel.CancelEventArgs e)
		//{
		//	TreeNode selected = _treePoms.SelectedNode;
		//	if (selected == null || selected.Tag as ProjectView == null)
		//	{
		//		return;
		//	}
		//	ProjectView projectView = (ProjectView) selected.Tag;
			
		//	BuildActionsContextMenu(projectView);
		//}

		//private void BuildActionsContextMenu(ProjectView projectView)
		//{
		//	ProjectContextMenuStrip.SuspendLayout();
		//	ProjectContextMenuStrip.Items.Clear();
		//	foreach (var contextAction in _actionsList)
		//	{
		//		if (!contextAction.IsApplicable(projectView.Project)) continue;
		//		contextAction.Source = projectView.Project;
		//		var button = new ToolStripButton
		//			{
		//				DisplayStyle = ToolStripItemDisplayStyle.Text,
		//				TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
		//				Text = contextAction.Title,
		//				Width = 150,
		//				AutoSize = true,
		//			};
		//		ContextAction cAction = contextAction;
		//		button.Click += (senderr, er) => cAction.Do();
		//		ProjectContextMenuStrip.Items.Add(button);
		//	}
		//	ProjectContextMenuStrip.ResumeLayout();
		//}

		//private List<ContextAction> GetActions()
		//{
		//	List<ContextAction> actionsList = new List<ContextAction>();
		//	ContextAction action = new ContextAction
		//		{
		//			IsApplicable = p => true,
		//			DelegatedAction = source =>
		//				{
		//					var proj = ProjectsRepo.FindFirstProject(source);
		//					using (PomTextEditorForm form = new PomTextEditorForm((Project)proj))
		//					{
		//						form.ShowDialog();
		//					}
		//					RefreshPropertyGrid();
		//				},
		//			Title = "Edit as text",
		//		};
		//	actionsList.Add(action);
		//	action = new ContextAction
		//		{
		//			IsApplicable = p => true,
		//			DelegatedAction = source =>
		//				{
		//					var proj = ProjectsRepo.FindFirstProject(source);
		//					using (PomAdvancedEditor form = new PomAdvancedEditor(CurrentProjectView, ProjectsRepo))
		//					{
		//						form.ShowDialog();
		//					}
		//					RefreshPropertyGrid();
		//				},
		//			Title = "Advanced editor",
		//		};
		//	actionsList.Add(action);
			
		//	return actionsList;

		//	// REVIEW: add cascade switch to snapshot for release projects
		//}


		//private void AddSnapshotToAllSelectedNodes(object sender, EventArgs e)
		//{
		//	SetSnapshotToAllSelectedNodes(true);
		//}

		//private void RemoveSnapshotToAllSelectedNodes(object sender, EventArgs e)
		//{
		//	SetSnapshotToAllSelectedNodes(false);
		//}

		//private void VersionIncrementFirstNumberClick(object sender, EventArgs e)
		//{
		//	VersionIncrementOfSelectedProjects(0);
		//}

		//private void VersionIncrementSecondNumberClick(object sender, EventArgs e)
		//{
		//	VersionIncrementOfSelectedProjects(1);
		//}

		//private void VersionIncrementThirdNumberClick(object sender, EventArgs e)
		//{
		//	VersionIncrementOfSelectedProjects(2);
		//}

		//private void VersionIncrementOfSelectedProjects(int position)
		//{
		//	if (!Multiselect)
		//	{
		//		ShowWarning("Multiselect mode has to be enabled");
		//		return;
		//	}

		//	_listPoms.BeginUpdate();
		//	_treePoms.BeginUpdate();

		//	foreach (var prjView in _views.AllViews.Where(v => v.Checked))
		//	{
		//		prjView.IncrementVersion(position);
		//	}

		//	_listPoms.EndUpdate();
		//	_treePoms.EndUpdate();

		//	RefreshPropertyGrid();
		//	UpdateAllProjectViews();
		//}

		//private void CascadeSwitchToSnapshotOnClick(object sender, EventArgs e)
		//{
		//	if (CurrentProjectView == null)
		//		return;

		//	_listPoms.BeginUpdate();
		//	_treePoms.BeginUpdate();

		//	try
		//	{
		//		var action = new CascadeSwitchAction(ProjectsRepo);
		//		action.ExecuteFor(CurrentProjectView.ProjectNode);
		//	}
		//	finally
		//	{
		//		_listPoms.EndUpdate();
		//		_treePoms.EndUpdate();
		//	}

		//	RefreshPropertyGrid();
		//	UpdateAllProjectViews();
		//}

		//private void ReleaseAllSnapshotsOnClick(object sender, EventArgs e)
		//{
		//	VersionDialog dialog = new VersionDialog();
		//	if (dialog.ShowDialog() != DialogResult.OK)
		//		return;

		//	_listPoms.BeginUpdate();
		//	_treePoms.BeginUpdate();

		//	try
		//	{
		//		var action = new BulkSwitchToReleaseAction(_views, ProjectsRepo, dialog.Version);
		//		action.Execute();
		//	}
		//	finally
		//	{
		//		_listPoms.EndUpdate();
		//		_treePoms.EndUpdate();
		//	}

		//	RefreshPropertyGrid();
		//	UpdateAllProjectViews();
		//}
	}
}
