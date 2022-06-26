using Consultorio.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Application.Contratos
{
    public interface IProfissionalService
    {
        Task<ProfissionalDto> CadastrarProfissional(ProfissionalDto profissional);
        Task AlterarProfissional(ProfissionalDto profissional);
        Task ExcluirProfissional(int id);
    }
}
