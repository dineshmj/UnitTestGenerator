using Mono.Cecil;
using Mono.Cecil.Cil;

namespace UnitTestGenerator.Logic.NewCore
{
	public sealed class DependencyReflector
		: IDependencyReflector
	{
		public MethodDefinition GetMethodDefinition (string assemblyPath, string className, string methodName)
		{
			var assemblyDefinition = AssemblyDefinition.ReadAssembly (assemblyPath);
			var typeDefinition = assemblyDefinition.MainModule.Types.FirstOrDefault (t => t.FullName == className);
			var methodDefinition = typeDefinition?.Methods.FirstOrDefault (m => m.Name == methodName);
			return methodDefinition;
		}

		public IEnumerable<FieldDefinition> GetFields (string assemblyPath, string className)
		{
			var assemblyDefinition = AssemblyDefinition.ReadAssembly (assemblyPath);
			var typeDefinition = assemblyDefinition.MainModule.Types.FirstOrDefault (t => t.FullName == className);
			return typeDefinition?.Fields ?? Enumerable.Empty<FieldDefinition> ();
		}

		public IEnumerable<DependencyDetail> GetDependencyDetails (string assemblyPath, string className, string methodName)
		{
			var methodDefinition = GetMethodDefinition (assemblyPath, className, methodName);
			var fields = GetFields (assemblyPath, className).ToDictionary (f => f.Name, f => f.FieldType.FullName);

			if (methodDefinition == null)
			{
				yield break;
			}

			foreach (var instruction in methodDefinition.Body.Instructions)
			{
				if (instruction.OpCode == OpCodes.Call || instruction.OpCode == OpCodes.Callvirt)
				{
					var methodReference = instruction.Operand as MethodReference;
					if (methodReference != null && methodReference.DeclaringType != null)
					{
						var fieldReference = GetFieldReference (methodDefinition, instruction);
						if (fieldReference != null && fields.TryGetValue (fieldReference.Name, out var fieldType))
						{
							var dependencyDetail = new DependencyDetail
							{
								FieldName = fieldReference.Name,
								Abstraction = fieldType,
								MethodName = methodReference.Name,
								Arguments = methodReference.Parameters.Select (p => $"{p.ParameterType.FullName} {p.Name}").ToList ()
							};
							yield return dependencyDetail;
						}
					}
				}
			}
		}

		public FieldReference GetFieldReference (MethodDefinition methodDefinition, Instruction instruction)
		{
			// Traverse back from the call instruction to find the field load instruction (ldfld or ldflda)
			var previousInstruction = instruction.Previous;
			while (previousInstruction != null)
			{
				if (previousInstruction.OpCode == OpCodes.Ldfld || previousInstruction.OpCode == OpCodes.Ldflda)
				{
					return previousInstruction.Operand as FieldReference;
				}
				previousInstruction = previousInstruction.Previous;
			}
			return null;
		}
	}
}