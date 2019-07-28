using System;

namespace ChangeLoadingImage.OptionsFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ButtonAttribute : AbstractOptionsAttribute
    {
        public ButtonAttribute(string description, string group, Type actionClass = null, string actionMethod = null) :
            base(description, group, actionClass, actionMethod)
        {

        }
    }
}