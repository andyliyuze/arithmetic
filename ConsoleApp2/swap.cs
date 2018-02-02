using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
   public class swap
    {

       //异或运算  两个二进制数的每一位进行比较，如果相同则为0，不同则为1

        //结论任何一个变量与任何给定的值连续进行异或操作两次，值不变，即地址不变,因为异或符合交换律，两个相同的值进行异或运算得到0

         
        public static void execute(int a,int b)
        {
         

            //a现在的二进制值是a与b进行一次异或操作，属于中间状态
            a = a ^ b;
            //此操作是相当于中间状态再与b进行异或，即得到原来的a的地址的值
            b = a ^ b;
            //此操作相当于，中间状态与原来的a进行异或，即b连续与a进行异或两次，得到原来b的地址；
            a = a ^ b;
        }

        public static void execute2(int a, int b)
        {
            //两者差距
            a = b-a;
            //b减去两个差距
            b= b - a;
        }


    }
}
