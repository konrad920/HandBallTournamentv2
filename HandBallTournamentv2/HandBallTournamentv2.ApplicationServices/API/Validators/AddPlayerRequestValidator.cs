using FluentValidation;
using FluentValidation.Validators;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;

namespace HandBallTournamentv2.ApplicationServices.API.Validators
{
    public class AddPlayerRequestValidator : AbstractValidator<AddPlayerRequest>
    {
        public AddPlayerRequestValidator()
        {
            this.RuleFor(x => x.PlayerSalary).GreaterThan(0);
            this.RuleFor(x => x.PlayerYearOfBirth).LessThan(2005);
            this.RuleFor(x => x.PlayerName).Length(1, 60);
            this.RuleFor(x => x.PlayerSurname).Length(1, 60);
        }
    }
}
