class TimerCore {
    constructor(intervalStep, element, buttonsBlockElement) {
        this._element = element;
        this._intervalStep = intervalStep;
        this._buttonsBlockElement = buttonsBlockElement;
        this.time = TimerCoreLogic.getTime(0);
    }

    #_interval = null;
    #_startDate = null;

    set(milliseconds) {
        this.#_startDate = milliseconds;
        this.time = TimerCoreLogic.getTime(this.#_startDate);
    }

    draw() {
        TimerCoreDraw.drawTime(this._element, this.time);
    }

    process = function () {
        this.time = TimerCoreLogic.getTime(new Date() - this._startDate);
        TimerCoreDraw.drawTime(this._element, this.time);
    }

    start() {        
        this.stop();
        this._startDate = new Date() - this.time.milliseconds;
        this._interval = setInterval(
            () => {
                this.process();
            },
            this._intervalStep);
    }

    stop() {
        if (this._interval != null) clearInterval(this._interval);
    }

    reset() {
        this.time = TimerCoreLogic.getTime(0);
        this._startDate = new Date();
        TimerCoreDraw.drawTime(this._element, this.time);
    }

    correctValue(value) {
        return TimerCoreDraw.correctValue(value);
    }
}