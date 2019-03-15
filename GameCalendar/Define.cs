using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCalendar.Data;

namespace GameCalendar
{
    public static class Define
    {
        // http://www.flounder.com/csharp_color_table.htm
        public static readonly Color UnknownColor = Color.Thistle;
        public static readonly Color TooLongColor = Color.LightPink;
        public static readonly Color CloseColor = Color.Orange;
        public static readonly Color CameColor = Color.PaleGreen;

        public static readonly int IgnoreDay = 30;

        public static readonly string resourcesPath = "https://raw.githubusercontent.com/Elysia-ff/GameCalendar-resources/master/Calendar.json";
    }
}
