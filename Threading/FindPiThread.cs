/* Author: Reily Stanford
 * Date: 10/26/2020
 * File: FindPiThread.cs
 * Description:
 *      This file houses FindPiThread including its local variables, an accessor
 *      for one of the variables, a constructor for the class, and a function to
 *      simulate throwing darts at a dart board.
 */

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Threading
{
    class FindPiThread
    {
        private int totalDarts;
        private int hitDarts = 0;
        private Random rng;

        public FindPiThread(int thrownDarts)
        {
            totalDarts = thrownDarts;
            hitDarts = 0;
            rng = new Random();
        }

        public int _hitDarts
        {
            get => hitDarts;
        }

        public void throwDarts()
        {
            for(int i = 0; i < totalDarts; i++)
            {
                double dartX = rng.NextDouble();
                double dartY = rng.NextDouble();
                double hypotenuse = Math.Sqrt(Math.Pow(dartX, 2) + Math.Pow(dartY, 2));

                if (hypotenuse <= 1)
                {
                    hitDarts++;
                }
            }
        }
    }
}
