using System;

namespace Taller01
{
    public class Time
    {
        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;

        public int Hour
        {
            get => _hour;
            private set
            {
                if (!ValidHour(value))
                    throw new Exception($"The hour: {value}, is not valid.");
                _hour = value;
            }
        }

        public int Minute
        {
            get => _minute;
            private set
            {
                if (!ValidMinute(value))
                    throw new Exception($"The minute: {value}, is not valid.");
                _minute = value;
            }
        }

        public int Second
        {
            get => _second;
            private set
            {
                if (!ValidSecond(value))
                    throw new Exception($"The second: {value}, is not valid.");
                _second = value;
            }
        }

        public int Millisecond
        {
            get => _millisecond;
            private set
            {
                if (!ValidMillisecond(value))
                    throw new Exception($"The millisecond: {value}, is not valid.");
                _millisecond = value;
            }
        }

        public Time() : this(0, 0, 0, 0) { }
        public Time(int hour) : this(hour, 0, 0, 0) { }
        public Time(int hour, int minute) : this(hour, minute, 0, 0) { }
        public Time(int hour, int minute, int second) : this(hour, minute, second, 0) { }
        public Time(int hour, int minute, int second, int millisecond)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;
        }

        public static bool ValidHour(int hour) => hour >= 0 && hour <= 23;
        public static bool ValidMinute(int minute) => minute >= 0 && minute <= 59;
        public static bool ValidSecond(int second) => second >= 0 && second <= 59;
        public static bool ValidMillisecond(int ms) => ms >= 0 && ms <= 999;

        public long ToMilliseconds()
        {
            if (!ValidHour(Hour) || !ValidMinute(Minute) || !ValidSecond(Second) || !ValidMillisecond(Millisecond))
                return 0;
            return (long)Hour * 3600000 + Minute * 60000 + Second * 1000 + Millisecond;
        }

        public long ToSeconds()
        {
            if (!ValidHour(Hour) || !ValidMinute(Minute) || !ValidSecond(Second) || !ValidMillisecond(Millisecond))
                return 0;
            return (long)Hour * 3600 + Minute * 60 + Second;
        }

        public long ToMinutes()
        {
            if (!ValidHour(Hour) || !ValidMinute(Minute) || !ValidSecond(Second) || !ValidMillisecond(Millisecond))
                return 0;
            return (long)Hour * 60 + Minute;
        }

        public Time Add(Time other)
        {
            int ms = this.Millisecond + other.Millisecond;
            int s = this.Second + other.Second;
            int m = this.Minute + other.Minute;
            int h = this.Hour + other.Hour;

            if (ms > 999)
            {
                s += ms / 1000;
                ms %= 1000;
            }
            if (s > 59)
            {
                m += s / 60;
                s %= 60;
            }
            if (m > 59)
            {
                h += m / 60;
                m %= 60;
            }

            h %= 24;
            return new Time(h, m, s, ms);
        }

        public bool IsOtherDay(Time other)
        {
            long total = this.ToMilliseconds() + other.ToMilliseconds();
            long oneDay = 24L * 3600 * 1000;
            return total >= oneDay;
        }

        public override string ToString()
        {
            DateTime dt = new DateTime(1, 1, 1, Hour, Minute, Second, Millisecond);
            return dt.ToString("hh:mm:ss.fff tt");
        }
    }
}
