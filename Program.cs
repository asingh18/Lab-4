using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Program
    {
        private static Random numgen = new Random();
        static void Main(string[] args)
        {
            LinkedList<Primal> Values = new LinkedList<Primal>();

            //[15 pts] Fill your list with 100 Primals with random Values in the range 1-100
            for (int i = 0; i < 100; i++)
            {
                Primal hundered = new Primal(); //Making a new node in my linked list
                hundered.Value = (uint)numgen.Next(1,101);//Rnd num is being set to hundered.Value .Value goes into struct and grabs value and sets hundered = to Value in the struct. Like a property of my struct
                //[5 pts] Iterate through your list, and call Factor (see below) on each element to fill in 
                //its vector of factors.
                hundered = Factor(hundered);//Sending the value to factor
                Values.AddFirst(hundered);//Add onto the beg of the list my new generated number

            }

        

            //Get a sorted version of your List (you'll need to finish the Sort() code below
            LinkedListNode<Primal> SortedValues = Sort(Values.First);
            while(SortedValues != null)
            {
                Console.WriteLine(SortedValues.Value.ToString());
                SortedValues = SortedValues.Next;//moving the list forward
            }

            //[10 pts] Iterate through your new thing (now a Node, not a List), and print it out (including
            //List of Factors and its Primality.  You must use the ToString() method you created in the Primal Struct
            //(other file).

            Console.WriteLine();
            Console.Write("< ----Press Return---- >");
            Console.ReadLine();
        }

        
        //[30 pts] Fill the "Factors" list with the Prime Factors of Value.
        //Also set the Primality to the appropriate value/
        //The prime factors of 8 are (2,2,2) (1 is not prime).  
        //The prime factors of 7 are (7), of 12 are (2,2,3) (note sorted)
        //A prime number has exactly one prime factor, all others are composite
        //Replace my non-functioning code below, but keep signature
        static Primal Factor(Primal p)
        {
            p.Factors = new List<uint>();
            p.Primality = Primality.Unknown;

            uint primes = 0;
            uint total = 0;

            total = p.Value;// without this itll show all ones.

            for (uint div = 2; div <= total; div++)
            {
                while (total % div == 0)
                {
                    total /= (div);//
                    p.Factors.Add(div);
                    primes++;//adds one everytime a prime factor is seen
                    
                }
            }
          

            if(primes > 1)
            {
                p.Primality = Primality.Composite;//iF more than 2 factors its composite prime
            }
            else if(primes == 1)
            {
                p.Primality = Primality.Prime;
            }
            else
            {
                p.Primality = Primality.Unknown;
            }

            return p;
        }

            //** Make sure you sort your factors in ascending order!! (That's easy on a vector)
            // -10 if you do not (but I don't really care how you manage to do it).



        //[30 pts] Implement an Insertion sort on a List!  (Sort by Value, Increasing)
        //***NB: YOU MAY NOT DESTROY OR REPLACE NODES!  JUST REARRANGE THEM.
        static LinkedListNode<Primal> Sort(LinkedListNode<Primal> Head)
        {
            LinkedList<Primal> SortedList = new LinkedList<Primal>();
            LinkedListNode<Primal> Current = null;

            if(Head != null)
            {
                SortedList.AddFirst(Head.Value);
            }

            Head = Head.Next;

            Current = SortedList.First;

            while(Head != null)
            {
                if(Head.Value.Value <= Current.Value.Value)
                { 
                    SortedList.AddBefore(Current, Head.Value);
                    Head = Head.Next;
                    Current = SortedList.First;
                }
                else if(Current == SortedList.Last)
                {
                    SortedList.AddLast(Head.Value);
                }
                else
                {
                    Current = Current.Next;
                }

            }

            return SortedList.First;
        }
    }
}
