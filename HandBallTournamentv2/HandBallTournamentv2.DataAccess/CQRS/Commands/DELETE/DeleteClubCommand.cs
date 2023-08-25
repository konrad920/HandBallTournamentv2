using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace HandBallTournamentv2.DataAccess.CQRS.Commands.DELETE
{
    public class DeleteClubCommand : CommandBase<Club, Club>
    {
        public override async Task<Club> Execute(TournamentEntitiesContext context)
        {
            context.Clubs.Remove(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
