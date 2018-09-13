var azureUrl = "https://simpleserver2018.azurewebsites.net/api/values";

/*

CRUD - Create, Read, Update, Delete


REST - 
1. Convention over configuration
2. Stateless

Http Verbs == Http Methods
	GET - Read data from the server
	POST - Create data on the server
	PUT - Update data on the server (and sometimes create)
	PATCH - Also update
	DELETE - Delete data from the server
	OPTIONS - Sent automatically by the web server for CORS (Cross-origin resource sharing)
	
How we talk to the server:

1. URL
 - Tell the server where we want to go
 - Users are able to easily edit this
2. The Body, The Request Payload, Request Data
 - Sending user data, such as name, color, address, age, etc. i.e. - anything entered into form data
3. Headers
 - The metadata of the request
 - Not editable easily by the end user
	

How the server talks to us:

1. Status Code
 - An integer response indicating the status of the request
2. Response payload, response body, response data
 - The result of the request, often the data we requested or created
3. Headers
 - The metadata of the response

Status Codes 
2xx means anything in the 200 range of status codes

It is always better to use a more specific status code

	100 - Continue, Keep on going!
	
	200 - OK
		201 - Created, often for POST requests
		202 - Accepted, often for long-running work
		204 - NoContent, the request body is empty, often for DELETE requests
	
	300 - Redirect
		301 - Moved permanently, www.blog.com -> www.mynewawesomeblog.com
		307 - Moved temporarily
			I need to give you a new URL each time
	
	400 - Bad Request, "It's YOUR fault."
		401 - Unauthorized, your credentials were not accepted
		403 - Forbidden, your credentials WERE accepted, but you aren't allowed to do it
		404 - Not Found
	
	500 - Internal Server Error, "It's THEIR fault"
		503 - Server Unavailable, you should probably retry your request again soon
		

Headers

	Content-Type, the MIME type of the request or response
		application/json, image/jpg, text/plain, text/css, etc.
	Content-Length, an INT indicating the length of the request/response in bytes
	Authorization, the users credentials
	Location, used with 3xx status codes to send the client somewhere else

*/

function runGet() {
	$.ajax(azureUrl,
	{
		method: "GET",
		success: simpleResult,
		error: simpleError
	});
}

function runPost() {
	
	$.ajax(azureUrl,
	{
		method: "POST",
		success: simpleResult,
		error: simpleError,
		processData: false,
		contentType: "application/json",
		headers: {
			"Authorization": "some token for user authentication",
			"SomeSillyString": "some silly value"
			
		},
		data: JSON.stringify({
			Value: document.getElementById("userInput").value
		})
	});
	
}

function runPut() {
	
	$.ajax(azureUrl + "/" + document.getElementById("userIndex").value,
	{
		method: "PUT",
		success: simpleResult,
		error: simpleError,
		processData: false,
		contentType: "application/json",
		data: JSON.stringify({
			Value: document.getElementById("userInput").value
		})
	});
}

function runDelete() {
	$.ajax(azureUrl + "/" + document.getElementById("userIndex").value,
	{
		method: "DELETE",
		success: simpleResult,
		error: simpleError
	});
}


function simpleResult(data) {
	document.getElementById("results").innerHTML = JSON.stringify(data);
}

function simpleError(data) {
	document.getElementById("error").innerHTML = JSON.stringify(data);
}

window.onload = function () {
	
	document.getElementById("runGetButton").onclick = runGet;
	document.getElementById("runPostButton").onclick = runPost;
	document.getElementById("runPutButton").onclick = runPut;
	document.getElementById("runDeleteButton").onclick = runDelete;
}