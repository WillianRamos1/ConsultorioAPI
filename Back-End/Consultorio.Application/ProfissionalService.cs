using AutoMapper;
using Consultorio.Application.Contratos;
using Consultorio.Domain.Dtos;
using Consultorio.Domain.Models;
using Consultorio.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Application
{
    public class ProfissionalService : IProfissionalService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ProfissionalService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProfissionalDto> CadastrarProfissional(ProfissionalDto profissional)
        {
            var adicionar = _mapper.Map<Profissional>(profissional);
            _context.Add(adicionar);
            await _context.SaveChangesAsync();
            return profissional;
        }

        public async Task AlterarProfissional(ProfissionalDto profissional)
        {
            var alterar = _mapper.Map<Profissional>(profissional);
            _context.Entry(alterar).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirProfissional(int id)
        {
            var deletar = await _context.Profissionais.FindAsync(id);
            _context.Profissionais.Remove(deletar);
            await _context.SaveChangesAsync();
        }
    }
}
