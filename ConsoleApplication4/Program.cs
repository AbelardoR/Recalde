using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thread4_Exp
{
    class Program
    {
        static long i;
        static int a, b, c, d;
        public static void Threadfunc1()
        {
            for (i = 0; i < 100000000; i++) ;
            y1 = 3*a;
            y2 = b*b;
            y3 = a*a;

            Console.writeline("Privet of thread {0}! ",
                Thread.currentThread.GetHasCode());
        }
        pirvate static void threadfunc2()
        {
            for (i = 0; i < 100000000; i++) ;
            y4 = y1+y2;
            y5 = c+d;

            Console.writeline("Privet of thread {0}! ",
                Thread.currentThread.GetHasCode());
        }
        pirvate static void threadfunc3()
        {
            for (i = 0; i < 100000000; i++) ;
            y6 = y4/y5;
            y7 = c/y3;

            Console.writeline("Privet of thread {0}! ",
                Thread.currentThread.GetHasCode());
        }
        pirvate static void threadfunc4()
        {
            for (i = 0; i < 100000000; i++) ;
            y8 = y6-y7;
            Console.writeline("Privet of thread {0}! ",
                Thread.currentThread.GetHasCode());
        }
        public static void CheckTime(object state)
        {
            Console.WriteLine(DateTime.Now);
        }
        static void main(string[] args)
        {
            int y;
            a=10; b=7;
            c=15; d=3;
            TimerCallback tc = new TimeCallback(CheckTime);
            Thread thread1 = new Thread(new ThreadStart(Program.Threadfunc1));
            Thread thread2 = new Thread(new ThreadStart(Program.Threadfunc2));
            Thread thread3 = new Thread(new ThreadStart(Program.Threadfunc3));
            Thread thread4 = new Thread(new ThreadStart(Program.Threadfunc4));
            Timer t = new timer(tc, null, 0, 1000);

            Console.WriteLine("thread1.ThreadState=" + thread1.ThreadState);
            Console.WriteLine("thread2.ThreadState=" + thread2.ThreadState);
            Console.WriteLine("thread3.ThreadState=" + thread3.ThreadState);
            Console.WriteLine("thread4.ThreadState=" + thread4.ThreadState);
            thread1.start();
            thread2.start();

            Console.WriteLine("thread1.ThreadState=" + thread1.ThreadState);
            Console.WriteLine("thread2.ThreadState=" + thread2.ThreadState);
            Console.WriteLine("thread3.ThreadState=" + thread3.ThreadState);
            Console.WriteLine("thread4.ThreadState=" + thread4.ThreadState);
            thread1.join();
            thread2.join();

            Console.WriteLine("new threads ending");
            Console.WriteLine("y1=" + y1);
            Console.WriteLine("y2=" + y2);

            thread3.start();
            thread4.Start();
            Console.WriteLine("thread1.ThreadState=" + thread1.ThreadState);
            Console.WriteLine("thread2.ThreadState=" + thread2.ThreadState);
            Console.WriteLine("thread3.ThreadState=" + thread3.ThreadState);
            Console.WriteLine("thread4.ThreadState=" + thread4.ThreadState);
           
            thread3.join();
            thread4.join();

            Console.WriteLine("new threads ending");
            Console.WriteLine("y3=" + y3);
            Console.WriteLine("y4=" + y4);

            Thread.sleep(2000);
            y = y3 + y4;
            Console.WriteLine("y=" + y);
            t.dispose();
            Console.ReadLine();
        }
    }
}