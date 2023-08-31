using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Player
{
    public class DeletePlayerByIdRequest : IRequest<DeletePlayerByIdResponse>
    {
        public int Id { get; set; }
    }
}
