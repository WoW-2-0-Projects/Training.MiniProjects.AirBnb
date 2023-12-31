using AirBnb.Domain.Entities;
using AirBnb.Infrastructure.StorageFiles.Settings;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace AirBnb.Infrastructure.StorageFiles.Mappers;

/// <summary>
/// Represents converter from a storage file path to an absolute url.
/// </summary>
public class StorageFileToUrlConverter(IOptions<StorageFileSettings> storageFileSettings, IOptions<ApiSettings> apiSettings)     
    : IValueConverter<StorageFile, string>
{
    public string Convert(StorageFile sourceMember, ResolutionContext context)
    {
        // Get relative path
        var relativePath = Path.Combine(
            storageFileSettings.Value.LocationSettings.First(x => x.StorageFileType == sourceMember.Type).FolderPath,
            sourceMember.FileName
        );

        // Get absolute url
        var absoluteUrl = new Uri(new Uri(apiSettings.Value.BaseAddress), relativePath);
        return absoluteUrl.ToString();
    }
}