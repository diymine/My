using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.IO;

namespace Test.Unit
{
    internal class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    [TestClass]
    public class UnitTest2
    {
        private string Decode(string input, string rgbKey, string rgbIV)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(rgbKey);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(rgbIV);

            byte[] byEnc;
            try
            {
                // decode from base64rul string to base64 string
                input = input.Replace('_', '/').Replace('-', '+');

                byEnc = Convert.FromBase64String(input);

                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                using (MemoryStream memoryStream = new MemoryStream(byEnc))
                {
                    using (
                        CryptoStream cryptoStream = new CryptoStream(memoryStream,
                            cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            string str1 =
                Decode(
                    "LSzvdpgQwbE5JLLBs7JIl-_RA0dF9M_axyTOqZRcIVHOTHx3gsgRzTwB77h_9bvjpA74Ke32P7uc4L-3Vba6ejJdJfmPcmgB3UVeg4SK-j-5Yc-SDvfmzQ==",
                    "bX1VyN3R", "bX1VyN3R");
            Console.WriteLine(str1);
            string str2 =
                Decode(
                    "MtkkG8gKTkP90GMUofvYCkTAadVSA_2nhiFEJ1qVUi_AfdXasWKfkdGitVVvjp87uZFHKh4swFgs-kiUMbBIefmrd2OuP2RhKNnrpoD-zpbDEtyJJ6P7JA==",
                    "bX1VyN3R", "bX1VyN3R");
            Console.WriteLine(str2);
        }

        [TestMethod]
        public void GroupByEx1()
        {
            // Create a list of pets.
            List<Pet> pets =
                new List<Pet>
                {
                    new Pet {Name = "Barley", Age = 8},
                    new Pet {Name = "Barley", Age = 8},
                    new Pet {Name = "Boots", Age = 4},
                    new Pet {Name = "Whiskers", Age = 1},
                    new Pet {Name = "Daisy", Age = 4}
                };

            //// Group the pets using Age as the key value 
            //// and selecting only the pet's Name for each value.
            //IEnumerable<IGrouping<int, string>> query =
            //    pets.GroupBy(pet => pet.Age, pet => pet.Name);

            //// Iterate over each IGrouping in the collection.
            //foreach (IGrouping<int, string> petGroup in query)
            //{
            //    // Print the key value of the IGrouping.
            //    Console.WriteLine(petGroup.Key);
            //    // Iterate over each value in the 
            //    // IGrouping and print the value.
            //    foreach (string name in petGroup)
            //    {
            //        Console.WriteLine("  {0}", name);

            //    }
            //    Console.WriteLine("  {0}", petGroup.Count());  
            //}
            var resu = pets.GroupBy(x => new {x.Age, x.Name}).Select(g => new {Key = g.Key, Count = g.Count()});
            foreach (var item in resu)
            {
                Console.WriteLine("Key: " + item.Key);
                Console.WriteLine("Key.Age: " + item.Key.Age);
                Console.WriteLine("Count: " + item.Count);
            }
            //var query1 = from item in pets group item by new {Age = item.Age,Name = item.Name};} 
            //    into g select new { g.Key.weno, g.Key.wename };

        }

        [TestMethod]
        public void TestDateTimeOffset()
        {
            DateTime date1, date2;
            DateTimeOffset dateOffset1, dateOffset2;
            TimeSpan difference;

            // Find difference between Date.Now and Date.UtcNow
            date1 = DateTime.Now;
            date2 = DateTime.UtcNow;
            difference = date1 - date2;
            Console.WriteLine("{0} - {1} = {2}", date1, date2, difference);

            // Find difference between Now and UtcNow using DateTimeOffset
            dateOffset1 = DateTimeOffset.Now;
            dateOffset2 = DateTimeOffset.UtcNow;
            difference = dateOffset1 - dateOffset2;
            Console.WriteLine("{0} - {1} = {2}",
                              dateOffset1, dateOffset2, difference);
            // If run in the Pacific Standard time zone on 4/2/2007, the example
            // displays the following output to the console:
            //    4/2/2007 7:23:57 PM - 4/3/2007 2:23:57 AM = -07:00:00
            //    4/2/2007 7:23:57 PM -07:00 - 4/3/2007 2:23:57 AM +00:00 = 00:00:00                        
        }
    }
}
