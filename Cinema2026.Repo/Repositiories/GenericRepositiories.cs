using Cinema2026.Repo.Data;
using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Cinema2026.Repo.Repositiories
{
    public class GenericRepositiories<T> : IGenericRepository<T> where T : class
    {
        protected readonly DatabaseContext context; 
        protected readonly DbSet<T> dbSet;

        public GenericRepositiories(DatabaseContext c)
        {
            context = c;
            dbSet = context.Set<T>();
        }

        public async Task<T?> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public async Task<T> Add(T objekt)
        {
            await dbSet.AddAsync(objekt); 
            await context.SaveChangesAsync();
            return objekt;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task Update(T objekt)
        {
            dbSet.Update(objekt);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null) return;
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
