using FluentValidation;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;

namespace HandBallTournamentv2.ApplicationServices.API.Validators
{
    public class AddClubRequestValidator : AbstractValidator<AddClubRequest>
    {
        public AddClubRequestValidator()
        {
            this.RuleFor(x => x.NameOfClub).Length(0, 30);
            this.RuleFor(x => x.NameofStadium).Length(0, 30);
        }
    }
}
