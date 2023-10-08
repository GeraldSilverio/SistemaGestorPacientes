using AutoMapper;
using GestorDePacientes.Core.Application.ViewModels.RolViewModels;
using GestorDePacientes.Core.Application.ViewModels.UserViewModels;
using GestorDePacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Application.Mappings
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile() 
        {
            CreateMap<User, UserViewModel>().ForMember(x => x.RolName, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Creaty, opt => opt.Ignore())
                .ForMember(x => x.CreatyBy, opt => opt.Ignore());

            CreateMap<User, SaveUserViewModel>()
                .ReverseMap()
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Creaty, opt => opt.Ignore())
                .ForMember(x => x.CreatyBy, opt => opt.Ignore());

            CreateMap<Rol, RolViewModel>()
                .ReverseMap()
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Creaty, opt => opt.Ignore())
                .ForMember(x => x.CreatyBy, opt => opt.Ignore());

        }
    }
}
