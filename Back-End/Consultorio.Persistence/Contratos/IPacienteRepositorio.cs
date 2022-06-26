using Consultorio.Domain.Dtos;
using Consultorio.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultorio.Persistence.Contratos
{
    public interface IPacienteRepositorio
    {
        Task<IEnumerable<PacienteDto>> MostrarPacientes();
        Task<Paciente> MostrarPacientesById(int id);
    }
}
