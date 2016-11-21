using System;
using System.IO;
using System.Web.Mvc;

namespace Ignition.Foundation.Core.ComponentBlock
{
    public class ComponentBlock : IDisposable
    {
        private readonly TextWriter _writer;
        private readonly string _componentName;
        public ComponentBlock(ViewContext viewContext, string componentName)
        {
            _componentName = componentName;
            _writer = viewContext.Writer;
        }

        public void Dispose()
        {
            _writer.Write("</div>\n");
#if DEBUG
            _writer.Write("<!-- End {0} -->", _componentName);
#endif
        }
    }
}
