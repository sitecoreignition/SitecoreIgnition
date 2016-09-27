using JLL.SP2013.Internet.Eloqua.Models.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JLL.SP2013.Internet.Eloqua.Models.Forms
{
    [DataContract]
    public class FormsList : QueryResultFormRest10
    {
        [DataMember(Name = "elements")]
        public List<FormRest10> Elements { get; set; }
    }
}
