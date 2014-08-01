using System.Windows.Forms;

namespace Pustota.Maven.Editor
{
	public partial class VersionDialog : Form
	{
		public string Version
		{
			get { return tbVersion.Text; }
			set { tbVersion.Text = value; }
		}

		public VersionDialog()
		{
			InitializeComponent();
		}
	}
}
