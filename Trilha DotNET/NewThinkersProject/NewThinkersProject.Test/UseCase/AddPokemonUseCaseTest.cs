using FluentAssertions;
using Moq;
using NewThinkersProject.Border.Adapter;
using NewThinkersProject.Border.Repositories;
using NewThinkersProject.DTO.Pokemon.AddPokemon;
using NewThinkersProject.Entities;
using NewThinkersProject.Test.Builder;
using NewThinkersProject.UseCase.Pokemon;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NewThinkersProject.Test.UseCase
{
    public class AddPokemonUseCaseTest
    {
        private readonly Mock<IPokemonRepository> _pokemonRepository;
        private readonly Mock<IAddPokemonAdapter> _addPokemonAdapter;
        private readonly AddPokemonUseCase _useCase;

        public AddPokemonUseCaseTest()
        {
            _pokemonRepository = new Mock<IPokemonRepository>();
            _addPokemonAdapter = new Mock<IAddPokemonAdapter>();
            _useCase = new AddPokemonUseCase(_pokemonRepository.Object, _addPokemonAdapter.Object);
        }

        [Fact]
        public void Pokemon_AddPokemon_Sucess()
        {
            //Arrange
            //Criar variaveis
            var request = new AddPokemonRequestBuilder().Build();
            var response = new AddPokemonResponse();
            var pokemon = new Pokemon();
            pokemon.id = 1;

            response.id = pokemon.id;
            response.message = "Adicionado com sucesso";

            _pokemonRepository.Setup(repository => repository.Add(pokemon)).Returns(pokemon.id);
            _addPokemonAdapter.Setup(adapter => adapter.RequestToPokemonConversor(request)).Returns(pokemon);
            //Act
            //Chamar as funções
            var result = _useCase.Execute(request);

            //Assert
            //Regras dos testes que vamos utilizar
            response.Should().BeEquivalentTo(result);

        }

        [Fact]
        public void Pokemon_AddPokemon_Length_Less_Than_Twenty()
        {
            //Arrange
            //Criar variaveis
            var request = new AddPokemonRequestBuilder().withNameLength(10).Build();
            var response = new AddPokemonResponse();

            response.message = "Erro ao adicionar o pokemon";


            //Act
            //Chamar as funções
            var result = _useCase.Execute(request);

            //Assert
            //Regras dos testes que vamos utilizar
            response.Should().BeEquivalentTo(result);

        }

        [Fact]
        public void Pokemon_AddPokemon_Repository_Exception()
        {
            //Arrange
            //Criar variaveis
            var request = new AddPokemonRequestBuilder().Build();
            var response = new AddPokemonResponse();
            var pokemon = new Pokemon();
            pokemon.id = 1;

            response.message = "Erro ao adicionar o pokemon";

            _pokemonRepository.Setup(repository => repository.Add(pokemon)).Returns(pokemon.id);
            _addPokemonAdapter.Setup(adapter => adapter.RequestToPokemonConversor(request)).Throws(new Exception());
            //Act
            //Chamar as funções
            var result = _useCase.Execute(request);

            //Assert
            //Regras dos testes que vamos utilizar
            response.Should().BeEquivalentTo(result);

        }
    }
}
