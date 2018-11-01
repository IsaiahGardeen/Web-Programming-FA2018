var mainUrl = "https://webrequestsserver2018.azurewebsites.net/api/favoriteCharacters";

function forcePullFunc() {
	forceReadIndex = -1;
	document.getElementById('forceReadIndex').innerHTML = "";
	$.ajax(mainUrl,
	{
		method: "GET",
		success: simpleResponse
	});	
}

function simpleResponse(data) {
	document.getElementById('result').innerHTML = JSON.stringify(data);
}

function forcePushFunc() {
	forceReadIndex = -1;
	document.getElementById('forceReadIndex').innerHTML = "";

	$.ajax(mainUrl,
	{
		method: "POST",
		success: simpleResponse,
		contentType: 'application/json',
		processData: false,
		data: JSON.stringify({
			FirstName: document.getElementById('firstName').value,
			LastName: document.getElementById('lastName').value,
			Character: document.getElementById('favoriteCharacter').value,
			Views: 5
		})
	});
}

function forceReadFunc() {
	$.ajax(mainUrl,
	{
		method: "GET",
		dataType: 'json',
		success: forceReadStep2
	});
}

var forceReadIndex = -1;
function forceReadStep2(data) {
	if (!data.length) {
		simpleResponse({ message: "Couldn't get the length" });
		document.getElementById('forceReadIndex').innerHTML = "";
		return;
	}
	
	var index = Math.floor(Math.random() * data.length);
	$.ajax(mainUrl + "/" + index,
	{
		method: "GET",
		success: function(result) {
			document.getElementById('forceReadIndex').innerHTML = "Picked index " + index;
			forceReadIndex = index;
			simpleResponse(result);
		}
	});
}

function forceInsightFunc() {
	if (forceReadIndex < 0) {
		simpleResponse({ message: "Use Force Read first." });
		return;
	}

	$.ajax(mainUrl + "/" + forceReadIndex + "/views",
	{
		method: "GET",
		success: function (result) {
			document.getElementById('viewsResult').innerHTML = JSON.stringify(result);
		}
	});
}

function watchMoviesFunc() {
	if (forceReadIndex < 0) {
		simpleResponse({ message: "Use Force Read first." });
		return;
	}

	$.ajax(mainUrl + "/" + forceReadIndex + "/views",
	{
		method: "POST",
		success: function (result) {
			document.getElementById('viewsResult').innerHTML = JSON.stringify(result);
		},
		contentType: 'application/json',
		processData: false,
		data: JSON.stringify({
			ViewDate: document.getElementById('viewDate').value
		})
	});
}

function forceDeleteFunc() {
	$.ajax(mainUrl,
	{
		method: "GET",
		dataType: 'json',
		success: forceDeleteStep2
	});
}

function forceDeleteStep2(data) {
	if (!data.length) {
		simpleResponse({ message: "Couldn't get the length" });
		document.getElementById('forceReadIndex').innerHTML = "";
		return;
	}
	
	var index = 0;
	if (forceReadIndex >= 0) {
		index = forceReadIndex;
	} else {
		index = Math.floor(Math.random() * data.length);
	}
	
	$.ajax(mainUrl + "/" + index,
	{
		method: "DELETE",
		error: function(xhr, errorStatus, errorCode) {
			alert(errorStatus, errorCode);
		},
		success: function() {
			$.ajax(mainUrl,
			{
				method: "GET",
				success: function (result) {
					simpleResponse(result);
					document.getElementById('forceReadIndex').innerHTML = "Picked index " + index;
					forceReadIndex = -1; // reset the force read index if we used it to delete.
				}
			});
		}
	});
}
