using System.Collections.Generic;
using DotaAPI.Models;

namespace DotaAPI.Data

{
    public class MockDotaRepo : IDotaRepo
    {
        public IEnumerable<Dota> GetAllCharacters()
        {
            var DotaList = new List<Dota>
            {
                new Dota{
                    Id = 0,
                    Character = "Juggernaut",
                    Power = 1000,
                    Type = "Melee"
                },
                new Dota{
                    Id = 1,
                    Character = "Lina",
                    Power = 800,
                    Type = "Ranged"
                },
                new Dota{
                    Id = 2,
                    Character = "Troll",
                    Power = 1200,
                    Type = "Melee/Ranged"
                }
            };
            return DotaList;
        }
        public Dota GetCharacterbyId(int id)
        {
            return new Dota{
                Id = 0,
                Character = "Jugg",
                Power = 1000,
                Type = "Melee"
            };
        }

        Dota IDotaRepo.AddCharacter(Dota character)
        {
            throw new System.NotImplementedException();
        }
    }
}