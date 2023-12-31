using AirBnb.Application.RequestContexts.Brokers;
using AirBnb.Domain.Common.Entities;
using AirBnb.Domain.Entities;
using AutoMapper;

namespace AirBnb.Infrastructure.Finances.Mappers;

public class ComputedMoneyConverter(IRequestContextProvider requestContextProvider) : IValueConverter<Money, ComputedMoney>
{
    public ComputedMoney Convert(Money money, ResolutionContext context)
    {
        // TODO : compute money
        return new ComputedMoney
        {
            CalculatedAmount = money.Amount,
            UserCurrency = money.Currency
        };
    }
}