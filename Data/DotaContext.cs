using DotaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotaAPI.Data
{
	public class DotaContext : DbContext
    {
        public DotaContext(DbContextOptions<DotaContext> opt) : base(opt)
        {

        }

        public DbSet<Dota> Dotas { get; set; }
    }
}