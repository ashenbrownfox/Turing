using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing
{
    /**
     * 
     * This class is to emulate a TapeList
     */
    public class TapeList<E>
    {
        private LinkedList<E> tape;
        //private ListIterator<E> iterator;
        private E itemRead;
        bool WentRight = false;
        bool WentLeft = false;
        StringBuilder sb;
        char[] infinitetape;
        int tape_position; 
        public TapeList()
        {
            tape = new LinkedList<E>();
            //itemRead = WentRight();
            sb = new StringBuilder();
            infinitetape = new char[50];
            for (int i = 0; i < infinitetape.Length; i++)
            {
                infinitetape[i] = '#';
            }
            tape_position = 16;
        }
        public void InitializeTape(string input_string)
        {
            char[] array_buffer = input_string.ToCharArray();
            for (int i = 0; i < array_buffer.Length; i++)
            {
                infinitetape[tape_position] = array_buffer[i];
                tape_position++;
            }
            tape_position = 16;
        }
        public int MoveLeft(){
            int pos = tape_position - 1;
            return pos;
        }

        public int MoveRight()
        {
            int pos = tape_position + 1;
            return pos;
        }
        public int StandStill()
        {
            return tape_position;
        }
        public void AppendTape(string s)
        {
            sb.Append(s);
        }
        public char ReadTape(int pos)
        {
            char current_content = infinitetape[pos];
            return current_content;
        }

        public void WriteTape(int pos, char c)
        {
            infinitetape[pos] = c;
        }
        /** 
         * Create a tape strand with a collection of items written to it in order, with the tape head set at the firs item.
	     * @param inputString the array of items to initialize the tape with
         * **/
        public TapeList(E[] inputString)
        {
            tape = new LinkedList<E>();
            foreach(var c in inputString) {
                tape.AddLast(c);
            }
        }

        /**
	     * Read out the item that is currently under the tape head.
	     * @return the item under the tape head
	     */
        public E read()
        {
            return itemRead;
        }

        public string DisplayTape()
        {
            string finaltape = new string(infinitetape);
            string tapecontent = sb.ToString();
            Console.WriteLine(finaltape);
            return finaltape;
        }
        /**
	     * Write an item to tape at the tape head.
	     * @param c the item to write to tape
	     * @return the updated tape
	     */
        
    }
}
