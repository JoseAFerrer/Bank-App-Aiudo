using AutoMapper;
using BankAppAiudo.Entities;
using BankAppAiudo.PersistenceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppAiudo.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ClienteDocument, Cliente>(); //Source/Destination
            CreateMap<Cliente, ClienteDocument>();

            CreateMap<MovimientoDocument, Transferencia>(); //Source/Destination
            CreateMap<Transferencia, MovimientoDocument>()
                .ForMember(dest => dest.Interest, opt => opt.MapFrom(src => 0));

            CreateMap<MovimientoDocument, Prestamo>(); //Source/Destination
            CreateMap<Prestamo, MovimientoDocument>();
        }
    }
}
