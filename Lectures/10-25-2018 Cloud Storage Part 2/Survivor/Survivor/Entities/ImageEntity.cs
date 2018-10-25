using CloudStorage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudStorage.Entities
{
    public class ImageEntity
    {

        public string Id { get; internal set; }

        [MinLength(3)]
        public string Name { get; set; }

        public string BlobUrl { get; internal set; }

        public string UploadSasToken { get; internal set; }

        public string DownloadUrl { get; internal set; }

        public ImageModel ToModel()
        {
            return new ImageModel()
            {
                Name = this.Name
            };
        }
    }
}
