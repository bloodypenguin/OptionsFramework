using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TouristTaxiBooster.OptionsFramework.Attributes;

namespace TouristTaxiBooster.OptionsFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EnumDropDownAttribute : DropDownAttribute
    {
        public EnumDropDownAttribute(string description, string itemsClass, string group = null, string actionClass = null,
            string actionMethod = null) : base(description, group, actionClass, actionMethod)
        {
            ItemsClass = itemsClass;
        }

        public IList<DropDownEntry<int>> GetItems(Func<string, string> translator = null)
        {
            var type = Util.FindType(ItemsClass);
            var enumValues = Enum.GetValues(type);
            return (from object enumValue in enumValues
                let code = (int) enumValue
                let memInfo = type.GetMember(Enum.GetName(type, enumValue))
                let attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false)
                let description = ((DescriptionAttribute) attributes[0]).Description
                let translatedDesctiption = translator == null ? description : translator.Invoke(description)
                select new DropDownEntry<int>(code, translatedDesctiption)).ToArray();
        }

        private string ItemsClass { get; }
    }
}