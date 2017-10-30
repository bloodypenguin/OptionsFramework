using System;

namespace SkyboxReplacer.OptionsFramework.Attibutes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class HideConditionAttribute : Attribute
    {
        public abstract bool IsHidden();
    }
}