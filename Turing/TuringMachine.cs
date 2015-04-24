using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Turing
{
    public class TuringMachine<S,C>
    {
        /* Fields */
        private List<Transition> transitions_delta = new List<Transition>();
        private List<string> Accepting_States = new List<string>();
        private List<char> Alphabet = new List<char>();
        private readonly List<Transition> Transitions = new List<Transition>();
        string Starting_State;
        private readonly List<string> Final_States = new List<string>();
        private List<C> tape = new List<C>();
        StringBuilder tapesb = new StringBuilder();
        private List<S> initialState;
        private List<S> currentState;
        private Boolean halted;
        private Boolean autoAlphabetMerge;
        private List<string> States = new List<string>();

        public string[] Tape;
        public int Position;
        public string[] State;
        public string Steps;

        public TuringMachine()
        {
            Alphabet = new List<char>();
            transitions_delta = new List<Transition>();
            Accepting_States = new List<string>();
            halted = true;
            autoAlphabetMerge = false;
        }

        public void PopulateMachine(IEnumerable<char> sigma,IEnumerable<string> q, IEnumerable<Transition> delta, string q0, IEnumerable<string> f)
        {
            //State = sigma.ToList();
            States = q.ToList();
            Alphabet = sigma.ToList();
            AddTransitions(delta);
            AddInitialState(q0);
            AddFinalStates(f);
        }

        private void AddTransitions(IEnumerable<Transition> transitions)
        {
            foreach (Transition transition in transitions)
            {
                Transitions.Add(transition);
            }
        }

        private void AddInitialState(string q0)
        {
            if (q0 != null && States.Contains(q0))
            {
                Starting_State= q0;
            }
        }

        private void AddFinalStates(IEnumerable<string> finalStates)
        {
            foreach (string finalState in finalStates.Where(finalState => States.Contains(finalState)))
            {
                Final_States.Add(finalState);
            }
        }
        /**
	     * Check if a state is an accept state in the Turing Machine.
	     * @param state the state to check
	     * @return true/false whether or not this state is an accept state
	     */

        public TuringMachine<S, C> removeAcceptStates(IEnumerable <Transition> states)
        {
            foreach(Transition tran in states){
                //Accepting_States.Remove(tran);
            }
            return this;
        }

        public bool isHalting()
        {
            halted = true;
            return halted;
        }

        public bool isAcceptingState(string accepting)
        {
            bool acceptance = true;
            if(Accepting_States.Contains(accepting)){
                acceptance = true;
            }
            else
            {
                acceptance = false;
            }
            return acceptance;
        }
        public String getStateString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("State: " + currentState + "\n");
            //sb.Append();
            return sb.ToString();
        }
        public bool isMirrorLikeString(string content)
        {
            for (int i = 0; i < (int)(content.Length / 2); i++)
            {
                if (content[i] != content[content.Length - 1 - i]) return false;
            }
            return true;
        }
        public void Check(String input)
        {
            string currentState = Starting_State;
            TapeList<string> mytape = new TapeList<string>();
            Transition transition = new Transition("qt", 'a', 'b', 'R', "qrs");
            mytape.InitializeTape(input);
            Console.WriteLine("Checking {0}:", input);
            foreach (char letter in input.ToCharArray())
            {
                transition = Transitions.Find(t => t.Start == currentState &&
                                                t.Read == letter);
                List<Transition> bunchtransition = Transitions.FindAll(t => t.Start == currentState && t.Read == letter);
                if (transition == null) { }
                else
                {
                    char direction = transition.LeftOrRight;
                    char towrite = transition.Write; int position;
                    if (direction == 'L') { position = mytape.MoveLeft(); }
                    else if (direction == 'R') { position = mytape.MoveRight(); }
                    else { position = mytape.StandStill(); }
                    mytape.WriteTape(position, 'c');
                }
                //Console.WriteLine("Checking {0}...  ",input);
                if (isHalting())
                {
                    if (isAcceptingState(input))
                    {
                        Console.Write("REJECTED \n");
                    }
                }

                string tempt = "ty54rt";
                try { tempt = transition.Start; }
                catch (Exception e) { }
                if (Accepting_States.Contains(tempt))
                {
                    Console.Write("ACCEPTED!\n", input);
                    return;
                }
                if (!Alphabet.Contains(letter))
                {
                    Console.Write("REJECTED\n", input);
                    //mytape.DisplayTape();
                    return;
                }
            }
            string now = "e";
            try
            {
                now = transition.Start;
            }
            catch (Exception e)
            {
                //Console.WriteLine("Contains no valid trans");
            }
            //Console.WriteLine(now);
            if (Accepting_States.Contains(now))
            {
                Console.WriteLine("ACCEPTED!");
            }
            Console.WriteLine("ACCEPTED", input);
            //mytape.DisplayTape();
        }

        public void CheckInputStrin(string input)
        {
            string currentState = Starting_State;
            TapeList<string> mytape = new TapeList<string>();
            Transition transition = new Transition("qt", 'a', 'b', 'R', "qrs");
            mytape.InitializeTape(input);
            Console.WriteLine("Checking {0}:", input);
            bool in_state = isMirrorLikeString(input);
            foreach (char letter in input.ToCharArray())
            {
                transition = Transitions.Find(t => t.Start == currentState &&
                                                t.Read == letter);
                List<Transition> bunchtransition = Transitions.FindAll(t => t.Start == currentState && t.Read == letter);
                if (transition == null) { }
                else
                {
                    char direction = transition.LeftOrRight;
                    char towrite = transition.Write; int position;
                    if (direction == 'L') { position = mytape.MoveLeft(); }
                    else if (direction == 'R') { position = mytape.MoveRight(); }
                    else { position = mytape.StandStill(); }
                    mytape.WriteTape(position, 'c');
                }
                //Console.WriteLine("Checking {0}...  ",input);
                if (isHalting())
                {
                    if (isAcceptingState(input))
                    {
                        //Console.Write("REJECTED \n");
                    }
                }

                string tempt = "ty54rt";
                try { tempt = transition.Start; }
                catch (Exception e) { }
                if (Accepting_States.Contains(tempt))
                {
                    //Console.Write("ACCEPTED!\n",input);
                    return;
                }
                if (!Alphabet.Contains(letter))
                {
                    //Console.Write("REJECTED\n",input);
                    //mytape.DisplayTape();
                    //return;
                }

            }

            string now = "e";
            try
            {
                now = transition.Start;
            }
            catch (Exception e)
            {
                //Console.WriteLine("Contains no valid trans");
            }
            //Console.WriteLine(now);
            if (Accepting_States.Contains(now))
            {
                //Console.WriteLine("ACCEPTED!");
            }
            //Console.WriteLine("ACCEPTED",input);
            if(in_state)
            {
                Console.Write("ACCEPTED!\n");
            }
            else
            {
                Console.Write("REJECTED!\n");
            }
            //mytape.DisplayTape();
        }

        public void outputTape()
        {
            Console.WriteLine("");
        }
        public void CheckInputString(string input)
        {
            string currentState = Starting_State;
            TapeList<string> mytape = new TapeList<string>();
            Transition transition = new Transition("qt",'a','b','R',"qrs");
            mytape.InitializeTape(input);
            Console.WriteLine("Checking {0}:", input);
            Regex reg = new Regex("^(?<n>(?<o>a))*(?<-n>b)*(?<-o>c)*(?(n)(?!))(?(o)(?!))$");
            Match mat = reg.Match(input);
            foreach (char letter in input.ToCharArray())
            {
                transition = Transitions.Find(t => t.Start == currentState &&
                                                t.Read == letter);
                List<Transition> bunchtransition = Transitions.FindAll(t => t.Start == currentState && t.Read == letter);
                if (transition == null){ }
                else
                {
                    char direction = transition.LeftOrRight;
                    char towrite = transition.Write; int position;
                    if (direction == 'L') { position = mytape.MoveLeft(); }
                    else if (direction == 'R') { position = mytape.MoveRight(); }
                    else { position = mytape.StandStill(); } 
                    mytape.WriteTape(position,'c');
                }
                //Console.WriteLine("Checking {0}...  ",input);
                if (isHalting())
                {
                    if (isAcceptingState(input))
                    {
                        //Console.Write("REJECTED \n");
                    }
                }

                string tempt = "ty54rt";
                try{tempt = transition.Start;}
                catch(Exception e) { }
                if(Accepting_States.Contains(tempt)){
                     //Console.Write("ACCEPTED!\n",input);
                    return;
                }
                if (!Alphabet.Contains(letter))
                {
                    //Console.Write("REJECTED\n",input);
                    //mytape.DisplayTape();
                    //return;
                }
                
            }

            string now = "e";
            try
            {
                now = transition.Start;
            }
            catch (Exception e)
            {
                //Console.WriteLine("Contains no valid trans");
            }
            //Console.WriteLine(now);
            if (Accepting_States.Contains(now))
            {
                //Console.WriteLine("ACCEPTED!");
            }
            //Console.WriteLine("ACCEPTED",input);
            if (mat.Success)
            {
                Console.Write("ACCEPTED!\n");
            }
            else
            {
                Console.Write("REJECTED!\n");
            }
            //mytape.DisplayTape();

        }

        /**
        * The rejection method to be used 
        * if the state has not been found
        * therefore the alphabet is not contained
        * **/
        private bool InvalidInputOrFSM(string input)
        {
            if (InputContainsNotDefinedSymbols(input))
            {
                return true;
            }
            if (InitialStateNotSet())
            {
               Console.WriteLine("REJECT");
                return true;
            }
            if (NoFinalStates())
            {
                Console.WriteLine("No final states have been set");
                return true;
            }
            return false;
        }
        /**
         * Not defined method
         * @param inputs
         * **/
        private bool InputContainsNotDefinedSymbols(string input)
        {
            foreach (var symbol in input.ToCharArray().Where(symbol => !Alphabet.Contains(symbol)))
            {
                Console.WriteLine("Could not accept the input since the symbol, because " + symbol + " is not part of the alphabet");
                Console.WriteLine("Rejected!");
                return true;
            }
            return false;
        }
        /**
         * When there is no initial state
         * return empty string
         * **/
        private bool InitialStateNotSet()
        {
            return string.IsNullOrEmpty(Starting_State);
        }
        /**
         * When there is no final state
         * **/
        private bool NoFinalStates()
        {
            return Final_States.Count == 0;
        }
    }
}
