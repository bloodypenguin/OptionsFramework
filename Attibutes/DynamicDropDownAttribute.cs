using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace SkyboxReplacer.OptionsFramework.Attibutes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DynamicDropDownAttribute : DropDownAttribute
    {
        public DynamicDropDownAttribute(string description, string populatorClass, string populatorMethod, string group = null, string actionClass = null, string actionMethod = null) :
            base(description, group, actionClass, actionMethod)
        {
            this.Populator = () =>
            {
                var method = Util.FindType(populatorClass).GetMethod(populatorMethod, BindingFlags.Public | BindingFlags.Static);
                return (List<DropDownEntry<string>>)method.Invoke(null, new object[] { });
            };
        }

        public IList<DropDownEntry<string>> GetItems(Func<string, string> translator = null)
        {
            var entries = Populator.Invoke();
            return (from DropDownEntry<string> entry in entries
                    let code = entry.Code
                    let description = entry.Description
                    let translatedDesctiption = translator == null ? description : translator.Invoke(description)
                    select new DropDownEntry<string>(code, translatedDesctiption)).ToList();
        }

        private Func<List<DropDownEntry<string>>> Populator { get; }
    }
}