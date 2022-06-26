using Consultorio.Domain.Dtos;
using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Persistence.Contratos
{
    public interface IConsultaRepositorio
    {
        Task<IEnumerable<Consulta>> MostrarConsultas();
        Task<Consulta> MostrarConsultasById(int id);
    }
}
