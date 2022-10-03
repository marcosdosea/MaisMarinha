using AutoMapper;
using MaisMarinhaWeb.Models;
using Core;

namespace MaisMarinhaWeb.Mappers
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<PessoaModel, Pessoa>().ReverseMap();
        }
    }
}
