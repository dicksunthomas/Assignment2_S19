//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Assignment2_S19
//{
//    class Class1
//    {
//        static void Main(string[] args)
//        {
//            int[] a = { 1, 2, 3, 4, 5 };
//            int d = 4;
//            Rotate(a, d);
            
//        }
//        public static void Rotate( int[] array, int count)
//        {
//            if (array == null || array.Length < 2) return array;
//            count %= array.Length;
//            if (count == 0) return array;
//            int left = count < 0 ? -count : array.Length + count;
//            int right = count > 0 ? count : array.Length - count;
//            if (left <= right)
//            {
                
//                for (int i = 0; i < right; i++)
//                {
//                    var temp = array[array.Length - 1];
//                    Array.Copy(array, 0, array, 1, array.Length - 1);
//                    array[0] = temp;
//                }
//            }
//            else
//            {
//                for (int i = 0; i < left; i++)
//                {
//                    var temp = array[0];
//                    Array.Copy(array, 1, array, 0, array.Length - 1);
//                    array[array.Length - 1] = temp;
//                }
//            }
//            displayArray(array);
//            Console.ReadKey();
//        }
//        static void displayArray(int[] arr)
//        {
//            Console.WriteLine();
//            foreach (int n in arr)
//            {
//                Console.Write(n + " ");
//            }
//        }
//    }
//    }
