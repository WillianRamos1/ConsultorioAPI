using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Persistence.Contratos
{
    public interface IEspecialidadeRepositorio
    {
        Task<IEnumerable<Especialidade>> MostrarEspecialidades();
        Task<Especialidade> MostrarEspecialidadesById(int id);
    }
}
