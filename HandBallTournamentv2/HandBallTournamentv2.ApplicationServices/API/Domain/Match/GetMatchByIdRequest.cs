using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Match
{
    public class GetMatchByIdRequest : IRequest<GetMatchByIdResponse>
    {
        public int Id { get; set; }
    }
}
