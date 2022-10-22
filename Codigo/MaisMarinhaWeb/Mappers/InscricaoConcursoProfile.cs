using AutoMapper;
using Core;
using MaisMarinhaWeb.Models;

namespace MaisMarinhaWeb.Mappers
{
    public class InscricaoConcursoProfile : Profile
    {

        public InscricaoConcursoProfile()
        {
            CreateMap<InscricaoConcursoModel, Inscricaoconcurso>().ReverseMap();
        }
    }
}
