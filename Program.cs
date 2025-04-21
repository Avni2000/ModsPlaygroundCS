// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace Program
{
    public class recurse(int n)
    {
        private int maxResidue = n;

        public static void Main(string[] args)
        {
            /*suppose you have the typical {P_EPT_IDE_} where "_"represents a residue, Max residues are given as n. 
            and you want to find the cartesian product/powerset of the residues up till a certain length, defined as m.
            Now let's consider the residues as a set of numbers, weighted individually. Suppose 1-3 residues are weighted 2, 2, 4 like in the example
             */
            int n = 3; //max residue
            int m = 2; //max length
            List<int> toPowerList = new List<int>();
            toPowerList.Add(2);
            toPowerList.Add(2);
            toPowerList.Add(4);
            WeightedPowerset(2, toPowerList, new List<List<int>>());
        }


        public static List<List<int>> WeightedPowerset (int m, List<int> toPowerList, List<List<int>> result) 
        {
            //quick note: List.addAll = List.addRange.
            
            //we start with the empty set result, toPowerList should be full before recursive cases.
            if (toPowerList.Count == 0)
            {
                return result;
            }
            int current = toPowerList[0];
            //case 1: exclude current
            List<int> remaining = new List<int>(toPowerList);
            remaining.Remove(current);
            //recursively call the function w/o current integer.
            result.AddRange(WeightedPowerset(m, remaining, result)); //essentially removing from toPowerList
            //exclude contains all possible sets wherein current is NOT included.

            //case 2: include current
            //consider if adding current to set keeps length less or equal to m.
            List<int> include = new List<int>(toPowerList);
            include.Add(current);
            if (include.Count <= m) //note that the only way to add to empty set 
            {
                result.AddRange(WeightedPowerset(m, toPowerList,result));

            }
            else
            {
                //if the length of the set exceeds m, we need to remove the last element added.
                include.RemoveAt(include.Count - 1);
                result.AddRange(WeightedPowerset(m, include, result));
            }

            return result; 
        }

        //can we modify the above slightly to output a list of integers instead? How about just a single integer? 
        // At what point does it integer overflow, and is it worthwhile to actually represent that? I don't believe so. .
        public static int cartesianProd(int m, List<int> toPowerList, int result)
        {
            
            /*
             *We don't need any other changes than those done to return methods.
             *
             */


            //we start with the empty set result, toPowerList should be full before recursive cases.
            if (toPowerList.Count == 0)
            {
                return result;
            }
            int current = toPowerList[0];
            //case 1: exclude current
            List<int> remaining = new List<int>(toPowerList);
            remaining.Remove(current);
            //recursively call the function w/o current integer.
            var exclude = (WeightedPowerset(m, remaining, result)); //essentially removing from toPowerList
            //exclude contains all possible sets wherein current is NOT included.
            
            //case 2: include current
            //consider if adding current to set keeps length less or equal to m.
            List<int> include = new List<int>(toPowerList);
            include.Add(current);
            if (include.Count <= m) //note that the only way to add to empty set 
            {
                include = (WeightedPowerset(m, toPowerList, include));

            }
            else
            {
                //if the length of the set exceeds m, we need to remove the last element added.
                include.RemoveAt(include.Count - 1);
                int other =  (WeightedPowerset(m, include, ));
            }

            return 


        }

        public static int PI(List<int> x)//The method name has nothing to do with it, apparently uppercase PI is also the viscous stress tensor and I thought that was cool.
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