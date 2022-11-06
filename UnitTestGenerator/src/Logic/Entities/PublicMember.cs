using System.Reflection;
using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Entities
{
    public sealed class PublicMember
	{
		public MemberType MemberType { get; private set; }

		public int OverloadRank { get; private set; }

		public string Representation { get; private set; }

		public MethodBase ReflectedMemberInfo { get; private set; }

		public IList<DependencyCallInfo> DependencyCalls { get; }

		public PublicMember (MemberType memberType, MethodBase reflectedMemberInfo, int overloadRank, IList<DependencyCallInfo> dependencyCalls)
		{
			this.MemberType = memberType;
			this.OverloadRank = overloadRank;
			this.DependencyCalls = dependencyCalls;

			var qualifierPrefix
				= reflectedMemberInfo.IsExtensionMethod ()
					? "[Static Extension] "
					: (reflectedMemberInfo.IsStatic
						? "[Static] "
						: string.Empty);

			switch (memberType)
			{
				case MemberType.Constructor:
					var constructorInfo = (ConstructorInfo) reflectedMemberInfo;
					var parameters 
						= String.Join (
							", ",
							constructorInfo
								.GetParameters ()
								.Select (p => $"{ p.ParameterType.GetRealGenericTypeName () } { p.Name }")
								.ToList ()
							);
					this.Representation = $"Constructor  →  { constructorInfo?.DeclaringType?.Name } ({ parameters })";
					this.ReflectedMemberInfo = constructorInfo;
					break;

				case MemberType.Method:
					var methodInfo = (MethodInfo) reflectedMemberInfo;
					parameters
						= String.Join (
							", ",
							methodInfo
								.GetParameters ()
								.Select (p => $"{ p.ParameterType.GetRealGenericTypeName () } {p.Name}")
								.ToList ()
							);
					this.Representation = $"Method       →  { qualifierPrefix }.{ methodInfo.Name } ({ parameters })";
					this.ReflectedMemberInfo = methodInfo;
					break;

				default:
					this.Representation = String.Empty;
					this.ReflectedMemberInfo = reflectedMemberInfo;
					break;
			}
		}
	}
}