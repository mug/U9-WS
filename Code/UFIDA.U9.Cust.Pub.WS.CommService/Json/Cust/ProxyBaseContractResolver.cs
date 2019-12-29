using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UFIDA.U9.Cust.Pub.WS.CommService.Json.Serialization;
using UFIDA.U9.Cust.Pub.WS.CommService.Json.Utilities;
using UFSoft.UBF.Business;
using UFSoft.UBF.Service.Base;

namespace UFIDA.U9.Cust.Pub.WS.CommService.Json.Cust
{
    public class ProxyBaseContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var ignoreSerializableAttribute = this.IgnoreSerializableAttribute;
            var objectMemberSerialization = JsonTypeReflector.GetObjectMemberSerialization(objectType,
                ignoreSerializableAttribute);
            var allMembers = (
                from m in
                    ReflectionUtils.GetFieldsAndProperties(objectType,
                        BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                where
                    !ReflectionUtils.IsIndexedProperty(m)
                select m).ToList();
            var serializableMembers = new List<MemberInfo>();
            if (objectMemberSerialization != MemberSerialization.Fields)
            {
                var dataContractAttribute = JsonTypeReflector.GetDataContractAttribute(objectType);
                var defaultMembers = (
                    from m in ReflectionUtils.GetFieldsAndProperties(objectType, this.DefaultMembersSearchFlags)
                    where
                        !ReflectionUtils.IsIndexedProperty(m)
                    select m).ToList();
                foreach (var current in allMembers)
                {
                    //DataTransObjectBase
                    if (current.DeclaringType == typeof (DataTransObjectBase))
                    {
                        continue;
                    }
                    //contextdto
                    if (current.DeclaringType != null && current.DeclaringType.IsSubclassOf(typeof(ProxyBase)))
                    {
                        var memberName = current.Name.ToLower(CultureInfo.CurrentCulture);
                        if (memberName == "contextdto") continue;
                    }
                    var isDTOType = false;
                    switch (current.MemberType())
                    {
                        case MemberTypes.Field:
                            var fieldInfo = (FieldInfo) current;
                            if (fieldInfo.DeclaringType != null &&
                                fieldInfo.FieldType.IsSubclassOf(typeof (DataTransObjectBase)))
                            {
                                isDTOType = true;
                            }
                            break;
                        case MemberTypes.Property:
                            var propertyInfo = (PropertyInfo) current;
                            if (propertyInfo.DeclaringType != null &&
                                propertyInfo.DeclaringType.IsSubclassOf(typeof (DataTransObjectBase)))
                            {
                                isDTOType = true;
                            }
                            break;
                    }
                    if (isDTOType)
                    {
                        var memberName = current.Name.ToLower(CultureInfo.CurrentCulture);
                        if (memberName == "combinename" || memberName.StartsWith("multi_")) continue;
                    }
                    if (!ReflectionUtils.CanSetMemberValue(current, true, true))
                        continue;
                    if (this.SerializeCompilerGeneratedMembers ||
                        !current.IsDefined(typeof (CompilerGeneratedAttribute), true))
                    {
                        if (defaultMembers.Contains(current))
                        {
                            serializableMembers.Add(current);
                        }
                        else
                        {
                            if (JsonTypeReflector.GetAttribute<JsonPropertyAttribute>(current) != null)
                            {
                                serializableMembers.Add(current);
                            }
                            else
                            {
                                if (dataContractAttribute != null &&
                                    JsonTypeReflector.GetAttribute<DataMemberAttribute>(current) != null)
                                {
                                    serializableMembers.Add(current);
                                }
                                else
                                {
                                    if (objectMemberSerialization == MemberSerialization.Fields &&
                                        current.MemberType() == MemberTypes.Field)
                                    {
                                        serializableMembers.Add(current);
                                    }
                                }
                            }
                        }
                    }
                }
                Type type;
                if (objectType.AssignableToTypeName("System.Data.Objects.DataClasses.EntityObject", out type))
                {
                    serializableMembers = serializableMembers.Where(this.ShouldSerializeEntityMember).ToList();
                }
            }
            else
            {
                foreach (var current2 in allMembers)
                {
                    var fieldInfo = current2 as FieldInfo;
                    if (fieldInfo != null && !fieldInfo.IsStatic)
                    {
                        var memberName = fieldInfo.Name.ToLower(CultureInfo.CurrentCulture);
                        if (memberName == "sysstate" || memberName.StartsWith("multi_")) continue;
                        serializableMembers.Add(current2);
                    }
                }
            }
            return serializableMembers;
        }

        public override JsonContract ResolveContract(Type type)
        {
            var contract = base.ResolveContract(type);
            contract.IsReference = false;
            return contract;
        }
    }
}