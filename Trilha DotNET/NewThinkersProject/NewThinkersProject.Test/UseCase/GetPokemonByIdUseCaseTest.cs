using FluentAssertions;
using Moq;
using NewThinkersProject.Border.Repositories;
using NewThinkersProject.DTO.Pokemon.GetPokemonById;
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
    public class GetPokemonByIdUseCaseTest
    {
        private readonly Mock<IPokemonRepository> _pokemonRepository;
        private readonly GetPokemonByIdUseCase _useCase;
        public GetPokemonByIdUseCaseTest()
        {
            _pokemonRepository = new Mock<IPokemonRepository>();
            _useCase = new GetPokemonByIdUseCase(_pokemonRepository.Object);
        }

        [Fact]
        public void Pokemon_GetPokemonById_Sucess()
        {
            var request = new GetPokemonByIdRequest();
            var response = new GetPokemonByIdResponse();
            var pokemon = new Pokemon();
            pokemon.id = 1;
            pokemon.name = "Pikachu";
            pokemon.type = "Elétrico";

            request.id = pokemon.id;

            response.message = "Nome: " + pokemon.name + "\nTipo: " + pokemon.type;

            _pokemonRepository.Setup(repository => repository.Get(request.id)).Returns(pokemon);

            var result = _useCase.Execute(request);

            response.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void Pokemon_GetPokemonById_Return_Exception()
        {
            var request = new GetPokemonByIdRequest();
            var response = new GetPokemonByIdResponse();

            request.id = 2;

            response.message = "Pokemon não encontrado";

            _pokemonRepository.Setup(repository => repository.Get(request.id)).Throws(new Exception());

            var result = _useCase.Execute(request);

            response.Should().BeEquivalentTo(result);
        }
    }
}
