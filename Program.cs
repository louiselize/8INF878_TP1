// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Collections;
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
            /*int iteration = 0;*/

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
            bool wait = true;
            Console.WriteLine("Method1 Started using " + Thread.CurrentThread.Name);
            while (true)
            {
                
                ev.Generate();
                Map map = ev.GetMap();
                /* ------ TO TEST SUCK AND COLLECT ------ */
                /*
                map.Suck(1,0);
                map.Suck(2,0);
                map.Suck(3,0);
                map.Suck(4,0);
                
                map.Collect(1,0);
                map.Collect(2,0);
                map.Collect(3,0);
                map.Collect(4,0);*/
                
                
                Console.WriteLine();  
                //Console.WriteLine(); 

                Thread.Sleep(6000);
                /*if(!wait){
                    ev.UpdatePerformance();
                    Console.WriteLine("Perf : " + ev.GetPerformance()); 
                    wait = true;
                }

                wait=false;*/

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
            LearnFromInformed learnFromInformed = new LearnFromInformed(map.GetNumberOfRows(),map.GetNumberOfColumns());
            int waitingTimeInterval = 10000;
            int iterationForLearning = 0 ; //to have an average
            ArrayList performanceList = new ArrayList();
            int performanceMean = 0;

            Thread.Sleep(1000);

            while (true)
            {
                //Console.WriteLine((learnFromInformed.GetMillisecondsToWait()-waitingTimeInterval) / 10000);
                
                //map = ev.GetMap();
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
                //ev.GetMap().GetMap()[2][2]["DIRT"] = true;

                if(ev.GetUninformedSearchTime()){
                    Console.WriteLine("------------ UNINF -------------");
                    agent.AgentDoYourJob(uninformed, ev);
                }
                
                else if(ev.GetInformedSearchTime()){
                    Console.WriteLine("------------ INF -------------");
                    agent.AgentDoYourJob(informed, ev);
                }

                else{
                    
                    Console.WriteLine("------------ LEARN -------------");
                    Console.WriteLine("Number of actions : " + learnFromInformed.GetNumberOfActions() + " | Number of milliseconds to wait : " + learnFromInformed.GetMillisecondsToWait());
                    agent.AgentDoYourJob(learnFromInformed,ev);

                    performanceList.Add(ev.GetPerformance());

                    
                    if(iterationForLearning==10){

                        //calculates mean
                        foreach(int perf in performanceList){
                            performanceMean += perf;   
                        }
                        performanceMean = performanceMean / performanceList.Count;

                        learnFromInformed.UpdatePerformanceData((learnFromInformed.GetMillisecondsToWait()-waitingTimeInterval) / 10000 ,performanceMean);

                        //put value in their initial state
                        performanceList = new ArrayList();
                        performanceMean=0;
                        iterationForLearning=0;

                        //add one more action to do
                        learnFromInformed.SetNumberOfActions(learnFromInformed.GetNumberOfActions()+1);

                        //reinitialise our map
                        ev.GetMap().MakeMapClean();

                        //new line in our performance array (change of waiting time between actions)
                        if(learnFromInformed.GetNumberOfIterationsToLearn()+1==learnFromInformed.GetNumberOfActions()){
                            learnFromInformed.SetNumberOfActions(1);
                            learnFromInformed.SetMillisecondsToWait(learnFromInformed.GetMillisecondsToWait()+waitingTimeInterval);

                            //end of learning, array full
                            if((learnFromInformed.GetMillisecondsToWait()-waitingTimeInterval) / 10000 == learnFromInformed.GetEndOfLearning()){
                                Console.WriteLine("END OF LEARNING");
                                return;
                            }

                        }

                        learnFromInformed.DisplayPerformanceData();
                        performanceList.Clear();
                    }

                    iterationForLearning++;
                }
                
                
                ev.SetIteration(ev.GetIteration()+1);     
                //iteration++;

                
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