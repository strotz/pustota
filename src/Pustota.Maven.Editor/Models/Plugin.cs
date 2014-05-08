using Pustota.Maven.Editor.PomXml;

namespace Pustota.Maven.Editor.Models
{
	class Plugin :
		ProjectReference,
		IPlugin
	{
		private PomXmlElement Executions { get; set; }
		private PomXmlElement Configuration { get; set; }

		internal protected override void LoadFromElement(PomXmlElement element)
		{
			base.LoadFromElement(element);
			Executions = element.ReadElement("executions");
			Configuration = element.ReadElement("configuration");
		}

		protected internal override void SaveToElement(PomXmlElement element)
		{
			base.SaveToElement(element);

			if (Executions != null)
				element.AddElement(Executions);

			if (Configuration != null)
				element.AddElement(Configuration);
		}
	}
}