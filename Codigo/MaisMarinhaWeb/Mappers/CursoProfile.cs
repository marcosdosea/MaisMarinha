using AutoMapper;
using Core;
using MaisMarinhaWeb.Models;

namespace MaisMarinhaWeb.Mappers
{
    public class CursoProfile : Profile
    {
        public CursoProfile()
        {
            CreateMap<CursoModel, Curso>().ReverseMap();
        }
    }
}
