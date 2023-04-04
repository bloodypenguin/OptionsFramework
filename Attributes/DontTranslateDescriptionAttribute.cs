using System;
using System.ComponentModel;

namespace TouristTaxiBooster.OptionsFramework.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class DontTranslateDescriptionAttribute : DescriptionAttribute
    {
        public DontTranslateDescriptionAttribute(string description) :
            base(description)
        {
            
        }
    }
}