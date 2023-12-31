using AirBnb.Persistence.Caching.Models;
using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;

namespace AirBnb.Infrastructure.Common.Caching.Mappers;

public class DistributedCacheEntryOptionsMapper : Profile
{
    public DistributedCacheEntryOptionsMapper()
    {
        CreateMap<CacheEntryOptions, DistributedCacheEntryOptions>();
    }
}