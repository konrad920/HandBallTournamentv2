using FluentValidation;
using HandBallTournamentv2.ApplicationServices.API.Domain.Match;

namespace HandBallTournamentv2.ApplicationServices.API.Validators
{
    public class AddMatchRequestValidator : AbstractValidator<AddMatchRequest>
    {
        public AddMatchRequestValidator()
        {
            this.RuleFor(x => x.MatchTicketCost).InclusiveBetween(0, 150);
            this.RuleFor(x => x.MatchAudience).InclusiveBetween(0, 35000);
            this.RuleFor(x => x.MatchQuestClubId).GreaterThanOrEqualTo(0);
            this.RuleFor(x => x.MatchHostClubId).GreaterThanOrEqualTo(0);
            this.RuleFor(x => x.MatchHostPoints).GreaterThanOrEqualTo(0);
            this.RuleFor(x => x.MatchHostScore).GreaterThanOrEqualTo(0);
            this.RuleFor(x => x.MatchQuestPoints).GreaterThanOrEqualTo(0);
            this.RuleFor(x => x.MatchQuestScore).GreaterThanOrEqualTo(0);
        }
    }
}
