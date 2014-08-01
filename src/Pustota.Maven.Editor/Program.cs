using System;
using System.Windows.Forms;
using Pustota.Maven.Editor.Resources;

namespace Pustota.Maven.Editor
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			// Application.Run(new MainForm());
		}

		static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			var exception = e.ExceptionObject as Exception;
			if (exception != null)
				MessageBox.Show(string.Format("{0}\nStack Trace:\n{1}", exception.Message, exception.StackTrace), CommonResources.UnhandledException);
		}
	}
}
