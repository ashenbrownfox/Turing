using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing
{
    //public delegate void StateAction(object sender, StateEventArgs eventArgs);
    public class Transition
    {
        public char Read { get; private set; } //char
        public char Write { get; private set; }
        public string LeftOrRight { get; private set; }

        public Transition(char start, char symbol, string endState)
        {
            Read = start;
            Write = symbol;
            LeftOrRight = endState;
        }

        public override string ToString()
        {
            return string.Format("Read {0}, Write {1} -> Go {2}",Read,Write,LeftOrRight);
        }
    }
}
