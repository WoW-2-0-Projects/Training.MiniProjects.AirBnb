using AirBnb.Domain.Entities;
using AirBnb.Infrastructure.StorageFiles.Settings;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace AirBnb.Infrastructure.StorageFiles.Mappers;

/// <summary>
/// Represents converter from a storage file path to an absolute url.
/// </summary>
public class ListingMediaToUrlConverter(IOptions<StorageFileSettings> storageFileSettings, IOptions<ApiSettings> apiSettings)
    : IValueConverter<IList<ListingMedia>, IList<string>>
{
    public IList<string> Convert(IList<ListingMedia> listingMedias, ResolutionContext context)
    {
        return listingMedias.Select(
                listingMedia =>
                {
                    var relativePath = Path.Combine(
                        storageFileSettings.Value.LocationSettings.First(x => x.StorageFileType == listingMedia.StorageFile.Type).FolderPath,
                        listingMedia.StorageFile.FileName
                    );

                    // Get absolute url
                    var absoluteUrl = new Uri(new Uri(apiSettings.Value.BaseAddress), relativePath);
                    return absoluteUrl.ToString();
                }
            )
            .ToList();
    }
}