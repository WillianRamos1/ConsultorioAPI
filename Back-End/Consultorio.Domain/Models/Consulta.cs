using Consultorio.Domain.Dtos;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consultorio.Domain.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime DataHorario { get; set; }
        public int Status { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        public int PacienteId { get; set; }
        public int EspecialidadeId { get; set; }
        public int ProfissionalId { get; set; }

        public Paciente Paciente { get; set; }
        public Especialidade Especialidade { get; set; }
        public Profissional Profissional { get; set; }
    }
}
