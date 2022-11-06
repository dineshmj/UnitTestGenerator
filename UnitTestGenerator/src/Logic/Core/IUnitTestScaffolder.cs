using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Core
{
    public interface IUnitTestScaffolder
    {
        IDictionary<PublicMember, string> GenerateUnitTestsFor
            (
                IList<PublicMember> selectedPublicMembers,
                UnitTestScaffoldOption scaffoldOption
            );
    }
}