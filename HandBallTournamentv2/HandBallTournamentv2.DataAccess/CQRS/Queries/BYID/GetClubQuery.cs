using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournamentv2.DataAccess.CQRS.Queries.BYID
{
    public class GetClubQuery : QueryBase<Club>
    {
        public int ClubId { get; set; }

        public float CostOfSalary { get; set; }
        public override async Task<Club> Execute(TournamentEntitiesContext context)
        {
            var club = await context.Clubs.Include(x => x.Players).FirstOrDefaultAsync(x => x.Id == ClubId);
            return club;
        }
    }
}
