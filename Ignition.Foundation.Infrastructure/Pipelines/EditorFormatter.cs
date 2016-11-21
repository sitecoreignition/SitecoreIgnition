using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore;
using Sitecore.Configuration;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Reflection;
using Sitecore.Resources;
using Sitecore.Security;
using Sitecore.Shell;
using Sitecore.Shell.Applications.ContentEditor;
using Sitecore.Shell.Applications.ContentEditor.Pipelines.RenderContentEditor;
using Sitecore.Shell.Applications.ContentManager;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI;
using Sitecore.Web.UI.HtmlControls;
using Control = System.Web.UI.Control;
using Memo = Sitecore.Shell.Applications.ContentEditor.Memo;
using WebControl = Sitecore.Web.UI.WebControl;

namespace Ignition.Foundation.Infrastructure.Pipelines
{
    /// <summary>
    ///Formatter for rendering the editor
    ///Decompiled from original Sitecore Source
    ///Originally modified and implemented by Eric Stafford
    /// </summary>
    public class EditorFormatter
    {
		#region Ignition Edit

	    public void RenderLabel(Control parent, Editor.Field field, Item fieldType, bool readOnly)
	    {
		    var itemField = field.ItemField;
		    var language = Arguments.Language;
		    var customFieldMapping = false;
		    var s = field.TemplateField.GetTitle(language);
		    if (string.IsNullOrEmpty(s))
			    s = field.TemplateField.IgnoreDictionaryTranslations ? itemField.Name : Translate.Text(itemField.Name);
		    var template = field.ItemField.Item.TemplateName;
			var item =
					YmlSettingsReader.TemplateMap.TemplateItem.FirstOrDefault(a => a.TemplateName == template)?
						.MapItems.FirstOrDefault(a => a.FieldName == s);
			    
			if (item != null)
			{
				s = $"<b>[Ignition-{s}]</b>: <span style=\"font-style: italic\">{item.MapTo}</span>";
				customFieldMapping = true;
			}

			var toolTip = itemField.ToolTip;
		    
		    if (!string.IsNullOrEmpty(toolTip))
		    {
			    var text = Translate.Text(toolTip);
			    if (text.EndsWith(".", StringComparison.InvariantCulture))
				    text = StringUtil.Left(text, text.Length - 1);
			    s = (customFieldMapping && !string.IsNullOrEmpty(item.ShortDescription)) ? $"{s} - <span style=\"font-style: italic\">{item.ShortDescription}</span>" : $"{s} - {text}";
		    }

			var str1 = customFieldMapping ? s : HttpUtility.HtmlEncode(s);

		    var label = field.ItemField.GetLabel(Arguments.IsAdministrator || Settings.ContentEditor.ShowFieldSharingLabels);
			if (!string.IsNullOrEmpty(label))
				str1 = str1 + "<span class=\"scEditorFieldLabelAdministrator\"> [" + label + "]</span>";
			var typeKey = itemField.TypeKey;
			if (!string.IsNullOrEmpty(typeKey) && typeKey != "checkbox")
				str1 += ":";
			if (readOnly)
				str1 = "<span class=\"scEditorFieldLabelDisabled\">" + str1 + "</span>";
			var str2 = HttpUtility.HtmlAttributeEncode(itemField.HelpLink);
			if (str2.Length > 0)
				str1 = "<a class=\"scEditorFieldLabelLink\" href=\"" + str2 + "\" target=\"__help\">" + str1 + "</a>";
			var str3 = string.Empty;
			if (itemField.Description.Length > 0)
				str3 = " title=\"" + HttpUtility.HtmlAttributeEncode(itemField.Description) + "\"";
			var text1 = "<div class=\"" + "scEditorFieldLabel" + "\"" + str3 + ">" + str1 + "</div>";
			AddLiteralControl(parent, text1);
		}
		#endregion
		#region Sitecore Decompile
		public EditorFormatter(RenderContentEditorArgs args)
        {
            Arguments = args;
        }

        public RenderContentEditorArgs Arguments { get; set; }

        public bool IsFieldEditor { get; set; }

        public static void SetAttributes(Control editor, Editor.Field field, bool hasRibbon)
        {
            var attributeCollection = ReflectionUtil.GetProperty(editor, "Attributes") as AttributeCollection;

            if (attributeCollection == null)
                return;

            var str = field.ItemField.Item.Uri + "&fld=" + field.ItemField.ID + "&ctl=" + field.ControlID;

            if (hasRibbon)
                str += "&rib=1";

            attributeCollection["onfocus"] = $"javascript:return scContent.activate(this,event,'{str}')";
            attributeCollection["onblur"] = $"javascript:return scContent.deactivate(this,event,'{str}')";
        }

        public static void SetProperties(Control editor, Editor.Field field, bool readOnly)
        {
            ReflectionUtil.SetProperty(editor, "ID", field.ControlID);
            ReflectionUtil.SetProperty(editor, "ItemID", field.ItemField.Item.ID.ToString());
            ReflectionUtil.SetProperty(editor, "ItemVersion", field.ItemField.Item.Version.ToString());
            ReflectionUtil.SetProperty(editor, "ItemLanguage", field.ItemField.Item.Language.ToString());
            ReflectionUtil.SetProperty(editor, "FieldID", field.ItemField.ID.ToString());
            ReflectionUtil.SetProperty(editor, "Source", field.ItemField.Source);
            ReflectionUtil.SetProperty(editor, "ReadOnly", readOnly ? 1 : 0);
            ReflectionUtil.SetProperty(editor, "Disabled", readOnly ? 1 : 0);
        }

        public static void SetStyle(Control editor, Editor.Field field)
        {
            if (string.IsNullOrEmpty(field.ItemField.Style))
                return;

            var css = ReflectionUtil.GetProperty(editor, "Style") as CssStyleCollection;

            if (css == null)
                return;

            UIUtil.ParseStyle(css, field.ItemField.Style);
        }

        public void AddEditorControl(Control parent, Control editor, Editor.Field field,
            bool hasRibbon, bool readOnly, string value)
        {
            SetProperties(editor, field, readOnly);
            SetValue(editor, value);

            var editorFieldContainer = new EditorFieldContainer(editor);
            editorFieldContainer.ID = field.ControlID + "_container";
            var control = (Control) editorFieldContainer;

            Context.ClientPage.AddControl(parent, control);
            SetProperties(editor, field, readOnly);
            SetAttributes(editor, field, hasRibbon);
            SetStyle(editor, field);

            SetValue(editor, value);
        }

        public void AddLiteralControl(Control parent, string text)
        {
            if (parent.Controls.Count > 0)
            {
                var literalControl = parent.Controls[parent.Controls.Count - 1] as LiteralControl;
                if (literalControl != null)
                {
                    literalControl.Text += text;
                    return;
                }
            }

            Context.ClientPage.AddControl(parent, new LiteralControl(text));
        }

        public Control GetEditor(Item fieldType)
        {
            if (!Arguments.ShowInputBoxes)
            {
                var str = fieldType.Name.ToLowerInvariant();
                if (str == "html" || str == "memo" || str == "rich text" || str == "security" ||
                    str == "multi-line text")
                    return new Memo();

                return fieldType.Name == "password" ? new Password() : new Text();
            }

            var control = Resource.GetWebControl(fieldType["Control"]);

            if (control == null)
            {
                var assembly = fieldType["Assembly"];
                var className = fieldType["Class"];

                if (!string.IsNullOrEmpty(assembly) && !string.IsNullOrEmpty(className))
                    control = ReflectionUtil.CreateObject(assembly, className, new object[0]) as Control;
            }

            return control ?? new Text();
        }

        public Item GetFieldType(Field itemField)
        {
            Assert.ArgumentNotNull(itemField, "itemField");
            return FieldTypeManager.GetFieldTypeItem(StringUtil.GetString(itemField.Type, "text")) ??
                   FieldTypeManager.GetDefaultFieldTypeItem();
        }

        public virtual void RenderField(Control parent, Editor.Field field, bool readOnly)
        {
            var itemField = field.ItemField;
            var fieldType = GetFieldType(itemField);

            if (fieldType == null)
                return;

            if (!itemField.CanWrite)
                readOnly = true;

            RenderMarkerBegin(parent, field.ControlID);
            var typeKey = itemField.TypeKey;

            if (!string.IsNullOrEmpty(typeKey) && typeKey.Equals("checkbox") && !UserOptions.ContentEditor.ShowRawValues)
            {
                RenderField(parent, field, fieldType, readOnly);
                RenderLabel(parent, field, fieldType, readOnly);
                RenderMenuButtons(parent, field, fieldType, readOnly);
            }
            else
            {
                RenderLabel(parent, field, fieldType, readOnly);
                RenderMenuButtons(parent, field, fieldType, readOnly);
                RenderField(parent, field, fieldType, readOnly);
            }

            RenderMarkerEnd(parent);
        }

        public virtual void RenderField(Control parent, Editor.Field field, Item fieldType, bool readOnly)
        {
            var str = string.Empty;
            if (field.ItemField.IsBlobField && !Arguments.ShowInputBoxes)
            {
                readOnly = true;
                str = Translate.Text("[Blob Value]");
            }
            else
                str = field.Value;

            RenderField(parent, field, fieldType, readOnly, str);
        }

        public virtual void RenderField(Control parent, Editor.Field field, Item fieldType, bool readOnly,
            string value)
        {
            var hasRibbon = false;
            var text = string.Empty;
            var editor = GetEditor(fieldType);

            if (Arguments.ShowInputBoxes)
            {
                hasRibbon = !UserOptions.ContentEditor.ShowRawValues && fieldType.Children["Ribbon"] != null;
                var typeKey = field.TemplateField.TypeKey;

                if (typeKey == "rich text" || typeKey == "html")
                    hasRibbon = hasRibbon &&
                                UserOptions.HtmlEditor.ContentEditorMode != UserOptions.HtmlEditor.Mode.Preview;
            }

            var str1 = string.Empty;
            var str2 = string.Empty;
            var @int = Registry.GetInt("/Current_User/Content Editor/Field Size/" + field.TemplateField.ID.ToShortID(),
                -1);
            if (@int != -1)
            {
                str1 = $" height:{@int}px";
                var control = editor as Sitecore.Web.UI.HtmlControls.Control;

                if (control != null)
                {
                    control.Height = new Unit(@int, UnitType.Pixel);
                }
                else
                {
                    var webControl = editor as WebControl;

                    if (webControl != null)
                        webControl.Height = new Unit(@int, UnitType.Pixel);
                }
            }
            else if (editor is Frame)
            {
                var style = field.ItemField.Style;
                if (string.IsNullOrEmpty(style) || !style.ToLowerInvariant().Contains("height"))
                    str2 = " class='defaultFieldEditorsFrameContainer'";
            }
            else if (editor is MultilistEx)
            {
                var style = field.ItemField.Style;
                if (string.IsNullOrEmpty(style) || !style.ToLowerInvariant().Contains("height"))
                    str2 = " class='defaultFieldEditorsMultilistContainer'";
            }
            else
            {
                var typeKey = field.ItemField.TypeKey;
                if (!string.IsNullOrEmpty(typeKey) && typeKey.Equals("checkbox") &&
                    !UserOptions.ContentEditor.ShowRawValues)
                    str2 = "class='scCheckBox'";
            }

            AddLiteralControl(parent, "<div style='" + str1 + "' " + str2 + ">");
            AddLiteralControl(parent, text);
            AddEditorControl(parent, editor, field, hasRibbon, readOnly, value);
            AddLiteralControl(parent, "</div>");
            RenderResizable(parent, field);
        }

		public void RenderMarkerBegin(Control parent, string fieldControlID)
        {
            var text =
                "<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"scEditorFieldMarker\"><tr><td id=\"FieldMarker" +
                fieldControlID +
                "\" class=\"scEditorFieldMarkerBarCell\"><img src=\"/sitecore/images/blank.gif\" width=\"4px\" height=\"1px\" /></td><td class=\"scEditorFieldMarkerInputCell\">";

            AddLiteralControl(parent, text);
        }

        public void RenderMarkerEnd(Control parent)
        {
            AddLiteralControl(parent, "</td></tr></table>");
        }

        public virtual void RenderMenuButtons(Control parent, Editor.Field field, Item fieldType,
            bool readOnly)
        {
            if (!Arguments.ShowInputBoxes || UserOptions.ContentEditor.ShowRawValues)
                return;

            var menu = fieldType.Children["Menu"];

            if (menu == null || !menu.HasChildren)
                return;

            AddLiteralControl(parent, RenderMenuButtons(field, menu, readOnly));
        }

        public void RenderSection(Editor.Section section, Control parent, bool readOnly)
        {
            var sectionCollapsed = section.IsSectionCollapsed;
            var renderFields = !sectionCollapsed || UserOptions.ContentEditor.RenderCollapsedSections;

            RenderSectionBegin(parent, section.ControlID, section.Name, section.DisplayName, section.Icon,
                sectionCollapsed, renderFields);

            if (renderFields)
            {
                for (var index = 0; index < section.Fields.Count; ++index)
                    RenderField(parent, section.Fields[index], readOnly);
            }

            RenderSectionEnd(parent, renderFields, sectionCollapsed);
        }

        public void RenderSectionBegin(Control parent, string controlId, string sectionName,
            string displayName, string icon, bool isCollapsed, bool renderFields)
        {
            var htmlTextWriter = new HtmlTextWriter(new StringWriter(new StringBuilder(1024)));
            if (Arguments.ShowSections)
            {
                var str1 = isCollapsed ? "scEditorSectionCaptionCollapsed" : "scEditorSectionCaptionExpanded";
                var str2 = string.Empty;

                if (UserOptions.ContentEditor.RenderCollapsedSections)
                    str2 = "javascript:scContent.toggleSection('" + controlId + "','" + sectionName + "')";
                else
                    str2 = "javascript:return scForm.postRequest('','','','" +
                           StringUtil.EscapeQuote("ToggleSection(\"" + sectionName + "\",\"" + (isCollapsed ? "1" : "0") +
                                                  "\")") + "')";

                htmlTextWriter.Write("<div id=\"{0}\" class=\"{1}\" onclick=\"" + str2 + "\">", controlId, str1);

                var imageBuilder1 = new ImageBuilder
                {
                    ID = controlId + "_Glyph",
                    Src = isCollapsed ? "Images/accordion_down.png" : "Images/accordion_up.png",
                    Class = "scEditorSectionCaptionGlyph"
                };
                htmlTextWriter.Write(imageBuilder1.ToString());

                var imageBuilder2 = new ImageBuilder
                {
                    Src = Images.GetThemedImageSource(icon, ImageDimension.id16x16),
                    Class = "scEditorSectionCaptionIcon"
                };
                htmlTextWriter.Write(Translate.Text(displayName));
                htmlTextWriter.Write("</div>");
            }

            if (renderFields || !isCollapsed)
            {
                var str1 = !isCollapsed || !Arguments.ShowSections ? string.Empty : " style=\"display:none\"";
                var str2 = Arguments.ShowSections
                    ? "scEditorSectionPanelCell"
                    : "scEditorSectionPanelCell_NoSections";
                htmlTextWriter.Write("<table width=\"100%\" class=\"scEditorSectionPanel\"{0}><tr><td class=\"{1}\">",
                    str1, str2);
            }

            AddLiteralControl(parent, htmlTextWriter.InnerWriter.ToString());
        }

        public void RenderSectionEnd(Control parent, bool renderFields)
        {
            RenderSectionEnd(parent, renderFields, false);
        }

        public void RenderSectionEnd(Control parent, bool renderFields, bool isCollapsed)
        {
            if (!renderFields && isCollapsed)
                return;

            AddLiteralControl(parent, "</td></tr></table>");
        }

        public void RenderSections(Control parent, Editor.Sections sections, bool readOnly)
        {
            Context.ClientPage.ClientResponse.DisableOutput();
            AddLiteralControl(parent, "<div class=\"scEditorSections\">");

            for (var index = 0; index < sections.Count; ++index)
                RenderSection(sections[index], parent, readOnly);

            AddLiteralControl(parent, "</div>");
            Context.ClientPage.ClientResponse.EnableOutput();
        }

        public void SetValue(Control editor, string value)
        {
            if (editor is IStreamedContentField)
                return;

            var contentField = editor as IContentField;

            if (contentField != null)
                contentField.SetValue(value);
            else
                ReflectionUtil.SetProperty(editor, "Value", value);
        }

        private string RenderMenuButtons(Editor.Field field, Item menu, bool readOnly)
        {
            var htmlTextWriter = new HtmlTextWriter(new StringWriter());
            htmlTextWriter.Write("<div class=\"scContentButtons\">");
            var flag1 = true;

            foreach (Item button in menu.Children)
            {
                if (!IsFieldEditor || MainUtil.GetBool(button["Show In Field Editor"], false))
                {
                    var str1 = button["Message"];
                    var flag2 = false;
                    var flag3 = false;
                    var command = CommandManager.GetCommand(str1);
                    if (command != null)
                    {
                        var commandState = CommandManager.QueryState(command,
                            new CommandContext(Arguments.Item));
                        flag2 = commandState == CommandState.Hidden;
                        flag3 = commandState == CommandState.Disabled;
                    }
                    if (!flag2)
                    {
                        if (!flag1)
                            htmlTextWriter.Write("");
                        flag1 = false;
                        var str2 = Context.ClientPage.GetClientEvent(str1).Replace("$Target", field.ControlID);
                        if (readOnly || DisableAssignSecurityButton(button) || flag3)
                        {
                            htmlTextWriter.Write("<span class=\"scContentButtonDisabled\">");
                            htmlTextWriter.Write(button["Display Name"]);
                            htmlTextWriter.Write("</span>");
                        }
                        else
                        {
                            htmlTextWriter.Write("<a href=\"#\" class=\"scContentButton\" onclick=\"" + str2 + "\">");
                            htmlTextWriter.Write(button["Display Name"]);
                            htmlTextWriter.Write("</a>");
                        }
                    }
                }
            }

            htmlTextWriter.Write("</div>");
            return htmlTextWriter.InnerWriter.ToString();
        }

        private void RenderResizable(Control parent, Editor.Field field)
        {
            var type = field.TemplateField.Type;
            if (string.IsNullOrEmpty(type))
                return;

            var fieldType = FieldTypeManager.GetFieldType(type);
            if (fieldType == null || !fieldType.Resizable)
                return;

            var text1 =
                "<div style=\"cursor:row-resize; position: relative; height: 5px; width: 100%; top: 0px; left: 0px;\" onmousedown=\"scContent.fieldResizeDown(this, event)\" onmousemove=\"scContent.fieldResizeMove(this, event)\" onmouseup=\"scContent.fieldResizeUp(this, event, '" +
                field.TemplateField.ID.ToShortID() + "')\">" + Images.GetSpacer(1, 4) + "</div>";
            AddLiteralControl(parent, text1);
            var text2 = "<div class style=\"display:none\" \">" + Images.GetSpacer(1, 4) + "</div>";
            AddLiteralControl(parent, text2);
        }

        private bool DisableAssignSecurityButton(Item button)
        {
            var flag = button.ID == FieldButtonIDs.AssignSecurity &&
                       (!SecurityHelper.CanRunApplication("Content Editor/Ribbons/Chunks/Security/Assign") ||
                        !SecurityHelper.CanRunApplication("Security/Item Security Editor"));

            return flag;
        }
		#endregion
	}
}