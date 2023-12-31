using AirBnb.Api.Models.Dtos;
using AirBnb.Domain.Common.Entities;
using AirBnb.Domain.Entities;
using AutoMapper;

namespace AirBnb.Api.Mappers;

public class AddressMapper : Profile
{
    public AddressMapper()
    {
        CreateMap<Address, ComputedDistance>();
    }
}