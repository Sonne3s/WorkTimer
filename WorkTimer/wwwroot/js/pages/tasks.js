const showAddTaskContainerSelecor = ".show-add-task-container";
const addTaskContainerSelector = ".add-task-container";
const addTaskSelector = ".add-task";
const cancelTaskSelector = ".cancel-task";
const emptyMessageSelector = ".tasks-list-empty";
const tasksListSelector = ".tasks-list";
const tasksListItemSelector = ".tasks-list-item";

if (document.readyState == "complete") {
    initIasks();
}

document.addEventListener("DOMContentLoaded", () => {
    initIasks();
});

function initIasks() {
    document.querySelector(showAddTaskContainerSelecor).onclick = function () {
        showAddTaskContainer();
    }
    document.querySelector(addTaskSelector).onclick = function () {
        addTask(this);
    }
    document.querySelector(cancelTaskSelector).onclick = function () {
        hideAddTaskContainer(this);
    }
    document.querySelector(tasksListSelector).addEventListener('click', event => showTaskListItem(event));
}

function showAddTaskContainer() {
    document.querySelector(addTaskContainerSelector).classList.remove("hide");
}

function hideAddTaskContainer(element) {
    element.parentElement.parentElement.querySelector(".add-task-input").value = "";
    document.querySelector(addTaskContainerSelector).classList.add("hide");
}

function addTask(element) {
    let name = element.parentElement.parentElement.querySelector(".add-task-input").value;
    let url = "/Task/Create?name=" + name;
    AJAX.getJSON(url, insertTask, element);
}

function showEmptyMessage() {
    document.querySelector(emptyMessageSelector).classList.remove("hide");
}

function hideEmptyMessage() {
    document.querySelector(emptyMessageSelector).classList.add("hide");
}

function showTasksList() {
    document.querySelector(tasksListSelector).classList.remove("hide");
}

function hideTasksList() {
    document.querySelector(tasksListSelector).classList.add("hide");
}

function showTaskListItem(event) {
    if (event.target.nodeName == "A") {
        event.preventDefault();
        hidePages();
        let url = loadPage(event.target);
        let initInterval = setInterval(() => { if (pagesLoader.loadedPages.has(url)) initTask(); clearInterval(initInterval); }, 100);
    }
}

function insertTask(response, element) {
    let parent = element.parentElement.parentElement;
    let sample = parent.querySelector(".sample .tasks-list-item").cloneNode();
    sample.textContent = response.name;
    sample.dataset.url += "/" + response.id;
    sample.href = "/" + sample.href.split("/").slice(3, 5).join("/") + "/" + response.id;
    parent.querySelector(".tasks-list").prepend(sample);
    hideAddTaskContainer(element);
    hideEmptyMessage();
    showTasksList()
}