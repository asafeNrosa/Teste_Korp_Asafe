using AutoMapper;
using NotasApi.DTOs;
using NotasApi.Models;

namespace NotasApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<NotaFiscal, NotaFiscalDto>().ReverseMap();
            CreateMap<NotaProduto, NotaProdutoDto>().ReverseMap();
        }
    }
}
