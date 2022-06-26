using Consultorio.Domain.Dtos;
using System.Threading.Tasks;

namespace Consultorio.Application.Contratos
{
    public interface IPacienteService
    {
        Task<PacienteAdicionarDto> CadastrarPaciente(PacienteAdicionarDto paciente);
        Task AlterarPaciente(PacienteAdicionarDto paciente);
        Task ExcluirPaciente(int id);
    }
}
