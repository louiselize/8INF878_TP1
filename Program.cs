// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Threading;
using System;
using static Environment;
using static Map;
using static Items;
using static Uninformed;
using static Informed;

namespace ThreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment ev = new Environment();

            Console.WriteLine("Main Thread Started");
            //Creating Threads
            Thread t1 = new Thread(EnvironmentMethod)
            {
                Name = "Thread_Environment"
            };
            Thread t2 = new Thread(AgentMethod)
            {
                Name = "Thread_Agent"
            };

            //Executing the methods
            t1.Start(ev);
            t2.Start(ev);
            Console.WriteLine("Main Thread Ended");
            //Console.Read();
        }
        static void EnvironmentMethod(Object environment)
        {
            Environment ev = (Environment) environment;
            Console.WriteLine("Method1 Started using " + Thread.CurrentThread.Name);
            while (true)
            {
                
                ev.Generate();
                Map map = ev.GetMap();
                /* ------ TO TEST SUCK AND COLLECT ------ */
                map.Suck(1,0);
                map.Suck(2,0);
                /*map.Suck(3,0);
                map.Suck(4,0);
                
                map.Collect(1,0);
                map.Collect(2,0);
                map.Collect(3,0);
                map.Collect(4,0);*/
                
                
                Console.WriteLine("Perf : " + ev.GetPerformance()); 
                Console.WriteLine();  
                Console.WriteLine();      

                Thread.Sleep(4000);

            }
            Console.WriteLine("Method1 Ended using " + Thread.CurrentThread.Name);
        }

        static void AgentMethod(Object environment)
        {
            Environment ev = (Environment) environment;
            Map map = ev.GetMap();
            Agent agent = new Agent();
            Uninformed uninformed = new Uninformed(map.GetNumberOfRows(),map.GetNumberOfColumns());
            Informed informed = new Informed(map.GetNumberOfRows(),map.GetNumberOfColumns());

            while (true)
            {
                
                Thread.Sleep(5000);
                map = ev.GetMap();
                //to test if map is cleaned
                //Console.WriteLine("is cleaned" + map.IsMapClean());
                
                /*map.Suck(1,0);
                map.Suck(2,0);
                map.Suck(3,0);
                map.Suck(4,0);
                
                map.Collect(1,0);
                map.Collect(2,0);
                map.Collect(3,0);
                map.Collect(4,0);
                
                map.Suck(1,1);
                map.Suck(2,1);
                map.Suck(3,1);
                map.Suck(4,1);
                
                map.Collect(1,1);
                map.Collect(2,1);
                map.Collect(3,1);
                map.Collect(4,1);

                map.Suck(1,2);
                map.Suck(2,2);
                map.Suck(3,2);
                map.Suck(4,2);
                
                map.Collect(1,2);
                map.Collect(2,2);
                map.Collect(3,2);
                map.Collect(4,2);*/

                agent.AgentDoYourJob(map, uninformed, ev);

                
                /*
                -------- TO TEST CELL TO COLLECT AND SUCK ---------
                Console.WriteLine("to collect");
                foreach(int [] element in sensor.getCellsToCollect()){
                    Console.WriteLine(element[0] + " " + element[1]);
                }

                Console.WriteLine("to suck");
                foreach(int [] element in sensor.getCellsToSuck()){
                    Console.WriteLine(element[0] + " " + element[1]);
                }*/

                //ObserveEnvironmentWithAllMySensors()
                //UpdateMyState()
                //ChooseAnAction()
                //justDoIt()
            }
            
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