using System.Text.Json.Serialization;

namespace test_raylibs.Model
{
    class JsonData
    {
        [JsonPropertyName("blocks")]
        public List<BlockData> Blocks { get; set; } = new List<BlockData>();
    }
}
