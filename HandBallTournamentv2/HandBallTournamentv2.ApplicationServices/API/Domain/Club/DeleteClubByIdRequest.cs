using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Club
{
    public class DeleteClubByIdRequest : IRequest<DeleteClubByIdResponse>
    {
        public int Id { get; set; }
    }
}
