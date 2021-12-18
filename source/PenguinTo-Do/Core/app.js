// get required elements
const inputBox = document.querySelector(".inputField input");
const list = document.querySelector(".list");

// add keyboard event listener
var input = document.getElementById("input");
input.addEventListener("keyup", function (event) {
    if (event.keyCode === 13) {
        event.preventDefault();
        addTask();
    }
});

// load Tasks
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
    newLiTag += `<li>${element}<img class="icon" src="../Assets/images/done.png" height="22" width="22" onClick="deleteTask(${index})"</img></li>`;
  });
  list.innerHTML = newLiTag;
  inputBox.value = "";
}

function deleteTask(index){
  let getLocalStorageData = localStorage.getItem("New Todo");
  listArray = JSON.parse(getLocalStorageData);
  listArray.splice(index, 1);
  localStorage.setItem("New Todo", JSON.stringify(listArray));
  loadTasks();
}