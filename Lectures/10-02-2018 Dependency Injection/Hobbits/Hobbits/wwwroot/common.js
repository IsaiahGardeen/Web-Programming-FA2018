var mainUrl = "https://localhost:44340/api/hobbits";

function simpleResult(data) {
	document.getElementById("result").innerHTML = JSON.stringify(data);
}

function simpleError(data) {
	document.getElementById("error").innerHTML = JSON.stringify(data);
}

function runGet() {
	
	$.ajax(mainUrl,
	{
		method: "GET",
		success: simpleResult,
		error: simpleError
	});
}

function runGetOne() {
	
	$.ajax(mainUrl + "/" + document.getElementById("userIndex").value,
	{
		method: "GET",
		success: simpleResult,
		error: simpleError
	});
}

function runPost() {
	$.ajax(mainUrl, 
	{
		method: "POST",
		success: simpleResult,
		error: simpleError,
		contentType: "application/json",
		processData: false,
		data: JSON.stringify(
		{
            Name: document.getElementById("hobbitName").value
		})
	});
}

function runPut() {
	$.ajax(mainUrl + "/" + document.getElementById("userIndex").value, 
	{
		method: "PUT",
		success: simpleResult,
		error: simpleError,
		contentType: "application/json",
		processData: false,
		data: JSON.stringify(
		{
            Name: document.getElementById("hobbitName").value
		})
	});
}

function runDelete() {
	$.ajax(mainUrl + "/" + document.getElementById("userIndex").value, 
	{
		method: "DELETE",
		success: simpleResult,
		error: simpleError
	});
	
}