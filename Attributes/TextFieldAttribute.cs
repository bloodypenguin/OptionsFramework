using System;

namespace ChangeLoadingImage.OptionsFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TextfieldAttribute : AbstractOptionsAttribute
    {
        public TextfieldAttribute(string description, string group = null, Type actionClass = null,
            string actionMethod = null) : base(description, group, actionClass, actionMethod)
        {
        }
    }
}