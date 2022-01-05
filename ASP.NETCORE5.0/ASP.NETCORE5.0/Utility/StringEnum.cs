using System;

namespace ASP.NETCORE5._0.Utility
{
    public static class StringEnum
    {
        /// <summary>
        /// Gets the string value.
        /// </summary>
        /// <param name="thisEnum">The value.</param>
        /// <returns></returns>
        public static string ToValue(this Enum thisEnum)
        {
            string output = null;
            var type = thisEnum.GetType();
            //
            // Check first in our cached results...
            // Look for our 'StringValueAttribute' in the field's custom attributes
            var fi = type.GetField(thisEnum.ToString());
            var attrs = fi.GetCustomAttributes(typeof(StringValue), false) as StringValue[];
            if (attrs != null && attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }
        public class StringValue : Attribute
        {
            public StringValue(string value)
            {
                Value = value;
            }

            /// <summary>
            /// Gets the value.
            /// </summary>
            /// <value>
            /// The value.
            /// </value>
            public string Value { get; }
        }
    }
}