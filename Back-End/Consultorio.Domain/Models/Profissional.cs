using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Domain.Models
{
    public class Profissional
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public bool Ativo { get; set; }

        public List<Consulta> Consultas { get; set; }
        public List<Especialidade> Especialidades { get; set; }
    }
}
