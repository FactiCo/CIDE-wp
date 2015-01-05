using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace CIDE_CotiApp.Core.Modelo
{
    public class interfaceExpediente : DefaultContractResolver
    {
        ExpedienteReveiceType tipo;
        public interfaceExpediente(ExpedienteReveiceType _tipo )
        {
            tipo = _tipo;

        }

        protected override JsonProperty CreateProperty(System.Reflection.MemberInfo member, MemberSerialization memberSerialization)
        {
    
        JsonProperty property = base.CreateProperty(member, memberSerialization);

        if (property.PropertyName == "_id" || 
            property.PropertyName == "created")
            {
                //property.ShouldSerialize=new Predicate();
            }

            return base.CreateProperty(member, memberSerialization);
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
            
            switch (tipo)
            {
                case ExpedienteReveiceType.PostNG:
                    properties = properties.Where(p => !(p.PropertyName == "_id" || p.PropertyName == "created")).ToList();
                    break;
                case ExpedienteReveiceType.GetNG:
                    break;
                default:
                    break;
            }

            return properties;

        }

    }

    public enum ExpedienteReveiceType
    {
        PostNG,GetNG
    }


}
