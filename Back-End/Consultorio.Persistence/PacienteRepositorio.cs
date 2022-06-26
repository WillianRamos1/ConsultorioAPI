using Consultorio.Domain.Dtos;
using Consultorio.Domain.Models;
using Consultorio.Persistence.Context;
using Consultorio.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Repositorio
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly DatabaseContext _contex;

        public PacienteRepositorio(DatabaseContext contex)
        {
            _contex = contex;
        }

        public async Task<IEnumerable<PacienteDto>> MostrarPacientes()
        {
            return await _contex.Pacientes.Select(x => new PacienteDto { Id = x.Id, Nome = x.Nome })
                .ToListAsync();
        }

        public async Task<Paciente> MostrarPacientesById(int id)
        {
            return await _contex.Pacientes.Include(x => x.Consultas)
                         .ThenInclude(c => c.Especialidade)
                         .ThenInclude(c => c.Profissionais)
                        .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
