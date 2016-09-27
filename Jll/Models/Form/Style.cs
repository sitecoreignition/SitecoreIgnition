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
    public class Style
    {
        [DataMember(Name = "fieldSize")]
        public string FieldSize { get; set; }
        [DataMember(Name = "labelPosition")]
        public string LabelPosition { get; set; }
        [DataMember(Name = "labelAlignment")]
        public string LabelAlignment { get; set; }
        [DataMember(Name = "listOrder")]
        public string ListOrder { get; set; }

        public Style()
        {

        }

        public Style(string styleJson)
        {
            var obj = JsonConvert.DeserializeObject<Style>(styleJson);
            this.FieldSize = obj.FieldSize;
            this.LabelPosition = obj.LabelPosition;
            this.LabelAlignment = obj.LabelAlignment;
            this.ListOrder = obj.ListOrder;
        }

    }
}
