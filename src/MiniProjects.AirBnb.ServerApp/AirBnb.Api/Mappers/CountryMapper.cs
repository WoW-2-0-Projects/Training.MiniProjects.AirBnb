using AirBnb.Api.Models.Dtos;
using AirBnb.Domain.Entities;
using AutoMapper;

namespace AirBnb.Api.Mappers;

public class CountryMapper : Profile
{
    public CountryMapper()
    {
        CreateMap<Country, CountryDto>().ReverseMap();
    }
}