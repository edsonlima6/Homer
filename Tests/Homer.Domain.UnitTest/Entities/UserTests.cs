using Homer.Domain.Entities;
using Xunit;

namespace Homer.Domain.UnitTest.Entities
{
    /// <summary>
    /// Used to test <see cref="User"/> class.
    /// </summary>
    public class UserTests
    {
        private readonly User User;

        public UserTests()
        {
            User = new User();
        }

        [Fact]
        public void UserTestId()
        {
            User.Id = 1;

            User.Id++;

            Assert.True(User.Id > 1);
        }
    }
}
