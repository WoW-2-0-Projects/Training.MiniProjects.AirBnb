using AirBnb.Api.Models.Dtos;
using AirBnb.Domain.Entities;
using AutoMapper;

namespace AirBnb.Api.Mappers;

public class CityMapper : Profile
{
    public CityMapper()
    {
        CreateMap<City, CityDto>().ReverseMap();
    }
}