using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.run();
        }

        private void run()
        {

            getUserChoices(out int maxIntToPrint, out Dictionary<int,bool> rules );

            printOutput(maxIntToPrint, rules);
            //printOutputNew is incomplete, restructuring to work with a Dictionary
            //printOutputNew(maxIntToPrint, rules);
        }


        private void printOutputNew(int maxIntToPrint, Dictionary<int, bool> rules)
        {
            for (int i = 1; i <= maxIntToPrint; i++)
            {
                List<string> toPrint = new List<string>();
                Dictionary<int, string> ruleBook = generateRuleBook();
                foreach (int key in ruleBook.Keys)
                {
                    if (i % key == 0)
                    {
                        toPrint.Add(ruleBook[key]);
                    }
                }

                if (toPrint.Count() == 0)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    string output = string.Join("", toPrint);
                    Console.WriteLine(output);
                }
            }

            //Change orders etc
            //TODO Need to check the reordering rules turn off if the rule is off
            //Also need to check words will appear in correct order
        }
        private void printOutput(int maxIntToPrint, Dictionary<int, bool> rules)
        {

            //TODO make this bit work//TODO Change from bool dictionary that ifs act on, to Dictionary that if's can run over.
            Dictionary<int, string> ruleBook = generateRuleBook();
            

            for (int i = 1; i <= maxIntToPrint; i++)
            {
                List<string> toPrint = new List<string>();


                if (i % 3 == 0 && rules[3])
                {
                    toPrint.Add("Fizz");
                }
                if (i % 5 == 0 && rules[5])
                {
                    toPrint.Add("Buzz");
                }
                if (i % 7 == 0 && rules[7])
                {
                    toPrint.Add("Bang");
                }
                if (i % 11 == 0 && rules[11])
                {
                    toPrint = new List<string>();
                    toPrint.Add("Bong");
                }
                if (i % 13 == 0 && rules[13])
                {
                    if (i % 3 != 0 || !rules[3])
                    {
                        toPrint.Insert(0, "Fezz");
                    }
                    else
                    {
                        toPrint.Insert(1, "Fezz");
                    }
                }
                if (i % 17 == 0 && rules[17])
                {
                    toPrint.Reverse();
                }


                if (toPrint.Count() == 0)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    string output = string.Join("", toPrint);
                    Console.WriteLine(output);
                }
            }
        }

        private void getUserChoices(out int maxIntToPrint, out Dictionary<int,bool> rules)
        {

            //Attempt to get user input, use 100 if input invalid
            Console.WriteLine("FizzBuzz will print out the numbers from 1 to what?");
            string userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out maxIntToPrint))
            {
                Console.WriteLine("Sorry, didn't understand that. Here's 1:100 instead");
                maxIntToPrint = 100;
            }

            //Take user input for which rules to implement
            List<int> listOfRulesAvailable = new List<int>{3,5,7,11,13,17};
            
            rules = new Dictionary<int, bool>();
            foreach(int num in listOfRulesAvailable)
            {
                rules.Add(num, false);
            }

            Console.WriteLine("By default, all rules are off. If you would like to turn any on, please type the relevant numbers in the form \"3\", \"3,5,11\" etc. ");
            string userChoices = Console.ReadLine();
            string[] rulesToSwitchOn = userChoices.Split(',');
            for (int i = 0; i < rulesToSwitchOn.Length; i++)
            {
                if (int.TryParse(rulesToSwitchOn[i], out int ruleNumber) && listOfRulesAvailable.Contains(ruleNumber))
                {
                    rules[ruleNumber] = true;
                }
            }

            


        }

        private Dictionary<int,string> generateRuleBook()
        {
            Dictionary<int, string> ruleBook = new Dictionary<int, string>();
            ruleBook.Add(3, "Fizz");
            ruleBook.Add(5, "Buzz");
            ruleBook.Add(7, "Bang");
            ruleBook.Add(11, "Bong");
            ruleBook.Add(13, "Fezz");

            return ruleBook;
        }
    }
}
