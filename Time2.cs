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
        public StringBuilder sb;


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

        public virtual string ToUniversalString()
        {
            sb = new StringBuilder();
            sb.Append($"{Hour:D2}".ToString());
            sb.Append(":");
            sb.Append($"{Minute:D2}".ToString());
            sb.Append(":");
            sb.Append($"{Second:D2}".ToString());
            sb.Append(" Version: Modified.");

            string s1 = sb.ToString();
            return s1;
        }

        public override string ToString()
        {
            int tempHour; // To not lose 24 hour format

            sb = new StringBuilder();
            if (Hour == 0 || Hour == 12)
            {
                tempHour = 12;
            }
            else
            {
                tempHour = Hour % 12;
            }
            sb.Append(tempHour.ToString());
            sb.Append(":");
            sb.Append($"{Minute:D2}".ToString());
            sb.Append(":");
            sb.Append($"{Second:D2}".ToString());
            sb.Append(" ");
            if (Hour >= 12)
            {
                sb.Append("PM ");
            }
            else
            {
                sb.Append("AM ");
            }
            sb.Append("Version: Modified.");

            string s2 = sb.ToString();
            return s2;
        }

        public void addTime(int h, int m, int s)
        {
           

            if ((Second + s) > 59) 
            {
                Second = (Second + s) % 60;
                m += (Second + s) / 60;
            }
            else
                Second += s;

            if ((Minute + m) > 59) 
            {
                Minute = (Minute + m) % 60;
                h += (Minute + m) / 60;
            }
            else
                Minute += m;


            if ((Hour + h) > 23) 
            {
               
                throw new ArgumentOutOfRangeException(nameof(Hour), Hour+h, $"Time exceeds 23:59:59"); 

            }
            else
                Hour += h;
        }

        public void addTime(Time2 time)
        {
            

            if ((Second + time.Second) > 59) 
            {
                Second = (Second + time.Second) % 60;
                Minute += (Second + time.Second) / 60;
            }
            else 
                Second += time.Second;

            if ((Minute + time.Minute) > 59) /
            {
                Minute = (Minute + time.Minute) % 60;
                Hour += (Minute + time.Minute) / 60;
            }
            else
                Minute += time.Minute;

            if ((Hour + time.Hour) > 23) 
            {
                Hour = (Hour + time.Hour) % 24;

            }
            else
                Hour += time.Hour;
        }
    }
}
