using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UFIDA.U9.Cust.Pub.WS.Json;
using UFIDA.U9.Cust.Pub.WS.Json.Serialization;
using UFIDA.U9.Cust.Pub.WS.Json.Utilities;
using UFSoft.UBF.Business;
using UFSoft.UBF.Service.Base;

namespace UFIDA.U9.Cust.Pub.WS.ProxyService.Json
{
    public class ProxyBaseContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            bool ignoreSerializableAttribute = this.IgnoreSerializableAttribute;
            MemberSerialization objectMemberSerialization = JsonTypeReflector.GetObjectMemberSerialization(objectType,
                ignoreSerializableAttribute);
            List<MemberInfo> allMembers = (
                from m in
                    ReflectionUtils.GetFieldsAndProperties(objectType,
                        BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                where
                    !ReflectionUtils.IsIndexedProperty(m)
                select m).ToList();
            List<MemberInfo> serializableMembers = new List<MemberInfo>();
            if (objectMemberSerialization != MemberSerialization.Fields)
            {
                DataContractAttribute dataContractAttribute = JsonTypeReflector.GetDataContractAttribute(objectType);
                List<MemberInfo> defaultMembers = (
                    from m in ReflectionUtils.GetFieldsAndProperties(objectType, this.DefaultMembersSearchFlags)
                    where
                        !ReflectionUtils.IsIndexedProperty(m)
                    select m).ToList();
                foreach (MemberInfo memberInfo in allMembers)
                {
                    //DataTransObjectBase
                    if (memberInfo.DeclaringType == typeof (DataTransObjectBase))
                    {
                        continue;
                    }
                    //contextdto
                    if (memberInfo.DeclaringType != null && memberInfo.DeclaringType.IsSubclassOf(typeof (ProxyBase)))
                    {
                        var memberName = memberInfo.Name.ToLower(CultureInfo.CurrentCulture);
                        if (memberName == "contextdto" ||
                            memberName.EndsWith("_skey")) continue;
                    }
                    var isDTOType = false;
                    switch (memberInfo.MemberType())
                    {
                        case MemberTypes.Field:
                            var fieldInfo = (FieldInfo) memberInfo;
                            if (fieldInfo.DeclaringType != null &&
                                fieldInfo.FieldType.IsSubclassOf(typeof (DataTransObjectBase)))
                            {
                                isDTOType = true;
                            }
                            break;
                        case MemberTypes.Property:
                            var propertyInfo = (PropertyInfo) memberInfo;
                            if (propertyInfo.DeclaringType != null &&
                                propertyInfo.DeclaringType.IsSubclassOf(typeof (DataTransObjectBase)))
                            {
                                isDTOType = true;
                            }
                            break;
                    }
                    if (isDTOType)
                    {
                        var memberName = memberInfo.Name.ToLower(CultureInfo.CurrentCulture);
                        if (memberName == "combinename" || memberName.StartsWith("multi_") ||
                            memberName.EndsWith("_skey")) continue;
                    }
                    if (!ReflectionUtils.CanSetMemberValue(memberInfo, true, true))
                        continue;
                    if (this.SerializeCompilerGeneratedMembers ||
                        !memberInfo.IsDefined(typeof (CompilerGeneratedAttribute), true))
                    {
                        if (defaultMembers.Contains(memberInfo))
                        {
                            serializableMembers.Add(memberInfo);
                        }
                        else
                        {
                            if (JsonTypeReflector.GetAttribute<JsonPropertyAttribute>(memberInfo) != null)
                            {
                                serializableMembers.Add(memberInfo);
                            }
                            else
                            {
                                if (dataContractAttribute != null &&
                                    JsonTypeReflector.GetAttribute<DataMemberAttribute>(memberInfo) != null)
                                {
                                    serializableMembers.Add(memberInfo);
                                }
                                else
                                {
                                    if (objectMemberSerialization == MemberSerialization.Fields &&
                                        memberInfo.MemberType() == MemberTypes.Field)
                                    {
                                        serializableMembers.Add(memberInfo);
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
                foreach (MemberInfo member in allMembers)
                {
                    var fieldInfo = member as FieldInfo;
                    if (fieldInfo != null && !fieldInfo.IsStatic)
                    {
                        var memberName = fieldInfo.Name.ToLower(CultureInfo.CurrentCulture);
                        if (memberName == "sysstate" || memberName.StartsWith("multi_") ||
                            memberName.EndsWith("_skey")) continue;
                        serializableMembers.Add(member);
                    }
                }
            }
            return serializableMembers;
        }

        public override JsonContract ResolveContract(Type type)
        {
            JsonContract contract = base.ResolveContract(type);
            contract.IsReference = false;
            return contract;
        }
    }
}