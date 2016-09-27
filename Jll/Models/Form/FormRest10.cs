using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JLL.SP2013.Internet.Eloqua.Models.Form
{
    [DataContract]
    public class FormRest10
    {
        [DataMember(Name = "accessedAt")]
        public string AccessedAt { get; set; }
        [DataMember(Name = "createdAt")]
        public string CreatedAt { get; set; }
        [DataMember(Name = "createdBy")]
        public string CreatedBy { get; set; }
        [DataMember(Name = "currentStatus")]
        public string CurrentStatus { get; set; }
        [DataMember(Name = "depth")]
        public string Depth { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "elements")]
        public List<FormElementRest10> Elements { get; set; }
        [DataMember(Name = "emailAddressFormFieldId")]
        public string EmailAddressFormFieldId { get; set; }
        [DataMember(Name = "html")]
        public string Html { get; set; }
        [DataMember(Name = "htmlName")]
        public string HtmlName { get; set; }
        [DataMember(Name = "id")]
        public int? Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "permissions")]
        public string Permissions { get; set; }
        [DataMember(Name = "processingType")]
        public string ProcessingType { get; set; }
        [DataMember(Name = "style")]
        public string Style { get; set; }
        [DataMember(Name = "submitFailedLandingPageId")]
        public string SubmitFailedLandingPageId { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "updatedAt")]
        public string UpdatedAt { get; set; }
        [DataMember(Name = "updatedBy")]
        public string UpdatedBy { get; set; }


    }
}
