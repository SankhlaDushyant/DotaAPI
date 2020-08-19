using DotaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace DotaAPI.Data
{
    public class SqlDotaRepoWithEf : IDotaRepo
    {
        private readonly DotaContext _context;

        public SqlDotaRepoWithEf(DotaContext context)
        {
            _context = context;
        }
        public IEnumerable<Dota> GetAllCharacters()
        {
            return _context.Dotas.ToList();
        }

        public Dota GetCharacterbyId(int id)
        {
            return _context.Dotas.FirstOrDefault(p => p.Id == id);
        }

        Dota IDotaRepo.AddCharacter(Dota character)
        {
            throw new System.NotImplementedException();
        }
    }
}
