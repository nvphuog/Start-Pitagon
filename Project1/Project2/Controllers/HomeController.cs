using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Project2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()// Numbers To String
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(int input) // Numbers To String
        {
            ViewData["Number"] = NumberToWord(input);
            return View();
        }
        public IActionResult StringToBase64()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StringToBase64(string input)
        {
            ViewData["StringToBase64"] = StringToBase64Convert(input);
            return View();
        }

        public static string StringToBase64Convert(string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(data);
        }

        public IActionResult StringToByte() // String To Byte
        {
            return View();
        }
        [HttpPost]
        public IActionResult StringToByte(string input) // String To Byte
        {
            ViewData["Byte"] = StringToByConvert(input);
            return View();
        }
        private static string StringToByConvert(string input) // String To Byte
        {
            byte[] array = Encoding.ASCII.GetBytes(input);
            return string.Join(' ', array);
        }

        public IActionResult ImageToBase() // Image To Base64
        {
            return View();
        }
        [HttpPost]
        public IActionResult ImageToBase(FileImage input) // Image To Base64
        {
            //ViewData["InputImage"] = input.Image;
            ViewData["Image"] = ImageToBase64(input.Image[0]);
            return View();
        }
        public static string ImageToBase64(IFormFile imagepath) // Image To Base64
        {
            MemoryStream ms = new MemoryStream();
            imagepath.CopyTo(ms);
            return Convert.ToBase64String(ms.ToArray());
        }

        public IActionResult Base64ToImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Base64ToImage(string input)
        {
            ViewData["StringInput"] = input;
            return View();
        }
        public static string NumberToWord(int number) // Numbers To String
        {
            if (number == 0) return "Zezo";
            if (number < 0) return "Minus" + NumberToWord(Math.Abs(number));
            string word = null;
            if (number / 1000000 > 0)
            {
                word += NumberToWord(number / 1000000) + "Million";
                number %= 1000000;
            }
            if (number / 1000 > 0)
            {
                word += NumberToWord(number / 1000) + "Thousand";
                number %= 1000;
            }
            if (number / 100 > 0)
            {
                word += NumberToWord(number / 100) + "Hundred";
                number %= 100;
            }
            if (number > 0)
            {
                if (word != "") word += "";
                var print = new[] { "Zero","One","Two","Three","Four","Five","Six","Seven","Eight","Nine",
                    "Ten","Eleven","Twelve","Thirteen","Fourteen","Fifteen","Sixteen","Seventeen","Eighteen","Nineteen" };
                var display = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                {
                    word += print[number];
                }
                else
                {
                    word += display[number / 10];
                    if (number % 10 > 0) word += "-" + print[number % 10];
                }
            }
            return word;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
