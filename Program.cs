using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Threading;


namespace among_us_drip_randomizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            
            
            while (1 == 1)
            {
                Process[] pname = Process.GetProcessesByName("Among Us");
                int idofhat = rng.Next(1, 95); // from 1-94
                int idofskin = rng.Next(1, 16); // from 1-15
                int idofpet = rng.Next(1, 12); // from 1-12
                Thread.Sleep(3000);
                if (pname.Length == 0)
                {
                    Console.WriteLine("Among us is closed, randomizing otufit");
                    Console.WriteLine($"hat : {idofhat}");
                    Console.WriteLine($"skin : {idofskin}");
                    Console.WriteLine($"pet : {idofpet}");
                    costum(idofhat.ToString(), idofskin.ToString(), idofpet.ToString());
                    
                }
                else
                {
                    Console.WriteLine("among us found, close to randomize outfit");
                }
            }
            
        }
        public static void costum(string idofhat, string idofskin, string petid)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fullpath = path + @"Low\Innersloth\Among Us\";
            string readfile = File.ReadAllText(fullpath + "playerPrefs");
            List<string> file_tolist = readfile.Split(',').ToList();
            file_tolist[10] = idofhat;
            file_tolist[15] = idofskin;
            file_tolist[16] = petid;
            string finaltext = string.Join(",", file_tolist);
            File.WriteAllText(fullpath + "playerPrefs", finaltext);
        }
    }
}
