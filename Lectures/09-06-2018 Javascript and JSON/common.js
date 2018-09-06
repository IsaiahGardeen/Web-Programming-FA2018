
// window allows us to talk to the browser

// alert('test');


function doStuff() {
	
	
	document.getElementById("div1").classList.toggle("warning");
	document.getElementById("div1").classList.toggle("center");
	
}



window.onload = function () {
	
	// DOM - document object model
	// document.getElementById("div1").style.backgroundColor = "blue";

	// a better way, use classes
	
	// document.getElementById("div2").classList.add("warning");
	
	
	// access the button by its id and setup the onclick function
	
	document.getElementById("doStuffButton").onclick = doStuff;
	
}