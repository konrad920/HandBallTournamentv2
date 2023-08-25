using HandBallTournamentv2.DataAccess;
using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournament.DataAccess.CQRS.Queries
{
    public class GetClubsQuery : QueryBase<List<Club>>
    {
        public override Task<List<Club>> Execute(TournamentEntitiesContext context)
        {
            return context.Clubs.ToListAsync();
        }
    }
}
