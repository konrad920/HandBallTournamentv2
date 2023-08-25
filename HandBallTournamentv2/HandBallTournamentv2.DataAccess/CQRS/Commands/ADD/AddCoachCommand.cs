using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;

namespace HandBallTournamentv2.DataAccess.CQRS.Commands.ADD
{
    public class AddCoachCommand : CommandBase<Coach, Coach>
    {
        public override async Task<Coach> Execute(TournamentEntitiesContext context)
        {
            await context.Coaches.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
