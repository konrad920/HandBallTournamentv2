using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournamentv2.DataAccess.CQRS.Commands.PUT
{
    public class PutClubCommand : CommandBase<Club, Club>
    {
        public string NameOfClub { get; set; }

        public string NameOfStadium { get; set; }
        public override async Task<Club> Execute(TournamentEntitiesContext context)
        {
            Parameter.NameOfClub = NameOfClub;
            Parameter.NameOfStadium = NameOfStadium;
            context.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
