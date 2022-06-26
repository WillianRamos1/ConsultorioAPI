using Consultorio.Domain.Dtos;
using System.Threading.Tasks;

namespace Consultorio.Application.Contratos
{
    public interface IEspecialidadeService
    {
        Task<EspecialidadeDto> CadastrarEspecialidade(EspecialidadeDto especialidade);
        Task AlterarEspecialidade(EspecialidadeDto especialidade);
        Task ExcluirEspecialidade(int id);
    }
}
