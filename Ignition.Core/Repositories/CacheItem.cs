using System;
using Ignition.Core.Models.BaseModels;

namespace Ignition.Core.Repositories
{
    public class CacheItem
    {
        public string Key { get; set; }
        public IModelBase Item { get; set; }
        public Type FinalType { get; set; }

        public CacheItem(string key, IModelBase item, Type finalType)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (finalType == null) throw new ArgumentNullException(nameof(finalType));
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("Argument is null or empty", nameof(key));
            Key = key;
            Item = item;
            FinalType = finalType;
        }
    }
}