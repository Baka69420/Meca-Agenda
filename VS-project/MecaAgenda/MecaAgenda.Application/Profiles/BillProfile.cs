using AutoMapper;
using MecaAgenda.Application.DTOs;
using MecaAgenda.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Profiles
{
    public class BillProfile : Profile
    {
        public BillProfile()
        {
            CreateMap<BillDTO, Bills>().ReverseMap();
        }
    }
}
