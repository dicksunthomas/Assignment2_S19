using System;
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
            List<int> arr = new List<int> { 1, 2, 3 };
            Console.WriteLine(balancedSums(arr));
            

            // Missing numbers
            Console.WriteLine("\n\nMissing numbers");
            int[] arr1 = { 11, 4, 11, 7, 13, 4, 12, 11, 10, 14 };
            int[] brr = { 11, 4, 11, 7, 3, 7, 10, 13, 4, 8, 12, 11, 10, 14, 12 };
            int[] r2 = missingNumbers(arr1, brr);
            displayArray(r2);
           

            // grading students
            Console.WriteLine("\n\nGrading students");
            int[] grades = { 73, 67, 38, 33 };
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
           return "NO";
        }

        // Complete the missingNumbers function below.
        static int[] missingNumbers(int[] arr, int[] brr)
        {
           
            return new int[1];
        } 
        // Complete the gradingStudents function below.
        static int[] gradingStudents(int[] grades)
        {
            return new int[1];
        }

        // Complete the findMedian function below.
        static int findMedian(int[] arr)
        {
            return 0;
            
        }

        // Complete the closestNumbers function below.
        static int[] closestNumbers(int[] arr)
        {
            return new int[1];
        }

        // Complete the dayOfProgrammer function below.
        static string dayOfProgrammer(int year)
        {

            return "";
            
        }
        
    }
}
