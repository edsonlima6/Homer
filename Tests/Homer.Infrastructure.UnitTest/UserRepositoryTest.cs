using FluentAssertions;
using Homer.Domain.Entities;
using Homer.Infrastructure.Context;
using Homer.Infrastructure.Repositories;
using Homer.Infrastructure.UnitTest.Common;
using NSubstitute;
using System.Linq;
using Xunit;

namespace Homer.Infrastructure.UnitTest
{
    /// <summary>
    /// Unit tests for <see cref="UserRepository"/>
    /// </summary>
    public class UserRepositoryTest
    {
        /// <summary>
        /// Add user to repository
        /// </summary>
        /// <param name="userName"> user name.</param>
        [Theory]
        [InlineData("usernameMocked")]
        public void AddUserToRepository(string userName)
        {
            // Arrange 
            var newUser = new User() { UserName= userName };
            var mockContext = Substitute.For<HomerDbContext>();
            HomerDbFixture.SetMockContext(mockContext);
            mockContext.When(c => c.SaveChanges()).Do((s) => {
                HomerDbFixture.SetMockContext(mockContext, [newUser]);
            });
            var userRepository = new UserRepository(mockContext);


            // Act
            mockContext.Users.Add(newUser);
            userRepository.SaveChange();
            var userSaved = userRepository.GetAll().FirstOrDefault(x => x.UserName == userName);

            // Assert
            Assert.NotNull(userSaved);
            userSaved.Should().NotBeNull();
            userSaved.UserName.Should().Be(userName);
            mockContext.Received();
        }
    }
}
