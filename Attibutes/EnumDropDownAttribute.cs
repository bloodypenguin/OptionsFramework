using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DlcFlags.OptionsFramework.Attibutes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EnumDropDownAttribute : DropDownAttribute
    {
        public EnumDropDownAttribute(string description, Type itemsClass, string group = null, Type actionClass = null,
            string actionMethod = null) : base(description, group, actionClass, actionMethod)
        {
            ItemsClass = itemsClass;
        }

        public IList<DropDownEntry<int>> GetItems(Func<string, string> translator = null)
        {
            var type = ItemsClass;
            var enumValues = Enum.GetValues(type);
            return (from object enumValue in enumValues
                let code = (int) enumValue
                let memInfo = type.GetMember(Enum.GetName(type, enumValue))
                let attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false)
                let description = ((DescriptionAttribute) attributes[0]).Description
                let translatedDesctiption = translator == null ? description : translator.Invoke(description)
                select new DropDownEntry<int>(code, translatedDesctiption)).ToArray();
        }

        private Type ItemsClass { get; }
    }
}