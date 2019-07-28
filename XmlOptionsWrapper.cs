using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ChangeLoadingImage.OptionsFramework.Attributes;
using ColossalFramework.IO;
using UnityEngine;

namespace ChangeLoadingImage.OptionsFramework
{
    public class XmlOptionsWrapper<T> : IOptionsWrapper<T>
    {
        private T _options;

        public static XmlOptionsWrapper<T> Instance { get; } = new XmlOptionsWrapper<T>();

        public static T Options => Instance.GetOptions();
        
        public T GetOptions()
        {
            try
            {
                Ensure();
            }
            catch (XmlException e)
            {
                UnityEngine.Debug.LogError("Error reading options XML file");
                UnityEngine.Debug.LogException(e);
            }
            return _options;
        }

        public void SaveOptions()
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                using (var streamWriter = new StreamWriter(GetFileName()))
                {
                    xmlSerializer.Serialize(streamWriter, _options);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private XmlOptionsWrapper()
        {
            
        }
        
        private void Ensure()
        {
            if (_options != null)
            {
                return;
            }
            var type = typeof(T);
            var attrs = type.GetCustomAttributes(typeof(XmlOptionsAttribute), false);
            if (attrs.Length != 1)
            {
                throw new Exception($"Type {type.FullName} is not an options type!");
            }
            _options = (T)Activator.CreateInstance(typeof(T));
            LoadOptions();
        }

        private void LoadOptions()
        {
            try
            {
                if (GetLegacyFileName() != string.Empty)
                {
                    try
                    {
                        ReadOptionsFile(GetLegacyFileName());
                        try
                        {
                            File.Delete(GetLegacyFileName());
                        }
                        catch (Exception e)
                        {
                            UnityEngine.Debug.LogException(e);
                        }
                        SaveOptions();
                    }
                    catch (FileNotFoundException)
                    {
                        ReadOptionsFile(GetFileName());
                    }
                }
                else
                {
                    ReadOptionsFile(GetFileName());
                }
            }
            catch (FileNotFoundException)
            {
                SaveOptions();// No options file yet
            }
        }

        private void ReadOptionsFile(string fileName)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var streamReader = new StreamReader(fileName))
            {
                var options = (T) xmlSerializer.Deserialize(streamReader);
                foreach (var propertyInfo in typeof(T).GetProperties())
                {
                    if (!propertyInfo.CanWrite)
                    {
                        continue;
                    }
                    var value = propertyInfo.GetValue(options, null);
                    propertyInfo.SetValue(_options, value, null);
                }
            }
        }

        private string GetFileName()
        {
            var type = _options.GetType();
            var attrs = type.GetCustomAttributes(typeof(XmlOptionsAttribute), false);
            var fileName = Path.Combine(DataLocation.localApplicationData, ((XmlOptionsAttribute) attrs[0]).FileName);
            if (!fileName.EndsWith(".xml"))
            {
                fileName = fileName + ".xml";
            }
            return fileName;
        }

        private string GetLegacyFileName()
        {
            var type = _options.GetType();
            var attrs = type.GetCustomAttributes(typeof(XmlOptionsAttribute), false);
            var fileName =  ((XmlOptionsAttribute)attrs[0]).LegacyFileName;
            if (fileName == string.Empty)
            {
                return fileName;
            }
            if (!fileName.EndsWith(".xml"))
            {
                fileName = fileName + ".xml";
            }
            return fileName;
        }
    }
}