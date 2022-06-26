using AutoMapper;
using Consultorio.Application.Contratos;
using Consultorio.Domain.Dtos;
using Consultorio.Domain.Models;
using Consultorio.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Consultorio.Repositorio
{
    public class PacienteService : IPacienteService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public PacienteService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PacienteAdicionarDto> CadastrarPaciente(PacienteAdicionarDto paciente)
        {
            var adicionar = _mapper.Map<Paciente>(paciente);
            _context.Add(adicionar);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task AlterarPaciente(PacienteAdicionarDto paciente)
        {
            var alterar = _mapper.Map<Paciente>(paciente);
            _context.Entry(alterar).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task ExcluirPaciente(int id)
        {
            var deletar = await _context.Pacientes.FindAsync(id);
            _context.Pacientes.Remove(deletar);
            await _context.SaveChangesAsync();
        }
    }
}
