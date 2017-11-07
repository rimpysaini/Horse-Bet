using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssignment
{
    delegate void PrintResult(List<BetClass> bets);
    class Program
    {


        static string FILE_PATH = @"C:\HorseBet\Betting.txt";
        static string FILE_PATH1 = @"C:\HorseBet\Betting.bin";
        static string FILE_PATH3 = @"C:\HorseBet\WinningRatio.txt";
        static string FILE_PATH2 = @"C:\HorseBet\WonAndLost.txt";
        static string FILE_PATH4 = @"C:\HorseBet\DateOrder.txt";


        static List<BetClass> report = new List<BetClass>
        {
         new BetClass("Aintree", "Ali", new DateTime(2017, 05, 12), 11.58m, true),
         new BetClass("Punchestown", " Neon ", new DateTime(2016, 12, 22), 122.52m, true),
         new BetClass("Sandown", "Blacky", new DateTime(2016, 11, 17), 20.00m, false),
        new BetClass("Ayr", "Stuffy", new DateTime(2016, 11, 03), 25.00m, false),
        new BetClass("Fairyhouse", "Kalu", new DateTime(2016, 12, 02), 65.75m, true),
        new BetClass("Ayr", "Bhura", new DateTime(2017, 03, 11), 12.05m, true),
         new BetClass("Doncaster", "Brown", new DateTime(2017, 12, 02), 10.00m, false),
         new BetClass("Towcester", "Ghora", new DateTime(2016, 03, 12), 50.00m, false),
         new BetClass("Goodwood", "Nora", new DateTime(2017, 10, 07), 525.74m, true),
         new BetClass("Kelso", "Rana", new DateTime(2016, 09, 13), 43.21m, true),
        new BetClass("Punchestown", "Amir", new DateTime(2017, 07, 05), 35.00m, false),
         new BetClass("Ascot", "Rocky", new DateTime(2016, 02, 04), 23.65m, true),
         new BetClass("Kelso", "Bhura", new DateTime(2017, 08, 02), 30.00m, false),
        new BetClass("Towcester", "Nora", new DateTime(2017, 05, 01), 104.33m, true),
         new BetClass("Ascot", "Bhura", new DateTime(2017, 06, 21), 25.00m, false),
         new BetClass("Bangor", "wafa", new DateTime(2016, 12, 22), 30.00m, false),
        new BetClass("Ayr", "Rocky", new DateTime(2017, 05, 22), 11.50m, true),
       new BetClass("Ascot", "Rana", new DateTime(2017, 06, 23), 30.00m, false),
        new BetClass("Ascot", "wafa", new DateTime(2017, 06, 23), 374.27m, true),
         new BetClass("Goodwood", "Stuffy", new DateTime(2016, 10, 05), 34.12m, true),
        new BetClass("Dundalk", "Blacky", new DateTime(2016, 11, 09), 20.00m, false),
         new BetClass("Haydock", "Nora", new DateTime(2016, 11, 12), 87.00m, true),
        new BetClass("Perth", "Rana", new DateTime(2017, 01, 20), 15.00m, false),
         new BetClass("York", "Rana", new DateTime(2017, 11, 11), 101.25m, true),
         new BetClass("Punchestown", "Blacky", new DateTime(2016, 12, 22), 11.50m, true),
        new BetClass("Chester", "Blacky", new DateTime(2016, 08, 14), 10.00m, false),
         new BetClass("Kelso", "Rocky", new DateTime(2016, 09, 18), 10.00m, false),
        new BetClass("Kilbeggan", "Rocky", new DateTime(2017, 03, 03), 20.00m, false),
        new BetClass("Fairyhouse", "Rocky", new DateTime(2017, 03, 11), 55.50m, true),
         new BetClass("Punchestown", "Nora", new DateTime(2016, 11, 15), 10.00m, false),
        new BetClass("Towcester", "Blacky", new DateTime(2016, 05, 08), 16.55m, true),
         new BetClass("Punchestown", "Stuffy", new DateTime(2016, 05, 23), 13.71m, true),
         new BetClass("Cork", "Henry", new DateTime(2016, 11, 30), 20.00m, false),
       new BetClass("Punchestown", "Nora", new DateTime(2016, 04, 25), 13.45m, true),
         new BetClass("Bangor", "Nora", new DateTime(2016, 01, 23), 10.00m, false),
         new BetClass("Sandown", "Nora", new DateTime(2017, 08, 07), 25.00m, false)
    };
        private static bool exit;

        static void Main(string[] args)
        {
            
            foreach (BetClass bet in report)
            {
                Console.WriteLine(bet.ToString());
            }

            using (FileStream fstream = new FileStream(FILE_PATH, FileMode.OpenOrCreate))


            using (StreamWriter txtWriter = new StreamWriter(fstream, Encoding.UTF8))
            {
                foreach (var line in report)
                {
                    txtWriter.WriteLine(line);
                }
            }


            using (FileStream fstream = new FileStream(FILE_PATH1, FileMode.OpenOrCreate))

            {

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fstream, report);

            }

            while (exit == false)
            {
                Console.WriteLine("1. Total won and total lost: ");
                Console.WriteLine("2. Most popular RaceCourse: ");
                Console.WriteLine("3. Bets in date order: ");
                Console.WriteLine("4. Highest Amount won & lost: ");
                Console.WriteLine("5. How successful: ");
                Console.WriteLine("6. Quit the program");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {



                    case 1:
                        Console.WriteLine("Total Bets Won and Lost");
                        Console.WriteLine("*********************************************************************");
                        TotalWonAndLost();
                        Console.WriteLine("*********************************************************************");
                        break;
                    case 2:
                        Console.WriteLine("*********************************************************************");
                        mostPopularRaceCourse();
                        Console.WriteLine("*********************************************************************");
                        break;
                    case 3:
                        Console.WriteLine("Report after sort by date order is ");
                        Console.WriteLine("*********************************************************************");
                        sortInDateOrder();
                        Console.WriteLine("*********************************************************************");
                        break;
                    case 4:
                        Console.WriteLine("Total Highest amount won and lost");
                        Console.WriteLine("**********************************************************************");
                        highestAmountWonAndLost(report);
                        Console.WriteLine("**********************************************************************");
                        break;


                    case 5:
                        Console.WriteLine("Ratio to Total Race to the Races Won");
                        Console.WriteLine("***********************************************************************");
                        winningRatio(report);
                        Console.WriteLine("***********************************************************************");
                        break;
                    case 6:
                        if (choice == 9)
                        {
                            exit = true;
                        }

                        break;
                }
            }
        }
            //Report of Total won and Lost in year...
            public static void TotalWonAndLost()
            {
                var Total = from Bets in report
                                orderby Bets.Date
                                let bettingwon = new
                                {
                                    Year = Bets.Date.ToString(),
                                }
                                group Bets by bettingwon into data
                                select new
                                {
                                    Year = data.Key.Year,
                                    Loss = data.Where(g => g.Result == false).Sum(g => g.Amount),
                                    Won = data.Where(g => g.Result == true).Sum(g => g.Amount)
                                };
                Console.WriteLine("\tYear\t\t\t\tTotal Loss\t\tTotal Won");
                foreach (var item in Total)
                {
                    Console.WriteLine("{0}\t\t\t{1}\t\t\t{2}", item.Year, item.Loss, item.Won);
                }
            }
            //most popular race course of the year
            public static void mostPopularRaceCourse()
            {
                var raceCourse = report.GroupBy(g => g.RaceCourse).OrderByDescending(g => g.Count())
                    .First().Key;
                foreach (var bets in raceCourse)
                {
                    Console.Write($"Most Popular RaceCourse is {raceCourse.ToString()}" );
                }
            }
            //Shows bet in date order
            public static void sortInDateOrder()
            {
                var betDates = report.OrderBy(g => g.Date);
                using (Stream fstream = new FileStream($@"{FILE_PATH4}", FileMode.OpenOrCreate))
                {
                using (StreamWriter txtWriter = new StreamWriter(fstream, Encoding.UTF8))
                {
                    foreach (var line in report)
                    {
                        txtWriter.WriteLine(line);
                    }
                }
                foreach (var date in betDates)
                    {
                        Console.Write($"Race Course: {date.RaceCourse}" + " \t "
                                    + $"Date: {date.Date}" + " \t "
                                    + $"Amount : {date.Amount}" + " \t "
                                    + $"Result: {date.Result}" + Environment.NewLine
                            );
                    }
                }
            }

            //Highest win and Lost
            public static void highestAmountWonAndLost(List<BetClass> Bet)
            {
                //Highest winning
                var hWinAmount = Bet.Where(g => g.Result == true).Max(m => m.Amount);
                var hWins = Bet.Where(m => m.Amount == hWinAmount).First();

                //Highest lost
                var highestLost = Bet.Where(g => g.Result == false).Max(g => g.Amount);
                var hLost = Bet.Where(m => m.Amount == highestLost).First();

                Console.WriteLine("\tHighest Won\t\t\tHighest Lost");
                using (Stream fStream = new FileStream($@"{FILE_PATH2}", FileMode.OpenOrCreate))
                {
                using (StreamWriter txtWriter = new StreamWriter(fStream, Encoding.UTF8))
                {
                    foreach (var line in report)
                    {
                        txtWriter.WriteLine(line);
                    }
                }
                Console.WriteLine($" Winning Amount  :  {hWins.Amount}" + "  " +
                                      $"    Lost Amount : {hLost.Amount}"
                        );
                }
            }
            //Winning Ratio
            public static void winningRatio(List<BetClass> Bets)
            {

                var Races = report.Count();
                var wins = Bets.Where(g => g.Result == true).Count();
                string winningRatio = wins.ToString() + "/" + Races.ToString() + Environment.NewLine;
                using (Stream fStream = new FileStream($@"{FILE_PATH3}", FileMode.OpenOrCreate))
                {
                using (StreamWriter txtWriter = new StreamWriter(fStream, Encoding.UTF8))
                {
                    foreach (var line in report)
                    {
                        txtWriter.WriteLine(line);
                    }
                }
                Console.WriteLine($"Winning Ratio is {winningRatio}" + Environment.NewLine);
                }
            }
       
        }
    }













