using System;
using System.Security.Cryptography;
using System.Text;

namespace Md5
{
    internal class Program
    {
        public static string enCode(string password)
        {
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(password);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));
            }
            else keyArray = UTF8Encoding.UTF8.GetBytes(password);
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static byte[] deCodeByte(string pass)
        {
            return Encoding.ASCII.GetBytes(pass);
        }
        public static string deCode(byte[] pass)
        {
            return Encoding.ASCII.GetString(pass);
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                string inputPass;
                Console.Write("Xin moi nhap password can ma hoa:");
                inputPass = Console.ReadLine();
                
                string mahoa = enCode(inputPass);
                Console.WriteLine("EnCode: " + mahoa);
                
                byte[] array = Encoding.ASCII.GetBytes(inputPass);
                for (int j = 0; j < array.Length; j++)
                {
                    Console.Write("EnCode: " + array[j] + ",\n");
                }

                byte[] all = deCodeByte(inputPass);
                Console.WriteLine("DeCode: " + deCode(all));
                
                Console.WriteLine("DeCode" + inputPass);
            }
        }
    }
}
