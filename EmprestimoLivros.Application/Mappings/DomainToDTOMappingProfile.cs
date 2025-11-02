using AutoMapper;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.SystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Cliente, ClienteDTOs>().ReverseMap();
            CreateMap<Usuario, UsuarioDTOs>().ReverseMap();
            CreateMap<Livro, LivroDTOs>().ReverseMap();
            CreateMap<LivroCLienteEmprestimo, EmprestimoDTOs>()
                .ForMember(dest => dest.ClienteDTO, opt =>opt.MapFrom(x=>x.Cliente))
                .ForMember(dest =>dest.LivroDTO, opt =>opt.MapFrom(x=>x.Livro)).ReverseMap();
            CreateMap<LivroCLienteEmprestimo, EmprestimoPostDTOs>().ReverseMap();
            CreateMap<QuantidadeItens, QuantidadeItensDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioPutDTO>().ReverseMap();



        }
    }
}
