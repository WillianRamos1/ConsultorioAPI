using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Persistence.Contratos
{
    public interface IProfissionalRepositorio
    {
        Task<IEnumerable<Profissional>> MostrarProfissionais();
        Task<Profissional> MostrarProfissionaisById(int id);
    }
}
