using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournamentv2.DataAccess.CQRS.Queries.ALL
{
    public class GetCoachesQuery : QueryBase<List<Coach>>
    {
        public override Task<List<Coach>> Execute(TournamentEntitiesContext context)
        {
            return context.Coaches.ToListAsync();
        }
    }
}
