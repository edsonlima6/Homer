
using Homer.Domain.Entities;
using Homer.Domain.Interfaces.Repositories;
using Homer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Homer.Infrastructure.Repositories
{
    /// <summary>
    /// Repository to handle user entity.
    /// </summary>
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly HomerDbContext Context;
        protected DbSet<T> dbSet;

        public RepositoryBase()
        {
            Context = new HomerDbContext();
            dbSet = Context.Set<T>();
        }

        /// <summary>
        /// Create an instance of RepositoryBase
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <exception cref="ArgumentNullException"> throws an exception if context is null.</exception>
        public RepositoryBase(HomerDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            dbSet = Context.Set<T>();
        }

        public async void AddAsync(T entity) => await dbSet.AddAsync(entity);

        public void Add(T entity) => dbSet.Add(entity);

        public void Remove(T entity) => dbSet.Remove(entity);

        public void Update(T entity) => dbSet.Update(entity);

        public void SaveChange() => Context.SaveChanges();
        public async void SaveChangeAsync() => await Context.SaveChangesAsync();

        public virtual IEnumerable<T> GetAll() => dbSet.AsNoTracking().AsEnumerable();

        public async virtual Task<T?> GetEntity(int id)
        {
            return await dbSet.FindAsync(id);
        }
    }
}
