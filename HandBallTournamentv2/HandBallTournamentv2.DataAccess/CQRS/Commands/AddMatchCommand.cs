using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;

namespace HandBallTournamentv2.DataAccess.CQRS.Commands
{
    public class AddMatchCommand : CommandBase<Match, Match>
    {
        public override async Task<Match> Execute(TournamentEntitiesContext context)
        {
            await context.Matches.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
