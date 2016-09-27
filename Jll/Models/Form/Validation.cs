using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JLL.SP2013.Internet.Eloqua.Models.Form
{
    [DataContract]
    public class Validation
    {
        [DataMember(Name = "condition")]
        public Condition Condition { get; set; }
        [DataMember(Name = "depth")]
        public string Depth { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "isEnabled")]
        public bool? IsEnabled { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }

}
