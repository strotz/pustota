using System;
using System.Windows.Forms;
using Pustota.Maven.Externals;
using Pustota.Maven.Serialization.Data;

namespace Pustota.Maven.UI.Forms
{
	partial class ExternalReferenceManagerForm : Form
	{
		// REVIEW: remove 
		private readonly IProjectsRepository _repository;
		private readonly IExternalModulesRepository _externalModules;

		private IDataFactory _dataFactory;

		public ExternalReferenceManagerForm(ISolution solution, IExternalModulesRepository externalModules)
		{
			if (solution == null)
				throw new ArgumentNullException("solution");

			// REVIEW: encapsulate
			_repository = solution;
			_externalModules = externalModules;

			InitializeComponent();
			
			PopulateMavenExternalGrid();
		}

		private void PopulateMavenExternalGrid()
		{
			dataGridViewMavenExternal.DataSource = new BindingSource {DataSource = _externalModules.Items};
		}

		private void UpdateView()
		{
			BindingSource bs = dataGridViewMavenExternal.DataSource as BindingSource;
			if (bs != null)
				bs.ResetBindings(true);
		}

		private void ButtonAddMavenExternalClick(object sender, EventArgs e)
		{
			_dataFactory.CreateExternalModule();
			_externalModules.Add(_dataFactory.CreateExternalModule());
			
			UpdateView();
		}

		private void ButtonDeleteMavenExternalClick(object sender, EventArgs e)
		{
			//BindingSource bs = dataGridViewMavenExternal.DataSource as BindingSource;
			//if (bs != null)
			//{
			//	ExternalModule externalModule = bs.Current as ExternalModule;
			//	if (externalModule != null)
			//	{
			//		_externalModules.Remove(externalModule);
			//		bs.ResetBindings(true);
			//	}
			//}
		}

		private void ExternalReferenceManagerFormFormClosing(object sender, FormClosingEventArgs e)
		{
			//dataGridViewMavenExternal.EndEdit();
			//var result = MessageBox.Show(MessageResources.DoYouWantToSaveChanges,
			//		CommonResources.PermanentChanges, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
			//switch (result)
			//{
			//	case DialogResult.Yes:
			//		_externalModules.AllModules.Save();
			//		break;
			//	case DialogResult.Cancel:
			//		e.Cancel = true;
			//		break;
			//}
		}

		private void DataGridViewMavenExternalRowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			//var currentRow = dataGridViewMavenExternal.Rows[e.RowIndex];
			//var current = currentRow.DataBoundItem as ExternalModule;
			//if (current != null)
			//	DecorateRow(currentRow, !_repository.IsItUsed(current));
		}

		private void DecorateRow(DataGridViewRow currentRow, bool isObsoleted)
		{
			//currentRow.DefaultCellStyle.BackColor = isObsoleted ? Color.LightGray : Color.White;
		}
	}
}

