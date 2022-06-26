using Consultorio.Application.Contratos;
using Consultorio.Domain.Dtos;
using Consultorio.Persistence.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly IEspecialidadeRepositorio _especialidadeRepositorio;
        private readonly IEspecialidadeService _especialidadeService;


        public EspecialidadesController(IEspecialidadeRepositorio especialidadeRepositorio, IEspecialidadeService especialidadeService)
        {
            _especialidadeRepositorio = especialidadeRepositorio;
            _especialidadeService = especialidadeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var especialidade = await _especialidadeRepositorio.MostrarEspecialidades();
                return especialidade.Any() ? Ok(especialidade) : BadRequest("Especialidades Não Encontradas.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar mostrar Especialidades. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var especialidade = await _especialidadeRepositorio.MostrarEspecialidadesById(id);
                if (especialidade == null) return BadRequest("Especialidade Não Encontrada.");
                return Ok(especialidade);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar mostrar Especialidade {id}. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EspecialidadeDto especialidade)
        {
            try
            {
                var adicionar = await _especialidadeService.CadastrarEspecialidade(especialidade);
                if (adicionar == null) return NoContent();
                return Ok("Especialidade Adicionada com Sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Cadastrar Especialidade {especialidade}. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(EspecialidadeDto especialidade)
        {
            try
            {
                await _especialidadeService.AlterarEspecialidade(especialidade);
                return Ok(especialidade);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Alterar Especialidade. Erro: {ex.Message}");
            }        
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _especialidadeService.ExcluirEspecialidade(id);
                return Ok("Especialidade Deletada com Sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Excluir Especialidade {id}. Erro: {ex.Message}");
            }
        }
    }
}
