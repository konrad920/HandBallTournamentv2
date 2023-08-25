using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournamentv2.DataAccess.CQRS.Commands
{
    public class PutClubCommand : CommandBase<Club, Club>
    {
        public string NameOfClub { get; set; }

        public string NameOfStadium { get; set; }
        public override async Task<Club> Execute(TournamentEntitiesContext context)
        {
            this.Parameter.NameOfClub = NameOfClub;
            this.Parameter.NameOfStadium = NameOfStadium;
            context.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
