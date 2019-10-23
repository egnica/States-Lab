using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {
            const int QUAN_PROPERTIES = 5;
            string filePath = "c:\\users\\egnnica\\States.csv";
            string strRead;

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader readerClass = new StreamReader(fs);

            int count;
            count = GetCount(filePath);

            States[] state = new States[count];
            for(int index = 0; index < count; ++index)
            {
                state[index] = new States();
            }

            strRead = readerClass.ReadLine();

            string[] headerParts = strRead.Split(',');

            state[0].state = headerParts[0];

            state[0].abb = headerParts[1];
            state[0].flower = headerParts[2];
            state[0].bird = headerParts[3];
            state[0].governor = headerParts[4];

            String[] recordParts = new String[QUAN_PROPERTIES];
            
            for(int counter = 1; counter < count; ++counter)
            {
                

                strRead = readerClass.ReadLine();
                string[] Parts = strRead.Split(',');

                for(int x = 0; x < 5; ++x)
                {
                    recordParts[x] = Parts[x];
                }
                
                state[counter].state = recordParts[0];
                state[counter].abb = recordParts[1];
                state[counter].flower = recordParts[2];
                state[counter].bird = recordParts[3];
                state[counter].governor = recordParts[4];
                

               
            }
            
            readerClass.Close();
            fs.Close();

            Console.WriteLine("Here's what was read from the CSV file: ");

            for(int x = 0; x < count; ++x)
            {
                if(x == 0)
                {
                    Console.WriteLine($"Header: {state[x].state} {state[x].abb} {state[x].flower} {state[x].bird} {state[x].governor}");
                }
                else
                {
                    Console.WriteLine($"Header: {state[x].state} {state[x].abb} {state[x].flower} {state[x].bird} {state[x].governor}, x");
                }
            }
            Console.WriteLine("---------------------------------");
            int selection;
            
            string[] options = { "1. Display State full names and their state flower", "2. Display State abbreviation and their state birds", "3. Display State abbreviation and their governors" };
            string EXIT = "QUIT";
            string primer;
            do
            {
                for (int a = 0; a < options.Length; a++)
                {
                    Console.WriteLine($" {options[a]}");
                }
                Console.Write("Please choose from one of the following. Enter a number 1-3: ");
                selection = Convert.ToInt32(Console.ReadLine());

                if (selection == 1)
                {
                    for (int b = 0; b < state.Length; b++)
                    {
                        Console.WriteLine($"{state[b].state} -- {state[b].flower}");
                    }
                }
                else if (selection == 2)
                {
                    for (int b = 0; b < state.Length; b++)
                    {
                        Console.WriteLine($"{state[b].abb} -- {state[b].bird}");
                    }
                }
                else
                {
                    for (int b = 0; b < state.Length; b++)
                    {
                        Console.WriteLine($"{state[b].abb} -- {state[b].governor}");
                    }
                }
                
                Console.WriteLine("Type 'QUIT' to exit. Or press 'enter' to continue ");
                primer = Console.ReadLine();

            } while (primer != EXIT);




        }// end main
        static int GetCount(string file)
        {
            int count = 0;
            string strRead;
            FileStream sr = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader readerCount = new StreamReader(sr);

            strRead = readerCount.ReadLine();

            while (strRead != null)
            {
                ++count;
                strRead = readerCount.ReadLine();
            }
            readerCount.Close();
            sr.Close();

            return count;
        }
    }//class program
    class States
    {
        public string state { get; set; }
        public string abb { get; set; }
        public string flower { get; set; }
        public string bird { get; set; }
        public string governor { get; set; }
    }
}
