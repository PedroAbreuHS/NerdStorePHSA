﻿
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        //Propriedades de ESTADO da Entidade
        public string? Nome { get; private set; }

        public string? Descricao { get; private set; }

        public bool Ativo { get; private set; }

        public decimal Valor { get; private set; }

        public DateTime? DataCadastro { get; private set; }

        public string? Imagem { get; private set; }

        public int QuantidadeEstoque { get; private set; }

        public Dimensoes Dimensoes { get; private set; }


        //EF Relation - Propriedades de associacao
        public Guid CategoriaId { get; private set; }
        public Categoria? Categoria { get; private set; }


        //Construtor
        public Produto(string? nome, string? descricao, bool ativo, decimal valor, DateTime? dataCadastro, string? imagem, Guid categoriaId, Dimensoes dimensoes)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            CategoriaId = categoriaId;
            Dimensoes = dimensoes;

            Validar();
        }

        
        //Ad Hoc Setters (Methods) COMPORTAMENTOS
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }
        public void AlterarDescricao(string descricao)
        {
            AssertionConcern.ValidarSeVazio(descricao, "O campo Descricao do produto não pode estar vazio.");
            Descricao = descricao;
        }
        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            //if (QuantidadeEstoque < quantidade) throw new DomainException("Estoque insuficiente.");
            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente.");
            QuantidadeEstoque -= quantidade;
        }
        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }
        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }
        public void Validar()
        {
            AssertionConcern.ValidarSeVazio(Nome, "O campo Nome do produto não pode estar vazio.");
            AssertionConcern.ValidarSeVazio(Descricao, "O campo Descricao do produto não pode estar vazio.");
            AssertionConcern.ValidarSeDiferente(CategoriaId, Guid.Empty, "O campo CategoriaId do produto não pode estar vazio");
            AssertionConcern.ValidarSeMenorQue(Valor, 0, "O campo Valor do produto não pode ser menor ou igual a 0");
            AssertionConcern.ValidarSeVazio(Imagem, "O campo Imagem do produto não pode estar vazio");
        }

    }
}
