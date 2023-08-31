using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Match
{
    public class DeleteMatchByIdRequest : IRequest<DeleteMatchByIdResponse>
    {
        public int Id { get; set; }
    }
}
