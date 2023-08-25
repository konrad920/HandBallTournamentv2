using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournamentv2.DataAccess.CQRS.Queries.BYID
{
    public class GetMatchQuery : QueryBase<Match>
    {
        public int MatchId { get; set; }
        public override async Task<Match> Execute(TournamentEntitiesContext context)
        {
            var match = await context.Matches.FirstOrDefaultAsync(x => x.Id == MatchId);
            return match;
        }
    }
}
