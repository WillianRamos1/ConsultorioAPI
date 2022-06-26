using AutoMapper;
using Consultorio.Domain.Dtos;
using Consultorio.Domain.Models;

namespace Consultorio.Application.Helpers
{
    public class ConsultorioProfile : Profile
    {
        public ConsultorioProfile()
        {
            CreateMap<Paciente, PacienteAdicionarDto>().ReverseMap();
            CreateMap<Paciente, PacienteDto>().ReverseMap();
            CreateMap<Consulta, ConsultaAdicionarDto>().ReverseMap();
            CreateMap<Consulta, ConsultaDetalhesDto>().ReverseMap().ForMember(dest => dest.Especialidade, opt => opt.MapFrom(src => src.Especialidade.Nome)).ForMember(dest => dest.Profissional, opt => opt.MapFrom(src => src.Profissional.Nome));
            CreateMap<Especialidade, EspecialidadeDto>().ReverseMap();
            CreateMap<Profissional, ProfissionalDto>().ReverseMap();
        }
    }
}
