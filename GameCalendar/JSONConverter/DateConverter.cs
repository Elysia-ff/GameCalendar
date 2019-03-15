using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCalendar.Data;

namespace GameCalendar.JSONConverter
{
    public class DateConverter : JsonConverter<DateInfo>
    {
        private const char separator = ',';

        public override void WriteJson(JsonWriter writer, DateInfo value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override DateInfo ReadJson(JsonReader reader, Type objectType, DateInfo existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string value = reader.Value.ToString();

            return new DateInfo(value);
        }
    }
}
