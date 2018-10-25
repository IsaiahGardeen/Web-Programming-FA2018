using Survivor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survivor.Services
{
    public interface IImageTableStorage
    {
        Task StartupAsync();

        Task<ImageModel> GetAsync(string id);

        Task<ImageModel> AddOrUpdateAsync(ImageModel image);

        string GetStorageAccountBlobUrl();

        string GetUploadSas(string id);

        string GetDownloadSas(string id);

        Task<bool> DeleteAsync(string id);

        Task<List<ImageModel>> GetAllImagesAsync();

        Task PurgeAsync();
    }
}
