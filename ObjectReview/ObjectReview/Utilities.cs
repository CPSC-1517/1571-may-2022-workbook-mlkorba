using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public static class Utilities
    {
        //Static classes are NOT instantiated or represented by the outside user (developer)
        //Static class items are referenced using the Classname.xxxxx
        //Methods within this class have the keyword 'static' in their signature
        //Static classes are shared between all outside user at the SAME time
        //DO NOT consider saving data within a static class because you cannot be
        //  certain it will be there went you use that class again
        //Consider placing GENERIC re-usable methods within a static class

        //Sample of overloaded methods
        //The method signatures are different
        public static bool IsZeroPositive(int value)
        {
            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }
        public static bool IsZeroPositive(double value)
        {
            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }
        public static bool IsZeroPositive(decimal value)
        {
            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }
    }
}