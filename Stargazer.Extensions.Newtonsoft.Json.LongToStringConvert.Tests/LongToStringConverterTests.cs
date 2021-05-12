using Newtonsoft.Json;
using NUnit.Framework;
using Stargazer.Extensions.Newtonsoft.Json.LongToStringConvert;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Stargazer.Extensions.Newtonsoft.Json.LongToStringConvert
{
    [TestFixture()]
    public class LongToStringConverterTests
    {
        [Test()]
        public void ReadJsonTest()
        {
            var longNumber = 123456789L;
            Assert.AreEqual("\"123456789\"", JsonConvert.SerializeObject(longNumber, new JsonSerializerSettings
            {
                Converters = { new LongToStringConverter() }
            }));
        }

        [Test()]
        public void WriteJsonTest()
        {
            var longNumber = "123456789";
            Assert.AreEqual(123456789L, JsonConvert.DeserializeObject<long>(longNumber, new JsonSerializerSettings
            {
                Converters = { new LongToStringConverter() }
            }));
            var longNumberString = "\"123456789\"";
            Assert.AreEqual(123456789L, JsonConvert.DeserializeObject<long>(longNumberString, new JsonSerializerSettings
            {
                Converters = { new LongToStringConverter() }
            }));
        }
    }
}