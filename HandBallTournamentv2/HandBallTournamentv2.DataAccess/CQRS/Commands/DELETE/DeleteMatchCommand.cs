using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;

namespace HandBallTournamentv2.DataAccess.CQRS.Commands.DELETE
{
    public class DeleteMatchCommand : CommandBase<Match, Match>
    {
        public override async Task<Match> Execute(TournamentEntitiesContext context)
        {
            context.Matches.Remove(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
