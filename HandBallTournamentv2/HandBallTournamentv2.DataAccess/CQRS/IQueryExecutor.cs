using HandBallTournamentv2.DataAccess.CQRS.Queries;

namespace HandBallTournamentv2.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
