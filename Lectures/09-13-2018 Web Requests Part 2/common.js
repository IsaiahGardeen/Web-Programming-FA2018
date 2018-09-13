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