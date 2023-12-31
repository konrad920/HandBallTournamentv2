﻿using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Club;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;

namespace HandBallTournamentv2.ApplicationServices.Mappings
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            this.CreateMap<AddClubRequest, DataAccess.Entities.Club>()
                .ForMember(x => x.NameOfClub, y => y.MapFrom(z => z.NameOfClub))
                .ForMember(x => x.NameOfStadium, y => y.MapFrom(z => z.NameofStadium));

            this.CreateMap<DataAccess.Entities.Club, ClubDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ClubName, y => y.MapFrom(z => z.NameOfClub))
                .ForMember(x => x.Players, y => y.MapFrom(z => z.Players != null ? z.Players.Select(x => x.Name) : new List<string>()))
                .ForMember(x => x.CostOfSalary, y => y.MapFrom(z => z.Players.Select(x => x.Salary).Sum()));
        }
    }
}
