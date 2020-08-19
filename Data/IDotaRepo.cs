using System.Collections.Generic;
using DotaAPI.Models;

namespace DotaAPI.Data
{
    public interface IDotaRepo
    {
        IEnumerable<Dota> GetAllCharacters();
        Dota GetCharacterbyId(int id);

        Dota AddCharacter(Dota character);
    } 
}