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
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;
        private readonly IPacienteService _pacienteService;

        public PacientesController(IPacienteRepositorio pacienteRepositorio, IPacienteService pacienteService)
        {
            _pacienteRepositorio = pacienteRepositorio;
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pacientes = await _pacienteRepositorio.MostrarPacientes();

                return pacientes.Any() ? Ok(pacientes) : BadRequest("Pacientes Não Encontrados.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar mostrar Pacientes. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var paciente = await _pacienteRepositorio.MostrarPacientesById(id);
                if(paciente == null) return BadRequest("Paciente Não Encontrado.");
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar recuperar Paciente {id}. Erro: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(PacienteAdicionarDto paciente)
        {
            try
            {
                var cadastrar = await _pacienteService.CadastrarPaciente(paciente);
                if (cadastrar == null) return NoContent();
                return Ok("Paciente Adicionado com Sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Cadastrar Paciente {paciente}. Erro: {ex.Message}");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] PacienteAdicionarDto paciente)
        {
            try
            {
                await _pacienteService.AlterarPaciente(paciente);
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Alterar Paciente. Erro: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _pacienteService.ExcluirPaciente(id);
                return Ok("Paciente Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Excluir Paciente {id}. Erro: {ex.Message}");
            }
        }
    }
}
