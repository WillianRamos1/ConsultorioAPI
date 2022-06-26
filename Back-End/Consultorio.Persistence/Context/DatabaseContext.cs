using Consultorio.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Persistence.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Consulta>().HasOne(x=> x.Paciente).WithMany(x => x.Consultas).HasForeignKey(x => x.PacienteId);
            modelBuilder.Entity<Consulta>().HasOne(x => x.Especialidade).WithMany(x => x.Consultas).HasForeignKey(x => x.EspecialidadeId);
            modelBuilder.Entity<Consulta>().HasOne(x => x.Profissional).WithMany(x => x.Consultas).HasForeignKey(x => x.ProfissionalId);
        }
    }
}
