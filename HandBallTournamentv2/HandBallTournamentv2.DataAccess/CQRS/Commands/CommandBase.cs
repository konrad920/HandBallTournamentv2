namespace HandBallTournamentv2.DataAccess.CQRS.Queries
{
    public abstract class CommandBase<TParameter, TResult>
    {
        public TParameter Parameter { get; set; }

        public abstract Task<TResult> Execute(TournamentEntitiesContext context);
    }
}
