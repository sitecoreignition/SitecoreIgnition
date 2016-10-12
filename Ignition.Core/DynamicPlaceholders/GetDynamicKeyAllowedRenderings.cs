//Code credit to Stack Overflow user Dunston - http://stackoverflow.com/questions/15134720/sitecore-dynamic-placeholders-with-mvc

using System.Collections.Generic;
using System.Text.RegularExpressions;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.GetPlaceholderRenderings;

namespace Ignition.Foundation.Core.DynamicPlaceholders
{
    public class GetDynamicKeyAllowedRenderings : GetAllowedRenderings
    {
        //text that ends in a GUID
        private const string DynamicKeyRegex = @"(.+)_[\d\w]{8}\-([\d\w]{4}\-){3}[\d\w]{12}";

        public new void Process(GetPlaceholderRenderingsArgs args)
        {
            Assert.IsNotNull(args, "args");

            var placeholderKey = args.PlaceholderKey;
            var regex = new Regex(DynamicKeyRegex);
            Match match = regex.Match(placeholderKey);
            if (match.Success && match.Groups.Count > 0)
            {
                placeholderKey = match.Groups[1].Value;
            }
            else
            {
                return;
            }
            // Same as Sitecore.Pipelines.GetPlaceholderRenderings.GetAllowedRenderings but with fake placeholderKey
            Item placeholderItem;
            if (ID.IsNullOrEmpty(args.DeviceId))
            {
                placeholderItem = Client.Page.GetPlaceholderItem(placeholderKey, args.ContentDatabase,
                                                                 args.LayoutDefinition);
            }
            else
            {
                using (new DeviceSwitcher(args.DeviceId, args.ContentDatabase))
                {
                    placeholderItem = Client.Page.GetPlaceholderItem(placeholderKey, args.ContentDatabase,
                                                                     args.LayoutDefinition);
                }
            }
            List<Item> collection = null;
            if (placeholderItem != null)
            {
                bool flag;
                args.HasPlaceholderSettings = true;
                collection = this.GetRenderings(placeholderItem, out flag);
                if (flag)
                {
                    args.CustomData["allowedControlsSpecified"] = true;
                    args.Options.ShowTree = false;
                }
            }
            if (collection == null) return;
            if (args.PlaceholderRenderings == null)
            {
                args.PlaceholderRenderings = new List<Item>();
            }
            args.PlaceholderRenderings.AddRange(collection);
        }
    }
}
