using NewThinkersProject.DTO.Pokemon.GetPokemonById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.Border.UseCase
{
    public interface IGetPokemonByIdUseCase
    {
        GetPokemonByIdResponse Execute(GetPokemonByIdRequest request);
    }
}
