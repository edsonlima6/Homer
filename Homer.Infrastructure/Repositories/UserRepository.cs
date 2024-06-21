using Homer.Domain.Entities;
using Homer.Domain.Interfaces.Repositories;
using Homer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Homer.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository()
        {
        }

        /// <summary>
        /// Create an instance of RepositoryBase
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <exception cref="ArgumentNullException"> throws an exception if context is null.</exception>
        public UserRepository(HomerDbContext homerDbContext) 
            : base(homerDbContext)
        {
        }

        public async override Task<User?> GetEntity(int id)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public override IEnumerable<User> GetAll()
        {
            return Context.Users.AsEnumerable();
        }
    }
}
