using Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Validators
{
    public static class Validator
    {
        public static bool IntValidator(User user)
        {
            var fields = new List<FieldInfo>();

            foreach (var item in typeof(User).GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                var attr = (IntValidatorAttribute)item.GetCustomAttribute(typeof(IntValidatorAttribute));

                if (!ReferenceEquals(attr, null))
                {
                    if ((int)item.GetValue(user) > attr.Max || (int)item.GetValue(user) < attr.Min)
                    {
                        return false;
                    }
                }
            }

            var properties = new List<PropertyInfo>();

            foreach (var item in typeof(User).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var attr = (IntValidatorAttribute)item.GetCustomAttribute(typeof(IntValidatorAttribute));

                if (!ReferenceEquals(attr, null))
                {
                    if ((int)item.GetValue(user) > attr.Max || (int)item.GetValue(user) < attr.Min)
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }

        public static bool StringValidator(User user)
        {
            var fields = new List<FieldInfo>();

            foreach (var item in typeof(User).GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                var attr = (StringValidatorAttribute)item.GetCustomAttribute(typeof(StringValidatorAttribute));

                if (!ReferenceEquals(attr, null))
                {
                    if (((string)item.GetValue(user)).Length > attr.Length)
                    {
                        return false;
                    }
                }
            }
            
            var properties = new List<PropertyInfo>();

            foreach (var item in typeof(User).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var attr = (StringValidatorAttribute)item.GetCustomAttribute(typeof(StringValidatorAttribute));

                if (!ReferenceEquals(attr, null))
                {
                    if (((string)item.GetValue(user)).Length > attr.Length)
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }
    }
}
