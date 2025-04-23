// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace ModsPlaygroundCS
{
    public class Recurse(int n)
    {
        private int maxResidue = n;

        public static void Main(string[] args)
        {
            /*
            suppose you have the typical {P_EPT_IDE_} where "_" represents a residue, Max residues are given as n.
            and you want to find the cartesian product/powerset of the residues up till a certain length, defined as m.
            Now let's consider the residues as a set of numbers, weighted individually. Suppose 1-3 residues are weighted 2, 2, 4 like in the example
            */
            int n = 3; //max residues
            int m = 3; //max length
            List<int> toPowerList = new List<int>();
            toPowerList.Add(2);
            toPowerList.Add(2);
            toPowerList.Add(4);
            var newList= Powerset(m, new List<List<int>>(), new List<int>(), toPowerList); 
            Console.WriteLine(newList.Count);
            for(int i = 0; i< newList.Count; i++) { Console.WriteLine("Set: " + i + " = " + string.Join(", ", newList[i])); } 



            /*    for (int i = 0; i < newList.Count; i++) //
                {
                    for (int j = 0; j < newList[i].Count; j++)
                    {
                           Console.WriteLine();
                    }
                }*/ 
        var newRes = Piset(m, 1, new List<int>(), toPowerList);
            Console.WriteLine(newRes);
            long sumOfProducts = 0;
            for (int i = 0; i < newList.Count;i++)
            {
                long setProduct = 1;
                for (int j = 0; j < newList[i].Count; j++)
                {
                    setProduct *= newList[i][j];
                }
                sumOfProducts += setProduct;
            }
            Console.WriteLine("Sum of products: " + (sumOfProducts));
        }

        public static List<List<int>> Powerset(int m, List<List<int>> result, List<int> subset, List<int> OG)
        {
            /* A good way to look at this method is through the lens of a 50/50 chance. If we start from a full set, can we remove elements from it such that
             * we consider a) not removed and b) removed subsets? Notice that we start from the top. So for a list of 3 in OG, we remove + add all 3 and decrement from OG each time
             * until we get to 0, where the running subset is counted. Then consider the list starting with (ALONG THE WAY FROM 3 TO 0) 2 and so on. 
             *
             */

            if (OG.Count == 0) {
                if (subset.Count <= m) // collect subset if valid and not already in result. Essentially, what conditions must exist if the subset is valid?
                { result.Add(new List<int>(subset)); }
                return result; 
            }

            int currentSite = OG[0]; //where OG[0] is the current residue. To add or not to add?
            //case 1: exclude current
            List<int> remaining = new List<int>(OG);
            remaining.RemoveAt(0);
            //recursively call the function w/o current integer.
             Powerset(m, result,subset, remaining); //var excludedrange = ...
            
            //case 2: include current
            //consider if adding current to set keeps length less or equal to m.
            if (subset.Count < m)  // Check if we can add one more element
            {
                List<int> include = new List<int>(subset);
                include.Add(currentSite); 
                Powerset(m, result, include, remaining);
            }
            //math max/math.min here.
            return result;
        }
        public static long Piset(int m, long result, List<int> subset, List<int> OG)
        {
            if (OG.Count == 0)
            {
                if (subset.Count <= m) // collect subset if valid and not already in result.
                                       // Essentially, what conditions must exist if the subset is valid?
                {
                    result += PI(subset);
                }
                return result;
            }

            int currentSite = OG[0]; //where OG[0] is the current residue. To add or not to add?
            //case 1: exclude current
            List<int> remaining = new List<int>(OG);
            remaining.RemoveAt(0);
            //recursively call the function w/o current integer.
            Piset(m, result, subset, remaining); //var excludedrange = ...

            //case 2: include current
            //consider if adding current to set keeps length less or equal to m.
            if (subset.Count < m)  // Check if we can add one more element
            {
                List<int> include = new List<int>(subset);
                include.Add(currentSite);
                Piset(m, result, include, remaining);
            }
            //math max/math.min here.
            return result;
        }
        /*
        //can we modify the above slightly to output a list of integers instead? How about just a single integer?
        // At what point does it integer overflow, and is it worthwhile to actually represent that? I don't believe so. .
        */

        public static int PI(List<int> x)
        {
            int product = 1;
            //helper method to output a single integer given a list.
            for (int i = 0; i < x.Count; i++)
            {
                //suppose no numbers are 0.
                product = product* x[i];
            }

            return product;
        }
    
    }
}