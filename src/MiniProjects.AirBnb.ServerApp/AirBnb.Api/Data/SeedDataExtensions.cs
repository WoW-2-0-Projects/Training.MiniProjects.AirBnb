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

        if (!await dbContext.Locations.AnyAsync())
            await SeedLocationsAsync(dbContext, webHostEnvironment);

        // if (!await dbContext.StorageFiles.AnyAsync())
        //     await SeedStorageFilesAsync(dbContext, webHostEnvironment);

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
    private static async ValueTask SeedLocationsAsync(AppDbContext dbContext, IWebHostEnvironment webHostEnvironment)
    {
        var countriesFileName = Path.Combine(webHostEnvironment.ContentRootPath, "Data", "SeedData", "Countries.json");
        var citiesFileName = Path.Combine(webHostEnvironment.ContentRootPath, "Data", "SeedData", "Cities.json");

        // Retrieve countries
        var countries = JsonConvert.DeserializeObject<List<Location>>(await File.ReadAllTextAsync(countriesFileName))!;
        countries.ForEach(country => country.Type = LocationType.Country);

        // Retrieve cities
        var cities = JsonConvert.DeserializeObject<List<Location>>(await File.ReadAllTextAsync(citiesFileName))!;
        cities.ForEach(city => city.Type = LocationType.City);

        // Add countries and cities
        await dbContext.Locations.AddRangeAsync(countries);
        await dbContext.Locations.AddRangeAsync(cities);

        await dbContext.SaveChangesAsync();
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

        await dbContext.SaveChangesAsync();
    }
}