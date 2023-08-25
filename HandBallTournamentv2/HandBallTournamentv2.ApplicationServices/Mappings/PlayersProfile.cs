using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;

namespace HandBallTournamentv2.ApplicationServices.Mappings
{
    public class PlayersProfile : Profile
    {
        public PlayersProfile()
        {
            this.CreateMap<DataAccess.Entities.Player, DTO_Player>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Position, y => y.MapFrom(z => z.Position));
        }
    }
}
