using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
   public class BubbleSort
    {

        private static void swap(int[] array, int i, int j)
        {

            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;


        }

        public static void sort(int[] array)
        {

            for (int i = 0; i <= array.Length; i++)
            {
                for (int j = 0; j <array.Length - i; j++)
                {


                    if (array[j] < array[j + 1])
                    {


                        swap(array, j, (j + 1));
                    }


                }




            }
        }



        public static void   CocktailSort(int[] A, int n)
        {
            int left = 0;                            // 初始化边界
            int right = n - 1;
            while (left < right)
            {
                for (int i = left; i < right; i++)   // 前半轮,将最大元素放到后面
                {
                    if (A[i] > A[i + 1])
                    {
                        swap(A, i, i + 1);
                    }
                }
                right--;
                for (int i = right; i > left; i--)   // 后半轮,将最小元素放到前面
                {
                    if (A[i - 1] > A[i])
                    {
                        swap(A, i - 1, i);
                    }
                }
                left++;
            }
        }

    }
}
