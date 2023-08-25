using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Models
{
    public class GetMatchesRequest : IRequest<GetMatchesResponse>
    {
        public float ?MaxMatchTicketCost { get; set; }

        public int ?MaxMatchAudience { get; set; }
    }
}
