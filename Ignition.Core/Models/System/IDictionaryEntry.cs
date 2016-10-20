using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.System
{
    public interface IDictionaryEntry : IModelBase
    {
        string Key { get; set; }
        string Phrase { get; set; }
    }
}