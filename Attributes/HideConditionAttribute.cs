using System;

namespace TouristTaxiBooster.OptionsFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class HideConditionAttribute : Attribute
    {
        public abstract bool IsHidden();
    }
}