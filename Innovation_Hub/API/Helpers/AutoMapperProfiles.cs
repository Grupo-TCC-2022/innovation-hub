using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();
            CreateMap<Idea, IdeaDto>();
            CreateMap<Project, ProjectDto>();
            CreateMap<Problem, ProblemDto>();
            CreateMap<AppUserProposal, AppUserProposalDto>();
        }
    }
}