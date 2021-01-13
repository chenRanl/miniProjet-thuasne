using System;
using System.Collections.Generic;
//using System.Text.RegularExpressions;

namespace miniProjet
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            Function fun = new Function();
            Dictionary<string, string> firmware = new Dictionary<string, string>();
            Dictionary<string, string> user = new Dictionary<string, string>();
            while (true)
            {
                str = Console.ReadLine();
                string[] sArray = str.Split(' ');
                switch (sArray[0])
                {
                    case "de":
                        fun.declarer(sArray[1],firmware);
                        break;
                    case "a":
                        fun.associer(sArray[1],user);
                        break;
                    case "di":
                        fun.dissocier(sArray[1],user);
                        break;
                    case "m":
                        fun.MiseAJour(sArray[1],firmware);
                        break;
                    case "show":
                        Console.WriteLine("user list:");
                        foreach (KeyValuePair<string, string> kvp in user)
                        {
                            Console.WriteLine("SLB : {0}, USER : {1}", kvp.Key, kvp.Value);
                        }
                        Console.WriteLine(" ");
                        Console.WriteLine("firmware list:", firmware);
                        foreach (KeyValuePair<string, string> kvp in firmware)
                        {
                            Console.WriteLine("SLB : {0}, FW : {1}", kvp.Key, kvp.Value);
                        }
                        break;

                    default:
                        Console.WriteLine("command not right");
                        Console.WriteLine(" ");
                        break;
                }
            }
        }
    }
    class Function
    {
        //function for check if the user is already in user list
        public bool isUserExist(string ele, Dictionary<string, string> user)
        {
            foreach (var value in user.Values)
            {
                if (ele == value)
                {
                    return true;
                }
            }
            return false;
        }
        public void declarer(string data, Dictionary<string, string> firmware)
        {
            data = data.Substring(1, data.Length - 2);
            string[] device = data.Split(',');
            if (firmware.ContainsKey(device[0]))
            {
                Console.WriteLine("SLB already declare");
                Console.WriteLine(" ");
            }
            else
            {
                firmware.Add(device[0], device[1]);
                Console.WriteLine("OK");
                Console.WriteLine(" ");
            }
        }

        public void associer(string data, Dictionary<string, string> user)
        {
            data = data.Substring(1, data.Length - 2);
            string[] device = data.Split(',');
            if (user.ContainsKey(device[0]))
            {
                Console.WriteLine("SLB already have an USER");
                Console.WriteLine(" ");
            }
            else if (user.Count == 0)
            {
                user.Add(device[0], device[1]);
                Console.WriteLine("OK");
                Console.WriteLine(" ");
            } else
            {
                if (isUserExist(device[1], user))
                {
                    Console.WriteLine("USER already have its own SLB");
                    Console.WriteLine(" ");
                }
                else
                {
                    user.Add(device[0], device[1]);
                    Console.WriteLine("OK");
                    Console.WriteLine(" ");
                }
            }
        }
   
        public void dissocier(string data, Dictionary<string, string> user)
        {
            data = data.Substring(1, data.Length - 2);
            string[] device = data.Split(',');
            if (user.ContainsKey(device[0]))
            {
                if (device[1] == user[device[0]])
                {
                    user.Remove(device[0]);
                    Console.WriteLine("OK");
                    Console.WriteLine(" ");
                } else
                {
                    Console.WriteLine("SLB and USER does not match");
                    Console.WriteLine(" ");
                }
            } else
            {
                Console.WriteLine("SLB does not have an USER");
                Console.WriteLine(" ");
            }
        }

        public void MiseAJour(string data, Dictionary<string, string> firmware)
        {
            data = data.Substring(1, data.Length - 2);
            string[] device = data.Split(',');
            if (firmware.ContainsKey(device[0]))
            {
                firmware[device[0]] = device[1];
                Console.WriteLine("OK");
                Console.WriteLine(" ");
            } else
            {
                Console.WriteLine("SLB does not have an FIRMWARE");
                Console.WriteLine(" ");
            }
        }
    }
}

