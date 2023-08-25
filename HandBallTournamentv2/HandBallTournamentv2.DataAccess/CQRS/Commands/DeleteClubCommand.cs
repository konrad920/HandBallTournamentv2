using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace HandBallTournamentv2.DataAccess.CQRS.Commands
{
    public class DeleteClubCommand : CommandBase<Club, Club>
    { 
        public override async Task<Club> Execute(TournamentEntitiesContext context)
        {
            context.Clubs.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
