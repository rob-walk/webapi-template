using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WebApi.Models
{
    [DataContract]
    public class ResponseMessageModel
    {
        public ResponseMessageModel()
        {
            Messages = new List<string>();
        }

        [JsonProperty(PropertyName = "messages")]
        [DataMember(Name = "messages")]
        public List<string> Messages { get; set; }
    }
}