using System;
using System.Windows.Forms;
using Pustota.Maven.Editor.Models;
using Pustota.Maven.Editor.Resources;

namespace Pustota.Maven.Editor
{
	// REVIEW: WPF and binding?
	partial class PomTextEditorForm : Form
	{
		private readonly Project _currentProject;
		private bool _textIsChanged;

		private bool ChangesAreSaved
		{
			get { return !_textIsChanged; }
			set { _textIsChanged = !value; }
		}

		public PomTextEditorForm(Project currentProject)
		{
			InitializeComponent();
			MouseWheel += PomEditorTextBoxMouseWheel;
			
			_currentProject = currentProject;

			pomTextEditorToolStripStatusLabel.Text = currentProject.ToString();
			
			FillTextBox();
		}

		private void FillTextBox()
		{
			PomEditorTextBox.Text = _currentProject.Text;
			_textIsChanged = false;
		}

		private void PomEditorTextBoxMouseWheel(object sender, MouseEventArgs e)
		{
			if (e.Delta != 0 && ModifierKeys == Keys.Control)
				((RichTextBox) sender).ZoomFactor += e.Delta;
		}

		private void ApplyChangesToDocument()
		{
			try
			{
				_currentProject.Text = PomEditorTextBox.Text;
				ChangesAreSaved = true;
			}
			catch (ArgumentException e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			ApplyChangesToDocument();
		}

		private void CloseToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}

		private void ReloadToolStripMenuItemClick(object sender, EventArgs e)
		{
			FillTextBox();
		}

		private void PomEditorTextBoxTextChanged(object sender, EventArgs e)
		{
			_textIsChanged = true;
		}

		private void PomTextEditorFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (!ChangesAreSaved)
			{
				var result = MessageBox.Show(string.Format("Do you want to apply changes to {0}?", _currentProject), CommonResources.PomTextEditorLable, MessageBoxButtons.YesNoCancel);
				if (result == DialogResult.Yes)
					ApplyChangesToDocument();
				if (result == DialogResult.Cancel)
					e.Cancel = true;
			}
		}
	}
}
