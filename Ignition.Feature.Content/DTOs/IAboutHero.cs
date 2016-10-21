using System.Collections.Generic;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.Content.DTOs
{
    public interface IAboutHero : IHeading, IImage, ICopy1
    {
        IEnumerable<ILinkedImage> LogoImages { get; set; }
    }
}