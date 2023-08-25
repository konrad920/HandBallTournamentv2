using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Club
{
    public class GetClubByIdRequest : IRequest<GetClubByIdResponse>
    {
        public int Id { get; set; }
    }
}
