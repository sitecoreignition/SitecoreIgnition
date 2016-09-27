using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JLL.SP2013.Internet.Eloqua.Models.OptionList
{
    [DataContract]
    public class OptionList
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "id")]
        public int? Id { get; set; }
        [DataMember(Name = "depth")]
        public string Depth { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "elements")]
        public List<Option> Elements { get; set; }

    }
}
