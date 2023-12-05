using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Time.Sheet.Web.DTO;
using TimeSheet.Core.Entities;

namespace Time.Sheet.Web.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<ClientDTO, Client>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<TeamMemberDTO, TeamMember>().ReverseMap();
            CreateMap<TeamMember, TeamMember>().ReverseMap();
            CreateMap<TimeSheetDTO, TimeSheet.Core.Entities.TimeSheet>().ReverseMap();
            CreateMap<TimeSheet.Core.Entities.TimeSheet, TimeSheetDTO>().ReverseMap();
        }
    }
}
