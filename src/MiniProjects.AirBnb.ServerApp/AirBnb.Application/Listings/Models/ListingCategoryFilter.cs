using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;

namespace AirBnb.Application.Listings.Models;

/// <summary>
/// Represents a listing category filter
/// </summary>
public class ListingCategoryFilter : FilterPagination, IQueryConvertible<ListingCategory>
{
    public QuerySpecification<ListingCategory> ToQuerySpecification()
    {
        // Get all listing categories   
        var querySpecification = new QuerySpecification<ListingCategory>(int.MaxValue, 1, true, GetHashCode());

        querySpecification.IncludingOptions.Add(listingCategory => listingCategory.ImageStorageFile);

        return querySpecification;
    }

    public override bool Equals(object? obj)
    {
        return obj is ListingCategoryFilter listingCategoryFilter && listingCategoryFilter.GetHashCode() == GetHashCode();
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageSize);
        hashCode.Add(PageToken);

        return hashCode.ToHashCode();
    }
}