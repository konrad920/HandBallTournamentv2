using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;

namespace HandBallTournamentv2.DataAccess.CQRS.Commands.PUT
{
    public class PutCoachCommand : CommandBase<Coach, Coach>
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public float Salary { get; set; }
        public override async Task<Coach> Execute(TournamentEntitiesContext context)
        {
            Parameter.Surname = Surname;
            Parameter.Name = Name;
            Parameter.Salary = Salary;
            context.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
