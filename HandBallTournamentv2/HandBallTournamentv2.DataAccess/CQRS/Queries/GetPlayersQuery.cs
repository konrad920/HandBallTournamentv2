using HandBallTournamentv2.DataAccess;
using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournament.DataAccess.CQRS.Queries
{
    public class GetPlayersQuery : QueryBase<List<Player>>
    {
        public string ?PlayerPosition { get; set; }
        public override Task<List<Player>> Execute(TournamentEntitiesContext context)
        {
            if (this.PlayerPosition == null)
            {
                return context.Players.ToListAsync();
            }

            return context.Players.Where(x => x.Position == this.PlayerPosition).ToListAsync();
        }
    }
}
