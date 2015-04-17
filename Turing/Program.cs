using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Turing
{
    public class Program
    {
        public static UserUtility UI = new UserUtility();
        public static void Main(string[] args)
        {
            Console.WriteLine("That's better!");
            //specify a number to reject when there is an infinte loop
            Console.WriteLine("Hello World!");
            String[] options = { "1) Load Turing Machine", "2) Read Input Strings", "3) Exit", "4) Exit" };
            Boolean repeat = true;
            string line_buffer;
 
            string[] arraybuffer = new string[1000];
            TuringMachine<string, string> ture = new TuringMachine<string, string>(); 
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
                    string Start_State = "";
                    int num_states = 0, num_alphabet = 0, num_accepting_states = 0, num_transitions = 0;
                    arraybuffer = new string[1000];
                    Console.WriteLine("Please type the name of the states file(default is state.txt):");
                    line_buffer = Console.ReadLine();
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
                        UI.FailMessage("Error, incorrect state input file.");
                    }

                    string[] Accepting_States = new string[num_accepting_states];
                    string[,] Finite_State_Array = new string[num_states, num_alphabet];
                    char[] Alphabet_Array = new char[num_alphabet];
                    Start_State = sr.ReadLine();
                    line_buffer = sr.ReadLine();

                    string[] States_Array = line_buffer.Split(' ');
                    line_buffer = sr.ReadLine();
                    Alphabet_Array = line_buffer.ToCharArray();
                    line_buffer = sr.ReadLine();
                    Accepting_States = line_buffer.Split(' ');
                    //string start, letter, next;
                    string[] start_array = new string[num_transitions];
                    char[] letter_array = new char[num_transitions];
                    string[] next_array = new string[num_transitions];
                    for (int i = 0; i < num_transitions; i++)
                    {
                        line_buffer = sr.ReadLine();
                        arraybuffer = line_buffer.Split(' ');
                        char[] char_buffer = arraybuffer[1].ToCharArray();
                        start_array[i] = arraybuffer[0]; letter_array[i] = char_buffer[0]; next_array[i] = arraybuffer[2];
                    }
                    //String transition_state = "new Transition(\"q0\", '0', \"q0\")";
                    #endregion
                    List<String> Q_States; List<char> Alpha; List<Transition> Trans_Delta;
                    //States_Array
                    Q_States = new List<string> { }; //states
                    Alpha = new List<char> { }; //alphabets
                    Trans_Delta = new List<Transition> { };
                    //After Processing, Stores the Data in 3 Lists
                    for (int i = 0; i < num_states; i++)
                    {
                        Q_States.Add(States_Array[i]);
                    }
                    for (int i = 0; i < num_alphabet; i++)
                    {
                        Alpha.Add(Alphabet_Array[i]);
                    }
                    for (int i = 0; i < num_transitions; i++)
                    {
                        // Trans_Delta.Add(new Transition(start_array[i], letter_array[i], next_array[i]));
                    }

                    //FSM dFSM = new FSM(Q_States, Alpha, Trans_Delta, Start_State, Accepting_States);
                    ture.PopulateMachine(Alphabet_Array);
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
                    for (int a = 0; a < j; a++)
                    {
                        ture.CheckInputString(input_buff[a]);
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
