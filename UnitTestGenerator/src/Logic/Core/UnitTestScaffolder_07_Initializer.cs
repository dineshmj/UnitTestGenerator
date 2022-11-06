using System.Text;

using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void AddInitializerMethodIfRegularMethod (StringBuilder builder)
		{
			// Typically, you need an initializer only if it is a regular method.
			// If it is a constructor, your Unit Test wouldn't mostly require an initializer.
			//
			// Add Initializer method only for methods.

			// Libraries.
			var utProvider = this.utGen.UtLibraryProvider;
			var mocker = this.utGen.MockLibraryProvider;

			// Context.
			var isTargetStatic = this.utGen.TargetMethodCallContext.DeclaringType.IsStatic ();
			var dependencies = this.context.Dependencies;
			var targetClassName = this.context.DeclaringTypeName;
			var targetFieldName = targetClassName.ToCamelCase ();
			var isConstructor = this.context.IsConstructor;

			if (isConstructor == false)
			{
				// Decorator attribute for Initializer.
				var initDecorator = utProvider.GetInitializeMethodDecorator ();

				if (!String.IsNullOrEmpty (initDecorator))
				{
					builder.AppendLine ($"\t\t{initDecorator}");
				}

				// Initializer method signature.
				var initMethod = utProvider.GetInitializeMethodSignature ();

				if (String.IsNullOrEmpty (initMethod))
				{
					// There is no initializer method for this UT library.
					// Proceed with generating a constructor that instantiates the
					// target class with its greediest constructor instead.
					builder.AppendLine ($"\t\tpublic {this.GetUnitTestClassName ()} ()");
				}
				else
				{
					// There is an initializer for this UT library.
					builder.AppendLine ($"\t\t{initMethod}");
				}

				builder.AppendLine ($"\t\t{{");

				if (dependencies.Count > 0)
				{
					// Assign the dependencies with mocked instances.
					foreach (var oneDependency in dependencies)
					{
						builder.AppendLine ($"\t\t\t{mocker.AssignDependency (oneDependency)}");
					}

					builder.AppendLine ();

					// Spawn the target class.
					builder.AppendLine ($"\t\t\tthis.{targetFieldName} = new {targetClassName}");
					builder.AppendLine ($"\t\t\t\t(");

					var atLeastOneParamAdded = false;

					foreach (var oneDependency in dependencies)
					{
						if (atLeastOneParamAdded)
						{
							builder.AppendLine (",");
						}

						builder.Append ($"\t\t\t\t\t{mocker.GetMockedObject (oneDependency)}");
						atLeastOneParamAdded = true;
					}

					builder.AppendLine ();
					builder.AppendLine ($"\t\t\t\t);");
				}
				else
				{
					if (isTargetStatic == false)
					{
						// There are no dependencies for the target class.
						builder.AppendLine ($"\t\t\tthis.{targetFieldName} = new ();");
					}
				}

				builder.AppendLine ($"\t\t}}\r\n");
			}
		}
	}
}