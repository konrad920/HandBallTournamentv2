using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;

namespace HandBallTournamentv2.DataAccess.CQRS.Commands.PUT
{
    public class PutPlayerCommand : CommandBase<Player, Player>
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Position { get; set; }

        public int YearOfBirth { get; set; }

        public float Salary { get; set; }
        public override async Task<Player> Execute(TournamentEntitiesContext context)
        {
            Parameter.Name = Name;
            Parameter.Surname = Surname;
            Parameter.Position = Position;
            Parameter.YearOfBirth = YearOfBirth;
            Parameter.Salary = Salary;
            context.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
