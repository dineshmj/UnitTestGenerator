using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Support
{
	public sealed class PrepareUsingDirectives
        : IPrepareUsingDirectives
    {
        public string ScaffoldUsingStatements
			(
				PublicMember publicMember,
				UnitTestScaffoldOption scaffoldOption,
				bool isMockingUsed,
				bool isTestDataUsed
			)
        {
            var usingStatements = new List<string> ();

            switch (scaffoldOption.UnitTestLibrary)
            {
                case UnitTestLibrary.NUnit:
                    usingStatements.Add ("using NUnit.Framework;"); 
					break;

				case UnitTestLibrary.XUnit:
					usingStatements.Add ("using Xunit;");
					break;

				case UnitTestLibrary.MicrosoftTest:
					usingStatements.Add ("using Microsoft.VisualStudio.TestTools.UnitTesting;");
					break;

				case UnitTestLibrary.XBehave:
					usingStatements.Add ("using Xbehave;");
					break;

				case UnitTestLibrary.NSpec:
					usingStatements.Add ("using NSpec;");
					break;
			}

			if (scaffoldOption.AddRelevantUsingNamespacesEvenIfNotUsed || isMockingUsed)
			{
				switch (scaffoldOption.MockingLibrary)
				{
					case MockingLibrary.Moq:
						usingStatements.Add ("using Moq;");
						break;

					case MockingLibrary.NSubstitute:
						usingStatements.Add ("using NSubstitute;");
						break;

					case MockingLibrary.TelerikJustMock:
						usingStatements.Add ("using Telerik.JustMock;");
						break;

					case MockingLibrary.FakeItEasy:
						usingStatements.Add ("using FakeItEasy;");
						break;

					case MockingLibrary.RhinoMock:
						usingStatements.Add ("using Rhino.Mocks;");
						break;
				}
			}

			switch (scaffoldOption.FluentAssertionLibrary)
			{
				case FluentAssertionLibrary.FluentAssertions:
					usingStatements.Add ("using FluentAssertions;");
					break;

				case FluentAssertionLibrary.Shouldly:
					usingStatements.Add ("using Shouldly;");
					break;

				case FluentAssertionLibrary.Should:
					usingStatements.Add ("using Should;");
					break;

				case FluentAssertionLibrary.NFluent:
					usingStatements.Add ("using NFluent;");
					break;

				case FluentAssertionLibrary.NSure:
					usingStatements.Add ("using NSure;");
					break;
			}

			if (scaffoldOption.AddRelevantUsingNamespacesEvenIfNotUsed || isTestDataUsed)
			{
				switch (scaffoldOption.TestDataPreparationLibrary)
				{
					case TestDataPreparationLibrary.FizzwareNBuilder:
						usingStatements.Add ("using FizzWare.NBuilder;");
						break;

					case TestDataPreparationLibrary.AutoFixture:
						usingStatements.Add ("using AutoFixture;");
						break;
				}
			}

			usingStatements.Sort ();
			var usingBlock = $"{ String.Join ("\r\n", usingStatements) }\r\n\r\nusing { publicMember.ReflectedMemberInfo.DeclaringType.Namespace };";

			return usingBlock;
        }
    }
}