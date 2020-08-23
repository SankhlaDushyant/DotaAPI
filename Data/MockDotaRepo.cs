using System.Collections.Generic;
using DotaAPI.Models;

namespace DotaAPI.Data

{
    public class MockDotaRepo : IDotaRepo
    {
        public Dota AddCharacter(Dota character)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCharacter(int id)
        {
            throw new System.NotImplementedException();
        }

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
            return new Dota
            {
                Id = 0,
                Character = "Jugg",
                Power = 1000,
                Type = "Melee"
            };
        }

        public Dota UpdateCharacter(Dota character)
        {
            throw new System.NotImplementedException();
        }
    }
}