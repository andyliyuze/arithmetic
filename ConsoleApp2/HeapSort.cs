
using System;
using System.Collections.Generic;

public class HeapSort
{
    //堆排序
    public static void Sort(List<int> list)
    {
      //  HeapAdjust(list, 0, list.Count);

        //首先构造大顶堆，即每个父节点都大于它的子节点
        for (int i = list.Count / 2 - 1; i >= 0; i--)
        {
            Console.WriteLine("调整");
            HeapAdjust(list, i, list.Count);
        }
        //进行调整，保持为大顶堆，那么最大值就会上浮到顶点位置
        for (int i = list.Count - 1; i >= 0; i--)
        {
            int temp = list[0];
            list[0] = list[i];
            list[i] = temp;
            HeapAdjust(list, 0, i);
        }    
    }
    //一次调整完成，以parnet为根节点的二叉树,parent代表的值会下沉到该树的合适位置，从而继续保持为大顶堆
    static void HeapAdjust(List<int> list, int parent, int length)
    {

        int temp = list[parent];
        //child为左子节点索引
        int child = 2 * parent + 1;
        //其实表示需要进行几次调整，就是父节点往下的深度，从上往下调整，只会往一边向下调整，要么往左要么往右
        while (child < length)
        {
            //先比较两个子节点哪个大，若右节点大，则child++
            if (child + 1 < length && list[child] < list[child + 1]) child++;
            //取值大的子节点与父节点比较
            if (temp >= list[child]) break;
            //若执行到这行代码，说明父节点比子节点小，因此被调整的父节点需要继续与下面的子节点继续比较
            list[parent] = list[child];
            //找到需要继续比较的子节点的索引
            parent = child;
            child = 2 * parent + 1;
        }

        list[parent] = temp;
    }

    public static void swap(int[] arr, int i, int len)
    {

        int temp = arr[i];

        arr[i] = arr[len];

        arr[len] = temp;

    }



}