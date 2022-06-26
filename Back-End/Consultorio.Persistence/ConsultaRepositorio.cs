using Consultorio.Domain.Dtos;
using Consultorio.Domain.Models;
using Consultorio.Persistence.Context;
using Consultorio.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Persistence
{
    public class ConsultaRepositorio : IConsultaRepositorio
    {
        private readonly DatabaseContext _context;


        public ConsultaRepositorio(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Consulta>> MostrarConsultas()
        {
            return await _context.Consultas.Include(x=> x.Paciente).Include(x => x.Especialidade).Include(x => x.Profissional).ToListAsync();
        }

        public async Task<Consulta> MostrarConsultasById(int id)
        {
            return await _context.Consultas.Include(x => x.Paciente).Include(x => x.Especialidade).Include(x => x.Profissional).Where( x=> x.Id == id).FirstOrDefaultAsync();
        }
    }
}
