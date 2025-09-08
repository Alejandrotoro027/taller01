﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace Taller01
{
    class Program
    {
        static void Main()
        {
            try
            {

                var t1 = new Time();
                var t2 = new Time(14);
                var t3 = new Time(9, 34);
                var t4 = new Time(19, 45, 56);
                var t5 = new Time(23, 3, 45, 678);

                var times = new List<Time> { t1, t2, t3, t4, t5 };

                foreach (var time in times)
                {
                    Console.WriteLine($"Time: {time}");
                    Console.WriteLine($"\tMilliseconds : {time.ToMilliseconds().ToString("N0", CultureInfo.InvariantCulture)}");
                    Console.WriteLine($"\tSeconds      : {time.ToSeconds().ToString("N0", CultureInfo.InvariantCulture)}");
                    Console.WriteLine($"\tMinutes      : {time.ToMinutes().ToString("N0", CultureInfo.InvariantCulture)}");
                    Console.WriteLine($"\tAdd          : {time.Add(t3)}");
                    Console.WriteLine($"\tIs Other day : {time.IsOtherDay(t4)}");
                    Console.WriteLine();
                }

                var t6 = new Time(45, -7, 90, -87);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
