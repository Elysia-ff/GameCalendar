using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCalendar.Data
{
    public class GameData
    {
        public class UIData
        {
            public Panel panel;
            public GroupBox groupBox;
            public List<Label> labels = new List<Label>();
            public Button button;
            public EventHandler clickEvent;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("developer")]
        public string Developer { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("koreanPatch")]
        public string KoreanPatch { get; set; }

        public UIData uiData;

        public TimeSpan? GetTimeSpan()
        {
            if (DateTime.TryParse(Date, out DateTime dateTime))
                return DateTime.UtcNow - dateTime;

            return null;
        }

        public static int SortByDate(GameData v1, GameData v2)
        {
            TimeSpan? v1Time = v1.GetTimeSpan();
            TimeSpan? v2Time = v2.GetTimeSpan();

            if (!v1Time.HasValue && !v2Time.HasValue)
                return 0;

            if (!v1Time.HasValue)
                return 1;
            if (!v2Time.HasValue)
                return -1;

            if (v1Time.Value.Days < v2Time.Value.Days)
                return 1;
            if (v1Time.Value.Days > v2Time.Value.Days)
                return -1;

            return 0;
        }
    }
}
