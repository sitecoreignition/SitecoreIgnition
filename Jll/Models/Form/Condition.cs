using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JLL.SP2013.Internet.Eloqua.Models.Form
{
    [DataContract]
    public class Condition
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "end")]
        public int? End { get; set; }
        [DataMember(Name = "start")]
        public int? Start { get; set; }
    }
}
