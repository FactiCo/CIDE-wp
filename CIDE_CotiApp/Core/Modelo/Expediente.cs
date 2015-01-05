using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace CIDE_CotiApp.Core.Modelo
{
    
    public class Expediente
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string category { get; set; }
        public string explanation { get; set; }
        public string entidadFederativa { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public string grade { get; set; }
        public string created { get; set; }
    }

    public class lst_Expedientes
    {
        public int count { get; set; }
        public List<Expediente> items { get; set; }
    }

    public class DynamicContractResolver : DefaultContractResolver
    {
        private readonly char _startingWithChar;
        public DynamicContractResolver(char startingWithChar)
        {
            _startingWithChar = startingWithChar;
        }

        protected override IList<JsonProperty> CreateProperties(Type type,MemberSerialization memberSerialization)
        {
            
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);

            // only serializer properties that start with the specified character
            properties =
              properties.Where(p => p.PropertyName.StartsWith(_startingWithChar.ToString())).ToList();

            return properties;
        }
    }

    public class Book
    {
        public string BookName { get; set; }
        public decimal BookPrice { get; set; }
        public string AuthorName { get; set; }
        public int AuthorAge { get; set; }
        public string AuthorCountry { get; set; }
    }

    public class Testimonio
    {
        public string name { get; set; }
        public string email { get; set; }
        public string category { get; set; }
        public string explanation { get; set; }
        public string entidadFederativa { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public string grade { get; set; }
    }
}
