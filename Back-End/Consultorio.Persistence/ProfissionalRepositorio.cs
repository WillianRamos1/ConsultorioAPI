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
    public class ProfissionalRepositorio : IProfissionalRepositorio
    {
        private readonly DatabaseContext _contex;

        public ProfissionalRepositorio(DatabaseContext contex)
        {
            _contex = contex;
        }

        public async Task<IEnumerable<Profissional>> MostrarProfissionais()
        {
            return await _contex.Profissionais.ToListAsync();
        }

        public async Task<Profissional> MostrarProfissionaisById(int id)
        {
            return await _contex.Profissionais.Where(x=> x.Id == id).FirstOrDefaultAsync();
        }
    }
}
