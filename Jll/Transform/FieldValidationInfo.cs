using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLL.SP2013.Internet.Eloqua.Transform
{
    internal class FieldValidationInfo
    {
        public bool HasRequiredFieldValidation { get; set; }
        public string ElementValidationTag { get; set; }
        public string ValidationMessageHtml { get; set; }
    }
}
