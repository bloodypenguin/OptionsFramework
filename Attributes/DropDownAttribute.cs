﻿using System;
using System.Collections.Generic;
using ColossalFramework;

namespace TouristTaxiBooster.OptionsFramework.Attributes
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