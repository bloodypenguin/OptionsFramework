using System;

namespace OptionsFramework.Attibutes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class XmlOptionsAttribute : Attribute
    {
        public XmlOptionsAttribute(string fileName, string legacyFileName = "")
        {
            FileName = fileName;
            LegacyFileName = legacyFileName;
        }

        //file name in local app data
        public string FileName { get; }

        //file name in Cities: Skylines folder
        public string LegacyFileName { get; }
    }
}