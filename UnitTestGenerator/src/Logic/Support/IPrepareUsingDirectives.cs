using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Support
{
    public interface IPrepareUsingDirectives
    {
        string ScaffoldUsingStatements
            (
                PublicMember publicMember,
                UnitTestScaffoldOption scaffoldOption,
                bool isMockingUsed,
                bool isTestDataUsed
            );
    }
}