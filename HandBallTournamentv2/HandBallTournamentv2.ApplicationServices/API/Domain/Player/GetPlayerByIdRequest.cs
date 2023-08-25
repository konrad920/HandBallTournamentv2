using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Player
{
    public class GetPlayerByIdRequest : IRequest<GetPlayerByIdResponse>
    {
        public int Id { get; set; }
    }
}
