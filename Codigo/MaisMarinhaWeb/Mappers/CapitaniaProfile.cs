using AutoMapper;
using MaisMarinhaWeb.Models;
using Core;

namespace MaisMarinhaWeb.Mappers
{
    public class CapitaniaProfile : Profile
    {
        public CapitaniaProfile()
        {
            CreateMap<CapitaniaModel, Capitania>().ReverseMap();
        }
    }
}
