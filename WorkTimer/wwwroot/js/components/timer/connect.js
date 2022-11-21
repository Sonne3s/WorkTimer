class TimerCoreConnect {
    time(callback) {
        AJAX.getJSON("/Timer/Time", callback);
    }

    start() {
        AJAX.getJSON("/Timer/Start");
    }

    pause() {
        AJAX.getJSON("/Timer/Pause");
    }

    stop() {
        AJAX.getJSON("/Timer/Stop");
    }
}