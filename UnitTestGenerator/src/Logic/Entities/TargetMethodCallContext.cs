using System.Reflection;
using System.Runtime.CompilerServices;
using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Entities
{
    public sealed class TargetMethodCallContext
	{
		public Type DeclaringType { get; private set; }

		public string DeclaringTypeName { get; private set; }

		public bool IsConstructor { get; private set; }

		public bool IsExtension { get; private set; }

		public string MethodName { get; private set; }

		public string OverloadRankText { get; private set; }

		public IList<DependencyInfo> Dependencies { get; }

		public IList<DependencyCallInfo> DependencyCalls { get; }

		public IList<Type> ParameterTypes { get; }

		public PublicMember PublicMember { get; }

		public Type MethodReturnType
		{
			get
			{
				var method = this.PublicMember.ReflectedMemberInfo as MethodInfo;

				if (null != method)
				{
					return method.ReturnType;
				}

				return typeof (void);
			}
		}

		public TargetMethodCallContext
			(
				PublicMember publicMember,
				IList<DependencyInfo> dependencies,
				IList<Type> parameterTypes,
				IList<DependencyCallInfo> dependencyCalls
			)
		{
			this.PublicMember = publicMember;
			this.Dependencies = dependencies;
			this.ParameterTypes = parameterTypes;
			this.DependencyCalls = dependencyCalls;

			var declaringType = publicMember.ReflectedMemberInfo.DeclaringType;
			var declaringTypeName = declaringType.GetRealGenericTypeName ();
			var isConstructor = publicMember.MemberType.Equals (MemberType.Constructor);
			var isExtension = publicMember.ReflectedMemberInfo.IsExtensionMethod ();

			var overloadText
				= (publicMember.OverloadRank > 1)
					? $"_{publicMember.OverloadRank.ToString ()}"
					: string.Empty;

			this.DeclaringType = declaringType;
			this.DeclaringTypeName = declaringTypeName;
			this.IsConstructor = isConstructor;
			this.IsExtension = isExtension;
			this.MethodName = publicMember.ReflectedMemberInfo.Name;
			this.OverloadRankText = overloadText;

			// this.DependencyCalls = reflector
		}

		public DependencyInfo? FindDependency (Type dependencyType)
		{
			return this.Dependencies.FirstOrDefault (d => d.DependencyAbstractionType == dependencyType);
		}
	}
}