using System;

namespace Taller01
{
    public class Time
    {
        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;

        public Time() : this(0, 0, 0, 0) { }
        public Time(int hour) : this(hour, 0, 0, 0) { }
        public Time(int hour, int minute) : this(hour, minute, 0, 0) { }
        public Time(int hour, int minute, int second) : this(hour, minute, second, 0) { }

        public Time(int hour, int minute, int second, int millisecond)
        {
            if (!ValidHour(hour)) throw new ArgumentException($"The hour: {hour}, is not valid.");
            if (!ValidMinute(minute)) throw new ArgumentException($"The minute: {minute}, is not valid.");
            if (!ValidSecond(second)) throw new ArgumentException($"The second: {second}, is not valid.");
            if (!ValidMillisecond(millisecond)) throw new ArgumentException($"The millisecond: {millisecond}, is not valid.");

            _hour = hour;
            _minute = minute;
            _second = second;
            _millisecond = millisecond;
        }

        public static bool ValidHour(int h) => h >= 0 && h <= 23;
        public static bool ValidMinute(int m) => m >= 0 && m <= 59;
        public static bool ValidSecond(int s) => s >= 0 && s <= 59;
        public static bool ValidMillisecond(int ms) => ms >= 0 && ms <= 999;

        public int Hour => _hour;
        public int Minute => _minute;
        public int Second => _second;
        public int Millisecond => _millisecond;


        public long ToMilliseconds()
        {
            return (long)_hour * 3600000L + (long)_minute * 60000L + (long)_second * 1000L + _millisecond;
        }

        public long ToSeconds()
        {
            return ToMilliseconds() / 1000L;
        }

        public long ToMinutes()
        {
            return ToMilliseconds() / 60000L;
        }

        public Time Add(Time other)
        {
            int ms = this._millisecond + other._millisecond;
            int secCarry = 0, minCarry = 0, hrCarry = 0;

            if (ms > 999)
            {
                secCarry = ms / 1000;
                ms = ms % 1000;
            }

            int sec = this._second + other._second + secCarry;
            if (sec > 59)
            {
                minCarry = sec / 60;
                sec = sec % 60;
            }

            int min = this._minute + other._minute + minCarry;
            if (min > 59)
            {
                hrCarry = min / 60;
                min = min % 60;
            }

            int hr = this._hour + other._hour + hrCarry;
            if (hr > 23) hr = hr % 24;

            return new Time(hr, min, sec, ms);
        }

        public bool IsOtherDay(Time other)
        {
            long total = this.ToMilliseconds() + other.ToMilliseconds();
            long oneDayMs = 24L * 3600L * 1000L;
            return total >= oneDayMs;
        }


        public override string ToString()
        {
            string suffix;
            int displayHour;

            if (_hour == 0)
            {
                displayHour = 0;
                suffix = "AM";
            }
            else if (_hour < 12)
            {
                displayHour = _hour;
                suffix = "AM";
            }
            else if (_hour == 12)
            {
                displayHour = 12;
                suffix = "PM";
            }
            else
            {
                displayHour = _hour - 12;
                suffix = "PM";
            }

            return $"{displayHour:D2}:{_minute:D2}:{_second:D2}.{_millisecond:D3} {suffix}";
        }
    }
}
