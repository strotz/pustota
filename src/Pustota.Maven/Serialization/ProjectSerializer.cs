using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Pustota.Maven.Models;
using Pustota.Maven.Serialization.Data;

namespace Pustota.Maven.Serialization
{
	public interface IProjectSerializer
	{
		IProject Deserialize(string content);
		string Serialize(IProject project);
	}

	internal class ProjectSerializer : IProjectSerializer
	{
		private readonly IDataFactory _dataFactory;

		public ProjectSerializer(IDataFactory dataFactory)
		{
			_dataFactory = dataFactory;
		}

		public IProject Deserialize(string content)
		{
			var document = XDocument.Parse(content, LoadOptions.PreserveWhitespace);
			var pom = new ProjectObjectModel(document);
			var project = _dataFactory.CreateProject();
			LoadProject(pom, project);
			return project;
		}

		public string Serialize(IProject project)
		{
			var pom = new ProjectObjectModel();
			SaveProject(project, pom);
			return pom.ToString();
		}


		// REVIEW: element is not ProjectObjectModel, it is wrapper XElement (dependency, parent)
		internal void LoadProjectReference(ProjectObjectModel pom, XElement startElement, IProjectReference projectReference)
		{
			projectReference.ArtifactId = pom.ReadElementValueOrNull(startElement, "artifactId");
			projectReference.GroupId = pom.ReadElementValueOrNull(startElement, "groupId");
			projectReference.Version = pom.ReadElementValueOrNull(startElement, "version");
		}

		// REVIEW: element is not ProjectObjectModel, it is wrapper XElement (dependency, parent)
		internal void SaveProjectReference(IProjectReference projectReference, ProjectObjectModel pom, XElement startElement)
		{
			pom.SetElementValue(startElement, "groupId", projectReference.GroupId);
			pom.SetElementValue(startElement, "artifactId", projectReference.ArtifactId);
			pom.SetElementValue(startElement, "version", projectReference.Version);
		}

		internal void LoadParentReference(ProjectObjectModel pom, IProject project)
		{
			var parentElement = pom.ReadElementOrNull("parent");
			if (parentElement == null)
			{
				project.Parent = null;
			}
			else
			{
				var parentReference = _dataFactory.CreateParentReference();
				LoadProjectReference(pom, parentElement, parentReference);
				parentReference.RelativePath = pom.ReadElementValueOrNull(parentElement, "relativePath");
				project.Parent = parentReference;
			}
		}

		internal void SaveParentReference(IProject project, ProjectObjectModel pom)
		{
			IParentReference parentReference = project.Parent;
			if (parentReference == null)
			{
				pom.RemoveElement("parent");
			}
			else
			{
				var parentElement = pom.SingleOrCreate(pom.RootElement, "parent");
				SaveProjectReference(parentReference, pom, parentElement);
				pom.SetElementValue(parentElement, "relativePath", parentReference.RelativePath);
			}
		}


		internal void LoadProject(ProjectObjectModel pom, IProject project)
		{
			LoadProjectReference(pom, pom.RootElement, project);
			LoadParentReference(pom, project);

			project.Packaging = pom.ReadElementValueOrNull("packaging");
			project.Name = pom.ReadElementValueOrNull("name");
			project.ModelVersion = pom.ReadElementValueOrNull("modelVersion");

			//_container.LoadFromElement(element);

			////load profiles
			//Profiles = element.ReadElements("profiles", "profile")
			//	.Select(e => _dataFactory.CreateProfile(e)).ToList();
		}

		internal void SaveProject(IProject project, ProjectObjectModel pom)
		{
			// XElement root = element.RootElement;

			SaveProjectReference(project, pom, pom.RootElement);
			SaveParentReference(project, pom);

			pom.SetElementValue("packaging", project.Packaging);
			pom.SetElementValue("name", project.Name);
			pom.SetElementValue("modelVersion", project.ModelVersion);

			//_container.SaveToElement(root);

			////writing profiles
			//var profileNode = pom.SingleOrCreate("profiles");
			//if (!Profiles.Any())
			//{
			//	profileNode.Remove();
			//}
			//else
			//{
			//	HashSet<PomXmlElement> usedElements = new HashSet<PomXmlElement>();
			//	foreach (Profile prof in Profiles)
			//	{
			//		var profElement = profileNode.Elements.FirstOrDefault(e => e.ReadElementValue("id") == prof.Id) ??
			//								profileNode.CreateElement("profile");

			//		usedElements.Add(profElement);
			//		prof.SaveToElement(profElement);
			//	}

			//	//delete all profiles elements which are not in the Profiles array
			//	foreach (var profElem in profileNode.Elements.Where(e => !usedElements.Contains(e)))
			//		profElem.Remove();
			//}
		}

	}
}
