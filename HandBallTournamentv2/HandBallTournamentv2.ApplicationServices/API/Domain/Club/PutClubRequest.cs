using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Club
{
    public class PutClubRequest : IRequest<PutClubResponse>
    {
        public int Id { get; set; }

        public string ?NameOfClub { get; set; }

        public string ?NameOfStadium { get; set; }
    }
}
