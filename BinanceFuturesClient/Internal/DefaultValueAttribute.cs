using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Inside
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class DefaultValueAttribute: Attribute
    {
        internal object value;
        internal bool useDefault = false;

        internal DefaultValueAttribute(object defaultValue)
        {
            value = defaultValue;
        }

        internal DefaultValueAttribute()
        {
            useDefault = true;
        }
    }
}
