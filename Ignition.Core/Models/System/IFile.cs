using System.IO;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.System
{
    public interface IFile : IModelBase
    {
        string MimeType { get; set; }
        string Icon { get; set; }
        Stream Blob { get; set; }
        string Extension { get; set; }
        int Size { get; set; }
    }
}
