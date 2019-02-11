﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2_S19
{
    class Program
    {
        static void Main(string[] args)
        {

            // left rotation
            Console.WriteLine("Left Rotation");
            int d = 4;
            int[] a = { 1, 2, 3, 4, 5 };
            int[] r = rotLeft(a, d);
            displayArray(r);


            // Maximum toys
            Console.WriteLine("\n\nMaximum toys");
            int k = 50;
            int[] prices = { 1, 12, 5, 111, 200, 1000, 10 };
            //int[] re = maximumToys(prices, k);
            Console.WriteLine(maximumToys(prices, k));
           

            // Balanced sums
            Console.WriteLine("\n\nBalanced sums");
            List<int> arr = new List<int> { 5, 3, 6, 8};
            Console.WriteLine(balancedSums(arr));
            

            // Missing numbers
            Console.WriteLine("\n\nMissing numbers");
            int[] arr1 = { 11, 4, 11, 7, 13, 4, 12, 11, 10, 14 };
            int[] brr = { 11, 4, 11, 7, 3, 7, 10, 13, 4, 8, 12, 11, 10, 14, 12 };
            int[] r2 = missingNumbers(arr1, brr);
            displayArray(r2);
           

            // grading students
            Console.WriteLine("\n\nGrading students");
            int[] grades = { 73, 66, 38, 33 };
            int[] r3 = gradingStudents(grades);
            displayArray(r3);
            
            // find the median
            Console.WriteLine("\n\nFind the median");
            int[] arr2 = { 0, 1, 2, 4, 6, 5, 3 };
            Console.WriteLine(findMedian(arr2));
            

            // closest numbers
            Console.WriteLine("\n\nClosest numbers");
            int[] arr3 = { 5, 4, 3, 2,1 };
            int[] r4 = closestNumbers(arr3);
            displayArray(r4);
           
            // Day of programmer
            Console.WriteLine("\n\nDay of Programmer");
            int year = 2017;
            Console.WriteLine(dayOfProgrammer(year));
            Console.ReadLine();
        }
        // This assignment was a bit challenging and got a experience of using hackerrank.
        //    -- Karthik
        static void displayArray(int[] arr)
        {
            Console.WriteLine();
            foreach (int n in arr)
            {
                Console.Write(n + " ");
            }
        }

        // Complete the rotLeft function below.
        static int[] rotLeft(int[] a, int d)
        {

            if (a == null || a.Length < 2) return a;
            d %= a.Length;
            if (d == 0) return a;
            int left = d < 0 ? -d : a.Length + d;
            int right = d > 0 ? d : a.Length - d;
            if (left <= right)
            {

                for (int i = 0; i < right; i++)
                {
                    var temp = a[a.Length - 1];
                    Array.Copy(a, 0, a, 1, a.Length - 1);
                    a[0] = temp;
                }
            }
            else
            {
                for (int i = 0; i < left; i++)
                {
                    var temp = a[0];
                    Array.Copy(a, 1, a, 0, a.Length - 1);
                    a[a.Length - 1] = temp;
                }
            }
            return a;
        }

        // Complete the maximumToys function below.
        static int maximumToys(int[] prices, int k)
        {
            int[] sorted = sortedArray(prices);
            int sum = 0, i;
            for (i = 0; i < sorted.Length; i++)
            {
                if (sum < k)
                {
                    sum += sorted[i];
                }
                else
                {
                    break;
                }
            }

            return i - 1;
        }
        static int[] sortedArray(int[] arr)
        {
            int min_position;
            // temp is used to conduct the swap during during the Selection Sort Algorithm
            int temp;

            for (int i = 0; i < arr.Length; i++)
            {
                // Here we initialize the min_position to the current index of array
                min_position = i;
                // From the min_position, check to see if the next element is smaller
                for (int x = i + 1; x < arr.Length; x++)
                {
                    // If the next element from the current min_position is smaller, then make that the new min_position
                    if (arr[x] < arr[min_position])
                    {
                        //min_position will keep track of the index that min is in, this is needed when a swap happens
                        min_position = x;
                    }
                } // End of inner for loop

                // If the min_position does not equal the current element being evaluated in the loop
                // Then execute the swap. by switching the postion of the lowest with the current element
                if (min_position != i)
                {
                    temp = arr[i];
                    arr[i] = arr[min_position];
                    arr[min_position] = temp;
                }
                //Console.Write("  " + prices[i]);
            } // End of outer for loop
            return arr;
        }
        // Complete the balancedSums function below.
        static string balancedSums(List<int> arr)
        {
            int sum = 0, leftsum = 0;
            //this loop will give us the sum of all variables in the array
            for (int i = 0; i < arr.Count; ++i)
                sum += arr[i];
            // this loop will decrease each item from the sum and compare with the left sum till sum is equal to left sum
            for (int i = 0; i < arr.Count; ++i)
            {

                // sum is now right sum 
                // for index i 
                sum -= arr[i];

                if (leftsum == sum)
                    return "YES";

                leftsum += arr[i];
            }

            /* If no equilibrium index found,  
            then return 0 */

            return "NO";
        }

        // Complete the missingNumbers function below.
        static int[] missingNumbers(int[] arr, int[] brr)
        {
            // Converted the array values to a dictonary with key value pairs where key is a array item and value is its frequency
            //using ConvertDictonary function
            Dictionary<int, int> arrd = convertDictonary(arr);
            Dictionary<int, int> brrd = convertDictonary(brr);
            // Initializing a new array list for missing elements
            ArrayList miss = new ArrayList();
            // In this loop we compare both dictonary key and value and missing elements will get added into the array list
            foreach (var pair in brrd)
            {
                if (arrd.TryGetValue(pair.Key, out int value))
                {
                    if (value != pair.Value)
                    {
                        miss.Add(pair.Key);
                    }
                }
                else
                {
                    miss.Add(pair.Key);
                }
            }
            return miss.OfType<int>().ToArray();
        }
        // Function for converting array to dictonary
        public static Dictionary<int, int> convertDictonary(int[] arrD)
        {
            return arrD.GroupBy(c => c)
                       .OrderBy(c => c.Key)
                       .ToDictionary(grp => grp.Key, grp => grp.Count());
        }
        // Complete the gradingStudents function below.
        static int[] gradingStudents(int[] grades)
        {
            int multiple = 5;
            List<int> rs = new List<int>();
            for (int i = 0; i < grades.Length; i++)
            {
                int rem = grades[i] % multiple;
                // This loop will check whether the grade can be rounded off or not
                if (grades[i] >= 38 && rem > 2)
                {
                    int result = grades[i] - rem;
                        result += multiple;
                    rs.Add(result);
                }
                else
                {
                    rs.Add(grades[i]);
                }
            }
            return rs.OfType<int>().ToArray();
        }

        // Complete the findMedian function below.
        static int findMedian(int[] arr)
        {
            arr = sortedArray(arr);
            int median = 0;
            if (arr.Length % 2 == 0)
            {
                median = (arr[arr.Length / 2] + arr[(arr.Length / 2) + 1]) / 2;
            }
            else
            {
                median = arr[arr.Length / 2];
            }
            return median;
        }

        // Complete the closestNumbers function below.
        static int[] closestNumbers(int[] arr)
        {
            sortedArray(arr);
            Dictionary<int[], int> arr1 = new Dictionary<int[], int>();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int diff = 0;

                diff = arr[i + 1] - arr[i];
                int[] qq = { arr[i], arr[i + 1] };
                arr1.Add(qq, diff);

            }
            var mn = arr1.Min(x => x.Value);
            Console.WriteLine("mn " + mn);
            ArrayList finalre = new ArrayList();
            var fr = arr1.Where(x => x.Value == mn).ToList();
            Console.WriteLine("Length " + fr.Count());
            foreach (var item in fr)
            {
                foreach (var k in item.Key)
                {
                    finalre.Add(k);
                }
            }

            return finalre.OfType<int>().ToArray();
        }

        // Complete the dayOfProgrammer function below.
        static string dayOfProgrammer(int year)
        {
            if (year <= 1917)
            {
                if (year % 4 == 0)
                {
                    return "12.09." + year;
                }
                else
                {
                    return "13.09." + year;
                }
            }
            else if (year == 1918)
            {
                return "26.09." + year;
            }
            else
            {
                if (year % 400 == 0 || year % 4 == 0 && year % 100 != 0)
                {
                    return "12.09." + year;
                }
                else
                {
                    return "13.09." + year;
                }
            }

        }


        
    }
}
