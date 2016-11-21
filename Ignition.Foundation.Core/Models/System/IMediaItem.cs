using System;

namespace Ignition.Foundation.Core.Models.System
{
    public interface IMediaItem : IFile
    {
        string Alt { get; set; }
        string Width { get; set; }
        string Height { get; set; }
        string Dimensions { get; set; }
		string MediaUrl { get; set; }
    }
}
