using HandBallTournamentv2.DataAccess;
using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournament.DataAccess.CQRS.Queries
{
    public class GetCoachesQuery : QueryBase<List<Coach>>
    {
        public override Task<List<Coach>> Execute(TournamentEntitiesContext context)
        {
            return context.Coaches.ToListAsync();
        }
    }
}
