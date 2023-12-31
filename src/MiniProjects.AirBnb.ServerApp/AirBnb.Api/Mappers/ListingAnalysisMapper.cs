using AirBnb.Api.Models.Dtos;
using AirBnb.Application.Listings.Models;
using AirBnb.Domain.Entities;
using AirBnb.Infrastructure.Finances.Mappers;
using AirBnb.Infrastructure.Locations.Mappers;
using AirBnb.Infrastructure.StorageFiles.Mappers;
using AutoMapper;

namespace AirBnb.Api.Mappers;

public class ListingAnalysisMapper : Profile
{
    public ListingAnalysisMapper()
    {
        CreateMap<ListingAnalysisDetails, ListingAnalysisDetailsDto>()
            .ForMember(dest => dest.Name, src => src.MapFrom(opt => opt.Listing.Name))
            .ForMember(dest => dest.BuiltDate, src => src.MapFrom(opt => opt.Listing.BuiltDate))
            .ForMember(dest => dest.Address, src => src.ConvertUsing<ComputedDistanceConverter, Address>(opt => opt.Listing.Address))
            .ForMember(dest => dest.PricePerNight, src => src.ConvertUsing<ComputedMoneyConverter, Money>(opt => opt.Listing.PricePerNight))
            .ForMember(dest => dest.ImagesUrl, src => src.ConvertUsing<ListingMediaToUrlConverter, IList<ListingMedia>>(opt => opt.Listing.ImagesStorageFile));
    }
}