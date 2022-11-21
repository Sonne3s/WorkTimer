class TimerVideoUI {
    constructor(videoElement, core) {
        this._element = videoElement;
        this._core = core;
        this._source = document.createElement('canvas');
        this._ctx = this._source.getContext('2d');;
        this._ctx.font = "50px Arial";
        this._ctx.textAlign = "center";
        this._ctx.textBaseline = "middle";
    }

    pip() {
        if (this._element !== document.pictureInPictureElement) {
            this._element.requestPictureInPicture();
        }
        // If Picture-in-Picture already exists, exit the mode
        else {
            document.exitPictureInPicture();
        }
    }

    start() {
        this.process(this._core);
        let stream = this._source.captureStream();
        this._element.srcObject = stream;
    }

    process(core) {
        this._ctx.fillStyle = "white";
        this._ctx.fillRect(0, 0, this._source.width, this._source.height);
        this._ctx.fillStyle = "black";
        this._ctx.fillText(this._correctTime(this._core.time), this._source.width / 2, this._source.height / 2);
        requestAnimationFrame(() => {
            this.process(core);
        });
    }

    _correctTime(time) {
        let string = "";
        if (time.days) string += this._core.correctValue(this._core.time.days) + " : ";
        if (time.days || time.hours) string += this._core.correctValue(this._core.time.hours) + " : ";
        if (time.days || time.hours || time.minutes) string += this._core.correctValue(this._core.time.minutes) + " : ";
        string += this._core.correctValue(this._core.time.seconds);

        return string;
    }
}