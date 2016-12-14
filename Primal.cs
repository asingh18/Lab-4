using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public enum Primality
    {
        Composite, Prime, Unknown = -1
    }

    public struct Primal
    {
        public uint Value;
        public List<uint> Factors;
        public Primality Primality;

        //[10 pts] Add an appropriate ToString here...

        public override string ToString()
        {
            string p = null;

            foreach(uint i in Factors)
            {
                p = p + " " + i;
               
            }

            return "Values " + Value + " " + "|| " + "List of Factors: " + p + "|| " + " " +"Primality: " + Primality;



        }

    }
}
