using Newtonsoft.Json;

namespace app.Model
{
    public class Member
    {
        [JsonProperty("Name")]
        public string Name {get;set;}

        [JsonProperty("Tag")]
        public string Tag {get;set;}
    }
}