using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournamentv2.DataAccess.CQRS.Queries.BYID
{
    public class GetCoachQuery : QueryBase<Coach>
    {
        public int CoachId { get; set; }
        public override async Task<Coach> Execute(TournamentEntitiesContext context)
        {
            var coach = await context.Coaches.FirstOrDefaultAsync(x => x.Id == CoachId);
            return coach;
        }
    }
}
