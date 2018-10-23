using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survivor.Services
{
    public interface ICloudStorageAccountProvider
    {
        CloudStorageAccount StorageAccount { get; }
    }
}
