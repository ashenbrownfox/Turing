using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing
{
    public class TapeList<E>
    {
        private LinkedList<E> tape;
        //private ListIterator<E> iterator;
        private E itemRead;
        bool WentRight = false;
        bool WentLeft = false;

        public TapeList()
        {
            tape = new LinkedList<E>();
            
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

        /**
	     * Write an item to tape at the tape head.
	     * @param c the item to write to tape
	     * @return the updated tape
	     */
        
    }
}
