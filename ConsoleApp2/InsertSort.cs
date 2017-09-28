using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
   public class InsertSort
    {


        //整体思路：将元素插入到有序集合里
        //单步操作：首先将第一个元素看成有序的，从第二个元素作为需要插入的元素，从排好序的集合的最末开始遍历，找到一个比其小的元素，
        //假如比其大，则被比较元素的位置往后移一位，假如比其小，则被比较元素的位置不变，该需要插入的元素的位置为被比较的元素的位置+1
        //遍历完毕，则完成排序


        public static void Sort(int[] arr)
        {


           
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                //只有在待插入元素小于已排好序的集合的最大值才需要插入排序，否则直接将其放置最后，即不需遍历操作就可；           
                int j = i - 1;
                while (temp < arr[j] && j >= 0)
                {

                    arr[j + 1] = arr[j];
                    j--;

                }
                arr[j + 1] = temp;
            }
        }
    }
}
