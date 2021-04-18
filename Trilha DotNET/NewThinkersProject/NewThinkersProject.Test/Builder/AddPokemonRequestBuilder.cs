using Bogus;
using NewThinkersProject.DTO.Pokemon.AddPokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewThinkersProject.Test.Builder
{
    public class AddPokemonRequestBuilder
    {
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly AddPokemonRequest _addPokemonRequest;

        public AddPokemonRequestBuilder()
        {
            _addPokemonRequest = new AddPokemonRequest();
            _addPokemonRequest.name = _faker.Random.String(40);
            _addPokemonRequest.type = _faker.Random.String(40);
        }

        public AddPokemonRequestBuilder withNameLength(int length)
        {
            _addPokemonRequest.name = _faker.Random.String(length);
            return this;
        }

        public AddPokemonRequest Build()
        {
            return _addPokemonRequest;
        }
    }
}
