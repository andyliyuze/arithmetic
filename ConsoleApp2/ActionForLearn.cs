using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ConsoleApp2
{
    class ActionForLearn
    {
     
            static void Main2(string[] args)
            {
                Console.WriteLine("Hello World!");
                SQLConfig(x =>
                {
                    x.Password = "123";
                    x.UserName = "sa";
                });
                List<string> list = new List<string>(new string[] { "liyuze", "lisixiao" });
                list.Count2(a =>
                a == "liyuze"
                );

                var ss = list.Where2(a =>
                a == "liyuze"
                );

                //使用“，”将字符串数据进行拼接；
                var filter = string.Join(",", list);
            }



            //类似于CreateUsingRabbitMq方法，使用Action委托，扩展方法是一开始设计没有的，后来加进去的

            static void SQLConfig(Action<MessageConfig> action)
            {
                MessageConfig message = new MessageConfig();
                action(message);
                message.Login();
            }



        }


        public class MessageConfig
        {

            public string UserName { get; set; }
            public string Password { get; set; }

        }
        public static class extion
        {

            public static int Count2<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            {

                int num = 0;
                foreach (TSource local in source)
                {
                    if (predicate(local))
                    {
                        num++;
                    }
                }
                return num;
            }
            public static IEnumerable<TSource> Where2<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            {

                ICollection<TSource> num = new Collection<TSource>();
                foreach (TSource local in source)
                {
                    if (predicate(local))
                    {
                        num.Add(local);
                    }
                }
                return num;
            }

            public static bool Login(this MessageConfig message)
            {

                return true;
            }


        }
    
}
