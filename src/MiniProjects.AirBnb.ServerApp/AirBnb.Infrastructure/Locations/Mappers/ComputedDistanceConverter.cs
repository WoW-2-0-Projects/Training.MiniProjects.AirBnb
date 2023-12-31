using AirBnb.Application.RequestContexts.Brokers;
using AirBnb.Domain.Common.Entities;
using AirBnb.Domain.Entities;
using AutoMapper;

namespace AirBnb.Infrastructure.Locations.Mappers;

public class ComputedDistanceConverter(IRequestContextProvider requestContextProvider) : IValueConverter<Address, ComputedDistance>
{
    public ComputedDistance Convert(Address addresss, ResolutionContext context)
    {
        var userInfo = requestContextProvider.GetRequestContext();

        // TODO : compute distance
        var computedDistance = new ComputedDistance
        {
            DisplayAddress = "test",
            DistanceFromUserInKm = 1000
        };

        return computedDistance;
    }
}