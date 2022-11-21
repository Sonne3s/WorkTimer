class ResourcesLoader {
    constructor(headElement) {
        this._headElement = headElement;
        this.state = this.#state.ready
        this._queue = [];
        this.resources = new Map();
    }

    static type = {
        js: 0,
        css: 1
    };

    #state = {
        ready: 0,
        loading: 1
    }

    #getElement(type, callback) {
        switch (type) {
            case ResourcesLoader.type.js:
                return this.#getScriptElement(callback);

            case ResourcesLoader.type.css:
                return this.#getStyleElement(callback);
        }
    }

    #getScriptElement(callback) {
        let script = document.createElement("script")
        this.#setOnload(script, callback, () => { this._queueProcessing() });

        return script
    }

    #getStyleElement(callback) {
        let styles = document.createElement("link")
        styles.rel = "stylesheet";
        this.#setOnload(styles, callback, () => { this._queueProcessing() });

        return styles
    }

    #setOnload(element, callback, queue) {
        element.onload = function () {
            if (callback != null) {
                callback();
            }
            queue();
        };
    }

    #setLink(element, type, url) {
        switch (type) {
            case ResourcesLoader.type.js:
                element.src = url;
                break;
            case ResourcesLoader.type.css:
                element.href = url;
                break;
        }
    }

    load(url, type, callback = null) {
        if (this.resources.has(url)) {
            return false;
        }
        if (this.state == this.#state.loading) {
            this._queue.push(new ResourcesLoader.QueueElement(url, type, callback));

            return true;
        }

        return this._load(url, type, callback)
    }

    _load(url, type, callback) {
        this.state = this.#state.loading
        let element = this.#getElement(type, callback);
        this.#setLink(element, type, url);
        this._headElement.appendChild(element);
        this.resources.set(url, element);        

        return true;
    }

    _queueProcessing() {
        if (this._queue.length > 0) {
            let item = this._queue.shift();
            this._load(item.url, item.type, item.callback);
        }
        else {
            this.state = this.#state.ready;
        }
    }

    static QueueElement = class {
        constructor(url, type, callback) {
            this.url = url;
            this.type = type;
            this.callback = callback;
        }
    }
}