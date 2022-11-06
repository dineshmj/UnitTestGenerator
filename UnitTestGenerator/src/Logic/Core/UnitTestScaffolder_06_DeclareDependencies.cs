using System.Text;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void DeclareDependenciesIfRelevant (StringBuilder builder)
		{
			// Libraries.
			var mocker = this.utGen.MockLibraryProvider;

			// Context details.
			var isConstructor = this.context.IsConstructor;
			var paramTypes = this.context.ParameterTypes;
			var paramsCount = paramTypes.Count;
			var dependencies = this.context.Dependencies;
			var dependencyCount = dependencies.Count;

			// User options.
			var addFriendlyComments = this.utGen.AddFriendlyComments;

			if (isConstructor)
			{
				// Dependencies of the target class's constructor method.
				if (paramsCount > 0)
				{
					if (addFriendlyComments)
					{
						builder.AppendLine ("\t\t// Mocked dependencies of this Constructor.");
					}

					// This is a specific constructor. Arguments and their order matter.
					foreach (var oneParamType in paramTypes)
					{
						var dependency = this.context.FindDependency (oneParamType);

						if (null != dependency)
						{
							builder.AppendLine ($"\t\t{ mocker.DeclareDependency (dependency) }");
						}
					}

					builder.Append ("\r\n");
				}
			}
			else
			{
				// It is a method, not a constructor.
				if (dependencyCount > 0)
				{
					if (addFriendlyComments)
					{
						builder.AppendLine ("\t\t// Mocked dependencies.");
					}

					// Proceed with declaring of parameters required for the greediest constructor.
					foreach (var dependency in dependencies)
					{
						builder.AppendLine ($"\t\t{mocker.DeclareDependency (dependency)}");
					}

					builder.Append ("\r\n");
				}
			}
		}
	}
}