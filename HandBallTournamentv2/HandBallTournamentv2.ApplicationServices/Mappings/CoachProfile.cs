using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;

namespace HandBallTournamentv2.ApplicationServices.Mappings
{
    public class CoachProfile : Profile
    {
        public CoachProfile()
        {
            this.CreateMap<AddCoachRequest, DataAccess.Entities.Coach>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.CoachName))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.CoachSurname))
                .ForMember(x => x.Salary, y => y.MapFrom(z => z.CoachSalary))
                .ForMember(x => x.ClubId, y => y.MapFrom(z => z.ClubCoachId));

            this.CreateMap<DataAccess.Entities.Coach, Coach>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
        }
    }
}
