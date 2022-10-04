using AutoMapper;
using Core;
using MaisMarinhaWeb.Models;

namespace MaisMarinhaWeb.Mappers
{
    public class ConcursoProfile : Profile
    {
        public ConcursoProfile()
        {
            CreateMap<ConcursoModel, Concurso>().ReverseMap();
        }
    }
}
