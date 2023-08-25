using HandBallTournamentv2.DataAccess.CQRS.Queries;

namespace HandBallTournamentv2.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly TournamentEntitiesContext context;

        public CommandExecutor(TournamentEntitiesContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command)
        {
            return command.Execute(context);
        }
    }
}
