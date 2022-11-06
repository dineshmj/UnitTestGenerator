using System.Reflection;

namespace UnitTestGenerator.Logic.Entities
{
	public sealed class DependencyCallInfo
	{
		public MethodBase Method { get; }

		public IList<Type> ParameterTypes { get; }

		public DependencyInfo Dependency { get; }

		public DependencyCallInfo (MethodBase method, IList<Type> parameterTypes, DependencyInfo dependency)
		{
			this.Method = method;
			this.ParameterTypes = parameterTypes;
			this.Dependency = dependency;
		}
	}
}