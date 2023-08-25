using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournamentv2.DataAccess.CQRS.Queries.ALL
{
    public class GetMatchesQuery : QueryBase<List<Match>>
    {
        public float? MatchTicketCost { get; set; }

        public int? MatchAudience { get; set; }

        public override Task<List<Match>> Execute(TournamentEntitiesContext context)
        {
            if (MatchAudience == null && MatchTicketCost == null)
            {
                return context.Matches.ToListAsync();
            }
            else if (MatchAudience != null && MatchTicketCost == null)
            {
                return context.Matches.Where(x => x.Audience <= MatchAudience).ToListAsync();
            }
            else if (MatchAudience == null && MatchTicketCost != null)
            {
                return context.Matches.Where(x => x.TicketCost <= MatchTicketCost).ToListAsync();
            }
            else
            {
                return context.Matches
                .Where(x => x.Audience <= MatchAudience)
                .Where(x => x.TicketCost <= MatchTicketCost)
                .ToListAsync();
            }
        }
    }
}
