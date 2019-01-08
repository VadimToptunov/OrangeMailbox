using Bogus;
using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace OrangeMailbox
{
    public static class DataGenerator
    {
        public static List<string> CreateBogusData()
        {
            var faker = new Faker("ru");
            List<string> bogusData = new List<string>();

            bogusData.Add(faker.Name.FirstName());
            bogusData.Add(faker.Name.LastName());
            bogusData.Add(BogusUsername());
            bogusData.Add(faker.Internet.Password());
            bogusData.Add(WebInterfaceInteraction.GetSecretQuestion());
            bogusData.Add(faker.Name.LastName(Name.Gender.Female));
            
            return bogusData;
        }

        static string BogusUsername()
        {
            var bogus = new Faker();
            return bogus.Internet.UserName();
        }
            public static string CreateRandomString()
            {
                RNGCryptoServiceProvider cryptRNG = new RNGCryptoServiceProvider();
                byte[] tokenBuffer = new byte[12];
                cryptRNG.GetBytes(tokenBuffer);
                string password = Convert.ToBase64String(tokenBuffer);
                return password;
            }
        }
}
