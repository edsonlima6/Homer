using FluentAssertions;
using Homer.Domain.Common;
using Homer.Domain.Entities;
using Homer.Infrastructure.Context;
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
            SetMockContext(mockContext);
            mockContext.When(c => c.SaveChanges()).Do((s) => {
                userList.Add(new User());
                SetMockContext(mockContext, userList);
            });

            // Act
            mockContext.Users.Add(new());
            mockContext.SaveChanges();

            // Assert
            mockContext.Users.Count().Should().BeGreaterThan(0);
            mockContext.Users.Should().HaveCount(1);
        }

        private static void SetMockContext(HomerDbContext mockContext, List<User>? systemEventLogEntries = null)
        {
            var data = new List<User>
              {
                new(),
              }.AsQueryable();

            if (systemEventLogEntries != null)
            {
                data = systemEventLogEntries.AsQueryable();
            }

            var mockSet = Substitute.For<DbSet<User>, IQueryable<User>>();

            ((IQueryable<User>)mockSet).Provider.Returns(data.Provider);
            ((IQueryable<User>)mockSet).Expression.Returns(data.Expression);
            ((IQueryable<User>)mockSet).ElementType.Returns(data.ElementType);
            ((IQueryable<User>)mockSet).GetEnumerator().Returns(data.GetEnumerator());

            mockContext.Users.Returns(mockSet);
        }
    }
}
