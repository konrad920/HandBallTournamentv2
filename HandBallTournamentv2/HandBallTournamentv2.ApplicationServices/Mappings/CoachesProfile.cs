using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;

namespace HandBallTournamentv2.ApplicationServices.Mappings
{
    public class CoachesProfile : Profile
    {
        public CoachesProfile()
        {
            this.CreateMap<DataAccess.Entities.Coach, Coach>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
        }
    }
}
