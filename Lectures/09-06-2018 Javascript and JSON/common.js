

function doStuff() {
	
	var userInput = document.getElementById("userInput");
	var results = document.getElementById("results");
	
	try {
		var userJson = JSON.parse(userInput.value);
	} catch (error) {
		results.innerHTML = "";
		displayError(error);
		
		return;
	}
	
	displayError("");
	
	var ol = document.createElement("ol");
	
	if (userJson.userArray) {
		if (Array.isArray(userJson.userArray)) {
			userJson.userArray.forEach(function (userElement) {
				if (typeof userElement === "string") {
					var li = document.createElement("li");
					li.appendChild(document.createTextNode(userElement));
					ol.appendChild(li);
				} else if (typeof userElement === "number") {
					var li = document.createElement("li");
					li.appendChild(document.createTextNode("NUM: " + userElement));
					ol.appendChild(li);
				} else {
					displayError("An element of userArray was not a string or number");
				}
				// the type we didn't handle is called "object"
			});
			
			results.appendChild(ol);
		} else {
			displayError("userArray key was not an array!");
		}				
		
	} else {
		displayError("userArray key was undefined!");
	}
}

function displayError(error) {
	
	document.getElementById("error").innerHTML = error;
}



window.onload = function () {
	
	document.getElementById("doStuffButton").onclick = doStuff;
	
}