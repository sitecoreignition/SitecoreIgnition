using Sitecore.Diagnostics;
using Sitecore.Shell.Applications.ContentEditor.Pipelines.RenderContentEditor;

namespace Ignition.Foundation.Infrastructure.Pipelines
{
    public class FieldnameRewriter 
    {
        public void Process(RenderContentEditorArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            var editorFormatter = new EditorFormatter(args);
            editorFormatter.RenderSections(args.Parent, args.Sections, args.ReadOnly);
        }
    }
}