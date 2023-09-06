using FluentValidation;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;

namespace HandBallTournamentv2.ApplicationServices.API.Validators
{
    public class AddCoachRequestValidator : AbstractValidator<AddCoachRequest>
    {
        public AddCoachRequestValidator()
        {
            this.RuleFor(x => x.CoachSalary).GreaterThan(0);
            this.RuleFor(x => x.CoachName).Length(1, 60);
            this.RuleFor(x => x.CoachSurname).Length(1, 60);
        }
    }
}
