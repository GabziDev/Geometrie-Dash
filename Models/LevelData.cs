using System.Text.Json.Serialization;

namespace test_raylibs.Model
{
    class LevelData
    {
        [JsonPropertyName("bgColor")]
        public string? BgColor {  get; set; }

        [JsonPropertyName("data")]
        public JsonData Data { get; set; } = new();
    }
}
