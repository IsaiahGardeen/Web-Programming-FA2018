var mainUrl = "api/images";

function startUpload() {
    var name = document.getElementById("name").value;

    if (!name || name.length < 3) {
        showError("Enter at least three characters for the title.");
        return;
    }

    var file = document.getElementById('fileInput').files[0];
    if (!file) {
        showError("Choose a file.");
        return;
    }

    // TODO: make a POST request to your controller here, calling startUploadSuccess on a successful response from your server
}

// hint for stretch level
// speedSummary will have a method getCompletePercent() that you can use to display a progress bar of how much of the upload has completed so far.
// this variable is set whenever you start a blob from a file
var speedSummary;

function showError(error) {
    document.getElementById("error").style.display = "block";
    document.getElementById("error").innerHTML = error;
    setTimeout(function () {
        document.getElementById("error").style.display = "none";
    }, 3000);
}

function startUploadSuccess(data) {
    var file = document.getElementById('fileInput').files[0];
   
    var blobService = AzureStorage.Blob.createBlobServiceWithSas(data.blobUrl, data.uploadSasToken);
    var customBlockSize = file.size > 1024 * 1024 * 32 ? 1024 * 1024 * 4 : 1024 * 512;
    blobService.singleBlobPutThresholdInBytes = customBlockSize;

    speedSummary = blobService.createBlockBlobFromBrowserFile(data.userName, data.id, file, { blockSize: customBlockSize }, function (error, result, response) {
        if (!error) {
            uploadComplete(data.id);
        }
    });
}

function uploadComplete(id) {
    // TODO: make a POST request to your server to tell the upload is complete.
    // then call refreshImages if the uploadComplete request is successful.
}

function refreshImages() {
    $.ajax(mainUrl, {
        method: "GET",
        success: refreshImagesResult
    });
}

function purge() {
    $.ajax(mainUrl, {
        method: "Delete",
        success: purgeResult
    });
}

function purgeResult() {
    document.getElementById("images").innerHTML = "";
}

function refreshImagesResult(data) {
    var imagesDiv = document.getElementById("images");
    imagesDiv.innerHTML = '';

    // data is an array of ImageEntity
    data.forEach(addImage);
}

var currentSize = 0;

function setImageSize(inputElement) {
    currentSize = inputElement.value;

    var imagesDiv = document.getElementById("images");

    imagesDiv.childNodes.forEach(function (imageElement) {
        imageElement.setAttribute("class", "size" + currentSize);
    });
}

function addImage(image) {
    var imagesDiv = document.getElementById("images");

    // TODO: create an img element, set its "src" to the image url, and its "title" and "alt" attributes to the image name.
    // then append that img to imagesDiv
}

window.onload = function () {
    document.getElementById("startUpload").onclick = startUpload;
    document.getElementById("refreshImages").onclick = refreshImages;
    document.getElementById("purge").onclick = purge;

    refreshImages();
};
