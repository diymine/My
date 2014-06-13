using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.IO;

namespace Test.Unit
{
    [TestClass]
    public class UnitTest2
    {
        private  string Decode(string input, string rgbKey, string rgbIV)
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
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read))
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
            string str1 = Decode("LSzvdpgQwbE5JLLBs7JIl-_RA0dF9M_axyTOqZRcIVHOTHx3gsgRzTwB77h_9bvjpA74Ke32P7uc4L-3Vba6ejJdJfmPcmgB3UVeg4SK-j-5Yc-SDvfmzQ==", "bX1VyN3R", "bX1VyN3R");
            Console.WriteLine(str1);
            string str2 = Decode("MtkkG8gKTkP90GMUofvYCkTAadVSA_2nhiFEJ1qVUi_AfdXasWKfkdGitVVvjp87uZFHKh4swFgs-kiUMbBIefmrd2OuP2RhKNnrpoD-zpbDEtyJJ6P7JA==", "bX1VyN3R", "bX1VyN3R");
            Console.WriteLine(str2);
        }
    }
}
