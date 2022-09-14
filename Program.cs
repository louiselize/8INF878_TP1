// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Threading;
using System;
using static Environment;

namespace ThreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment ev = new Environment();
            ev.displayMap();

            Console.WriteLine("Main Thread Started");
            //Creating Threads
            Thread t1 = new Thread(Method1)
            {
                Name = "Thread_Environment"
            };
            Thread t2 = new Thread(Method2)
            {
                Name = "Thread_Agent"
            };

            //Executing the methods
            t1.Start();
            t2.Start();
            Console.WriteLine("Main Thread Ended");
            //Console.Read();
        }
        static void Method1()
        {
            /*
            Console.WriteLine("Method1 Started using " + Thread.CurrentThread.Name);
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method1 :" + i);
            }
            Console.WriteLine("Method1 Ended using " + Thread.CurrentThread.Name);*/
        }
        static void Method2()
        {
            /*Console.WriteLine("Method2 Started using " + Thread.CurrentThread.Name);
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method2 :" + i);
                if (i == 3)
                {
                    Console.WriteLine("Performing the Database Operation Started ");
                    //Sleep for 10 seconds
                    //Thread.Sleep(10000);
                    Console.WriteLine("Performing the Database Operation Completed");
                }
            }
            Console.WriteLine("Method2 Ended using " + Thread.CurrentThread.Name);
            */

        }
        
    }
}