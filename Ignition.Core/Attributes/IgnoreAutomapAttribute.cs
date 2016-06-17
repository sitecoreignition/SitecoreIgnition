using System;

namespace Ignition.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Interface)]
    public class IgnoreAutomapAttribute : Attribute
    {
    }
}
