using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing
{
    public class TuringMachine<S,C>
    {
        /* Fields */
        private List<Transition> transitions_delta;
        private List<string> Halting_States;
        private List<char> Alphabet;
        string Starting_State;
        private List<C> tape;
        private List<S> initialState;
        private List<S> currentState;
        private Boolean halted;
        private Boolean autoAlphabetMerge;

        public string[] Tape;
        public int Position;
        public string[] State;
        public string Steps;

        public TuringMachine()
        {
            Alphabet = new List<char>();
            transitions_delta = new List<Transition>();
            Halting_States = new List<string>();
            halted = true;
        }

        public void PopulateMachine(IEnumerable<char> sigma)
        {
            //State = sigma.ToList();
            Alphabet = sigma.ToList();
        }
        /**
	     * Check if a state is an accept state in the Turing Machine.
	     * @param state the state to check
	     * @return true/false whether or not this state is an accept state
	     */
        public void CheckInputString(string input)
        {
            foreach (char letter in input.ToCharArray())
            {
                if (!Alphabet.Contains(letter))
                {
                    Console.WriteLine("Checking {0}: REJECTED",input);
                    return;
                }
            }
            Console.WriteLine("Checking {0}: ACCEPTED",input);

        }
    }
}
