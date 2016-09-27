using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JLL.SP2013.Internet.Eloqua.Models.Form
{
    [DataContract]
    public class FormElementRest10
    {
        [DataMember(Name = "createdFromContactFieldId")]
        public string CreatedFromContactFieldId { get; set; }

        [DataMember(Name = "dataType")]
        public string DataType { get; set; }
        [DataMember(Name = "displayType")]
        public string DisplayType { get; set; }
        [DataMember(Name = "fieldMergeId")]
        public int? FieldMergeId { get; set; }
        [DataMember(Name = "optionListId")]
        public int? OptionListId { get; set; }
        [DataMember(Name = "defaultValue")]
        public string DefaultValue { get; set; }
        [DataMember(Name = "htmlName")]
        public string HtmlName { get; set; }

        [DataMember(Name = "validations")]
        public List<Validation> Validations { get; set; }

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
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "instructions")]
        public string Instructions { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "permissions")]
        public string Permissions { get; set; }
        [DataMember(Name = "style")]
        public string Style { get; set; }

        [JsonIgnore]
        public Style StyleDetails
        {
            get
            {
                return new Models.Form.Style(this.Style);
            }
        }

        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "updatedAt")]
        public string UpdatedAt { get; set; }
        [DataMember(Name = "updatedBy")]
        public string UpdatedBy { get; set; }

    }
}
