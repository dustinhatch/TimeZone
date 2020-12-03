using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2
{
    public class Time2tz : Time2
    {
        private string timeZone;

        public Time2tz(int h, int m, int s, string tz) : base(h, m, s)
        {
            TimeZone = tz;
        }
        public Time2tz(Time2 time, string tz) : base(time)
        {
            TimeZone = tz;
        }

        public Time2tz(Time2tz time) 
        {
            base.Hour = time.Hour;
            base.Minute = time.Minute;
            base.Second = time.Second;
            TimeZone = time.TimeZone;
        }
        public string TimeZone
        {
            get
            {
                return timeZone;
            }

            set
            {
                string cst = "CST";
                string est = "EST";
                string pst = "PST";
                string mst = "MST";

                if (String.Equals(value, cst) == true) 
                {
                    timeZone = cst;
                }

                else if (String.Equals(value, est) == true)
                {
                    timeZone = est;
                }

                else if (String.Equals(value, pst) == true)
                {
                    timeZone = pst;
                }

                else if (String.Equals(value, mst) == true)
                {
                    timeZone = mst;
                }

                else
                    throw new ArgumentException("That is not a timezone.");
            }
        }

        public override string ToUniversalString() => $"{base.ToUniversalString()}" + $"Timezone: {TimeZone}";

        public override string ToString() => $"{base.ToString()}" + $"Timezone: {TimeZone}";
    }
}

