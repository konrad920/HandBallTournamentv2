using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Models
{
    public class GetPlayersRequest : IRequest<GetPlayersResponse>
    {
        public string? PlayerPosition { get; set; }
    }
}
