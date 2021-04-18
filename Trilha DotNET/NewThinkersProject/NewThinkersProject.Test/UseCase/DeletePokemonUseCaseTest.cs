using FluentAssertions;
using Moq;
using NewThinkersProject.Border.Repositories;
using NewThinkersProject.DTO.Pokemon.DeletePokemon;
using NewThinkersProject.Entities;
using NewThinkersProject.UseCase.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewThinkersProject.Test.UseCase
{
    public class DeletePokemonUseCaseTest
    {
        private readonly Mock<IPokemonRepository> _pokemonRepository;
        private readonly DeletePokemonUseCase _useCase;

        public DeletePokemonUseCaseTest()
        {
            _pokemonRepository = new Mock<IPokemonRepository>();
            _useCase = new DeletePokemonUseCase(_pokemonRepository.Object);
        }

        [Fact]
        
        public void Pokemon_DeletePokemon_Sucess()
        {
            var request = new DeletePokemonRequest();
            var response = new DeletePokemonResponse();
            var pokemon = new Pokemon();
           
            pokemon.id = 1;
            request.id = pokemon.id;
            response.message = "Pokemon deletado!";

            var deleted = true;

            _pokemonRepository.Setup(repository => repository.Delete(request.id)).Returns(deleted);

            var result = _useCase.Execute(request);

            response.Should().BeEquivalentTo(result);

        }

        [Fact]
        public void Pokemon_DeletePokemon_Return_False()
        {
            var request = new DeletePokemonRequest();
            var response = new DeletePokemonResponse();
            var pokemon = new Pokemon();

            pokemon.id = 1;
            request.id = 2;
            response.message = "Erro ao deleter o pokemon";

            var deleted = false;

            _pokemonRepository.Setup(repository => repository.Delete(request.id)).Returns(deleted);

            var result = _useCase.Execute(request);

            response.Should().BeEquivalentTo(result);

        }


        [Fact]
        public void Pokemon_DeletePokemon_Repository_Exception()
        {
            var request = new DeletePokemonRequest();
            var response = new DeletePokemonResponse();
            request.id = 2;

            response.message = "Erro ao deleter o pokemon";

            _pokemonRepository.Setup(repository => repository.Delete(request.id)).Throws(new Exception());

            var result = _useCase.Execute(request);

            response.Should().BeEquivalentTo(result);

        }
    }
}
