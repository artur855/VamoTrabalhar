﻿using AutoMapper;
using Hospital.Application.DTO;
using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.Mapping
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            CreateMap<ExamRequest, ExamRequestDTO>()
                .ForMember(dest => dest.MedicName, opt => opt.MapFrom(src => src.Medic.User.Name))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.User.Name))
                .ForMember(dest => dest.ExpectedDate, opt => opt.ConvertUsing(new DateConverter(), src => src.ExpectedDate))
                .ReverseMap();

            CreateMap<Medic, MedicDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .IncludeAllDerived()
                .ReverseMap();

            CreateMap<Resident, ResidentDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.InitialDate, opt => opt.ConvertUsing(new DateConverter(), src => src.InitialDate))
                .ReverseMap();

            CreateMap<Docent, DocentDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ReverseMap();

            CreateMap<Patient, PatientDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Birthdate, opt => opt.ConvertUsing(new DateConverter(), src => src.Birthdate))
                .ForMember(dest => dest.Sex, opt => opt.ConvertUsing(new SexConverter(), src => src.Sex))
                .ReverseMap();

            CreateMap<Exam, ExamDTO>()
                .ForMember(dest => dest.Date, opt => opt.ConvertUsing(new DateConverter(), src => src.Date))
                .ForMember(dest => dest.MedicName, opt => opt.MapFrom(src => src.ExamRequest.Medic.User.Name))
                .ForMember(dest => dest.MedicCRM, opt => opt.MapFrom(src => src.ExamRequest.Medic.CRM))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.ExamRequest.Patient.User.Name))
                .ReverseMap();




        }
    }
}
