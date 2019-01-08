using Bogus;
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
            bogusData.Add(faker.Person.FirstName);
            bogusData.Add(faker.Person.LastName);
            bogusData.Add(BogusUsername());
            bogusData.Add(faker.Internet.Password());
            bogusData.Add(WebInterfaceInteraction.GetSecretQuestion());
            //bogusData.Add(faker.Hacker.Noun());
            bogusData.Add(CreateRandomString()); //for secret answer
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
