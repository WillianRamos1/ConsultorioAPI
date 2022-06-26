using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Domain.Dtos
{
    public class ConsultaAdicionarDto
    {
        public int Id { get; set; }
        public DateTime DataHorario { get; set; }
        public int Status { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        public int PacienteId { get; set; }
        public int EspecialidadeId { get; set; }
        public int ProfissionalId { get; set; }
    }
}
