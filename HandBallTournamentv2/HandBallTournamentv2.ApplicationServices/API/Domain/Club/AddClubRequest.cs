using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Models
{
    public class AddClubRequest : IRequest<AddClubResponse>
    {
        public string NameOfClub { get; set; }

        public string NameofStadium { get; set; }
    }
}
