using AutoMapper;
using FinalProject.Entities.Models;
using FinalProject.Shared;
using System;
using System.Linq;

namespace FinalProject.Web.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Ambulance
            CreateMap<Ambulance, AmbulanceDto>()
                .ForMember(dest => dest.VehicleType,
                    opt => opt.MapFrom(src => src.VehicleType.ToString()));
            CreateMap<AmbulanceDto, Ambulance>()
                .ForMember(dest => dest.VehicleType,
                    opt => opt.MapFrom(src => ParseVehicleType(src.VehicleType)));

            // Room
            CreateMap<Room, RoomDto>()
                .ForMember(dest => dest.BedType,
                    opt => opt.MapFrom(src => src.BedType.ToString()));
            CreateMap<RoomDto, Room>()
                .ForMember(dest => dest.BedType,
                    opt => opt.MapFrom(src => Enum.Parse<BedType>(src.BedType, true)));

            // Patient
            CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.PatientId,
                    opt => opt.MapFrom(src => src.PatientId))
                .ReverseMap()
                .ForMember(dest => dest.Room, opt => opt.Ignore());

            // Department
            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.EmpaneledDoctorNames,
                    opt => opt.MapFrom(src => src.EmpaneledDoctorNames != null
                        ? src.EmpaneledDoctorNames.Select(e => e.Name).ToList()
                        : new List<string>()))
                .ReverseMap()
                .ForMember(dest => dest.EmpaneledDoctorNames, opt => opt.Ignore());

            // Employee
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.EmployeeId))
                .ReverseMap()
                .ForMember(dest => dest.EmployeeId,
                    opt => opt.MapFrom(src => src.Id));
        }

        private static VehicleType ParseVehicleType(string vehicleTypeStr)
        {
            return Enum.TryParse<VehicleType>(vehicleTypeStr, out var vt)
                ? vt
                : VehicleType.Normal;
        }
    }
}
