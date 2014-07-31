using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using Pustota.Maven.Editor.Models;

namespace Pustota.Maven.Editor.ViewModels
{
	internal class ProjectView
	{
		private TreeNode _treeNode;
		private ListViewItem _listItem;
		private bool _showSnapshotIcon;
		private bool _checked;

		//private readonly Project _project;
		//private readonly ProjectNode _projectNode;

		//[Browsable(false)]
		//public Project Project
		//{
		//	get { return _project; }
		//}

		//[Browsable(false)]
		//public ProjectNode ProjectNode
		//{
		//	get { return _projectNode; }
		//}

		//public string FullPath
		//{
		//	get
		//	{
		//		return _project.FullPath;
		//	}
		//}

		//public string ArtifactId
		//{
		//	get
		//	{
		//		return _project.ArtifactId;
		//	}
		//	set
		//	{
		//		if (ArtifactId != value)
		//		{
		//			_project.ArtifactId = value;
		//			MarkChanged();
		//			UpdateViews();
		//		}
		//	}
		//}

		//public string GroupId
		//{
		//	get { return _project.GroupId; }
		//	set
		//	{
		//		if (GroupId != value)
		//		{
		//			_project.GroupId = value;
		//			MarkChanged();
		//			UpdateViews();
		//		}
		//	}
		//}

		//public string Version
		//{
		//	get
		//	{
		//		return _projectNode.Version;
		//	}
		//	set
		//	{
		//		if (_projectNode.Version != value)
		//		{
		//			_projectNode.Version = value;
		//			UpdateViews();
		//		}
		//	}
		//}

		//[Browsable(false)]
		//public bool Checked
		//{
		//	get
		//	{
		//		return _checked;
		//	}
		//	set
		//	{
		//		if(_checked == value) return;
		//		_checked = value;
		//		UpdateViews();
		//	}
		//}

		//[Browsable(false)]
		//public bool IsSnapshot
		//{
		//	get { return ProjectNode.IsSnapshot; }
		//	set
		//	{
		//		if (ProjectNode.IsSnapshot != value)
		//		{
		//			ProjectNode.IsSnapshot = value;
		//			UpdateViews();
		//		}
		//	}
		//}

		//public void IncrementVersion(int position)
		//{
		//	Version = VersionOperations.IncrementNumber(Version, position);
		//}

		//[Browsable(false)]
		//public bool ShowSnapshotIcon
		//{
		//	get
		//	{
		//		return _showSnapshotIcon;
		//	}
		//	set
		//	{
		//		_showSnapshotIcon = value;
		//		UpdateViews();
		//	}
		//}

		//public string Name
		//{
		//	get { return _project.Name; }
		//	set
		//	{
		//		if (Name != value)
		//		{
		//			_project.Name = value;
		//			MarkChanged();
		//			UpdateViews();
		//		}
		//	}
		//}
		//public string Packaging
		//{
		//	get { return _project.Packaging; }
		//	set
		//	{
		//		if (Packaging != value)
		//		{
		//			_project.Packaging = value;
		//			MarkChanged();
		//			UpdateViews();
		//		}
		//	}
		//}
		//public List<IModule> Modules
		//{
		//	get { return _project.Modules; }
		//	set
		//	{
		//		if (Modules != value)
		//		{
		//			_project.Modules = value;
		//			MarkChanged();
		//			UpdateViews();
		//		}
		//	}
		//}
		//public List<IProperty> Properties
		//{
		//	get { return _project.Properties; }
		//	set
		//	{
		//		if (Properties != value)
		//		{
		//			_project.Properties = value;
		//			MarkChanged();
		//			UpdateViews();
		//		}
		//	}
		//}
		//public IParentReference Parent
		//{
		//	get { return _project.Parent; }
		//	set
		//	{
		//		if (Parent != value)
		//		{
		//			_project.Parent = value;
		//			MarkChanged();
		//			UpdateViews();
		//		}
		//	}
		//}

		//public List<IDependency> Dependencies
		//{
		//	get { return _project.Dependencies; }
		//	set
		//	{
		//		if (Dependencies != value)
		//		{
		//			_project.Dependencies = value;
		//			MarkChanged();
		//			UpdateViews();
		//		}
		//	}
		//}

		//public List<IProfile> Profiles
		//{
		//	get { return _project.Profiles; }
		//	set
		//	{
		//		if (Profiles != value)
		//		{
		//			_project.Profiles = value;
		//			MarkChanged();
		//			UpdateViews();
		//		}
		//	}
		//}

		//public List<IPlugin> Plugins
		//{
		//	get { return _project.Plugins; }
		//	set
		//	{
		//		if (Plugins != value)
		//		{
		//			_project.Plugins = value;
		//			MarkChanged();
		//			UpdateViews();
		//		}
		//	}
		//}

		//public List<IPlugin> PluginManagement
		//{
		//	get { return _project.PluginManagement; }
		//	set
		//	{
		//		if (Plugins != value)
		//		{
		//			_project.PluginManagement = value;
		//			MarkChanged();
		//			UpdateViews();
		//		}
		//	}
		//}


		//public ProjectView(ProjectNode projectNode)
		//{
		//	if (projectNode == null)
		//		throw new ArgumentNullException("projectNode");

		//	_projectNode = projectNode;
		//	_project = projectNode.Project;
		//}

		//public TreeNode CreateTreeNode()
		//{
		//	if (_treeNode != null)
		//	{
		//		return _treeNode;
		//	}
		//	_treeNode = new TreeNode
		//	{
		//		Text = string.Format("{0}:{1}", GroupId, ArtifactId),
		//		ToolTipText = Name,
		//		Tag = this,
		//		ImageKey = GetImageKey(),
		//		SelectedImageKey = GetImageKey(),
		//		Checked = false
		//	};
		//	return _treeNode;
		//}

		//private string GetImageKey()
		//{
		//	if (ShowSnapshotIcon)
		//	{
		//		return IsSnapshot ? "snapshot" : "release";
		//	}
		//	return new ProjectTypeMapService().ResolveTypeName(_projectNode.Project);
		//}

		//public void MarkChanged()
		//{
		//	_projectNode.Changed = true;
		//}

		//public ListViewItem CreateListItem()
		//{
		//	if (_listItem != null)
		//		return _listItem;

		//	_listItem = new ListViewItem(GroupId)
		//	{
		//		Tag = this,
		//		ToolTipText = Name,
		//		ImageKey = GetImageKey()
		//	};
		//	_listItem.SubItems.Add(ArtifactId);
		//	_listItem.SubItems.Add(Version);
		//	return _listItem;
		//}

		//public void UpdateViews()
		//{
		//	if (_treeNode != null)
		//	{
		//		_treeNode.Text = string.Format("{0}:{1}", GroupId, ArtifactId);
		//		_treeNode.ImageKey = GetImageKey();
		//		_treeNode.SelectedImageKey = GetImageKey();
		//		_treeNode.ForeColor = _project.Changed ? Color.DarkGreen : SystemColors.ControlText;
		//		_treeNode.Checked = _checked;
		//	}

		//	if (_listItem != null)
		//	{
		//		_listItem.Text = GroupId;
		//		_listItem.SubItems[1].Text = ArtifactId;
		//		_listItem.SubItems[2].Text = Version;
		//		_listItem.ImageKey = GetImageKey();
		//		_listItem.ForeColor = _project.Changed ? Color.DarkGreen : SystemColors.ControlText;
		//		_listItem.Checked = _checked;
		//	}
		//}
	}
}
