using AutoMapper;
using Consultorio.Application.Contratos;
using Consultorio.Domain.Dtos;
using Consultorio.Domain.Models;
using Consultorio.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Consultorio.Application
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public EspecialidadeService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EspecialidadeDto> CadastrarEspecialidade(EspecialidadeDto especialidade)
        {
            var adicionar = _mapper.Map<Especialidade>(especialidade);
            _context.Add(adicionar);
            await _context.SaveChangesAsync();
            return especialidade;
        }

        public async Task AlterarEspecialidade(EspecialidadeDto especialidade)
        {
            var alterar = _mapper.Map<Especialidade>(especialidade);
            _context.Entry(alterar).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirEspecialidade(int id)
        {
            var deletar = await _context.Especialidades.FindAsync(id);
            _context.Especialidades.Remove(deletar);
            await _context.SaveChangesAsync();
        }
    }
}
