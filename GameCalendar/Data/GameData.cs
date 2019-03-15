using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCalendar.Data
{
    public class GameData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date")]
        public DateInfo Date { get; set; }

        [JsonProperty("developer")]
        public string Developer { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("koreanPatch")]
        public string KoreanPatch { get; set; }

        public UIData uiData;

        public static int SortByDate(GameData v1, GameData v2)
        {
            TimeSpan v1Time = v1.Date.GetTimeSpan();
            TimeSpan v2Time = v2.Date.GetTimeSpan();

            if (v1Time.Days < v2Time.Days)
                return 1;
            if (v1Time.Days > v2Time.Days)
                return -1;

            return 0;
        }
    }
}
