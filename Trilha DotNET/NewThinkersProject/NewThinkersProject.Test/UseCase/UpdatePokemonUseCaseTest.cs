using FluentAssertions;
using Moq;
using NewThinkersProject.Border.Adapter;
using NewThinkersProject.Border.Repositories;
using NewThinkersProject.DTO.Pokemon.UpdatePokemon;
using NewThinkersProject.Entities;
using NewThinkersProject.Test.Builder;
using NewThinkersProject.UseCase.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewThinkersProject.Test.UseCase
{
    public class UpdatePokemonUseCaseTest
    {
        private readonly Mock<IPokemonRepository> _pokemonRepository;
        private readonly Mock<IUpdatePokemonAdapter> _addPokemonAdapter;
        private readonly UpdatePokemonUseCase _useCase;

        public UpdatePokemonUseCaseTest()
        {
            _pokemonRepository = new Mock<IPokemonRepository>();
            _addPokemonAdapter = new Mock<IUpdatePokemonAdapter>();
            _useCase = new UpdatePokemonUseCase(_pokemonRepository.Object, _addPokemonAdapter.Object);
        }

        [Fact]
        public void Pokemon_UpdatePokemon_Sucess()
        {
            //Arrange
            //Criar variaveis
            var request = new UpdatePokemonRequestBuilder().Build();
            var response = new UpdatePokemonResponse();
            var pokemon = new Pokemon();
            pokemon.id = request.id;
            pokemon.name = "Teste";
            pokemon.type = "Teste";

            var pokemon2 = new Pokemon();
            pokemon2.id = request.id;
            pokemon2.name = request.name;
            pokemon2.type = request.type;

            response.message = "Alteração realizada com sucesso";

            _pokemonRepository.Setup(repository => repository.Update(pokemon));
            _addPokemonAdapter.Setup(adapter => adapter.RequestToPokemonConversor(request)).Returns(pokemon2);
            //Act
            //Chamar as funções
            var result = _useCase.Execute(request);

            //Assert
            //Regras dos testes que vamos utilizar
            response.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void Pokemon_UpdatePokemon_Length_Less_Than_Twenty()
        {
            //Arrange
            //Criar variaveis
            var request = new UpdatePokemonRequestBuilder().withNameLength(10).Build();
            var response = new UpdatePokemonResponse();

            response.message = "Erro na alteração";

            //Act
            //Chamar as funções
            var result = _useCase.Execute(request);

            //Assert
            //Regras dos testes que vamos utilizar
            response.Should().BeEquivalentTo(result);

        }

        [Fact]
        public void Pokemon_UpdatePokemon_Repository_Exception()
        {
            //Arrange
            //Criar variaveis
            var request = new UpdatePokemonRequestBuilder().Build();
            var response = new UpdatePokemonResponse();
            var pokemon = new Pokemon();
            pokemon.id = request.id;
            pokemon.name = "Teste";
            pokemon.type = "Teste";

            var pokemon2 = new Pokemon();
            pokemon2.id = request.id;
            pokemon2.name = request.name;
            pokemon2.type = request.type;

            response.message = "Erro na alteração";

            _pokemonRepository.Setup(repository => repository.Update(pokemon));
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
