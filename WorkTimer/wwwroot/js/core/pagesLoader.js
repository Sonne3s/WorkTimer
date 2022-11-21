class PagesLoader {
    constructor(container) {
        this._container = container;
        this._loadedUrl = null;
        this._callback = null;
        this._queue = [];
        this.loadedPages = new Map();
        this.state = this.#state.ready
    }

    #state = {
        ready: 0,
        loading: 1
    }

    load(pageUrl, callback = null) {
        if (this.loadedPages.has(pageUrl)) {
            return false;
        }
        if (this.state == this.#state.loading) {
            this._queue.push(new PagesLoader.QueueElement(pageUrl, callback));

            return true;
        }
        return this._load(pageUrl, callback)
    }

    add(url, element) {
        this.loadedPages.set(url, element)
    }

    _load(pageUrl, callback = null) {
        this.state = this.#state.loading
        this._loadedUrl = pageUrl;
        this._callback = callback;
        AJAX.getPage(this._loadedUrl, (response, element) => { this._insert(response, element); }, this._container);

        return true;
    }

    _insert(response, element) {
        let htmlCollection = response.querySelector("body").children;
        for (var i = 0; i < htmlCollection.length; i++) {
            this.loadedPages.set(this._loadedUrl, htmlCollection[i]);
            element.appendChild(htmlCollection[i]);            
        }
        if (this._callback) {
            this._callback(this._loadedUrl);
        }
        this._queueProcessing();
    }

    _queueProcessing() {
        if (this._queue.length > 0) {
            let item = this._queue.shift();
            this._load(item.pageUrl, item.callback);
        }
        else {
            this._clear();
        }
    }

    _clear() {
        this._loadedUrl = null;
        this._callback = null;
        this.state = this.#state.ready;
    }

    static QueueElement = class {
        constructor(pageUrl, callback) {
            this.pageUrl = pageUrl;
            this.callback = callback;
        }
    }
}