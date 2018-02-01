using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace VictorBu.Tool.Class
{
    public static class ObjectExtension
    {
        /// <summary>
        /// 将类 A 的实例转换为类 B 的实例
        /// https://stackoverflow.com/questions/3672742/cast-class-into-another-class-or-convert-class-to-another
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myobj"></param>
        /// <returns></returns>
        public static T Cast<T>(this Object myobj)
        {
            Type target = typeof(T);
            var x = Activator.CreateInstance(target, false);
            var d = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                value = myobj.GetType().GetProperty(memberInfo.Name).GetValue(myobj, null);

                propertyInfo.SetValue(x, value, null);
            }
            return (T)x;
        }

        /// <summary>
        /// 为属性设置非空的默认值
        /// http://blog.csdn.net/yl2isoft/article/details/53169055
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public static void SetDefaultToProperties<T>(T obj)
        {
            Type type = typeof(T);
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo property in props)
            {
                if (property.CanWrite)
                {
                    Type propertyType = property.PropertyType;
                    if (propertyType.Name == "String")
                    {
                        property.SetValue(obj, string.Empty, null);
                    }
                    //else
                    //{
                    //    object value = propertyType.IsValueType ? Activator.CreateInstance(propertyType) : null;
                    //    property.SetValue(obj, value, null);
                    //}
                }
            }
        }
    }
}
