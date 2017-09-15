
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
            int key = array[low];
            while (low < high)
            {
                /*从后向前搜索比key小的值*/
                while (array[high] >= key && high > low)
                {
                    --high;
                }
                /*比key小的放左边*/
                array[low] = array[high];
                /*从前向后搜索比key大的值，比key大的放右边*/
                while (array[low] <= key && high > low)
                {
                    ++low;
                }
                /*比key大的放右边*/
                array[high] = array[low];
            }
            /*左边都比key小，右边都比key大。//将key放在游标当前位置。//此时low等于high */
            array[low] = key;
            foreach (int i in array)
            {
                Console.Write("{0}\t", i);
            }
            Console.WriteLine();
       
            return high;
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
            sort(array, low, index - 1);
            /*对右边单元进行排序*/
            sort(array, index + 1, high);
        }
    }
}