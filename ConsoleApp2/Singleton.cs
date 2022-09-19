using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace ConsoleApp2
{

    //一般的单例，但是当并发创建时，存在不同对象

    public sealed class Singleton
    {
        private static Singleton instance;

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }



    //泛型单例,在V5基础上进行的修改
    public abstract class Singleton<T>
    {
        private static readonly Lazy<T> _instance
          = new Lazy<T>(() =>
          {
              var ctors = typeof(T).GetConstructors(
                  BindingFlags.Instance
                  | BindingFlags.NonPublic
                  | BindingFlags.Public);
              if (ctors.Count() != 1)
                  throw new InvalidOperationException(String.Format("Type {0} must have exactly one constructor.", typeof(T)));
              var ctor = ctors.SingleOrDefault(c => c.GetParameters().Count() == 0 && c.IsPrivate);
              if (ctor == null)
                  throw new InvalidOperationException(String.Format("The constructor for {0} must be private and take no parameters.", typeof(T)));
              return (T)ctor.Invoke(null);
          });

        public static T Instance
        {
            get { return _instance.Value; }
        }
    }

    //防止多线程问题，但是不能保证单例被实例化的时机，例如存在不使用的情况下也被实例化了
    public sealed class SingletonV2
    {
        // 在静态私有字段上声明单例
        private static readonly SingletonV2 instance = new SingletonV2();

        // 私有构造函数，确保用户在外部不能实例化新的实例
        private SingletonV2() { }

        // 只读属性返回静态字段
        public static SingletonV2 Instance
        {
            get
            {
                return instance;
            }
        }
    }




    //使用锁机制保证单次被实例，这样能保证单例是在第一次使用的情况下被实例化
    //volatile修饰变量 ，保证当变量被修改时，会将值同步到其他线程
    public sealed class SingletonV3
    {
        // 依然是静态自动hold实例
        private static volatile SingletonV3 instance = null;
        // Lock对象，线程安全所用
        private static object syncRoot = new Object();

        private SingletonV3() { }

        public static SingletonV3 Instance
        {
            get
            {
                lock (syncRoot)
                {


                    if (instance == null)
                        instance = new SingletonV3();

                }

                return instance;
            }
        }
    }





    //使用了静态构造函数，保证了单例被使用前不会被实例化，即是在第一次被使用才会执行new()

    public class SingletonV4
    {
        // 因为下面声明了静态构造函数，所以在第一次访问该类之前，new Singleton()语句不会执行
        private static readonly SingletonV4 _instance = new SingletonV4();

        public static SingletonV4 Instance
        {
            get { return _instance; }
        }

        private SingletonV4()
        {
        }

        // 声明静态构造函数就是为了删除IL里的BeforeFieldInit标记
        //静态构造函数只执行一次
        static SingletonV4()
        {
        }
    }


    //Lazy关键字是延迟化加载，就是当真正调用Instance获取实例时才会调用new SingletonV5()
    public class SingletonV5
    {
        // 因为构造函数是私有的，所以需要使用lambda
        private static readonly Lazy<SingletonV5> _instance = new Lazy<SingletonV5>(
            () => new SingletonV5());
        // new Lazy<Singleton>(() => new Singleton(), LazyThreadSafetyMode.ExecutionAndPublication);

        private SingletonV5()
        {
        }

        public static SingletonV5 Instance
        {
            get
            {
                return _instance.Value;
            }
        }



        public void say()
        {

            Console.WriteLine("V5");
        }
    }


    class MySingleton : Singleton<MySingleton>
    {
        int _counter;

        public int Counter
        {
            get { return _counter; }
        }

        private MySingleton()
        {
            _counter = 0;
        }

        public void IncrementCounter()
        {
            Interlocked.Increment(ref _counter);
        }
    }





}
