using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JLL.SP2013.Internet.Eloqua.Models.Form
{
    [DataContract]
    public class FormDataRest10
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "currentStatus", IsRequired =false)]
        public string CurrentStatus { get; set; }
        [DataMember(Name = "submittedAt", IsRequired = false)]
        public string SubmittedAt { get; set; }
        [DataMember(Name = "submittedByContactId", IsRequired = false)]
        public string submittedByContactId { get; set; }
        [DataMember(Name = "type", IsRequired = false)]
        public string Type { get; set; }
        [DataMember(Name = "fieldValues")]
        public List<FieldValueRest10> FieldValues { get; set; }

        public FormDataRest10()
        {
            FieldValues = new List<FieldValueRest10>();
        }
    }
}
