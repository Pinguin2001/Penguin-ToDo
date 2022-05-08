// get required elements
const inputBox = document.querySelector(".inputField input");
const list = document.querySelector(".list");
const input = document.getElementById("input");

// add keyboard event listener
input.addEventListener("keyup", function (event) {
    if (event.keyCode === 13) {
        event.preventDefault();
        addTask();
    }
});

// get Todays Date and write to HTML
var today = new Date();
var dd = String(today.getDate()).padStart(2, "0");
var mm = String(today.getMonth() + 1 ).padStart(2, "0"); // need to add +1 becouse January is 0
var yyyy = today.getFullYear();
document.getElementById("Today").innerHTML = dd + "." + mm + "." + yyyy;

document.getElementById("Home").style.display = "block";

loadTasks();

function addTask () {
    let userEnteredValue = inputBox.value; //get input field value
    let getLocalStorageData = localStorage.getItem("New Todo"); //get localstorage
    if(getLocalStorageData === null){ //if localstorage has no data
      listArray = []; //create a blank array
    }else{
      listArray = JSON.parse(getLocalStorageData);  //transform json string into a js object
    }
    listArray.push(userEnteredValue); //push new value in array
    localStorage.setItem("New Todo", JSON.stringify(listArray)); //transform js object into a json string
    input.value = "";
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
    newLiTag += `<li>${element}<img class="icon" src="images/done.png" onClick="deleteTask(${index})"</img></li>`;
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

function showMenu() {
    var x = document.getElementById("myLinks");
    if (x.style.display === "block") {
    x.style.display = "none";
    } else {
     x.style.display = "block";
    }
}

function openNav() {
  document.getElementById("mySidenav").style.width = "250px";
}

function closeNav() {
  document.getElementById("mySidenav").style.width = "0";
}

function openPage(pageName) {
  var i, tabcontent;
  tabcontent = document.getElementsByClassName("tabcontent");
  for (i = 0; i < tabcontent.length; i++) {
    tabcontent[i].style.display = "none";
  }
  document.getElementById(pageName).style.display = "block";
  closeNav();
}

function toggledarkmode() {
  const darkmode =  new Darkmode();
  darkmode.toggle();
}