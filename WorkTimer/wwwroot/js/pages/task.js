var historyBackSelector = ".history-back";
var saveTaskChangesSelector = ".save-task-changes";
var editNameSelector = ".edit-name";
var inputNameSelector = "input.task-name";
var titleNameSelector = ".task-title .task-name"
var applyNewTitleSelector = ".apply-new-title";

if (document.readyState == "complete") {
    initTask();
}

document.addEventListener("DOMContentLoaded", () => {
    initTask();
});

function initTask() {
    let section = document.querySelector("main section:not(.hide)");
    section.querySelector(historyBackSelector).onclick = function () {
        historyBack();
    }
    section.querySelector(saveTaskChangesSelector).onclick = function () {
        updateTask(this.closest("form"));
    }
    section.querySelector(editNameSelector).onclick = function () {
        showTaskInputName();
    }
    section.querySelector(applyNewTitleSelector).onclick = function () {
        applyNewTitle();
    }
}

function historyBack() {
    window.location.href = "/Home/Tasks";
}

function updateTask(form) {
    AJAX.form("/Task/Update", form);
}

function showTaskInputName() {
    let section = document.querySelector("main section:not(.hide)");
    section.querySelector(inputNameSelector).classList.remove("hide");
    section.querySelector(titleNameSelector).classList.add("hide");
    section.querySelector(applyNewTitleSelector).classList.remove("hide");
    section.querySelector(editNameSelector).classList.add("hide");
}

function hideTaskInputName() {
    let section = document.querySelector("main section:not(.hide)");
    section.querySelector(inputNameSelector).classList.add("hide");
    section.querySelector(titleNameSelector).classList.remove("hide");
    section.querySelector(applyNewTitleSelector).classList.add("hide");
    section.querySelector(editNameSelector).classList.remove("hide");
}

function applyNewTitle() {
    let section = document.querySelector("main section:not(.hide)");
    section.querySelector(titleNameSelector).textContent = section.querySelector(inputNameSelector).value;
    hideTaskInputName();
}