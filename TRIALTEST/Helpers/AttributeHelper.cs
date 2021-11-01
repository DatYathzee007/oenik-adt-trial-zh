using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRIALTEST.Attributes;

namespace TRIALTEST.Helpers
{
    /*
     * a)	Create a Helper class called AttributeHelper that can return the display name of a property. (4 points)
     * Help: GetPropertyDisplayName<T>(string propertyName), where T is the class whose property you want to express,
     * propertyName is the name of the property whose DisplayName attribute you want to display.

     * */
    public static class AttributeHelper
    {
        public static string GetPropertyDisplayName<T>(string propertyName)
        {
            var propinfo = typeof(T).GetProperty(propertyName);
            var attribute = (DisplayNameAttribute)propinfo.GetCustomAttributes(typeof(DisplayNameAttribute), false).SingleOrDefault();
            return attribute?.name ?? propertyName;
        }

    }
}
