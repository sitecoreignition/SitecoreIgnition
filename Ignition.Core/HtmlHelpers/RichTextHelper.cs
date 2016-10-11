using System.Text.RegularExpressions;

namespace Ignition.Foundation.Core.HtmlHelpers
{
    public static class RichTextHelper
    {
        public static string RichTextWithoutDoublePTags(this string content)
        {
            return new Regex(@"^<p>(.*)</p>$").Replace(content, "$1");
        }
    }
}
