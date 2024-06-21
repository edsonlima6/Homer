
using Homer.Domain.Entities;
using Homer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;

namespace Homer.Infrastructure.UnitTest.Common
{
    /// <summary>
    /// class to mock  databa context.
    /// </summary>
    internal static class HomerDbFixture
    {
        public static void SetMockContext(HomerDbContext mockContext, List<User>? systemEventLogEntries = null)
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
