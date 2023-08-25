using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournamentv2.DataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly TournamentEntitiesContext _context;
        private readonly DbSet<T> _entities;
        public Repository(TournamentEntitiesContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<List<T>> GetAll()
        {
            return _entities.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return _entities.SingleOrDefaultAsync(s => s.Id == id); 
        }

        public Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entities.Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return _context.SaveChangesAsync();
        }
    }
}
