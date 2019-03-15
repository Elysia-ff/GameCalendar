using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCalendar.Data
{
    public class DateInfo
    {
        public string DateStr { get; private set; }
        public DateTime DateValue { get; private set; }

        private static readonly char separator = ' ';
        private static readonly Dictionary<string, int> dateOrder = new Dictionary<string, int>
        {
            ["1Q"] = 3,
            ["2Q"] = 6,
            ["3Q"] = 9,
            ["4Q"] = 12,

            ["Spring"] = 3,
            ["Summer"] = 6,
            ["Fall"] = 9,
            ["Winter"] = 12
        };

        public DateInfo(string value)
        {
            DateStr = value;

            if (DateTime.TryParse(DateStr, out DateTime temp))
            {
                DateValue = temp;
            }
            else
            {
                DateValue = DateTime.MaxValue;

                string[] str = DateStr.Split(separator);
                if (str.Length > 0)
                {
                    if (int.TryParse(str[0], out int year))
                    {
                        if (str.Length < 2 || !dateOrder.ContainsKey(str[1]))
                        {
                            DateValue = new DateTime(year, 12, 31);
                        }
                        else
                        {
                            int month = dateOrder[str[1]];
                            int day = DateTime.DaysInMonth(year, month);
                            DateValue = new DateTime(year, month, day);
                        }
                    }
                }
            }
        }

        public TimeSpan GetTimeSpan()
        {
            return DateTime.UtcNow - DateValue;
        }

        public Color GetColor()
        {
            if (DateValue == DateTime.MaxValue)
                return Define.UnknownColor;

            int days = (DateTime.UtcNow - DateValue).Days;
            if (days < -30)
                return Define.TooLongColor;
            if (days < 0)
                return Define.CloseColor;

            return Define.CameColor;
        }

        public override string ToString()
        {
            return DateStr;
        }
    }
}
