using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;

namespace HandBallTournamentv2.ApplicationServices.Mappings
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            this.CreateMap<AddPlayerRequest, DataAccess.Entities.Player>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.PlayerName))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.PlayerSurname))
                .ForMember(x => x.Position, y => y.MapFrom(z => z.PlayerPosition))
                .ForMember(x => x.Salary, y => y.MapFrom(z => z.PlayerSalary))
                .ForMember(x => x.YearOfBirth, y => y.MapFrom(z => z.PlayerYearOfBirth))
                .ForMember(x => x.ClubId, y => y.MapFrom(z => z.PlayerClubId));

            this.CreateMap<DataAccess.Entities.Player, DTO_Player>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Position, y => y.MapFrom(z => z.Position));
        }
    }
}
