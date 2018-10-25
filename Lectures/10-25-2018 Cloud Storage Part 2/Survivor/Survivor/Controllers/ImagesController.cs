using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survivor.Entities;
using Survivor.Services;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : Controller
    {
        private ImageTableStorage imageTableStorage;

        private IUserNameProvider userNameProvider;

        public ImagesController(ImageTableStorage imageTableStorage, IUserNameProvider userNameProvider)
        {
            this.imageTableStorage = imageTableStorage;
            this.userNameProvider = userNameProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var imageModel = await this.imageTableStorage.GetAsync(id);

            // TODO: check to make sure imageModel is not null
            // if it is null (i.e. it doesn't exist), return not found

            // TODO: set Cache-Control header here, it is in seconds; should be cached for seven hours

            // TODO: return actual download url in the Location header
            // the full url to view the image is the storage account url + the blob url
            // this.imageTableStorage.GetStorageAccountBlobUrl().ToString() + "replace this string with the method call that gets a SAS token for read access";
            Response.Headers["Location"] = "see comment above on how to fill this in";

            return StatusCode((int)HttpStatusCode.TemporaryRedirect);
        }


        // POST is called when we are trying to create a new image.
        // We will return to them the upload SAS and blob URL they need to use.
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ImageEntity imageEntity)
        {
            // TODO: add a filter to check ModelState

            var imageModel = await this.imageTableStorage.AddOrUpdateAsync(imageEntity.ToModel());

            var returnEntity = imageModel.ToEntity();
            returnEntity.UserName = this.userNameProvider.UserName;
            returnEntity.UploadSasToken = this.imageTableStorage.GetUploadSas(imageModel.Id);
            returnEntity.BlobUrl = imageTableStorage.GetStorageAccountBlobUrl();

            return Json(returnEntity);
        }

        [HttpPost("{id}/uploadComplete")]
        public async Task<IActionResult> UploadComplete(string id)
        {
            var imageModel = await this.imageTableStorage.GetAsync(id);

            // TODO: check to make sure imageModel is not null
            // if it is null (i.e. it doesn't exist), return not found

            // TODO: Set UploadComplete to true on the imageModel and then save it.

            return Json(imageModel.ToEntity());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (await this.imageTableStorage.DeleteAsync(id))
            {
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            return StatusCode((int)HttpStatusCode.NotFound);
        }

        [HttpDelete]
        public async Task<IActionResult> Purge()
        {
            await this.imageTableStorage.PurgeAsync();
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
