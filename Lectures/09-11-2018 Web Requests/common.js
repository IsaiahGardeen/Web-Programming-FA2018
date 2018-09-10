var azureUrl = "https://simpleserver2018.azurewebsites.net/api/values";


function runGet() {
	

}



function simpleResult(data) {
	document.getElementById("results").innerHTML = JSON.stringify(data);
}

function simpleError(data) {
	document.getElementById("error").innerHTML = JSON.stringify(data);
}



window.onload = function () {
	
	document.getElementById("runGetButton").onclick = runGet;
	
}