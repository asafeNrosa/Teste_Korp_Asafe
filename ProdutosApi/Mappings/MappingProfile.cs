using AutoMapper;
using ProdutosApi.DTO;
using ProdutosApi.Models;

namespace ProdutosApi.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Produto,ProdutoDto>().ReverseMap();
    }
}
