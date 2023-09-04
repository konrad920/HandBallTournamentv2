using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;

namespace HandBallTournamentv2.ApplicationServices.Mappings
{
    public class ClubsProfile : Profile
    {
        public ClubsProfile()
        {
            this.CreateMap<DataAccess.Entities.Club, ClubDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ClubName, y => y.MapFrom(z => z.NameOfClub));
        }
    }
}
