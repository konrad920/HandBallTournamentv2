using HandBallTournamentv2.DataAccess;
using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournament.DataAccess.CQRS.Queries
{
    public class GetCoachQuery : QueryBase<Coach>
    {
        public int CoachId { get; set; }
        public override async Task<Coach> Execute(TournamentEntitiesContext context)
        {
            var coach = await context.Coaches.FirstOrDefaultAsync(x => x.Id == this.CoachId);
            return coach;
        }
    }
}
