using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GBinanceFuturesClient.Inside
{
    internal class ObjectToQueryConverter
    {
        string name;
        object value;

        StringBuilder queryStringBuilder = new StringBuilder();
        object[] attributes;
        List<PropertyInfo> props;

        internal static string Convert(object obj)
        {
            ObjectToQueryConverter converter = new ObjectToQueryConverter();
            return converter.Run(obj);
        }

        internal static string DictionaryConvert(Dictionary<string, string> dictionary)
        {
            StringBuilder sb = new StringBuilder();
            int count = dictionary.Count;

            foreach(KeyValuePair<string, string> pair in dictionary)
            {
                sb.Append(pair.Key + "=" + pair.Value);

                count--;
                if (count > 0)
                    sb.Append("&");
            }

            return sb.ToString();
        }

        string Run(object obj)
        {
            Inicjalize(obj);

            foreach (PropertyInfo prop in props)
            {
                name = prop.Name;
                value = prop.GetValue(obj, null);

                if (value == null)
                    continue;

                bool write = CheckToWrite(prop);

                if (write)
                    WriteQueryProperty();
            }

            return BuildResult();
        }

        void Inicjalize(object obj)
        {
            Type objType = obj.GetType();
            props = objType.GetProperties().ToList();
        }

        bool CheckToWrite(PropertyInfo prop)
        {
            attributes = prop.GetCustomAttributes(true);
            foreach (object attribute in attributes)
            {
                if (attribute.GetType() == typeof(DefaultValueAttribute))
                    return DefaultValueAttributeChecker(attribute);
            }

            return true;
        }

        void WriteQueryProperty()
        {
            string propName = Char.ToLowerInvariant(name[0]) + name.Substring(1);
            queryStringBuilder.AppendFormat("{0}={1}", propName, value);

            queryStringBuilder.Append("&");
        }

        bool DefaultValueAttributeChecker(object attribute)
        {
            DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)attribute;
            if (defaultValueAttribute.useDefault)
            {
                if (value.GetType().IsValueType)
                {
                    object defaultValue = Activator.CreateInstance(value.GetType());
                    if (value.Equals(defaultValue))
                        return false;
                }
            }
            else
            {
                var valueToTest = Cast(defaultValueAttribute.value, value.GetType());
                if (value.Equals(valueToTest))
                {
                    return false;
                }
            }

            return true;
        }

        string BuildResult()
        {
            queryStringBuilder.Remove(queryStringBuilder.Length - 1, 1);    // Remove last &
            queryStringBuilder.Replace(',', '.');   // Replace "," char in decimal to "."
            return queryStringBuilder.ToString();
        }

        static dynamic Cast(dynamic obj, Type castTo)
        {
            return System.Convert.ChangeType(obj, castTo);
        }
    }
}
