using System;
using System.Linq;

namespace ValidIP
{
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();
            Console.WriteLine("enter the ip address :");
            String input = Console.ReadLine();
            if (!input.Any(ch => ch < '0' || ch > '9'))
                if (input.Length < 4)
                    Console.WriteLine("False");
                else if (input.Length == 4)
                    Console.WriteLine("True(" + input[0] + "." + input[1] + "." + input[2] + "." + input[3] + " )");
                else if (input.Length > 12)
                    Console.WriteLine("False");
                else
                    obj.finvalid(long.Parse(input));
            else
                Console.WriteLine("False");

        }
        public String result = "";
        public bool continue_var = true;
        public bool splitted = false;
        public bool contains_zero = false;
        void finvalid(long num)
        {
            if (!continue_var)
            {
                String[] res = result.Split(".");
                if (res.Length > 5)
                    Console.WriteLine("False");
                else if (res.Length == 5)
                    Console.WriteLine("True(" + result.Substring(1) + ")");
                else if (res.Length == 4)
                {
                    Char remainin;
                    String op = "";
                    for (int i = 0; i < res.Length; i++)
                    {
                        if (res[i].Length != 0)
                        {
                            if (res[i].Length == 3 && !splitted)
                            {
                                remainin = res[i].ElementAt(2);
                                res[i] = res[i].Substring(0, 2);
                                op += res[i] + "." + remainin + ".";
                                splitted = true;
                            }
                            else if (res[i].Length == 2 && !splitted)
                            {   
                                remainin = res[i].ElementAt(1);
                                res[i] = res[i].Substring(0, 1);
                                op += res[i] + "." + remainin + ".";
                                splitted = true;
                            }
                            else
                                op += res[i] + ".";
                            continue;
                        }
                    }
                    String[] checkarr = op.Split(".");
                    for (int i = 0; i < checkarr.Length; i++)
                    {
                        if (checkarr[i] == "0")
                            contains_zero = true;
                    }
                    Console.WriteLine(contains_zero ? "False" : "True(" + op.Substring(0, op.Length - 1) + ")");
                }
                else
                    Console.WriteLine("False");
                return;
            }
            else
            {
                if (num == 0)
                    continue_var = false;
                else if (num % 1000 > 255)
                {
                    result = "." + num % 100 + "" + result;
                    num = num / 100;
                }
                else
                {
                    result = "." + num % 1000 + "" + result;
                    num = num / 1000;
                }
                finvalid(num);
            }
        }
    }
}
