using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;

namespace HandBallTournamentv2.DataAccess.CQRS.Commands.DELETE
{
    public class DeletePlayerCommand : CommandBase<Player, Player>
    {
        public override async Task<Player> Execute(TournamentEntitiesContext context)
        {
            context.Players.Remove(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
