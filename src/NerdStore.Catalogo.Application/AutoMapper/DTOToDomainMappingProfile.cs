
using AutoMapper;
using NerdStore.Catalogo.Application.ViewModelsOrDTOs;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class DTOToDomainMappingProfile : Profile
    {
        public DTOToDomainMappingProfile()
        {
            CreateMap<CategoriaDTO, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));

            CreateMap<ProdutoDTO, Produto>()
                .ConstructUsing(p =>
                    new Produto(p.Nome, p.Descricao, p.Ativo,
                        p.Valor, p.DataCadastro, p.Imagem,
                        p.CategoriaId, new Dimensoes(p.Altura, p.Largura, p.Profundidade)));
        }
    }
}
