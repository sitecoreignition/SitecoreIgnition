using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JLL.SP2013.Internet.Eloqua.Models.Forms
{
    [DataContract]
    public class FormsListOptions
    {
        [DataMember(Name = "count")]
        public int? Count { get; set; }
        [DataMember(Name = "depth")]
        public string Depth { get; set; }
        [DataMember(Name = "orderBy")]
        public string OrderBy { get; set; }
        [DataMember(Name = "page")]
        public int? Page { get; set; }
        [DataMember(Name = "search")]
        public string Search { get; set; }
        [DataMember(Name = "lastUpdatedBy")]
        public int? LastUpdatedBy { get; set; }
    }
}
