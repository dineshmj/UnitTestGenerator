using System.Reflection;

using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Core
{
    public interface IILReader
    {
        IList<DependencyInfo> GetDependencies(Type targetType);

        IList<DependencyCallInfo> GetDependencyMethodCalls(MethodBase method);
    }
}