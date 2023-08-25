using HandBallTournamentv2.DataAccess.Entities;

namespace HandBallTournamentv2.DataAccess
{
    public interface IRepository <T> where T : EntityBase
    {
        Task<List<T>> GetAll ();

        Task<T> GetById (int id);

        Task Update (T entity);

        Task Delete (int id);

        Task Insert (T entity);
    }
}
