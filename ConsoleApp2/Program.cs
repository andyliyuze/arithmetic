using System;
using System.Collections;
using System.Collections.Generic;
 
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //求两个有序数组的交集

            //Hashtable解法，将其中一个放入hash表
            Hashtable ht = new Hashtable
            {
                { Guid.NewGuid(), 1 }, //添加keyvalue键值对
                { Guid.NewGuid(), 3},
                { Guid.NewGuid(), 4 },
                { Guid.NewGuid(),6 }
            }; //创建一个Hashtable实例

            int[] arr = { 3, 4, 5, 6, 7, 10, 15, 50, 51, 52, 54, 55 };
            int[] arr2 = { 1, 2, 3, 4, 5, 9, 10, 11, 12, 50, 51, 52, 54 };

            LinkedList<int> list = new LinkedList<int>();
            int j = 0;
            foreach (int i in arr)
            {
                if (ht.ContainsValue(i))
                {
                    list.AddLast(i);

                }
                j++;

            }
            Console.WriteLine("时间复杂度：" + j + "");
            j = 0;
            list.Clear();
            int arrIndex = 0;
            int arr2Index = 0;
            while (arrIndex < arr.Length && arr2Index < arr2.Length)
            {
                if (arr[arrIndex] < arr2[arr2Index])
                {

                    arrIndex++;
                }
                else if (arr2[arr2Index] < arr[arrIndex])
                {

                    arr2Index++;
                }
                else
                {
                    list.AddLast(arr[arrIndex]);
                    arrIndex++;
                    arr2Index++;

                }
                j++;
            }

            j = 0;
            list.Clear();
            arrIndex = 0;
            arr2Index = 0;
            //索引递进法，双方数组从0处开始对比，相同就是交集，小的一方索引进1
            while (arrIndex < arr.Length && arr2Index < arr2.Length)
            {
                if (arr[arrIndex] < arr2[arr2Index])
                {

                    //  list.AddLast(arr[arrIndex]);
                    arrIndex++;
                }
                else if (arr2[arr2Index] < arr[arrIndex])
                {

                    //list.AddLast(arr2[arr2Index]);
                    arr2Index++;
                }
                else
                {
                    list.AddLast(arr[arrIndex]);
                    arrIndex++;
                    arr2Index++;

                }
                j++;
                //   double k = (double)5 / (double)2;  //‘/’取商，“%”取余

            }

            Console.WriteLine("时间复杂度：" + j + "");


            int key = 3;
            j = 0;

            //求有序数组的指定元素
            //二分法查找
            int beginIndex = 0;
            int endIndex = arr.Length - 1;
            int midIndex = (beginIndex + beginIndex) / 2;
            while (beginIndex <= endIndex)
            {
                midIndex = (beginIndex + endIndex) / 2;
                var value = arr[midIndex];
                if (value < key)
                {
                    beginIndex = midIndex + 1;


                }
                else if (value > key)
                {

                    endIndex = midIndex - 1;

                }
                else
                {
                    Console.WriteLine("找到了在：" + midIndex);
                    endIndex = -1;
                }
                j++;
            }
            Console.WriteLine("时间复杂度：" + j + "");




            //利用两个栈是，实现队列

            Equeue equeue = new Equeue();
            equeue.EnQueue(5);
            equeue.EnQueue(6);
            equeue.EnQueue(7);
             var o= equeue.DeQueue();
            o = equeue.DeQueue();
            equeue.EnQueue(8);
            o = equeue.DeQueue();
            Console.WriteLine("Hello World!");


            int[] array = { 49, 38, 65, 97, 76, 13, 27 ,2,1,100,11,50,49,65};
          int[] array2 = { 69,39,55,100,78,22,99 };
            QuickSort.sort(array2, 0, array2.Length - 1);
            Console.ReadLine();
          
        }
    }

    //只利用两个栈，实现一个队列

    //入队时，将元素压入s1。

   // 出队时，判断s2是否为空，如不为空，则直接弹出顶元素；如为空，则将s1的元素逐个“倒入”s2，把最后一个元素弹出并出队。

    class Equeue
    {
        public Equeue()
        {

            s1 = new Stack();
            s2 = new Stack();
        }

        private Stack s1;
        private Stack s2;


        public void EnQueue(object o)
        {
          
            s1.Push(o);
        }
        public object DeQueue()
        {
 
            if (s2.Count != 0) { return s2.Pop(); }
            else
            {
                while (s1.Count > 0)
                {
                    var item = s1.Pop();
                    s2.Push(item);
                }
                return  s2.Pop();
            }
        }
    }
}