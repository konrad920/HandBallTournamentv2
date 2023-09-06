using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Models
{
    public class AddPlayerRequest : IRequest<AddPlayerResponse>
    {
        public string PlayerName { get; set; }

        public string PlayerSurname { get; set; }

        public string PlayerPosition { get; set; }

        public int PlayerYearOfBirth { get; set; }

        public float PlayerSalary { get; set; }

        public int PlayerClubId { get; set; }
    }
}
