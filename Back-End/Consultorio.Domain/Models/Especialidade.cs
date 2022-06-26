using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Domain.Models
{
    public class Especialidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativa { get; set; }

        public List<Profissional> Profissionais { get; set; }
        public List<Consulta> Consultas { get; set; }
    }
}
