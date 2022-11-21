class TimerCoreDraw {
    static segment =
        {
            Day: ".days",
            Hour: ".hours",
            Minute: ".minutes",
            Second: ".seconds",
            Millisecond: ".milliseconds"
        };

    static labels = {
        Day: ['день', 'дня', 'дней'],
        Hour: ['час', 'часа', 'часов'],
        Minute: ['минута', 'минуты', 'минут'],
        Second: ['секунда', 'секунды', 'секунд'],
        Millisecond: ['миллисекунда', 'миллисекунды', 'миллисекунд']
    }

    static drawFunctions = new Map([
        ['Millisecond', TimerCoreDraw.drawMilliseconds],
        ['Second', TimerCoreDraw.drawSeconds],
        ['Minute', TimerCoreDraw.drawMinutes],
        ['Hour', TimerCoreDraw.drawHours],
        ['Day', TimerCoreDraw.drawDays]
    ]);

    static drawTime(element, time) {
        TimerCoreDraw.drawFunctions.forEach(item => item(element, time));
    }

    static drawDays(element, time) {
        let days = element.querySelector(TimerCoreDraw.segment.Day);
        if (days) TimerCoreDraw._drawElement(days, time.days, TimerCoreDraw.labels.Day);
    }

    static drawHours(element, time) {
        let hours = element.querySelector(TimerCoreDraw.segment.Hour);
        if (hours) TimerCoreDraw._drawElement(hours, time.hours, TimerCoreDraw.labels.Hour);
    }

    static drawMinutes(element, time) {
        let minutes = element.querySelector(TimerCoreDraw.segment.Minute);
        if (minutes) TimerCoreDraw._drawElement(minutes, time.minutes, TimerCoreDraw.labels.Minute);
    }

    static drawSeconds(element, time) {
        let seconds = element.querySelector(TimerCoreDraw.segment.Second);
        if (seconds) TimerCoreDraw._drawElement(seconds, time.seconds, TimerCoreDraw.labels.Second);
    }

    static drawMilliseconds(element, time) {
        let milliseconds = element.querySelector(TimerCoreDraw.segment.Millisecond);
        if (milliseconds) TimerCoreDraw._drawElement(milliseconds, time.milliseconds, TimerCoreDraw.labels.Millisecond);
    }

    static _drawElement(element, value, titleWords) {
        element.textContent = TimerCoreDraw.correctValue(value);
        element.dataset.title = TimerCoreDraw.declensionNum(value, titleWords);
    }

    static correctValue(value) {
        return value < 10 ? '0' + value : value
    }

    static declensionNum(num, words) {
        return words[(num % 100 > 4 && num % 100 < 20) ? 2 : [2, 0, 1, 1, 1, 2][(num % 10 < 5) ? num % 10 : 5]];
    }
}