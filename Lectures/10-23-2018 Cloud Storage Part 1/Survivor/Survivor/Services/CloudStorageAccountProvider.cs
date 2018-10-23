using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survivor.Services
{
    public class CloudStorageAccountProvider : ICloudStorageAccountProvider
    {
        public CloudStorageAccount StorageAccount => CloudStorageAccount.Parse("key goes here. get it from moodle.");
    }
}
