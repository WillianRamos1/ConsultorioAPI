using Consultorio.Domain.Dtos;
using System.Threading.Tasks;

namespace Consultorio.Application.Contratos
{
    public interface IConsultaService
    {
        Task<ConsultaAdicionarDto> CadastrarConsulta(ConsultaAdicionarDto consulta);
        Task AlterarConsulta(ConsultaAdicionarDto consulta);
        Task ExcluirConsulta(int id);
    }
}
