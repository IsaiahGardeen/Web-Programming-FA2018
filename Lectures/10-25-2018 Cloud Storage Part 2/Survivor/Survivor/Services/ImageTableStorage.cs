using CloudStorage.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Threading.Tasks;

namespace Survivor.Services
{
    public class ImageTableStorage
    {
        private readonly ICloudStorageAccountProvider cloudStorageAccountProvider;

        private readonly IUserNameProvider userNameProvider;

        private readonly CloudBlobContainer cloudBlobContainer;

        private readonly CloudTable cloudTable;

        public ImageTableStorage(ICloudStorageAccountProvider cloudStorageAccountProvider, IUserNameProvider userNameProvider)
        {
            this.cloudStorageAccountProvider = cloudStorageAccountProvider;
            this.userNameProvider = userNameProvider;

            var blobClient = this.cloudStorageAccountProvider.StorageAccount.CreateCloudBlobClient();
            this.cloudBlobContainer = blobClient.GetContainerReference(this.userNameProvider.UserName);

            var tableClient = this.cloudStorageAccountProvider.StorageAccount.CreateCloudTableClient();
            this.cloudTable = tableClient.GetTableReference(this.userNameProvider.UserName);
        }

        public async Task StartupAsync()
        {
            await this.cloudBlobContainer.CreateIfNotExistsAsync();
            await this.cloudTable.CreateIfNotExistsAsync();
        }

        public string GetStorageAccountBlobUrl()
        {
            return this.cloudStorageAccountProvider.StorageAccount.BlobStorageUri.PrimaryUri.ToString();
        }

        public async Task<ImageModel> GetAsync(string id)
        {
            TableResult tableResult = await cloudTable.ExecuteAsync(TableOperation.Retrieve<ImageModel>(this.userNameProvider.UserName, id));
            return (ImageModel)tableResult.Result;
        }

        public async Task<ImageModel> AddOrUpdate(ImageModel imageModel)
        {
            if (string.IsNullOrWhiteSpace(imageModel.Id))
            {
                imageModel.Id = Guid.NewGuid().ToString();
                imageModel.UserName = this.userNameProvider.UserName;
            }

            await cloudTable.ExecuteAsync(TableOperation.InsertOrReplace(imageModel));
            return imageModel;
        }

        public string GetUploadSas(string id)
        {
            // TODO: change this method to not grant access to the entire container.
            // only grant access to the file they are trying to upload to
            // hint: GetBlobReference is a method that can be called on a blob container in order to get a specific blob in that container.
            // double hint: you will use the "id" as the name of the blob

            return this.cloudBlobContainer.GetSharedAccessSignature(new SharedAccessBlobPolicy()
            {
                SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddHours(8),
                Permissions = SharedAccessBlobPermissions.Add | SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Create
            });
        }

        public string GetDownloadSas(string id)
        {
            // TODO: get a SAS for the specific blob specfied by "id"
            // make sure permissions are set correctly, and that the sas doesn't grant access to the entire blob container.
            return "GetSharedAccessSignature";
        }
    }
}
