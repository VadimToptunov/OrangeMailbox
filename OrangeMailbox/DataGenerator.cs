using Bogus;
using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OrangeMailbox
{
    class DataGenerator
    {
            static string CreateFullName()
            {
                string name = "";
                string lastName = "";
                string fullName = "";
                return fullName;
                //return name, lastName; 
            }
            static string CreatePassword()
            {
                RNGCryptoServiceProvider cryptRNG = new RNGCryptoServiceProvider();
                byte[] tokenBuffer = new byte[12];
                cryptRNG.GetBytes(tokenBuffer);
                string password = Convert.ToBase64String(tokenBuffer);
                return password;
            }

            static string CreateFakeData()
            {
                //Create Fake data: name, last name, login;
                string fakeData = "";
                return fakeData;
            }
        }
}
