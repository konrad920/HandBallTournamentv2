namespace HandBallTournamentv2.DataAccess.CQRS.Queries
{
    public abstract class QueryBase<TResult>
    {
        public abstract Task<TResult> Execute(TournamentEntitiesContext context);
    }
}
