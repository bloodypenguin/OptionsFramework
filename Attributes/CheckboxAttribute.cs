using System;

namespace ChangeLoadingImage.OptionsFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckboxAttribute : AbstractOptionsAttribute
    {

        public CheckboxAttribute(string description, string group = null, Type actionClass = null, string actionMethod = null) : 
            base(description, group, actionClass, actionMethod)
        {
        }
    }
}