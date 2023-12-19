using AirBnb.Domain.Entities;
using AirBnb.Domain.Enums;
using AirBnb.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AirBnb.Api.Data;

/// <summary>
/// Provides extension methods for seeding data.
/// </summary>
public static class SeedDataExtensions
{
    /// <summary>
    /// Seeds the database with data.
    /// </summary>
    /// <param name="serviceProvider">Service provider</param>
    public static async ValueTask SeedDataAsync(this IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<AppDbContext>();
        var webHostEnvironment = serviceProvider.GetRequiredService<IWebHostEnvironment>();

        if (!await dbContext.Countries.AnyAsync())
            await SeedCountriesAsync(dbContext, webHostEnvironment);

        if (!await dbContext.Cities.AnyAsync())
            await SeedCitiesAsync(dbContext, webHostEnvironment);

        if (!await dbContext.ListingCategories.AnyAsync())
            await SeedListingCategoriesAsync(dbContext, webHostEnvironment);

        if (dbContext.ChangeTracker.HasChanges())
            await dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Seeds the database with locations.
    /// </summary>
    /// <param name="dbContext">Database context to seed data</param>
    /// <param name="webHostEnvironment">Web application environment</param>
    private static async ValueTask SeedCountriesAsync(AppDbContext dbContext, IWebHostEnvironment webHostEnvironment)
    {
        var countriesFileName = Path.Combine(webHostEnvironment.ContentRootPath, "Data", "SeedData", "Countries.json");

        // Retrieve countries
        var countries = JsonConvert.DeserializeObject<List<Location>>(await File.ReadAllTextAsync(countriesFileName))!;
        countries.ForEach(country => country.Type = LocationType.Country);

        await dbContext.AddRangeAsync(countries);
    }

    public static async ValueTask SeedCitiesAsync(AppDbContext dbContext, IWebHostEnvironment webHostEnvironment)
    {
        var citiesFileName = Path.Combine(webHostEnvironment.ContentRootPath, "Data", "SeedData", "Cities.json");

        // Retrieve cities
        var cities = JsonConvert.DeserializeObject<List<Location>>(await File.ReadAllTextAsync(citiesFileName))!;
        cities.ForEach(city => city.Type = LocationType.City);

        // Add countries and cities
        await dbContext.AddRangeAsync(cities);
    }


    /// <summary>
    /// Seeds the database with locations.
    /// </summary>
    /// <param name="dbContext">Database context to seed data</param>
    /// <param name="webHostEnvironment">Web application environment</param>
    private static async ValueTask SeedListingCategoriesAsync(AppDbContext dbContext, IWebHostEnvironment webHostEnvironment)
    {
        var listingCategoriesFileName = Path.Combine(webHostEnvironment.ContentRootPath, "Data", "SeedData", "ListingCategories.json");

        // Retrieve listing categories
        var listingCategories = JsonConvert.DeserializeObject<List<ListingCategory>>(await File.ReadAllTextAsync(listingCategoriesFileName))!;

        // Set image storage
        listingCategories.ForEach(
            listingCategory => listingCategory.ImageStorageFile = new StorageFile
            {
                Id = Guid.NewGuid(),
                FileName = $"{listingCategory.ImageStorageFileId}.jpg",
                Type = StorageFileType.Image
            }
        );

        // Add listing categories
        await dbContext.ListingCategories.AddRangeAsync(listingCategories);
    }
}