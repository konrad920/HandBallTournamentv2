using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournamentv2.DataAccess
{
    public class TournamentEntitiesContext : DbContext
    {
        public TournamentEntitiesContext(DbContextOptions<TournamentEntitiesContext> options) : base (options)
        {

        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<Match> Matches { get; set; }
    }
}
