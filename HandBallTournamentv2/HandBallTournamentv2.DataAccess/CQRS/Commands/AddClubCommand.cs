using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;

namespace HandBallTournamentv2.DataAccess.CQRS.Commands
{
    public class AddClubCommand : CommandBase<Club, Club>
    {
        public override async Task<Club> Execute(TournamentEntitiesContext context)
        {
            await context.Clubs.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
