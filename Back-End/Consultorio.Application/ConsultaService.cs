using AutoMapper;
using Consultorio.Application.Contratos;
using Consultorio.Domain.Dtos;
using Consultorio.Domain.Models;
using Consultorio.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Consultorio.Application
{
    public class ConsultaService : IConsultaService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ConsultaService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ConsultaAdicionarDto> CadastrarConsulta(ConsultaAdicionarDto consulta)
        {
            var adicionar = _mapper.Map<Consulta>(consulta);
            _context.Add(adicionar);
            await _context.SaveChangesAsync();
            return consulta;
        }

        public async Task AlterarConsulta(ConsultaAdicionarDto consulta)
        {
            var alterar = _mapper.Map<Consulta>(consulta);
            _context.Entry(alterar).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirConsulta(int id)
        {
            var deletar = await _context.Consultas.FindAsync(id);
            _context.Consultas.Remove(deletar);
            await _context.SaveChangesAsync();
        }
    }
}
