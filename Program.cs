using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput = 0;
            int h, s, m;
            string tz; 
            var times = new List<Time2>();

            while ( userInput != 4)
            {
                Console.WriteLine("Which type of object would you like to enter:\n1:time2\n2:time2tz\n3:Stop entering data");
                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Enter hour: ");
                        h = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter minute: ");
                        m = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter second: ");
                        s = Convert.ToInt32(Console.ReadLine());
                        var t = new Time2() { Hour = h, Minute = m, Second = s };
                        times.Add(t);
                        break;

                    case 2:
                        Console.WriteLine("Enter hour: ");
                        h = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter minute: ");
                        m = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter second: ");
                        s = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter timezone: ");
                        tz = Console.ReadLine();
                        t = new Time2tz(h,m,s,tz) {};
                        times.Add(t);
                        break;

                    case 3:
                        while (userInput != 4) {
                        Console.WriteLine("What report do you want:\n1:All objects\n2:All objects with AM times\n3:All Objects with PM Times\n4:QUIT");
                            int input = Convert.ToInt32(Console.ReadLine());
                            switch (input)
                            {
                                case 1:
                                    foreach (var time2 in times)
                                    {
                                        Console.WriteLine($"Time object:");
                                        Console.WriteLine($"{time2.ToUniversalString()}\n");
                                        Console.WriteLine($"{time2.ToString()}\n");
                                        
                                    }
                                    break;

                                case 2:
                                    var AMTimes =
                                        from time2 in times
                                        where time2.Hour < 12
                                        select time2;

                                    foreach (var time2 in AMTimes )
                                    {
                                        Console.WriteLine($"Time object:");
                                        Console.WriteLine($"{time2.ToUniversalString()}\n");
                                        Console.WriteLine($"{time2.ToString()}\n");
                                    }
                                    break;

                                case 3:
                                    var PMTimes =
                                        from time2 in times
                                        where time2.Hour > 11
                                        select time2;

                                    foreach (var time2 in PMTimes)
                                    {
                                        Console.WriteLine($"Time object:");
                                        Console.WriteLine($"{time2.ToUniversalString()}\n");
                                        Console.WriteLine($"{time2.ToString()}\n");
                                    }
                                    break;

                                case 4:
                                    userInput = input;
                                    break;

                                default:
                                    Console.WriteLine("Invalid input. Try again");
                                    break;
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid input. Try again");
                        break;
                }
            }


        }
    }
}
