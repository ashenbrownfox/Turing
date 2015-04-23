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
        public string Start { get; private set; }
        public char Read { get; private set; } //char
        public char Write { get; private set; }
        public char LeftOrRight { get; private set; }
        public string Next { get; private set; }

        public Transition(string start, char read, char write, char lr,string endState)
        {
            Start = start;
            Read = read;
            Write = write;
            LeftOrRight = lr;
            Next = endState;
        }

        public override string ToString()
        {
            return string.Format("Start: {0} Read {1}, Write {2} Go {3} -> Next {4}  ",Start,Read,Write,LeftOrRight,Next);
        }
    }
}
