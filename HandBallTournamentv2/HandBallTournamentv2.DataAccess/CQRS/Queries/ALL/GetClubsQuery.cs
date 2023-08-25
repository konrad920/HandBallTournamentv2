using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournamentv2.DataAccess.CQRS.Queries.ALL
{
    public class GetClubsQuery : QueryBase<List<Club>>
    {
        public override Task<List<Club>> Execute(TournamentEntitiesContext context)
        {
            return context.Clubs.ToListAsync();
        }
    }
}
