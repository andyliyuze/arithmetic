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

        //1正序，每一趟都将最大值放在最后
        //2每趟都是取前两个进行比较
        //3往后每一趟比上一次少一次比较
        public static void sort(int[] array)
        {
            for (int i = 0; i <= array.Length; i++)
            {
                for (int j = 0; j <array.Length - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        swap(array, j, (j + 1));
                    }
                }
            }
        }


        //正序
        //1一大趟都两小趟，前一趟比较n次，得到最大值放在最后一位
        //2后一趟比较n-1次，从后往前比较，得出最小一位放在第一位
        //往后的每一大躺都比之前少两次。
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
