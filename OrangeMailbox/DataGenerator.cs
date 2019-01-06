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
            var faker = new Faker();
            List<string> bogusData = new List<string>();
            bogusData.Add(faker.Person.FirstName);
            bogusData.Add(faker.Person.LastName);
            bogusData.Add(faker.Person.UserName);
            bogusData.Add(CreateRandomString()); // for password
            bogusData.Add(CreateRandomString()); //for secret answer

            //string bogusCsv = string.Join(", ", bogusData.ToArray());
            //Console.WriteLine(bogusCsv);
            return bogusData;
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
