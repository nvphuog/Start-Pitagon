using System;
using System.Text;

namespace Project1
{
    internal class Program
    {
        //private string[] i;
        public static string mahoa(string pass)
        {
            // byte[] array = Encoding.ASCII.GetBytes(pass);
            // for (int j = 0; j < array.Length; j++)
            // {
            //     return Convert.ToString(array.ToString());
            // }
            
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

        public static string giama(byte[] pass)
        {
            return Encoding.ASCII.GetString(pass);
        }
        public static byte[] Bytesy(string pass)
        {
            return Encoding.ASCII.GetBytes(pass);
        }
        static void Main(string[] args)
        {
            for (int j = 0; j < 10; j++)
            {
                string pass;
                Console.WriteLine("Nhap chuoi can ma hoa:");

                //ma hoa
                pass = Console.ReadLine();
                Console.WriteLine(mahoa(pass));

                //string to byte
                byte[] array = Encoding.ASCII.GetBytes(pass);
                for (int k = 0; k < array.Length; k++)
                {
                    Console.WriteLine(array[k]);
                }

                //giai ma
                byte[] all = Bytesy(pass);
                Console.WriteLine(giama(all));
            }
            
        }
    }
}
