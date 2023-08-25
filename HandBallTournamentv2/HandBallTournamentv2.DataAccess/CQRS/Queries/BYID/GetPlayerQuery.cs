using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournamentv2.DataAccess.CQRS.Queries.BYID
{
    public class GetPlayerQuery : QueryBase<Player>
    {
        public int PlayerId { get; set; }
        public override async Task<Player> Execute(TournamentEntitiesContext context)
        {
            var player = await context.Players.FirstOrDefaultAsync(x => x.Id == PlayerId);
            return player;
        }
    }
}
