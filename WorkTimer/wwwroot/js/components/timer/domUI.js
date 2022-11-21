class TimerUI {
    constructor(timerElement, buttonsBlockElement = null) {
        this._timerElement = timerElement;
        this._buttonsBlockElement = buttonsBlockElement
        this.hasButtons = buttonsBlockElement != null;
        if (!('pictureInPictureEnabled' in document)) this._buttonsBlockElement.querySelector(this.#pipButtonSelector).classList.add("hide");
    }

    #startButtonSelector = ".start";
    #pauseButtonSelector = ".pause";
    #pipButtonSelector = ".pip";

    hide() {
        this._timerElement.classList.add("hide");
    }

    show() {
        this._timerElement.classList.remove("hide");
    }

    start() {
        this._buttonsBlockElement.querySelector(this.#startButtonSelector).classList.add("hide");
        this._buttonsBlockElement.querySelector(this.#pauseButtonSelector).classList.remove("hide");
    }

    pause() {
        this._buttonsBlockElement.querySelector(this.#startButtonSelector).classList.remove("hide");
        this._buttonsBlockElement.querySelector(this.#pauseButtonSelector).classList.add("hide");
    }

    pip() {
        this._buttonsBlockElement.querySelector(this.#pipButtonSelector).classList.toggle("active");
    }
}