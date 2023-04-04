using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pars_num1
{
    internal class Program
    {

        static string Rev(string text)
        {
            if (text == null) return null;

            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }


        static string Parse(string num)
        {
            string res = "";
            int coma = num.IndexOf(",");
            int crapka = num.IndexOf(".");
            if (coma>=0)
            {
                string buf1 = num.Substring(0,coma);
                string buf2 = num.Substring(coma+1);
                int value = Convert.ToInt32(buf1);
                do
                {
                    if (value % 2 == 0)
                    {
                        res += "0";
                    }
                    else if (value % 2 == 1) { res += "1"; }
                    value /= 2;

                } while (value != 1);
                res += "1";
                res = Rev(res);
                res += ",";

                string res_buf = "";

                value = Convert.ToInt32(buf2);
                do
                {
                    if (value % 2 == 0)
                    {
                        res_buf += "0";
                    }
                    else if (value % 2 == 1) { res_buf += "1"; }
                    value /= 2;

                } while (value != 1);
                res_buf += "1";
                res_buf = Rev(res_buf);
                res += res_buf;
            }


            else if (crapka >= 0)
            {
                string buf1 = num.Substring(0, crapka);
                string buf2 = num.Substring(crapka + 1);
                int value = Convert.ToInt32(buf1);
                while (value != 1)
                {
                    if (value % 2 == 0)
                    {
                        res += "0";
                    }
                    else if (value % 2 == 1) { res += "1"; }
                    value /= 2;

                }
                res += "1";
                res = Rev(res);
                res += ".";
                value = Convert.ToInt32(buf2);

                string res_buf = "";

                do
                {
                    if (value % 2 == 0)
                    {
                        res_buf += "0";
                    }
                    else if (value % 2 == 1) { res_buf += "1"; }
                    value /= 2;

                } while (value != 1);
                res_buf += "1";
                res_buf = Rev(res_buf);
                res += res_buf;
            }
            else
            {
                int value = Convert.ToInt32(num);
                do
                {
                    if (value % 2 == 0)
                    {
                        res += "0";
                    }
                    else if (value % 2 == 1) { res += "1"; }
                    value /= 2;
                } while (value != 1);
                res += "1";
                res = Rev(res);
            }


            return res;
        }

        static bool check(string num)
        {

            string can = "0123456789,.";


            foreach (char i in num)
            {
                bool leaver = false;
                foreach (var j in can)
                {
                    if (i==j)
                    {
                        leaver = true;
                        break;
                    }
                }
                if (!leaver)
                {
                    return false;
                }
            }


            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введіть число, що хочете перевести в двійкову систему (дріб або ціле число) : ");
            string num = Console.ReadLine();
            if (check(num))
            {
                Console.Write("в двійковій системі - ");
                Console.WriteLine(Parse(num));
            }
            else
            {
                Console.WriteLine("Неправильний формат вводу");
            }
            Console.ReadKey();


        }
    }
}
