function gofuncAsync() {
	document.getElementById("results").innerHTML = "";
	
	addResult("end of gofuncAsync");
}


function gofuncPromises() {
	document.getElementById("results").innerHTML = "";
	
	addResult("end of gofuncPromises");
}

function addResult(result) {
	
	var ol = document.getElementById("results");
	var li = document.createElement("li");
	
	li.appendChild(document.createTextNode(result));
	
	ol.appendChild(li)
}
