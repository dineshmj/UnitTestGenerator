using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace UnitTestGenerator.Logic.Support.Extensions
{
	public static class TypeExtension
	{
		public static bool IsStatic (this Type typeToCheck)
		{
			return typeToCheck.IsAbstract && typeToCheck.IsSealed;
		}

		public static bool IsExtensionMethod (this MethodBase method)
		{
			return method.IsDefined (typeof (ExtensionAttribute), true);
		}

		public static string GetRealGenericTypeName (this Type typeToCheck)
		{
			if (!typeToCheck.IsGenericType)
			{
				switch (typeToCheck.Name)
				{
					case "Void":
						return "void";

					case "Int16":
						return "short";

					case "Int16[]":
						return "short []";

					case "Int32":
						return "int";

					case "Int32[]":
						return "int []";

					case "Int64":
						return "long";

					case "Int64[]":
						return "long []";

					case "Single":
						return "float";

					case "Single[]":
						return "float []";

					case "Double":
						return "double";

					case "Double[]":
						return "double []";

					case "Decimal":
						return "decimal";

					case "Decimal[]":
						return "decimal []";

					case "Char":
						return "char";

					case "Char[]":
						return "char []";

					case "String":
						return "string";

					case "String[]":
						return "string []";

					case "Boolean":
						return "bool";

					case "Boolean[]":
						return "bool []";

					default:
						return typeToCheck.Name;
				}
			}

			var builder = new StringBuilder ();

			builder.Append (typeToCheck.Name.Substring (0, typeToCheck.Name.IndexOf ('`')));
			builder.Append ('<');

			bool appendComma = false;

			foreach (Type arg in typeToCheck.GetGenericArguments ())
			{
				if (appendComma)
				{
					builder.Append (',');
				}

				builder.Append (arg.GetRealGenericTypeName ());
				appendComma = true;
			}

			builder.Append ('>');
			return builder.ToString ();
		}

		public static string ToCamelCase (this string name)
		{
			return $"{char.ToLower (name [0])}{name.Substring (1)}";
		}

		public static string ToPascalCase (this string name)
		{
			return $"{char.ToUpper (name [0])}{name.Substring (1)}";
		}

		public static string ToAlias (this string name)
		{
			var aliasDictionary = new Dictionary<string, string>
			{
				{"Int16", "short"},
				{"Int32", "int"},
				{"Int64", "long"},
				{"String", "string"},
				{"Char", "char"},
				{"Boolean", "bool"},
				{"Single", "float"},
				{"Double", "double"},
				{"Decimal", "decimal"},
				{"DateTime", "DateTime"},
			};

			if (aliasDictionary.ContainsKey (name))
			{
				return aliasDictionary [name];
			}

			return name;
		}

		public static string ToHumanReadable (this string methodName)
		{
			var chars = new List<char> ();

			foreach (var oneChar in methodName)
			{
				if (oneChar >= 'A' && oneChar <= 'Z')
				{
					if (chars.Count != 0)
					{
						chars.Add (' ');
					}
				}

				chars.Add (char.ToLower (oneChar));
			}

			return new string (chars.ToArray ());
		}
	}
}