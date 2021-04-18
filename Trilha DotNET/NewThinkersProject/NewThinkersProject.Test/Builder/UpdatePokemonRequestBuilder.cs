using Bogus;
using NewThinkersProject.DTO.Pokemon.UpdatePokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewThinkersProject.Test.Builder
{
    public class UpdatePokemonRequestBuilder
    {
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly UpdatePokemonRequest _updatePokemonRequest;

        public UpdatePokemonRequestBuilder()
        {
            _updatePokemonRequest = new UpdatePokemonRequest();
            _updatePokemonRequest.name = _faker.Random.String(40);
            _updatePokemonRequest.type = _faker.Random.String(40);
        }

        public UpdatePokemonRequestBuilder withNameLength(int length)
        {
            _updatePokemonRequest.name = _faker.Random.String(length);
            return this;
        }

        public UpdatePokemonRequest Build()
        {
            return _updatePokemonRequest;
        }
    }
}
