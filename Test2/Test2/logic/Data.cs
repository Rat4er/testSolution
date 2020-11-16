using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Test2.model;
using Newtonsoft.Json;

namespace Test2.logic
{
    class Data
    {
        public static byte[] GetAsync()
        {
            using var client = new HttpClient();           
            var content = client.GetByteArrayAsync("https://partner.market.yandex.ru/pages/help/YML.xml");
            return content.Result;
        }

        public static Yml_catalog Parse(byte[] xml)
        {           
            XmlSerializer serializer = new XmlSerializer(typeof(Yml_catalog));
            Yml_catalog result = (Yml_catalog)serializer.Deserialize(new MemoryStream(xml));
            return result;
        }

        public static string JsonSerialize(Offer offer)
        {
            return JsonConvert.SerializeObject(offer);
        }
    }
}
