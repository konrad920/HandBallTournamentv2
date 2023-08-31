using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;

namespace HandBallTournamentv2.DataAccess.CQRS.Commands.PUT
{
    public class PutMatchCommand : CommandBase<Match, Match>
    {
        public int HostClubId { get; set; }

        public int QuestClubId { get; set; }

        public int Audience { get; set; }

        public float TicketCost { get; set; }

        public int HostPoints { get; set; }

        public int QuestPoints { get; set; }

        public int HostScore { get; set; }

        public int QuestScore { get; set; }
        public override async Task<Match> Execute(TournamentEntitiesContext context)
        {
            Parameter.HostClubId = HostClubId;
            Parameter.QuestClubId = QuestClubId;
            Parameter.Audience = Audience;
            Parameter.TicketCost = TicketCost;
            Parameter.HostPoints = HostPoints;
            Parameter.HostScore = HostScore;
            Parameter.QuestPoints = QuestPoints;
            Parameter.QuestScore = QuestScore;
            context.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
