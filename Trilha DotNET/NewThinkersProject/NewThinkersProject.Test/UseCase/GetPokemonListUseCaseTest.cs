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
    public class GetPokemonListUseCaseTest
    {
        private readonly Mock<IPokemonRepository> _pokemonRepository;
        private readonly GetPokemonListUseCase _useCase;

        public GetPokemonListUseCaseTest()
        {
            _pokemonRepository = new Mock<IPokemonRepository>();
            _useCase = new GetPokemonListUseCase(_pokemonRepository.Object);
        }

        [Fact]
        public void Pokemon_GetPokemonList_Sucess()
        {
            var response = new GetPokemonListResponse();
            var pokemon1 = new Pokemon();
            pokemon1.id = 1;
            pokemon1.name = "Pikachu";
            pokemon1.type = "Elétrico";

            var pokemon2 = new Pokemon();
            pokemon2.id = 2;
            pokemon2.name = "Pichu";
            pokemon2.type = "Elétrico";

            List<Pokemon> pokemonList = new List<Pokemon>();

            pokemonList.Add(pokemon1);
            pokemonList.Add(pokemon2);

            response.list = pokemonList;

            string message = string.Empty;
            foreach (Pokemon pokemon in pokemonList)
            {
                string pokemonString = "Nome: " + pokemon.name + " | Tipo: " + pokemon.type + "\n";
                message += pokemonString;
            }
            response.message = message;


            _pokemonRepository.Setup(repository => repository.GetList()).Returns(pokemonList);

            var result = _useCase.Execute();

            response.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void Pokemon_GetPokemonList_Return_Exception()
        {
            var response = new GetPokemonListResponse();
            response.message = "Não foi possivel listar os pokemons";


            _pokemonRepository.Setup(repository => repository.GetList()).Throws(new Exception());

            var result = _useCase.Execute();

            response.Should().BeEquivalentTo(result);
        }
    }
}
