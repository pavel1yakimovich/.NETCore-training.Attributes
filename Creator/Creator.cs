using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Attributes;

namespace Creator
{
    public static class Creator
    {
        public static IEnumerable<AdvancedUser> CreateAdvancedUsers()
        {
            var list = new List<AdvancedUser>();
            var assy = typeof(User).Assembly;
            var instanciateAttrs = (InstantiateAdvancedUserAttribute[])Attribute.GetCustomAttributes(assy, typeof(InstantiateAdvancedUserAttribute));

            Type[] t = { typeof(int), typeof(int) };
            var matchAttr = (MatchParameterWithPropertyAttribute[])typeof(AdvancedUser).GetConstructor(t).GetCustomAttributes(typeof(MatchParameterWithPropertyAttribute), false);

            var defValAttrId = (DefaultValueAttribute)typeof(AdvancedUser).GetProperty(matchAttr.First(a => a.ParameterName == "id").PropertyName).GetCustomAttribute(typeof(DefaultValueAttribute));
            var defaultValueId = (int)defValAttrId.Value;

            var defValAttrExtId = (DefaultValueAttribute)typeof(AdvancedUser).GetProperty(matchAttr.First(a => a.ParameterName == "externalId").PropertyName).GetCustomAttribute(typeof(DefaultValueAttribute));
            var defaultValueExternalId = (int)defValAttrExtId.Value;

            foreach (var attr in instanciateAttrs)
            {
                int id = ReferenceEquals(attr.Id, null) ? defaultValueId : attr.Id.Value;
                int externalId = ReferenceEquals(attr.ExternalId, null) ? defaultValueExternalId : attr.ExternalId.Value;

                var user = new AdvancedUser(id, externalId) { FirstName = attr.FirstName, LastName = attr.LastName };
                list.Add(user);
            }

            return list;
        }

        public static IEnumerable<User> CreateUsers()
        {
            var attrs = (InstantiateUserAttribute[])typeof(User).GetCustomAttributes(typeof(InstantiateUserAttribute), false);
            var list = new List<User>();

            Type[] t = { typeof(int) };
            var matchAttr = (MatchParameterWithPropertyAttribute)typeof(User).GetConstructor(t).GetCustomAttribute(typeof(MatchParameterWithPropertyAttribute), false);

            var defValAttrId = (DefaultValueAttribute)typeof(User).GetProperty(matchAttr.PropertyName).GetCustomAttribute(typeof(DefaultValueAttribute));
            var defaultValueId = (int)defValAttrId.Value;
            
            foreach (var attr in attrs)
            {
                var id = ReferenceEquals(attr.Id, null) ? defaultValueId : attr.Id.Value;

                var user = new User(id) { FirstName = attr.FirstName, LastName = attr.LastName };
                list.Add(user);
            }

            return list;
        }
    }
}
