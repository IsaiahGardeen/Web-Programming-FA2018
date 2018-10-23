using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survivor.Services
{
    public class ImageTableStorage
    {
        private readonly ICloudStorageAccountProvider cloudStorageAccountProvider;

        private readonly IUsernameProvider usernameProvider;

        private CloudBlobContainer cloudBlobContainer;

        public ImageTableStorage(ICloudStorageAccountProvider cloudStorageAccountProvider, IUsernameProvider usernameProvider)
        {
            this.cloudStorageAccountProvider = cloudStorageAccountProvider;
            this.usernameProvider = usernameProvider;

            var blobClient = this.cloudStorageAccountProvider.StorageAccount.CreateCloudBlobClient();
            this.cloudBlobContainer = blobClient.GetContainerReference(this.usernameProvider.Username);
        }

        public async Task StartupAsync()
        {
            await this.cloudBlobContainer.CreateIfNotExistsAsync();
        }

        public string GetUploadSas()
        {
            return this.cloudBlobContainer.GetSharedAccessSignature(new SharedAccessBlobPolicy()
            {
                SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddHours(8),
                Permissions = SharedAccessBlobPermissions.Add | SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Create
            });
        }
    }
}
