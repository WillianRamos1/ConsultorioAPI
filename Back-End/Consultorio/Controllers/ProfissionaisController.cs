using Consultorio.Application.Contratos;
using Consultorio.Domain.Dtos;
using Consultorio.Persistence.Contratos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionaisController : ControllerBase
    {
        private readonly IProfissionalRepositorio _profissionalRepositorio;
        private readonly IProfissionalService _profissionalService;


        public ProfissionaisController(IProfissionalRepositorio profissionalRepositorio, IProfissionalService profissionalService)
        {
            _profissionalRepositorio = profissionalRepositorio;
            _profissionalService = profissionalService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var profissional = await _profissionalRepositorio.MostrarProfissionais();
                return profissional.Any() ? Ok(profissional) : BadRequest("Profissionais Não Encontrados");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar mostrar Profissionais. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var profissional = await _profissionalRepositorio.MostrarProfissionaisById(id);
                if (profissional == null) return BadRequest("Profissional Não Encontrada.");
                return Ok(profissional);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar mostrar Profissional {id}. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProfissionalDto profissional)
        {
            try
            {
                var adicionar = await _profissionalService.CadastrarProfissional(profissional);
                if (adicionar == null) return NoContent();
                return Ok("Profissional Adicionado com Sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Cadastrar Profissional {profissional}. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProfissionalDto profissional)
        {
            try
            {
                await _profissionalService.AlterarProfissional(profissional);
                return Ok(profissional);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Alterar Profissional. Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _profissionalService.ExcluirProfissional(id);
                return Ok("Profissional Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Excluir Profissional {id}. Erro: {ex.Message}");
            }
        }
    }
}
