using Mono.Cecil;
using Mono.Cecil.Cil;

namespace UnitTestGenerator.Logic.NewCore
{
	public interface IDependencyReflector
	{
		MethodDefinition GetMethodDefinition (string assemblyPath, string className, string methodName);

		IEnumerable<FieldDefinition> GetFields (string assemblyPath, string className);

		IEnumerable<DependencyDetail> GetDependencyDetails (string assemblyPath, string className, string methodName);

		FieldReference GetFieldReference (MethodDefinition methodDefinition, Instruction instruction);
	}
}