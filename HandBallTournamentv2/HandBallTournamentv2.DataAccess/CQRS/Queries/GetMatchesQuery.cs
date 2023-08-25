using HandBallTournamentv2.DataAccess;
using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournament.DataAccess.CQRS.Queries
{
    public class GetMatchesQuery : QueryBase<List<Match>>
    {
        public float ?MatchTicketCost { get; set; }

        public int ?MatchAudience { get; set; }

        public override Task<List<Match>> Execute(TournamentEntitiesContext context)
        {
            if (this.MatchAudience == null && this.MatchTicketCost == null)
            {
                return context.Matches.ToListAsync();
            }
            else if(this.MatchAudience != null && this.MatchTicketCost == null)
            {
                return context.Matches.Where(x => x.Audience <= this.MatchAudience).ToListAsync();
            }
            else if (this.MatchAudience == null && this.MatchTicketCost != null)
            {
                return context.Matches.Where(x => x.TicketCost <= this.MatchTicketCost).ToListAsync();
            }
            else
            {
                return context.Matches
                .Where(x => x.Audience <= this.MatchAudience)
                .Where(x => x.TicketCost <= this.MatchTicketCost)
                .ToListAsync();
            }
        }
    }
}
