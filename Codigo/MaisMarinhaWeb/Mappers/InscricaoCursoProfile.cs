using AutoMapper;
using Core;
using MaisMarinhaWeb.Models;

namespace MaisMarinhaWeb.Mappers
{
    public class InscricaoCursoProfile : Profile
    {

        public InscricaoCursoProfile()
        {
            CreateMap<InscricaoCursoModel, InscricaoCurso>().ReverseMap();
        }
    }
}
