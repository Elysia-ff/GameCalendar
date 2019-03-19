using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private static readonly Dictionary<string, int> monthOffset = new Dictionary<string, int>
        {
            ["1Q"] = 3,
            ["2Q"] = 6,
            ["3Q"] = 9,
            ["4Q"] = 12,

            ["Spring"] = 5,
            ["Summer"] = 8,
            ["Fall"] = 11,
            ["Winter"] = 14
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
                        if (str.Length < 2 || !monthOffset.ContainsKey(str[1]))
                        {
                            DateValue = new DateTime(year, 12, 31);
                        }
                        else
                        {
                            int month = monthOffset[str[1]];
                            DateValue = new DateTime(year - 1, 12, 31);
                            DateValue = DateValue.AddMonths(month);
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
