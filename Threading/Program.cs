/* Author: Reily Stanford
 * Date: 10/26/2020
 * File: Program.cs
 * Description:
 *      This is the main driver for the program, it creates a list of Thread objects
 *      and a list of FindPiThread objects that will be used to run multiple instances 
 *      of FindPiThread's throwDarts function. This will then give us a calculated 
 *      pi based on the functionality of throwDarts.
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Threading
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            int throwDarts = 0;
            int threadCount = 0;
            int hitDarts = 0;
            Console.Write("Enter a Number of Darts to Throw at a Dart Board: ");
            throwDarts = Convert.ToInt32(Console.ReadLine());
            Console.Write("How Many Threads Should Be Run: ");
            threadCount = Convert.ToInt32(Console.ReadLine());

            List<Thread> threads = new List<Thread>(threadCount);
            List<FindPiThread> piThreads = new List<FindPiThread>(threadCount);

            for(int i = 0; i < threadCount; i++)
            {
                FindPiThread piThread = new FindPiThread(throwDarts);
                piThreads.Add(piThread);
                Thread newThread = new Thread(new ThreadStart(piThread.throwDarts));
                threads.Add(newThread);
                newThread.Start();
                Thread.Sleep(16);
            }

            for(int i = 0; i < threads.Count; i++)
            {
                threads[i].Join();
            }

            for(int i = 0; i < piThreads.Count; i++)
            {
                hitDarts += piThreads[i]._hitDarts;
            }

            Console.WriteLine($"Hit Darts: {hitDarts}");
            Console.WriteLine($"Thrown Darts: {throwDarts}");

            double pi = 4.0 * ((double)hitDarts / ((double)throwDarts * (double)threadCount));
            Console.WriteLine(pi);

        }
    }
}
