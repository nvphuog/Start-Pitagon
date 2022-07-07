using System;
using System.Text;

namespace Project1
{
    internal class Program
    {
        public static string mahoa(string pass)
        {
            string mahoa1 = "";
            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] >= 33 && pass[i] <= 122 - 33)
                {
                    char abc = Convert.ToChar(pass[i] + '1');
                    mahoa1 += abc;
                }
                else
                {
                    char abc = Convert.ToChar(pass[i] - '1');
                    mahoa1 += abc;
                }
            }
            return mahoa1;
        }
        public static byte[] giaimaByte(string pass)
        {
            return Encoding.ASCII.GetBytes(pass);
        }
        public static string giaima(byte[] pass)
        {
            return Encoding.ASCII.GetString(pass);
        }
        static void Main(string[] args)
        {
            for (int j = 0; j < 10; j++)
            {
                string pass;
                Console.WriteLine("Nhap password can ma hoa:");
                pass = Console.ReadLine();

                //enCode
                Console.WriteLine("Ma hoa: " + mahoa(pass));
                //enCode
                byte[] array = Encoding.ASCII.GetBytes(pass);
                for (int k = 0; k < array.Length; k++)
                {
                    Console.WriteLine("Ma hoa: " + array[k]);
                }
                //deCode
                byte[] all = giaimaByte(pass);
                Console.WriteLine(giaima(all));
                //deCode
                Console.WriteLine("DeCode" + pass);
            }
            
        }
    }
}
