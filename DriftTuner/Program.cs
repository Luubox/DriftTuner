using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriftTuner
{
    class Program
    {
        static void Main(string[] args)
        {
            //Source: https://forums.forzamotorsport.net/turn10_postst10610_Tuning-Guide-for-Drifting.aspx
            //TODO: print to .txt?
            Calculator myCalculator = new Calculator();
            decimal? weightDistribution = (decimal)0.0;
            bool continueMenu = true;
            while (continueMenu)
            {
                const string menuString = "### Drift Tuning ###\n"+
                                          "1. Static Tunes\n"+
                                          "2. Anti-Roll Bars\n"+
                                          "3. Springs\n"+
                                          "4. Rebound & Bump Stiffness\n" +
                                          "5. Reset Weight Distribution\n" +
                                          "6. Exit";
                Console.WriteLine(menuString);
                Console.WriteLine("\nEnter a Number:"); 
                string menuChoice = Console.ReadLine(); //TODO: input validation
                switch (menuChoice)
                {
                    case "1":
                        //Static Tunes
                        Console.WriteLine("\n### Upgrades: ###\n"+
                                          " - Platform and Handling = Race everything, weight reduction, roll cage, and anti roll bars optional\n" +
                                          " - Drivetrain = Race Everything\n" +
                                          " - Wheels = Street or sport tire compound, wide rear/skinny fronts, or personal preference\n"+
                                          " - Aspiration = Own preference, turbos add power but potential lag\n" +
                                          " - Performance and Aspiration = Sport flywheel, rest optional (~400hp to 650hp)\n");
                        Console.WriteLine("### Tuning: ###\n"+
                                          " - Tire Pressure = Set to 28 PSI, adjust to be ~32 PSI mid drift\n"+
                                          " - Camber = Front -4 to -5 Rear -1 to -2 degrees, try to achieve a value close to 0 degrees mid drift\n"+
                                          " - Toe = Rear 0.0 to -0.5 degrees\n"+
                                          " - Front Caster = ~6.5 degrees, adjust to preference\n"+
                                          " - Ride Height = Low as you can in the rear, a bit higher in the front\n"+
                                          " - Brake Distribution = 45% front, adjust to preference\n"+
                                          " - Brake Pressure = 120%, adjust to preference\n"+
                                          " - Differential = More acceleration and deceleration the more angle and the more risk of spinning out\n"+
                                          " - Gearing = Go for 3rd or 4th gear, if redlining through the corner, tune closer to speed.\n");
                        Console.WriteLine("Press any key to continue..\n");
                        Console.ReadKey();
                        break;
                    case "2":
                        //Anti-Roll Bars
                        Console.WriteLine("\n### Anti-Roll Bars ###");
                        if (weightDistribution.Value == (decimal) 0.0)
                        {
                            Console.WriteLine("Please enter weight distribution:");
                            weightDistribution = Convert.ToDecimal(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine($"Using {weightDistribution} as weight distribution value");
                        }
                        Console.WriteLine("Please enter maximum value :");
                        decimal rollBarMax = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Please enter minimum value :");
                        decimal rollBarMin = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("\n### Values ###");
                        Console.WriteLine("Front tune: " + myCalculator.CalculateTune(rollBarMax, rollBarMin, weightDistribution.Value));
                        Console.WriteLine("Rear tune: " + myCalculator.CalculateTune(rollBarMax, rollBarMin, 1 - weightDistribution.Value) + "\n");
                        Console.WriteLine("Press any key to continue..\n");
                        Console.ReadKey();
                        break;
                    case "3":
                        //Springs
                        Console.WriteLine("\n### Springs ###");
                        if (weightDistribution.Value == (decimal)0.0)
                        {
                            Console.WriteLine("Please enter weight distribution:");
                            weightDistribution = Convert.ToDecimal(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine($"Using {weightDistribution} as weight distribution value");
                        }
                        Console.WriteLine("Please enter maximum value :");
                        decimal springMax = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Please enter minimum value :");
                        decimal springMin = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("\n### Spring Values ###");
                        Console.WriteLine("Front tune: " + myCalculator.CalculateTune(springMax, springMin, weightDistribution.Value));
                        Console.WriteLine("Rear tune: " + myCalculator.CalculateTune(springMax, springMin, 1 - weightDistribution.Value));
                        Console.WriteLine("Suspension tunes are fiddly, adjust to preference, softer rear suspension means more traction\n");
                        Console.WriteLine("Press any key to continue..\n");
                        Console.ReadKey();
                        break;
                    case "4":
                        //Rebound Stiffness
                        Console.WriteLine("\n### Rebound & Bump Stiffness ###");
                        if (weightDistribution.Value == (decimal)0.0)
                        {
                            Console.WriteLine("Please enter weight distribution:");
                            weightDistribution = Convert.ToDecimal(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine($"Using {weightDistribution} as weight distribution value");
                        }
                        Console.WriteLine("Please enter maximum value :");
                        decimal reboundMax = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Please enter minimum value :");
                        decimal reboundMin = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("\n### Rebound Values ###");
                        decimal reboundValueFront = myCalculator.CalculateTune(reboundMax, reboundMin, weightDistribution.Value);
                        decimal reboundValueRear = myCalculator.CalculateTune(reboundMax, reboundMin, 1 - weightDistribution.Value);
                        Console.WriteLine($"Front tune: {reboundValueFront}");
                        Console.WriteLine($"Rear tune: {reboundValueRear}\n");
                        Console.WriteLine("### Bump Values ###");
                        Console.WriteLine("Front tune: " + Decimal.Multiply(reboundValueFront, (decimal)0.5));
                        Console.WriteLine("Rear tune: " + Decimal.Multiply(reboundValueFront, (decimal)0.5) + "\n");
                        Console.WriteLine("Press any key to continue..\n");
                        Console.ReadKey();
                        break;
                    case "5":
                        //Reset Weight Distribution
                        weightDistribution = (decimal) 0.0;
                        Console.WriteLine("\n### Weight distribution value has been reset ###\n");
                        break;
                    case "6":
                        //Exit
                        continueMenu = false;
                        break;
                }
            }
        }
    }
}
