using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JLL.SP2013.Internet.Eloqua.Models.OptionList
{
    [DataContract]
    public class Option
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }
        [DataMember(Name = "value")]
        public string Value { get; set; }
    }
}
