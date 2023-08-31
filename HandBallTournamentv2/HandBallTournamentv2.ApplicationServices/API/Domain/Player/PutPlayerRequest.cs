using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Player
{
    public class PutPlayerRequest :IRequest<PutPlayerResponse>
    {
        public int Id { get; set; }

        public string ? Name { get; set; }

        public string ? Surname { get; set; }

        public string ? Position { get; set; }

        public int YearOfBirth { get; set; }

        public float Salary { get; set; }
    }
}
