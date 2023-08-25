using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HandBallTournamentv2.DataAccess
{
    public class TournamentEntitiesContextFactory : IDesignTimeDbContextFactory<TournamentEntitiesContext>
    {
        public TournamentEntitiesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TournamentEntitiesContext>();
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-QIGQKKJP\\SQLEXPRESS01;Initial Catalog=TournamentEntities;Integrated Security=True;TrustServerCertificate=true");
            return new TournamentEntitiesContext(optionsBuilder.Options);
        }
    }
}
