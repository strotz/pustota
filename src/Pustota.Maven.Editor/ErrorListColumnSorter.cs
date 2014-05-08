using System;
using System.Collections;
using System.Windows.Forms;
using Pustota.Maven.Editor.Models;
using Pustota.Maven.Editor.Validations;

namespace Pustota.Maven.Editor
{
	class ErrorListColumnSorter : IComparer
	{
		private readonly CaseInsensitiveComparer _objectCompare;

		public int SortColumn { get; set; }
		public SortOrder Order { get; set; }

		public ErrorListColumnSorter()
		{
			SortColumn = 0;
			Order = SortOrder.None;
			_objectCompare = new CaseInsensitiveComparer();
		}

		public int Compare(object x, object y)
		{
			int compareResult;
			ListViewItem listviewX = (ListViewItem)x;
			ListViewItem listviewY = (ListViewItem)y;
			
			if (SortColumn == 0) //image
			{
				try
				{
					var objx = (ErrorLevel)Enum.Parse(typeof(ErrorLevel), listviewX.ImageKey);
					var objy = (ErrorLevel)Enum.Parse(typeof(ErrorLevel), listviewY.ImageKey);
					compareResult = _objectCompare.Compare(objx, objy);
				}
				catch (OverflowException)
				{
					throw new OverflowException("ErrorListView: The listViewItem have to get a proper imageKey");
				}	
			}
			else
			{
				int obj1, obj2;
				bool xIsInt = int.TryParse(listviewX.SubItems[SortColumn].Text, out obj1);
				bool yIsInt = int.TryParse(listviewY.SubItems[SortColumn].Text, out obj2);

				if (xIsInt||yIsInt)
				{
					compareResult = _objectCompare.Compare(obj1, obj2);
				}
				else
				{
					compareResult = _objectCompare.Compare(listviewX.SubItems[SortColumn].Text, listviewY.SubItems[SortColumn].Text);
				}
			}
			switch (Order)
			{
				case SortOrder.Ascending:
					return compareResult;
				case SortOrder.Descending:
					return (-compareResult);
				default:
					return 0;
			}
		}
	}
}
