var resourcesLoader;
var pagesLoader;
var titles = new Map();
var scriptUrls = new Map();
var styleUrls = new Map();

document.addEventListener("DOMContentLoaded", () => {
    resourcesLoader = new ResourcesLoader(document.querySelector("head"));
    pagesLoader = new PagesLoader(document.querySelector("main"));

    document.querySelector("nav").addEventListener('click', event => {
        if (event.target.nodeName == "A") {
            event.preventDefault();
            setActiveLink(event);
            hidePages();
            loadPage(event.target);
        }
    });
});

function setActiveLink(event) {
    let navs = event.currentTarget.children;
    for (var i = 0; i < navs.length; i++) {
        navs[i].classList.remove("active");
    }
    event.target.classList.add("active");
}

function loadPage(element) {
    if (!pagesLoader.load(element.dataset.url, loadPageResources)) {
        pagesLoader.loadedPages.get(element.dataset.url).classList.remove("hide");
    }
    updateBrowserInformation(element.href, titles.get(normalizeUrl(element.dataset.url)));

    return element.dataset.url;
}

function normalizeUrl(url) {
    return "/" + url.split("/").slice(1, 3).join('/');
}

function loadPageResources(url) {
    resourcesLoader.load(scriptUrls.get(normalizeUrl(url)), ResourcesLoader.type.js);
    resourcesLoader.load(styleUrls.get(normalizeUrl(url)), ResourcesLoader.type.css);
}

function updateBrowserInformation(addressBar, title) {
    history.pushState(null, null, addressBar);
    document.title = title;
}

function hidePages() {
    let pages = document.querySelector("main").children;
    for (var i = 0; i < pages.length; i++) {
        pages[i].classList.add("hide");
    }
}

function initCurentPage(link, selector) {
    document.addEventListener("DOMContentLoaded", () => {
        pagesLoader.add(link, document.querySelector(selector));
    });
}