using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Text.RegularExpressions;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string RemoveSpecialCharacters(string str)
        {
            //string str1 = Regex.Replace(str, @"[\[\]\\\^\$\.\|\?\*\+\(\)\{\}%,;><!@#&\-\+]", "");
            if (str != null)
            {
                string str1 = Regex.Replace(str, @"[^a-z0-9\s-]", "");
                return str1;
            }
            else
            {
                return "";
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = RemoveSpecialCharacters("~!@#$%^&*()_+=-][{}';:/?><Your application description page.");

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        private static string getVowel(string xStr)
        {
            var test02="";

            char character;
            character = Char.Parse(xStr);

            if ((character >= 'A' && character <= 'Z') || character >= 'a' && character <= 'z')
            {
                if (character == 'a' || character == 'A' || character == 'e' || character == 'E' || character == 'i'
                    || character == 'I' || character == 'o' || character == 'O' || character == 'u' || character == 'U')
                {
                    //Console.WriteLine(character + " is a vowel");
                    test02 = character + " is a vowel";
                }
                else
                {
                    //Console.WriteLine(character + " is a consonant");
                    test02 = character + " is a consonant";
                }
            }
            else
            {
                //Console.WriteLine(character + " is not an alphabet");
                test02 = character + " is not an alphabet";
            }

            return test02;

        }

        public string Test01(int value)
        {
           
            var test01 = "";
            
            var ganjil = "";
            var genap = "";
            for (int i = 0; i <= (value-1); i ++)
            {
                genap = genap + i;
                int x = i += 1;
                ganjil = ganjil + x;
            }

            test01 = ganjil + "<br>" + genap;
            return test01;
        }

        public string Test02(string value)
        {
            var test02 = "";
            string[] karakter=new string[value.Length] ;


            for (int i = 0; i <= (value.Length-1); i++)
            {
                karakter[i]=value.Substring(i, 1);

                //test02 = test02+"-"+value.Substring(i, 1);
                //test02 = test02+"<br>"+getVowel(value.Substring(i, 1));
            }
            test02 = "Vowel dan consonantnya cari sendiri yah..<br>";
            //var res = from nm in karakter orderby nm select nm;
            Array.Sort(karakter);
            foreach (string kar in karakter)
            {
                test02 = test02 + "<br>" + getVowel(kar);
            }

            //ViewData["test02_tittle"] = "Consonant And Vowel";
            //ViewData["test02"] = test02;
            //ViewData["test02_vowel"] = test02_vowel;

            //return View();
            return test02;
        }




        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        
        public string checkRevMatch(string nilai,string sumber)
        {
            var betul = "";
            var test = 0;
            char[] charArray = nilai.ToCharArray();
            char[] charSumber = sumber.ToCharArray();
            
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i]==charSumber[i])
                {
                    test = test + 1;
                }
                else
                {
                    test = test - 1;
                }
                betul = betul + charArray[i]+"=" + charSumber[i] + "hasil "+test + "<br>";
            }

            return betul;
        }

        private static string bilPrima(int angka)
        {
            var t = "Y";
            if (angka==1)
            {
                t = "T";
            }
            else
            {
                for (int i = 2; i <= (angka-1); i++)
                {
                    if (angka % i == 0)
                    {

                        t = "T";
                        
                    }

                }
            }
           
            return t;
        }
        
        public string test03(int value)
        {
            var test03 = "";// checkRevMatch(Reverse("149"),"941");
            int count = 0;
            int i = 10;
            
            while (count < value)
            {
                var che = bilPrima(i);
                if (che == "Y")
                {
                    var she = bilPrima(Convert.ToInt32(Reverse(i.ToString())));
                    if (she=="Y")
                    {
                        count++; // kalau ketemu di tambah
                        test03 = test03 + "<br>" + i + " - Is Match With " + Convert.ToInt32(Reverse(i.ToString()));
                    }
                       
                }

                i++;
            }

            //test03 = test03 + "<hr>";

            return "Hasil : <br>"+test03+"<hr>";
        }



        private static string cekIamNumberOne(int nilai)
        {
            var betul = "T";

            string xs = nilai.ToString();
            var sem = 0;
            var Out = "";
            for (int x = 0; x <= (xs.Length - 1); x++)
            {
                int subx = Convert.ToInt32(xs.Substring(x, 1));
                int hit = subx * subx;
                string xsHit = hit.ToString();
                var ss = Out + ";" + subx + "*" + subx + "=" + hit.ToString() + "<br>";
                sem = sem + hit;
                Out = ss;
            }

            string s = sem.ToString();
            Regex regex = new Regex("1");
            //string str1 = "";
            foreach (Match match in regex.Matches(s))
            {
               //str1 = " I Am The One Number";
                betul = "Y";
            }

            return betul;
        }

        public string Test04(int value)
        {
            var test04 = "";
            int count = 0;
            int i = 100;
            //test04 = cekIamNumberOne(103);

            while (count < value)
            {
                var che= cekIamNumberOne(i);
                if (che == "Y")
                {
                    count++; // kalau ketemu di tambah
                    test04 = test04 + i + " - Is The One Number<hr>";
                }

                i++;
            }

            return test04;
        }


        public string Test05(string value, int max)
        {
            var test05 = "";
            var jcount = 0;
            string [] xr=value.Split("-");
            for (int i = 0; i < xr.Length; i++)
            {
                test05 = test05 + "Data Ke "+xr[i]+"<br>";
                int xsub = Convert.ToInt32(xr[i]);
                for (int iSub = 0; iSub < xr.Length; iSub++)
                {
                    int xnil = xsub + Convert.ToInt32(xr[iSub]);
                    if (xnil <= max)
                    {
                        test05 = test05 + xsub + "+" + xr[iSub] + "=" + xnil.ToString() + "<br>";
                        jcount++;
                    }
                    
                }
                test05 = test05 +"<hr>";
                //int xsub=

            }
            test05 = test05 + "<h1>Total Hasil : "+jcount +"</h1><hr>";
            return test05;
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
