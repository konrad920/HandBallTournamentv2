using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.CQRS.Queries.BYID;
using HandBallTournamentv2.DataAccess.Entities;

namespace HandBallTournamentv2.DataAccess.CQRS.Commands.DELETE
{
    public class DeleteCoachCommand : CommandBase<Coach, Coach>
    {
        public override async Task<Coach> Execute(TournamentEntitiesContext context)
        {
            context.Coaches.Remove(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
