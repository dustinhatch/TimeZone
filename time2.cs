//GitHub doesn't allow duplicate filenames but this the original Time2.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2
{
    public class Time2
    {
        private int hour;
        private int minute;
        private int second;
        string version = "Original";

        public Time2(int h = 0, int m = 0, int s = 0)
        {
            SetTime(h, m, s);
        }

        public Time2(Time2 time) : this(time.Hour, time.Minute, time.Second) { }

        public void SetTime(int h, int m, int s)
        {
            Hour = h;
            Minute = m;
            Second = s;

        }

        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Hour)} must be 0 - 23.");
                }

                hour = value;
            }
        }

        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Minute)} must be 0 - 59.");
                }

                minute = value;
            }
        }

        public int Second
        {
            get
            {
                return second;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Second)} must be 0 - 59.");
                }
                second = value;
            }
        }

        public string ToUniversalString() => $"{Hour:D2}:{Minute:D2}:{Second:D2} Version: {version}.";

        public override string ToString() => $"{((Hour == 0 || Hour == 12) ? 12 : Hour % 12)}: " + $"{Minute:D2}:{Second:D2} {(Hour < 12 ? "AM" : "PM")} " + $"Version: {version}.";
    }
}
