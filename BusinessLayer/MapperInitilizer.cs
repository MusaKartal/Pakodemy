using AutoMapper;
using EntitiesLayer;
using EntitiesLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Human, CacheDto>().ReverseMap();
            CreateMap<Human, HumanDto>().ReverseMap();
            CreateMap<Human, ResponsetwoDto>().ReverseMap();
        }
    }
}
