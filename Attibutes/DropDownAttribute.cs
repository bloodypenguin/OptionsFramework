using System;
using System.Collections.Generic;
using ColossalFramework;

namespace TreeUnlimiter.OptionsFramework.Attibutes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class DropDownAttribute : AbstractOptionsAttribute
    {
        protected DropDownAttribute(string description, string group, string actionClass, string actionMethod) : base(
            description, group, actionClass, actionMethod)
        {
        }
    }
}