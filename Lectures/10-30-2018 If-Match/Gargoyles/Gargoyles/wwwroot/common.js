
function put() {
    $.ajax(mainUrl, {
        method: "POST",
        processData: false,
        headers: {
            "IF-Match": // equal to the ETag from the data that came back from the server's GET
        },
        data: {
            Name: name,
            Size: size
        }

    });

}

// this would be the success: method of a GET
function simpleSuccess(data, stringStatus, metaData) {
    // get the ETag out of metaData
    // look at jQuery docs for this

}