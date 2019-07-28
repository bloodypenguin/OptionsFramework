using System;

namespace ChangeLoadingImage.OptionsFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class HideConditionAttribute : Attribute
    {
        public abstract bool IsHidden();
    }
}