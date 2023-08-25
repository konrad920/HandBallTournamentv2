using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournamentv2.DataAccess.CQRS.Queries.ALL
{
    public class GetPlayersQuery : QueryBase<List<Player>>
    {
        public string? PlayerPosition { get; set; }
        public override Task<List<Player>> Execute(TournamentEntitiesContext context)
        {
            if (PlayerPosition == null)
            {
                return context.Players.ToListAsync();
            }

            return context.Players.Where(x => x.Position == PlayerPosition).ToListAsync();
        }
    }
}
