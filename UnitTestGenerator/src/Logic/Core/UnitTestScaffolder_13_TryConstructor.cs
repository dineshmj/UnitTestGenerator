using System.Net.Sockets;
using System.Text;

using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void AddTryConstructorBlock (StringBuilder builder, string additionalIndent)
		{
			// Libraries.
			var mocker = this.utGen.MockLibraryProvider;

			// Context.
			var paramTypes = this.context.ParameterTypes;
			var paramCount = paramTypes.Count;
			var declaringTypeName = this.context.DeclaringTypeName;
			var targetFieldName = declaringTypeName.ToCamelCase ();

			builder.AppendLine ($@"			{additionalIndent}try
			{additionalIndent}{{");
			builder.Append ($"\t\t\t\t{additionalIndent}this.{targetFieldName}");

			var atLeastOneParameterAdded = false;

			if (paramCount > 0)
			{
				builder.AppendLine ();
				builder.AppendLine ($"\t\t\t\t\t{additionalIndent}= new {declaringTypeName}");
				builder.AppendLine ($"\t\t\t\t\t\t{additionalIndent}(");

				foreach (var oneParamType in paramTypes)
				{
					if (atLeastOneParameterAdded)
					{
						builder.AppendLine (",");
					}

					var dependency = this.context.FindDependency (oneParamType);

					if (null != dependency)
					{
						builder.Append ($"\t\t\t\t\t\t\t{additionalIndent}{mocker.GetMockedObject (dependency)}");
						atLeastOneParameterAdded = true;
					}
				}

				builder.AppendLine ();
				builder.AppendLine ($"\t\t\t\t\t\t{additionalIndent});");
			}
			else
			{
				builder.AppendLine ($"= new ();");
			}

			builder.AppendLine (additionalIndent + $@"			}}
			{additionalIndent}catch (Exception ex)
			{additionalIndent}{{
				{additionalIndent}this.caughtException = ex;
			{additionalIndent}}}");
		}
	}
}