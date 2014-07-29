using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	class ProjecModulesValidation : IProjectValidator
	{
		public IEnumerable<ValidationProblem> Validate(ValidationContext context, IProject project)
		{
			//string baseDir = Path.GetDirectoryName(project.FullPath);
			//if (baseDir == null) continue;
			//foreach (var module in project.AllModules)
			//{
			//	string moduleFolderPath = Path.Combine(baseDir, module.Path);
			//	if (!Directory.Exists(moduleFolderPath))
			//	{
			//		string details = string.Format("Project contains a module '{0}' but corresponding folder doesn't exist.", module.Path);
			//		ValidationErrors.Add(new ValidationError(project, "Module folder doesn't exists", details, ErrorLevel.Error));
			//		continue;
			//	}

			//	string moduleProjectPath = Path.GetFullPath(Path.Combine(moduleFolderPath, ProjectsRepository.ProjectFilePattern));
			//	if (!File.Exists(moduleProjectPath))
			//	{
			//		string details = string.Format("Project contains a module '{0}' but the folder doesn't contain a pom.xml.", module.Path);
			//		ValidationErrors.Add(new ValidationError(project, "Module project doesn't exists", details, ErrorLevel.Error));
			//		continue;
			//	}

			//	if (_repository.AllProjects.FirstOrDefault(p => PathOperations.ArePathesEqual(moduleProjectPath, p.FullPath)) == null)
			//	{
			//		string details = string.Format("Project contains a module '{0}', but corresponding project hasn't been loaded", module.Path);
			//		var fix = new DelegatedFix
			//		{
			//			Title = "Try to load the module",
			//			DelegatedAction = () => _repository.LoadOneProject(moduleProjectPath)
			//		};
			//		var error = new ValidationError(project, "Module hasn't been loaded", details, ErrorLevel.Error);
			//		error.AddFix(fix);
			//		ValidationErrors.Add(error);
			//		continue;
			//	}
			//}

			throw new NotImplementedException();
		}
	}
}
