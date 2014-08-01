using System;
using System.Windows.Forms;

namespace Pustota.Maven.Editor
{
	partial class EditorControl : UserControl
	{
		private BindingSource _bindingSource;
		private readonly int _maxRowsAllowed;

		public EditorControl()
		{
			InitializeComponent();
		}

		public EditorControl(BindingSource source, int maxRowsAllowed, Func<object> addNewDelegate) : this()
		{
			
			_bindingSource = source;
			_maxRowsAllowed = maxRowsAllowed;
			dataGridView.DataSource = source;
			_bindingSource.AddingNew += (o, args) => { args.NewObject = addNewDelegate(); };
		}

		public event DataGridViewEditingControlShowingEventHandler EditingControlShowing
		{
			add
			{
				dataGridView.EditingControlShowing += value;
			}
			remove
			{
				dataGridView.EditingControlShowing -= value;
			}
		}

		private void ButtonAddNewClick(object sender, EventArgs e)
		{
			if(_bindingSource.AllowNew && dataGridView.Rows.Count < _maxRowsAllowed)
				_bindingSource.AddNew();
		}

		private void ButtonDeleteRowClick(object sender, EventArgs e)
		{
			if (_bindingSource.Current != null && _bindingSource.AllowRemove)
			{
				_bindingSource.RemoveCurrent();
			}
		}

		public void SetGridDataSource(BindingSource source)
		{
			dataGridView.DataSource = source;
			_bindingSource = source;
		}
	}
}
