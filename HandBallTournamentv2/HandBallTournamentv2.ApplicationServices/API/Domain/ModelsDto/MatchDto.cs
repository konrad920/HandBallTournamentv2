
namespace HandBallTournamentv2.ApplicationServices.API.Domain.Models
{
    public class MatchDto
    {
        public int Id { get; set; }

        public float TicketCost { get; set; }

        public int HostClubId { get; set; }

        public int QuestClubId { get; set; }

        public int Audience { get; set; }

        public int HostScore { get; set; }

        public int QuestScore { get; set; }
    }
}
