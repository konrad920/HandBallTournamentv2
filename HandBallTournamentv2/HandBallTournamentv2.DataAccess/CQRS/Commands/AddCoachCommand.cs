using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;

namespace HandBallTournamentv2.DataAccess.CQRS.Commands
{
    public class AddCoachCommand : CommandBase<Coach, Coach>
    {
        public override async Task<Coach> Execute(TournamentEntitiesContext context)
        {
            await context.Coaches.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
