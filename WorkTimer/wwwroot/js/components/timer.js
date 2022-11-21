class Timer {
    constructor(intervalStep, element, buttonsBlockElement = null, videoElement = null) {
        this.connect = new TimerCoreConnect();
        this.connect.time((response) => { this.set(response) });
        this._core = new TimerCore(intervalStep, element, buttonsBlockElement);
        this._UI = new TimerUI(element, buttonsBlockElement);        
        if (videoElement != null) this._videoUI = new TimerVideoUI(videoElement, this._core);
        if (videoElement != null) this._videoUI.start();
    }

    set(response) {
        this._core.set(response.milliseconds);
        this._core.draw();
    }

    start = function () {
        this._core.start();
        if (this._UI.hasButtons) this._UI.start();
    }

    pause = function () {
        this._core.stop();
        if (this._UI.hasButtons) this._UI.pause();
    }

    reset = function () {
        this._core.reset();
    }

    hide = function () {
        this._UI.hide();
    }

    show = function () {
        this._UI.show();
    }

    pip = function () {
        if (this._videoUI != null) this._videoUI.pip();
        if (this._videoUI != null) this._UI.pip();
    }
}