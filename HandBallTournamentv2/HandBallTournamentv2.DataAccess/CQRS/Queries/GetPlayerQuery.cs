using HandBallTournamentv2.DataAccess;
using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournament.DataAccess.CQRS.Queries
{
    public class GetPlayerQuery : QueryBase<Player>
    {
        public int PlayerId { get; set; }
        public override async Task<Player> Execute(TournamentEntitiesContext context)
        {
            var player = await context.Players.FirstOrDefaultAsync(x => x.Id == this.PlayerId);
            return player;
        }
    }
}
