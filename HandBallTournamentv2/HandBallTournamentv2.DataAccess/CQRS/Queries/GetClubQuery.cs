using HandBallTournamentv2.DataAccess;
using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallTournament.DataAccess.CQRS.Queries
{
    public class GetClubQuery : QueryBase<Club>
    {
        public int ClubId { get; set; }
        public override async Task<Club> Execute(TournamentEntitiesContext context)
        {
            var club = await context.Clubs.FirstOrDefaultAsync(x => x.Id == this.ClubId);
            return club;
        }
    }
}
