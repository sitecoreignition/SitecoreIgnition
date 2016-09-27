using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JLL.SP2013.Internet.Eloqua.Models.Form
{
    [DataContract]
    public class FieldValueRest10
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "value")]
        public string Value { get; set; }

        public FieldValueRest10()
        {
            Type = "FieldValue";
        }
    }
}
