using CloudStorage.Entities;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudStorage.Models
{
    public class ImageModel : TableEntity
    {
        public ImageModel(string userName, string name)
        {
            this.UserName = userName;
            this.Name = name;
        }

        public ImageModel()
        {

        }

        public string UserName
        {
            get { return this.PartitionKey; }
            set { this.PartitionKey = value; }
        }

        public string Id {
            get { return this.RowKey; }
            set { this.RowKey = value; }
        }

        public string Name { get; set; }

        public bool UploadComplete { get; set; }

        public ImageEntity ToEntity()
        {
            return new ImageEntity()
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}
