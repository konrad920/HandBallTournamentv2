using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Match
{
    public class PutMatchRequest : IRequest<PutMatchResponse>
    {
        public int Id { get; set; }

        public int HostClubId { get; set; }

        public int QuestClubId { get; set; }

        public int Audience { get; set; }

        public float TicketCost { get; set; }

        public int HostPoints { get; set; }

        public int QuestPoints { get; set; }

        public int HostScore { get; set; }

        public int QuestScore { get; set; }
    }
}
