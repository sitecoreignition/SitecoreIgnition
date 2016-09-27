using JLL.SP2013.Internet.Eloqua.Client;
using JLL.SP2013.Internet.Eloqua.Models;
using JLL.SP2013.Internet.Eloqua.Models.Form;
using JLL.SP2013.Internet.Eloqua.Models.OptionList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLL.SP2013.Internet.Eloqua.Transform
{
    public class EloquaToJllHtmlTransformer
    {
        private EloquaRestServiceClient _service;
        private string _instanceId;
        private string _resultFieldClientId;
        private string _formInstanceId;
        public string FormInstanceId { get { return _formInstanceId; } private set { _formInstanceId = value; } }
        public string ResultFieldClientId { get { return _resultFieldClientId;} }
        private Dictionary<int, OptionList> loadedOptions;
        public EloquaToJllHtmlTransformer(EloquaRestServiceClient service, string instanceId, string resultFieldClientId)
        {
            _service = service;
            _instanceId = instanceId;
            _resultFieldClientId = resultFieldClientId;
        }

        /// <summary>
        /// Loads all options list metadata based on a list of Ids
        /// </summary>
        /// <param name="optionListIds"></param>
        /// <returns></returns>
        private void LoadOptionsLists(List<int> optionListIds)
        {
            var optionListDict = new Dictionary<int, OptionList>();
            foreach (var optionListId in optionListIds)
            {
                if (!optionListDict.ContainsKey(optionListId))
                {
                    var specificOptionList = _service.GetOptionList(new OptionListOptions { Id = optionListId, Depth = RequestDepths.Complete });
                    optionListDict.Add(optionListId, specificOptionList);
                }
            }
            loadedOptions =  optionListDict;
        }

        public string GenerateForm(int formId)
        {
            var convertedInstanceId = _instanceId.Replace("-", "_");
            FormInstanceId = "elq__" + convertedInstanceId + "__" + formId.ToString();
            var form = _service.GetForm(new Eloqua.Models.Forms.FormOptions { Id = formId, Depth = RequestDepths.Complete });

            //prepare necesary dropdowns
            var elementsWithOptionLists = form.Elements.Where(e => e.OptionListId.HasValue).Select(e=>e.OptionListId.Value).Distinct().ToList();
            LoadOptionsLists(elementsWithOptionLists);

            var htmlBuilder = new StringBuilder();
            htmlBuilder.Append(addCSS());
            htmlBuilder.Append(addJavaScript());
            foreach (var element in form.Elements)
            {

                if (element.Type == FormElementType.FormField && element.DisplayType == FieldDisplayType.Hidden)
                {
                    var fieldHtml = generateFormHiddenField(element);
                    htmlBuilder.Append(fieldHtml);
                    continue;
                }

                if (element.Type == FormElementType.FormField)
                {
                    if (element.DisplayType != FieldDisplayType.Submit)
                    {
                        var fieldHtml = generateFormField(element);
                        htmlBuilder.Append(fieldHtml);
                    }
                    if (element.DisplayType == FieldDisplayType.Submit)
                    {
                        var fieldHtml = generateSubmitButton(element);
                        htmlBuilder.Append(fieldHtml);
                    }
                }
            }
            return htmlBuilder.ToString();
        }

        private string addJavaScript() {
            var js = new StringBuilder();
            
            js.Append(@"<script type=""text/javascript"" src=""/_layouts/15/JLL/JLLEloquaFormRuntime.js"">");
            //js.Append(@"window.JLLEloquaForm_" + formInstance + @" = {");
            //js.Append(@"instance: """ + formInstance + @""",");
            //js.Append(@"validate : function() { var fields = $(""input[data-elq-instance="+ formInstance+ @"]""); var requiredFields = $.grep(fields, function(obj,i){ return $(obj).data(""elq-validations"")==""required""}); var requiredFieldsWithMissingData = $.grep(requiredFields, function (obj,o){ return $(obj).val()==""""});  $.each(requiredFieldsWithMissingData, function(obj,i){ $(obj).next().show(); }); return (requiredFieldsWithMissingData.length>0); },");
            //js.Append(@"submit : function() {  if(this.validate()){window.alert('Submit');} else {window.alert('Validation failse');}}");
            //js.Append("}");
            js.Append("</script>");
            js.Append(@"<script type=""text/javascript"">");
            js.Append(@"//JLL specific form instance
$( document ).ready(function() {
    window.JLLEloquaForm_"+ this.FormInstanceId + @" = new JLLEloquaForm("""+ this.FormInstanceId+ @""", """+this.ResultFieldClientId+ @""");
    window.JLLEloquaForm_" + this.FormInstanceId + @".attachFormSubmitHandler();
});");
            js.Append("</script>");

            return js.ToString(); ;
        }
        private string addCSS()
        {
            var cssBuilder = new StringBuilder();
            cssBuilder.Append(@"<link rel=""stylesheet"" href=""/_layouts/15/JLL/JLLEloquaFormRuntime.css"">");
            return cssBuilder.ToString();
        }

        private string generateFormField(FormElementRest10 formField)
        {

            if (formField.StyleDetails.LabelPosition == LabelPositionType.Left)
            {
                return generateFormFieldHorizontal(formField);
            } else
            {
                return generateFormFieldVertical(formField);
            }
        }

        private string generateFormFieldHorizontal(FormElementRest10 formField)
        {
            var template =
            @"<div class=""eloqua-form-group-horizontal eloqua-form-group"">" +
            @"<label for=""{1}"" class=""eloquaLabel eloqua-w2"">{0}</label>" +
            @"<div class=""eloqua-w10""><input type=""text"" class=""eloquaTextField"" id=""{1}"" placeholder=""{2}"" /><div>" +
            @"</div>";
            return string.Format(template, formField.Name, formField.HtmlName, formField.Instructions);
        }



        private FieldValidationInfo generateFieldValidation(FormElementRest10 formField)
        {
            var fieldValidationInfo = new FieldValidationInfo();
            var validationHtml = new StringBuilder();
            var hasRequiredValidation = false;
            var fieldValidationTypes = new List<string>();
            var fieldValidationAttribute = string.Empty;
            if (formField.Validations != null && formField.Validations.Count > 0)
            {
                foreach (var validationElement in formField.Validations)
                {

                    if (validationElement.Condition != null)
                    {
                        var conditionType = validationElement.Condition.Type;
                        switch (conditionType)
                        {
                            case ConditionType.Required:
                                {
                                    hasRequiredValidation = true;
                                    fieldValidationTypes.Add("required");
                                    var requiredValidationMessage = addRequiredValidation(formField);
                                    validationHtml.Append(requiredValidationMessage);
                                    break;
                                }
                            case ConditionType.IsEmailAddress:
                                {
                                    fieldValidationTypes.Add("email");
                                    var emailValidationMessage = addEmailValidation(formField);
                                    validationHtml.Append(emailValidationMessage);
                                    break;
                                }
                        }
                    }
                }

                //when all validations are added
                if (fieldValidationTypes.Count > 0)
                {
                    fieldValidationAttribute = string.Format(@" data-elq-validations=""{0}""", string.Join(",", fieldValidationTypes.ToArray()));
                }

            }
            fieldValidationInfo.HasRequiredFieldValidation = hasRequiredValidation;
            fieldValidationInfo.ElementValidationTag = fieldValidationAttribute;
            fieldValidationInfo.ValidationMessageHtml = validationHtml.ToString();

            return fieldValidationInfo;
        }

        private string generateFormFieldVertical(FormElementRest10 formField)
        {
            var html = new StringBuilder();

            html.AppendFormat(@"<div class=""eloqua-form-group-vertical eloqua-form-group"" data-elq-container=""{0}"">", formField.Id);

            var validationFieldInfo = generateFieldValidation(formField);
        
            switch (formField.DisplayType)
            {
                case FieldDisplayType.Text:
                    {
                        html.Append(generateFormTextFieldVertical(formField, validationFieldInfo));
                        break;
                    }
                case FieldDisplayType.Checkbox:
                    {
                        //html.Append(generateFormCheckboxFieldVertical(formField, validationFieldInfo));
                        break;
                    }
                case FieldDisplayType.Dropdown:
                    {
                        html.Append(generateFormFieldDropdownVertical(formField, validationFieldInfo));
                        break;
                    }
            }

            html.Append(validationFieldInfo.ValidationMessageHtml);
            html.Append("</div>");

            return html.ToString();
        }

        private string generateFormCheckboxFieldVertical(FormElementRest10 formField, FieldValidationInfo fieldValidationInfo)
        {

            var template =
            @"<label for=""{3}"" class=""eloquaLabel eloquaCheckbokField"">" +
            @"<input type=""checkbox"" data-elq-instance=""{0}"" data-elq-field=""{1}"" {6}class=""eloquaField eloquaCheckbokField"" id=""{3}"" value=""{5}"" />" +
            @"{2}</label>";

            return string.Format(template
                , this.FormInstanceId
                , formField.Id
                , formField.Name
                , formField.HtmlName
                , !string.IsNullOrEmpty(formField.DefaultValue) ? "checked ": string.Empty
                , formField.DefaultValue
                , fieldValidationInfo.ElementValidationTag);
        }

        private string generateFormTextFieldVertical(FormElementRest10 formField, FieldValidationInfo fieldValidationInfo)
        {

            var template =
            @"<label for=""{3}"" class=""eloquaLabel"">{2}{6}</label>" +
            @"<input type=""text"" data-elq-instance=""{0}"" data-elq-field=""{1}"" {7}class=""eloquaField eloquaTextField"" id=""{3}"" placeholder=""{4}"" value=""{5}"" />";
            
            return string.Format(template
                , this.FormInstanceId
                , formField.Id
                , formField.Name
                , formField.HtmlName
                , formField.Instructions
                , formField.DefaultValue ?? string.Empty
                , (fieldValidationInfo.HasRequiredFieldValidation) ?"*":string.Empty
                , fieldValidationInfo.ElementValidationTag);
        }

        private string generateFormHiddenField(FormElementRest10 formField)
        {

            var template =
            @"<input type=""hidden"" data-elq-instance=""{0}"" data-elq-field=""{1}"" id=""{2}"" value=""{3}"" />";

            return string.Format(template
                , this.FormInstanceId
                , formField.Id
                , formField.HtmlName
                , formField.DefaultValue ?? string.Empty
               );
        }

        private string generateFormFieldDropdownVertical(FormElementRest10 formField, FieldValidationInfo fieldValidationInfo)
        {
            var options = string.Empty;
            if (formField.OptionListId.HasValue)
            {
                var optionList = this.loadedOptions[formField.OptionListId.Value];
                var optionItemTemplate = @"<option value=""{0}"">{1}</option>";
                var htmlOptions = optionList.Elements.Select(optionItem => string.Format(optionItemTemplate, optionItem.Value??string.Empty, optionItem.DisplayName)).ToArray();
                options = string.Join(string.Empty, htmlOptions);
            }


            var template =
            @"<label for=""{3}"" class=""eloquaLabel"">{2}{5}</label>" +
            @"<select data-elq-instance=""{0}"" data-elq-field=""{1}"" {6}class=""eloquaField eloquaSelectField"" id=""{3}"">" +
            options + 
            @"</select>";
            return string.Format(template
                , this.FormInstanceId
                , formField.Id
                , formField.Name
                , formField.HtmlName
                , formField.Instructions
                , (fieldValidationInfo.HasRequiredFieldValidation) ? "*" : string.Empty
                , fieldValidationInfo.ElementValidationTag);
        }


        private string generateSubmitButton(FormElementRest10 formField)
        {
            var fieldFormat = @"<div class=""clearfix"">" +
            @"<a class=""button eloquaSubmitButton"" onclick=""javascript:JLLEloquaForm_{2}.submit()"" id=""{1}"">{0}</a>" +
            @"</div>";

            return string.Format(fieldFormat, formField.Name, formField.HtmlName, this.FormInstanceId);
        }

        private string addRequiredValidation(FormElementRest10 formField)
        {
            var validation = formField.Validations.FirstOrDefault(v => v.Condition != null && v.Condition.Type == ConditionType.Required);
            var template = @"<span data-elq-instance=""{0}"" data-elq-fieldRef=""{1}"" data-elq-vtype=""required"" class=""eloqua-validation-message"">{2}</span>";
            return string.Format(template, this.FormInstanceId, formField.Id, validation.Message);
        }

        private string addEmailValidation(FormElementRest10 formField)
        {
            var validation = formField.Validations.FirstOrDefault(v => v.Condition != null && v.Condition.Type == ConditionType.IsEmailAddress);
            var template = @"<span data-elq-instance=""{0}"" data-elq-fieldRef=""{1}"" data-elq-vtype=""email"" class=""eloqua-validation-message"">{2}</span>";
            return string.Format(template, this.FormInstanceId, formField.Id, validation.Message);
        }

    }
}
