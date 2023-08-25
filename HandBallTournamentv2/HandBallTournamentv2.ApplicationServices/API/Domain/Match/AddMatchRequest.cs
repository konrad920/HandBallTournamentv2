using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Match
{
    public class AddMatchRequest : IRequest<AddMatchResponse>
    {
        public int MatchHostClubId { get; set; }

        public int MatchQuestClubId { get; set; }

        public int MatchAudience { get; set; }

        public float MatchTicketCost { get; set; }

        public int MatchHostPoints { get; set; }

        public int MatchQuestPoints { get; set; }

        public int MatchHostScore { get; set; }

        public int MatchQuestScore { get; set; }
    }
}
