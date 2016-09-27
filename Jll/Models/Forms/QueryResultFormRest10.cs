using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JLL.SP2013.Internet.Eloqua.Models.Forms
{
    [DataContract]
    public class QueryResultFormRest10
    {
        [DataMember(Name = "page")]
        public int? Page { get; set; }
        [DataMember(Name = "pageSize")]
        public int? PageSize { get; set; }
        [DataMember(Name = "total")]
        public int? Total { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
