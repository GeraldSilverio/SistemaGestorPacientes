using AutoMapper;
using GestorDePacientes.Core.Application.ViewModels.DoctorViewModels;
using GestorDePacientes.Core.Application.ViewModels.PatientViewModels;
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
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Users
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
            #endregion

            #region Rols
            CreateMap<Rol, RolViewModel>()
                .ReverseMap()
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Creaty, opt => opt.Ignore())
                .ForMember(x => x.CreatyBy, opt => opt.Ignore());
            #endregion

            #region Patients
            CreateMap<Patient, PatientViewModel>()
                .ReverseMap()
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Creaty, opt => opt.Ignore())
                .ForMember(x => x.CreatyBy, opt => opt.Ignore());

            CreateMap<Patient, SavePatientViewModel>()
                .ForMember(x=> x.File, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Creaty, opt => opt.Ignore())
                .ForMember(x => x.CreatyBy, opt => opt.Ignore());
            #endregion

            #region Doctors
            CreateMap<Doctor, SaveDoctorViewModel>()
                .ForMember(x => x.File, opt => opt.Ignore())
                .ReverseMap()
                 .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Creaty, opt => opt.Ignore())
                .ForMember(x => x.CreatyBy, opt => opt.Ignore());

            CreateMap<Doctor, DoctorViewModel>()
               .ReverseMap()
                .ForMember(x => x.LastModified, opt => opt.Ignore())
               .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
               .ForMember(x => x.Creaty, opt => opt.Ignore())
               .ForMember(x => x.CreatyBy, opt => opt.Ignore());

            #endregion

        }
    }
}
