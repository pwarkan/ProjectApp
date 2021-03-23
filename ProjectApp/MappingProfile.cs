using AutoMapper;
using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApp
{
    //Данный маппер нужен для преобразования наших моделей в DTO и из DTO в обычные модели
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientCarsForCreationDTO, ClientCar>();

            CreateMap<ClientCar, ClientCarsDTO>()
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(m => m.CarId))
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(m => m.ClientId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(m => m.Client.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(m => m.Client.LastName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(m => m.Client.MiddleName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(m => m.Client.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(m => m.Client.Email))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(m => m.Car.Brand))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(m => m.Car.Model))
                .ForMember(dest => dest.ManufacturedYear, opt => opt.MapFrom(m => m.Car.ManufacturedYear))
                .ForMember(dest => dest.ManufacturedMonth, opt => opt.MapFrom(m => m.Car.ManufacturedMonth))
                .ForMember(dest => dest.VIN, opt => opt.MapFrom(m => m.Car.VIN))
                .ForMember(dest => dest.RegistrationPlate, opt => opt.MapFrom(m => m.Car.RegistrationPlate));

            CreateMap<Client, ClientDTO>();

            CreateMap<ClientForCreationDTO, Client>();

            CreateMap<Car, CarDTO>()
                .ForMember(dest => dest.ManufacturedYear,
                opt => opt.AddTransform(src => new DateTime(src.Year, src.Month, src.Day)))
                .ForMember(dest => dest.ManufacturedMonth,
                opt => opt.AddTransform(src => new DateTime(src.Year, src.Month, src.Day)));

            CreateMap<CarForCreationDTO, Car>()
                .ForMember(dest => dest.ManufacturedYear,
                opt => opt.AddTransform(src => new DateTime(src.Year, src.Month, src.Day)))
                .ForMember(dest => dest.ManufacturedMonth,
                opt => opt.AddTransform(src => new DateTime(src.Year, src.Month, src.Day)));

            CreateMap<CarForUpdateDTO, Car>()
                .ForMember(dest => dest.ManufacturedYear,
                opt => opt.AddTransform(src => new DateTime(src.Year, src.Month, src.Day)))
                .ForMember(dest => dest.ManufacturedMonth,
                opt => opt.AddTransform(src => new DateTime(src.Year, src.Month, src.Day)));

            CreateMap<ClientForUpdateDTO, Client>();
        }
    }
}
