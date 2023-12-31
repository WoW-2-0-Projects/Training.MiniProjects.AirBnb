using AirBnb.Api.Models.Dtos;
using AirBnb.Domain.Entities;
using AirBnb.Infrastructure.StorageFiles.Mappers;
using AutoMapper;

namespace AirBnb.Api.Mappers;

public class ListingCategoryMapper : Profile
{
    public ListingCategoryMapper()
    {
        CreateMap<ListingCategory, ListingCategoryDto>()
            .ForMember(dest => dest.ImageUrl, opt => opt.ConvertUsing<StorageFileToUrlConverter, StorageFile>(src => src.ImageStorageFile));
    }
}