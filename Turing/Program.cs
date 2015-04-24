using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Turing
{
    public class Program
    {
        public static UserUtility UI = new UserUtility();
        public static void testReg()
        {
            string[] testing = { "abc", "aabbcc", "aaabbbccc", "abbc", "aabbc", "aabbbccc", "bbaacc" };
            Regex reg = new Regex("^(?<n>(?<o>a))*(?<-n>b)*(?<-o>c)*(?(n)(?!))(?(o)(?!))$");
            Match match;
            foreach (string teststring in testing)
            {
                match = reg.Match(teststring);
                if (match.Success)
                {
                    Console.WriteLine("ACCEPTED!");
                    Console.WriteLine(match.Value);
                }
                else
                {
                    Console.WriteLine("REJECTED!");
                }
            }
        }
        public static bool isMirrorLikeString(string content)
        {
            for (int i = 0; i < (int)(content.Length / 2); i++)
            {
                if (content[i] != content[content.Length - 1 - i]) return false;
            }
            return true;
        }
        public static void Main(string[] args)
        {
            /*
            string[] testing = {"abccba","aBcCba","aabbbbaa","dcbbc" };
            foreach (string rev in testing)
            {
                if (isMirrorLikeString(rev))
                {
                    Console.WriteLine("{0} ACCEPTED!",rev);
                }
                else
                {
                    Console.WriteLine("{0} REJECTED!",rev);
                }
            }
             * */
            //testReg();
            //specify a number to reject when there is an infinte loop
            string filen="";
            Console.WriteLine("Hello World!");
            String[] options = { "1) Load Turing Machine", "2) Read Input Strings", "3) Exit", "4) Exit" };
            Boolean repeat = true;
            string line_buffer;
 
            string[] arraybuffer = new string[1000];
            TuringMachine<string, char> ture = new TuringMachine<string, char>(); 
            while (repeat)
            {
                Console.WriteLine("Please select an option.");
                for (int i = 0; i < options.Length; i++) { Console.WriteLine(options[i]); }
                line_buffer = Console.ReadLine();
                if (line_buffer.StartsWith("1"))
                {
                    Console.WriteLine("You have chosen option 1. ");
                    
                    /*************** reads and processes the DFSM formet file ****************/
                    #region
                    string path = ".//..//..//..//";
                    int num_states = 0, num_alphabet = 0, num_accepting_states = 0, num_transitions = 0;
                    arraybuffer = new string[1000];
                    Console.WriteLine("Please type the name of the states file(default is state.txt):");
                    line_buffer = Console.ReadLine();
                    filen = line_buffer;
                    if (filen.Equals("state2.txt"))
                    {
                    }
                    FileStream fs = new FileStream(path + line_buffer, FileMode.OpenOrCreate, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);


                    //reads the numbers
                    try
                    {
                        line_buffer = sr.ReadLine();
                        num_states = int.Parse(line_buffer);
                        line_buffer = sr.ReadLine();
                        num_accepting_states = int.Parse(line_buffer);
                        line_buffer = sr.ReadLine();
                        num_transitions = int.Parse(line_buffer);
                    }
                    catch (Exception ex)
                    {
                        UI.FailMessage("Error, incorrect numbers.");
                    }
                    //string[,] Finite_State_Array = new string[num_states, num_alphabet];
                    string Start_State = sr.ReadLine();
                    
                    line_buffer = sr.ReadLine();
                    string[] States_Array = line_buffer.Split(',');

                    line_buffer = sr.ReadLine();
                    char[] Alphabet_Array = line_buffer.ToCharArray();

                    line_buffer = sr.ReadLine();
                    string[] Accepting_States = line_buffer.Split(',');

                    string[] start_array = new string[num_transitions];
                    char[] read_array = new char[num_transitions];
                    char[] write_array = new char[num_transitions];
                    char[] direction_array = new char[num_transitions];
                    string[] next_array = new string[num_transitions];
                    for (int i = 0; i < num_transitions; i++)
                    {
                        line_buffer = sr.ReadLine();
                        arraybuffer = line_buffer.Split(' ');
                        char[] char_buffer = arraybuffer[1].ToCharArray();
                        start_array[i] = arraybuffer[0];
                        read_array[i] = char_buffer[0];
                        write_array[i] = char_buffer[1];
                        direction_array[i] = char_buffer[2];
                        next_array[i] = arraybuffer[2];
                    }
   
                    #endregion
                    List<String> Q_States; List<char> Alpha; List<Transition> Trans_Delta;
                    Q_States = new List<string>(); 
                    Alpha = new List<char>(); 
                    Trans_Delta = new List<Transition>();
                    for (int i = 0; i < num_states; i++)
                    {
                        Q_States.Add(States_Array[i]);
                    }
                    for (int i = 0; i < Alphabet_Array.Length; i++)
                    {
                        Alpha.Add(Alphabet_Array[i]);
                    }
                    for (int i = 0; i < num_transitions; i++)
                    {
                        Trans_Delta.Add(new Transition(start_array[i],read_array[i], write_array[i],direction_array[i], next_array[i]));
                    }

                    //FSM dFSM = new FSM(Q_States, Alpha, Trans_Delta, Start_State, Accepting_States);
                    ture.PopulateMachine(Alpha, Q_States,Trans_Delta, Start_State, Accepting_States);
                    Console.WriteLine("Ok, state machine processed.");
                }
                else if (line_buffer.StartsWith("2"))
                {
                    Console.WriteLine("You have chosen option 2.");
                    Console.WriteLine("Please enter the name of the input file(default is input.txt):");
                    string path = ".//..//..//..//";
                    Console.WriteLine("Please type the name of the input file.");
                    FileStream fs_in = new FileStream(path + "input.txt", FileMode.OpenOrCreate, FileAccess.Read);
                    StreamReader streamreader = new StreamReader(fs_in);
                    string[] input_buff = new string[1000];
                    int j = 0;
                    while (!streamreader.EndOfStream)
                    {
                        line_buffer = streamreader.ReadLine();
                        input_buff[j] = line_buffer; j++;
                    }
                    //After reading all the input strings and storing it in the array, loop and check them
                    if (filen.Equals("state2.txt"))
                    {
                        for (int a = 0; a < j; a++)
                        {
                            ture.CheckInputStrin(input_buff[a]);
                        }
                    }
                    else
                    {
                        for (int a = 0; a < j; a++)
                        {
                            ture.CheckInputString(input_buff[a]);
                        }
                    }
                    
                }
                else if (line_buffer.StartsWith("3"))
                {
                    Console.WriteLine("You have chosen option 3.");
                    //Console.WriteLine("Error, unable to minimize. Something went wrong.");
                }
                else
                {
                    repeat = false;
                    Console.WriteLine("Thank you. Now exiting the program.");
                }
            }
            UI.Write("Done. Press any key to continue...");
            Console.ReadLine();
        }


    }
}
