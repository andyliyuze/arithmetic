
using System;
namespace ConsoleApp2
{
   public class QuickSort
    {


       
       
        /**一次排序单元，完成此方法，key左边都比key小，key右边都比key大。
          
 
        **@param array排序数组 
          
 
        **@param low排序起始位置 
          
 
        **@param high排序结束位置
          
 
        **@return单元排序后的数组 */
        private static int sortUnit(int[] array, int low, int high)
        {

            //在array[low]处挖坑
            int key = array[low];
            while (low < high)
            {
                /*从后向前搜索比key小的值*/
                while (array[high] >= key && high > low)
                {
                    --high;
                }
                /*比key小的放左边*/
                //在array[low]填坑,并在array[high]处挖坑
                if (high > low)
                {
                    array[low] = array[high];
                    low++;
                }
               
               
                /*从前向后搜索比key大的值，比key大的放右边*/
                while (array[low] <= key && high > low)
                {
                    ++low;
                }
                /*比key大的放右边*/
                //在array[high]填坑,并在array[low]处挖坑
                if (high > low)
                {
                    array[high] = array[low];
                    high--;
                }
            }
            /*左边都比key小，右边都比key大。//将key放在游标当前位置。//此时low等于high */
            array[low] = key;
            foreach (int i in array)
            {
                Console.Write("{0}\t", i);
            }
            Console.WriteLine();
       
            return low;
        }
        /**快速排序 
        *@paramarry 
        *@return */

        public static void sort(int[] array, int low, int high)
        {
            //因为数组是引用类型，所以不用返回新的数组
            //以下算法是先对对比数左边进行递归遍历，对左边排序，然后在对右边递归，右边排序
            //递归结束条件是左边下标大于右边下边

            if (low >= high)
                return;
            /*完成一次单元排序*/
            int index = sortUnit(array, low, high);
            /*对左边单元进行排序*/
            sort(array, low, index-1);
            /*对右边单元进行排序*/
            sort(array, index + 1, high);
        }


        //快速排序适合越乱越好的数组

        //一次哨兵落定的算法
        //1选择哨兵，一般为索引为0的元素，此时哨兵位置也是坑
        //2从末到前找，找比哨兵小的数字，找到后放在坑上。此时该位置就成了坑。
        //3从哨兵的后一位从前往后找，找到比哨兵大的数字。找到后放在坑上，此时该位置就成了坑。
        //4重复以上的找法。也是从后往前开始，从没经历过的位置开始，一直到只剩下最后一个元素。
        //5最后一个坑的位置就是哨兵最后落定的位置。
        //6此时已经完成了一次排序，哨兵左边都是比它小的，右边都是比它大的。
       
        //根据上一次哨兵最终位置索引，使用相同算法进行最递归与右递归。
        //完成最终的排序。
    }
}