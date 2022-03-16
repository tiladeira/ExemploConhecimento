using Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace InfraData.Context
{
    public class DBContextEFCore : DbContext
    {
        public DBContextEFCore(DbContextOptions<DBContextEFCore> options) : base(options)
        {
        }

        public virtual DbSet<CidadaoEntity> Cidadao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
