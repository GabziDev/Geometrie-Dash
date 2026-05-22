using System.Text.Json.Serialization;

namespace test_raylibs.Model
{
    public class PlayerData
    {
        [JsonPropertyName("xp")]
        public int Xp {  get; set; }

        [JsonPropertyName("jump")]
        public int Jump {  get; set; }

        [JsonPropertyName("attempts")]
        public int Attempts { get; set; }
    }
}