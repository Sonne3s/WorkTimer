const timerSelector = ".timer-section .time";
const timerButtonsBlockSelector = ".timer-section .controls";
const idleTimerSelector = ".timer-section .idle-time"
const videoSelector = "#target";
const timerDivisionValue = 1000;
var timer;
var idleTimer;

if (document.readyState == "complete") {
    initTimer();
}

document.addEventListener("DOMContentLoaded", () => { initTimer(); });

function initTimer() {
    resourcesLoader.load("/js/components/timer/core/draw.js", ResourcesLoader.type.js);
    resourcesLoader.load("/js/components/timer/core/logic.js", ResourcesLoader.type.js);
    resourcesLoader.load("/js/components/timer/connect.js", ResourcesLoader.type.js);
    resourcesLoader.load("/js/components/timer/core.js", ResourcesLoader.type.js);
    resourcesLoader.load("/js/components/timer/domUI.js", ResourcesLoader.type.js);
    resourcesLoader.load("/js/components/timer/videoUI.js", ResourcesLoader.type.js);
    resourcesLoader.load("/js/components/timer.js", ResourcesLoader.type.js, initTimer);

    document.querySelector('.start').onclick = () => {
        idleTimer.hide();
        idleTimer.pause();
        idleTimer.reset();
        timer.start();
        timer.connect.start();
    }

    document.querySelector('.pause').onclick = () => {
        timer.pause();
        idleTimer.show();
        idleTimer.start();
        timer.connect.pause();
    }

    document.querySelector('.reset').onclick = () => {
        timer.reset();
        idleTimer.hide();
        idleTimer.pause();
        idleTimer.reset();
        timer.connect.stop();
    }

    document.querySelector('.pip').onclick = () => {
        timer.pip();
    }

    function initTimer() {
        timer = new Timer(
            timerDivisionValue,
            document.querySelector(timerSelector),
            document.querySelector(timerButtonsBlockSelector),
            document.querySelector(videoSelector));
        idleTimer = new Timer(timerDivisionValue, document.querySelector(idleTimerSelector));
    }
}