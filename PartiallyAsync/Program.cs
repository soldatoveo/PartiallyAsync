namespace PartiallyAsync
{
    using System;
    using System.Threading;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var ac = new AsyncCaller(Wr);
            var completedOk = ac.Invoke(2000, null, EventArgs.Empty);
            var text = $"Задание выполнено вовремя: {(completedOk ? "Да" : "Нет")}";
            Console.WriteLine(text);
            Console.ReadKey();
        }

        public static void Wr(object sender, EventArgs args)
        {
            Console.WriteLine("Работа началась...");
            Thread.Sleep(5000);
            Console.WriteLine("Работа завершилась...");
        }
    }
}