using Bogus;
using System.Collections.Generic;

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
            bogusData.Add("Фамилия вашего любимого учителя");
            //bogusData.Add(WebInterfaceInteraction.GetSecretQuestion());
            bogusData.Add(faker.Name.LastName());
            return bogusData;
        }

        public static string BogusUsername()
        {
            var bogus = new Faker();
            return bogus.Internet.UserName().Replace("_", ".");
        }
    }
}
