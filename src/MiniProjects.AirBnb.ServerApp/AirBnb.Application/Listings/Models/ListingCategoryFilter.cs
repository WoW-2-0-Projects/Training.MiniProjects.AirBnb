using AirBnb.Domain.Common.Query;

namespace AirBnb.Application.Listings.Models;

/// <summary>
/// Represents a listing category filter
/// </summary>
public class ListingCategoryFilter : FilterPagination
{
    public ListingCategoryFilter()
    {
        // Set pagination to max values
        PageSize = int.MaxValue;
        PageToken = 1;
    }
}