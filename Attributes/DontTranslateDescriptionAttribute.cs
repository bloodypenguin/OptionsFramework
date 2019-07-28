using System;
using System.ComponentModel;

namespace ChangeLoadingImage.OptionsFramework.Attributes
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