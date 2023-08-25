using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;

namespace HandBallTournamentv2.DataAccess.CQRS.Commands.ADD
{
    public class AddPlayerCommand : CommandBase<Player, Player>
    {
        public override async Task<Player> Execute(TournamentEntitiesContext context)
        {
            await context.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
