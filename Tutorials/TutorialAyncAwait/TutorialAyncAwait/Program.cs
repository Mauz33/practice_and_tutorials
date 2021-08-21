using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TutotialAyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }
        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------[ТОСТЕР НАЧАЛ СВОЮ РАБОТУ]----------------");
            Console.ResetColor();

            for (int slice = 0; slice < slices; slice++)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Putting a slice of bread in the toaster");
                Console.ResetColor();
            }
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Start toasting...");
            Console.ResetColor();
            await Task.Delay(3000);

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Remove toast from toaster");
            Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------[ТОСТЕР ЗАКОНЧИЛ СВОЮ РАБОТУ]----------------");
            Console.ResetColor();

            return new Toast();
        }

        // Exception
        //private static async Task<Toast> ToastBreadAsync(int slices)
        //{
        //    Console.BackgroundColor = ConsoleColor.DarkGreen;
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.WriteLine("----------------[ТОСТЕР НАЧАЛ СВОЮ РАБОТУ]----------------");
        //    Console.ResetColor();

        //    for (int slice = 0; slice < slices; slice++)
        //    {
        //        Console.BackgroundColor = ConsoleColor.DarkGreen;
        //        Console.ForegroundColor = ConsoleColor.White;
        //        Console.WriteLine("Putting a slice of bread in the toaster");
        //        Console.ResetColor();
        //    }
        //    Console.BackgroundColor = ConsoleColor.DarkGreen;
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.WriteLine("Start toasting...");
        //    Console.ResetColor();
        //    await Task.Delay(2000);

        //    Console.BackgroundColor = ConsoleColor.Magenta;
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.WriteLine("Fire! Toast is ruined!");
        //    Console.ResetColor();
        //    throw new InvalidOperationException("The toaster is on fire");
        //    await Task.Delay(1000);

        //    Console.BackgroundColor = ConsoleColor.DarkGreen;
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.WriteLine("Remove toast from toaster");
        //    Console.ResetColor();

        //    Console.BackgroundColor = ConsoleColor.DarkGreen;
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.WriteLine("----------------[ТОСТЕР ЗАКОНЧИЛ СВОЮ РАБОТУ]----------------");
        //    Console.ResetColor();

        //    return new Toast();
        //}

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------[БЕКОН НАЧАЛ СВОЮ РАБОТУ]----------------");
            Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("cooking first side of bacon...");
            Console.ResetColor();
            await Task.Delay(3000);

            for (int slice = 0; slice < slices; slice++)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("flipping a slice of bacon");
                Console.ResetColor();
            }
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("cooking the second side of bacon...");
            Console.ResetColor();
            await Task.Delay(3000);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Put bacon on plate");
            Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------[БЕКОН ЗАКОНЧИЛ СВОЮ РАБОТУ]----------------");
            Console.ResetColor();

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------[ЯЙЦА НАЧАЛИ СВОЮ РАБОТУ]----------------");
            Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Warming the egg pan...");
            Console.ResetColor();
            await Task.Delay(3000);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"cracking {howMany} eggs");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("cooking the eggs ...");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.ResetColor();
            await Task.Delay(3000);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Put eggs on plate");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------[ЯЙЦА ЗАКОНЧИЛИ СВОЮ РАБОТУ]----------------");
            Console.ResetColor();

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }
}
