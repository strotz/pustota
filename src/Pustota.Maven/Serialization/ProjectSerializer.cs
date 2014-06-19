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
	internal class ProjectSerializer
	{
		// REVIEW: element is not ProjectObjectModel, it is wrapper XElement 
		internal void LoadProjectReference(ProjectObjectModel element, IProjectReference projectReference)
		{
			projectReference.ArtifactId = element.ReadElementValueOrNull("artifactId");
			projectReference.GroupId = element.ReadElementValueOrNull("groupId");
			projectReference.Version = element.ReadElementValueOrNull("version");
		}

		internal void SaveProjectReference(IProjectReference projectReference, ProjectObjectModel element)
		{
			element.SetElementValue("groupId", projectReference.GroupId);
			element.SetElementValue("artifactId", projectReference.ArtifactId);
			element.SetElementValue("version", projectReference.Version);
		}

		internal void LoadProject(ProjectObjectModel element, IProject project)
		{
			LoadProjectReference(element, project);

			//Packaging = element.ReadElementValue("packaging");
			//Name = element.ReadElementValue("name");
			//ModelVersion = element.ReadElementValue("modelVersion");

			////read parent
			//var parentNode = element.ReadElement("parent");
			//Parent = parentNode == null ? null : _dataFactory.CreateParentReference(parentNode);

			//_container.LoadFromElement(element);

			////load profiles
			//Profiles = element.ReadElements("profiles", "profile")
			//	.Select(e => _dataFactory.CreateProfile(e)).ToList();
		}

		internal void SaveProject(IProject project, ProjectObjectModel element)
		{
			// XElement root = element.RootElement;

			SaveProjectReference(project, element);

			//root.SetElementValue("packaging", Packaging);
			//root.SetElementValue("name", Name);
			//root.SetElementValue("modelVersion", ModelVersion);

			////writing parent
			//var parentNode = pom.ReadOrCreateElement("parent");
			//if (Parent == null)
			//{
			//	parentNode.Remove();
			//}
			//else
			//{
			//	((ParentReference)Parent).SaveToElement(parentNode);
			//}

			//_container.SaveToElement(root);

			////writing profiles
			//var profileNode = pom.ReadOrCreateElement("profiles");
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
