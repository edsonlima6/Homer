using FluentAssertions;
using Homer.Domain.Common;
using Homer.Domain.Entities;
using Homer.Infrastructure.Context;
using Homer.Infrastructure.UnitTest.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Homer.Infrastructure.UnitTest
{
    /// <summary>
    /// Unit tests for <see cref="HomerDbContext"/>
    /// </summary>
    public class HomerDbContextTests
    {
        /// <summary>
        /// Given DbContext Using Default DbPath then create directory if not exists.
        /// </summary>
        [Fact]
        public void GivenDbContextUsingDefaultDbPathTest()
        {
            // Arrange
            var context = new HomerDbContext();
            var filePath = FilePath.DatabaseFilePath(FilePath.DefaultUserDataFolderPath);
            var directoryPath = Path.Combine(FilePath.DefaultUserDataFolderPath, "Database");

            // Act
            var dbPathCreated = context.DbPath;

            // Assert
            dbPathCreated.Should().NotBeEmpty();
            filePath.Should().Be(dbPathCreated);
            Directory.Exists(directoryPath).Should().BeTrue();
        }

        /// <summary>
        /// Given DbContext To Add User Then SaveChanges Sucessfully.
        /// </summary>
        [Fact]
        public void GivenDbContextToAddUserThenSaveChangesTest()
        {
            // Arrange
            var mockContext = Substitute.For<HomerDbContext>();
            var userList = new List<User>();
            HomerDbFixture.SetMockContext(mockContext);
            mockContext.When(c => c.SaveChanges()).Do((s) => {
                userList.Add(new User());
                HomerDbFixture.SetMockContext(mockContext, userList);
            });

            // Act
            mockContext.Users.Add(new());
            mockContext.SaveChanges();

            // Assert
            mockContext.Users.Count().Should().BeGreaterThan(0);
            mockContext.Users.Should().HaveCount(1);
        }
    }
}
