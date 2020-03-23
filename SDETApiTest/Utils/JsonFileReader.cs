using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SDETApiTest.Utils
{
    class JsonFileReader<T>
    {
        public static T LoadJson(string fileName)
        {
            T jsonAsGenericType;
            
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                jsonAsGenericType= JsonConvert.DeserializeObject<T>(json);
            }

            return jsonAsGenericType;
        }
    }
}
