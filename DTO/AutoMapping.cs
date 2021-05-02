using System;
using System.Collections.Generic;
using AutoMapper;
using project_backend_dev.Models;

namespace project_backend_dev.DTO
{
    public class AutoMapping : Profile
    {
        public AutoMapping() {

            CreateMap<Match, MatchDTO>();
            CreateMap<Player, PlayerDTO>();
            CreateMap<Team, TeamDTO>();
             
        }
    }
}
