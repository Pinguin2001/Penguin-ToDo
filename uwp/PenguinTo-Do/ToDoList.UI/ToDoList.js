// get required elements
const list = document.querySelector(".list");

// get Todays date and write to HTML
var today = new Date();
var dd = String(today.getDate()).padStart(2, "0");
var mm = String(today.getMonth() + 1 ).padStart(2, "0"); // need to add +1 becouse January is 0
var yyyy = today.getFullYear();
document.getElementById("Today").innerHTML = dd + "." + mm + "." + yyyy;

// if TextBox contains Text add Task from XAMLText Box 
let userEnteredValue = getTextBoxText("inputBoxValue"); //get input field value
if (userEnteredValue !== null) {
    addTask();
}

loadTasks();

function addTask() {
    let getLocalStorageData = localStorage.getItem("New Todo"); //get localstorage
    if (getLocalStorageData === null) { //if localstorage has no data
        listArray = []; //create a blank array
    } else {
        listArray = JSON.parse(getLocalStorageData);  //transform json string into a js object
    }
    listArray.push(userEnteredValue); //push new value in array
    localStorage.setItem("New Todo", JSON.stringify(listArray)); //transform js object into a json string
    loadTasks();
}

function loadTasks(){
  let getLocalStorageData = localStorage.getItem("New Todo");
  if(getLocalStorageData === null){
    listArray = [];
  }else{
    listArray = JSON.parse(getLocalStorageData); 
  }
  let newLiTag = "";
  listArray.forEach((element, index) => {
    newLiTag += `<li>${element}<img class="icon" src="ms-appx-web:///Assets/Images/done.png" onClick="deleteTask(${index})"</img></li>`;
  });
  list.innerHTML = newLiTag;
}

function deleteTask(index){
  let getLocalStorageData = localStorage.getItem("New Todo");
  listArray = JSON.parse(getLocalStorageData);
  listArray.splice(index, 1);
  localStorage.setItem("New Todo", JSON.stringify(listArray));
  loadTasks();
}

function getTextBoxText(String) {
    return decodeURI((new RegExp("[?]" + String + "=" + "([^&]+?)($)").exec(location.search) || [null, ""])[1].replace(/\+/g, "%20")) || null;
}