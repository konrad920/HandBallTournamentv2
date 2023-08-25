namespace HandBallTournamentv2.DataAccess.Entities
{
    public class Match : EntityBase
    {
        public List<Club> Clubs { get; set; }

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
