// Code to Eric Stafford - http://www.paragon-inc.com/resources/blogs-posts/sitecore_view_renderings_implementing_views_for_the_experience_editor

using System.Text.RegularExpressions;
using Sitecore.Mvc.Presentation;
using Sitecore.Mvc.Pipelines.Response.GetRenderer;

namespace Ignition.Core.Mvc.ViewEngines
{
    public class GetViewRenderer : Sitecore.Mvc.Pipelines.Response.GetRenderer.GetViewRenderer
    {
        public override void Process(GetRendererArgs args)
        {
            if (args.Result != null)
                return;

            args.Result = this.GetRenderer(args.Rendering, args);
        }

        protected override Renderer GetRenderer(Rendering rendering, GetRendererArgs args)
        {
            var viewPath = this.GetViewPath(rendering, args);

            if (string.IsNullOrWhiteSpace(viewPath))
                return null;

            if (Sitecore.Context.PageMode.IsExperienceEditorEditing)
            {
                var eeViewPath = Regex.Replace(viewPath, @"^(.*)\.cshtml$", "$1_EE.cshtml");
                viewPath = System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(eeViewPath)) ? eeViewPath : viewPath;
            }

            return new ViewRenderer
            {
                ViewPath = viewPath,
                Rendering = rendering
            };
        }
    }
}
