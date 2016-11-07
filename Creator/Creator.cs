using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using Attributes;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Creator
{
    public static class Creator
    {
        //public static IEnumerable<AdvancedUser> Create()
        //{
        //    var list = new List<AdvancedUser>();
        //    var assy = typeof(Creator).Assembly;
        //    var attrs = (InstantiateAdvancedUserAttribute[])Attribute.GetCustomAttributes(assy, typeof(InstantiateAdvancedUserAttribute));

        //    foreach (var attr in attrs)
        //    {
        //        int id;
        //        if (ReferenceEquals(attr.Id, null))
        //        {
        //            id = GetDefault(typeof(User));
        //        }
        //        else
        //        {
        //            id = attr.Id.Value;
        //        }

        //        var user = new AdvancedUser(id, attr.ExternalId) { FirstName = attr.FirstName, LastName = attr.LastName };
        //        list.Add(user);
        //    }
            
        //    return list;
        //}

        public static IEnumerable<User> CreateUsers()
        {
            var attrs = (InstantiateUserAttribute[])typeof(User).GetCustomAttributes(typeof(InstantiateUserAttribute), false);
            var list = new List<User>();

            foreach (var attr in attrs)
            {
                Type[] t = {typeof(int)};
                var matchAttr = (MatchParameterWithPropertyAttribute)typeof(User).GetConstructor(t).GetCustomAttribute(typeof(MatchParameterWithPropertyAttribute), false);
                
                var attributesOfId = TypeDescriptor.GetProperties(typeof(User))[matchAttr.PropertyName].Attributes;
                var  defaultValueAttribute = (DefaultValueAttribute)attributesOfId[typeof(DefaultValueAttribute)];

                var user = new User( !ReferenceEquals(attr.Id, null) ? attr.Id.Value : (int)defaultValueAttribute.Value) { FirstName = attr.FirstName, LastName = attr.LastName };
                list.Add(user);
            }

            return list;
        }
    }
}
