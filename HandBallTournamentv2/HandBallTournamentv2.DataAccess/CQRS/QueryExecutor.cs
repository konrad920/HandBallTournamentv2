using HandBallTournamentv2.DataAccess.CQRS.Queries;

namespace HandBallTournamentv2.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly TournamentEntitiesContext context;

        public QueryExecutor(TournamentEntitiesContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}
