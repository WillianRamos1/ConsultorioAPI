using AutoMapper;
using Consultorio.Application.Contratos;
using Consultorio.Domain.Dtos;
using Consultorio.Persistence.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaRepositorio _consultaRepositorio;
        private readonly IConsultaService _consultaService;
        private readonly IMapper _mapper;


        public ConsultasController(IConsultaRepositorio consultaRepositorio, IConsultaService consultaService, IMapper mapper)
        {
            _consultaRepositorio = consultaRepositorio;
            _consultaService = consultaService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var consulta = await _consultaRepositorio.MostrarConsultas();
                var retorno = _mapper.Map<IEnumerable<ConsultaDetalhesDto>>(consulta);
                return retorno.Any() ? Ok(retorno) : BadRequest("Consultas Não Encontradas.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar mostrar Consultas. Erro: {ex.Message}");
            }     
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var consulta = await _consultaRepositorio.MostrarConsultasById(id);
                var retorno = _mapper.Map<ConsultaDetalhesDto>(consulta);
                if (consulta == null) return BadRequest("Consulta Não Encontrada.");
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar mostrar Consulta {id}. Erro: {ex.Message}");
            }        
        }

        [HttpPost]
        public async Task<IActionResult> Post(ConsultaAdicionarDto consulta)
        {
            try
            {
                var cadastrar = await _consultaService.CadastrarConsulta(consulta);
                if (cadastrar == null) return NoContent();
                return Ok("Consulta Adicionada com Sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Cadastrar Consulta {consulta}. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] ConsultaAdicionarDto consulta)
        {
            try
            {
                await _consultaService.AlterarConsulta(consulta);
                return Ok(consulta);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Alterar Consulta. Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _consultaService.ExcluirConsulta(id);
                return Ok("Consulta Deletada com Sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Deletar Consulta. Erro: {ex.Message}");
            }        
        }
    }
}
