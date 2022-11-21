class TimerCoreLogic {
    static getTime(milliseconds) {
        return new TimerCoreLogic.TimerCoreTime(
            milliseconds,
            TimerCoreLogic.getSeconds(milliseconds),
            TimerCoreLogic.getMinutes(milliseconds),
            TimerCoreLogic.getHours(milliseconds),
            TimerCoreLogic.getDays(milliseconds));
    }

    static segment = { Day: 24, Hour: 60, Minute: 60, Second: 1000 };

    static getDays(milliseconds) {
        return milliseconds > 0
            ? Math.floor(
                milliseconds
                / TimerCoreLogic.segment.Second
                / TimerCoreLogic.segment.Minute
                / TimerCoreLogic.segment.Hour
                / TimerCoreLogic.segment.Day)
            : 0;
    }

    static getHours(milliseconds) {
        return milliseconds > 0
            ? (
                Math.floor(
                    milliseconds
                    / TimerCoreLogic.segment.Second
                    / TimerCoreLogic.segment.Minute
                    / TimerCoreLogic.segment.Hour)
                % this.segment.Day)
            : 0;
    }

    static getMinutes(milliseconds) {
        return milliseconds > 0
            ? (
                Math.floor(
                    milliseconds
                    / TimerCoreLogic.segment.Second
                    / TimerCoreLogic.segment.Minute)
                % TimerCoreLogic.segment.Hour)
            : 0;
    }

    static getSeconds(milliseconds) {
        return milliseconds > 0
            ? (
                Math.floor(milliseconds / TimerCoreLogic.segment.Second)
                % TimerCoreLogic.segment.Minute)
            : 0;
    }

    static TimerCoreTime = class {
        constructor(milliseconds, seconds, minutes, hours, days) {
            this.milliseconds = milliseconds;
            this.seconds = seconds;
            this.minutes = minutes;
            this.hours = hours;
            this.days = days;
        }
    }
}