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
    public class EspecialidadeRepositorio : IEspecialidadeRepositorio
    {
        private readonly DatabaseContext _contex;

        public EspecialidadeRepositorio(DatabaseContext contex)
        {
            _contex = contex;
        }

        public async Task<IEnumerable<Especialidade>> MostrarEspecialidades()
        {
            return await _contex.Especialidades.ToListAsync();
        }

        public async Task<Especialidade> MostrarEspecialidadesById(int id)
        {
            return await _contex.Especialidades.Where(x=> x.Id == id).FirstOrDefaultAsync();
        }
    }
}
