using HandBallTournamentv2.DataAccess.CQRS.Queries;

namespace HandBallTournamentv2.DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command);
    }
}