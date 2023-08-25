using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Models
{
    public class AddCoachRequest : IRequest<AddCoachResponse>
    {
        public string CoachName { get; set; }

        public string CoachSurname { get; set; }

        public float CoachSalary { get; set; }

        public int ClubCoachId { get; set; }
    }
}
