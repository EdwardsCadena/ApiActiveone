using Activeone.Core.DTOs;
using Activeone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace Activeone.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Cliente, ClienteDtos>();
            CreateMap<ClienteDtos, Cliente>();

            CreateMap<Cd, CdDtos>();
            CreateMap<CdDtos, Cd>();

            CreateMap<AlquilerDtos, AlquilerDtos>();
            CreateMap<Alquiler, AlquilerDtos>();
        }
    }
}
