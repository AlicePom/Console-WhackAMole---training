using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Console_WhackAMole___training
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int randomNumber;
            int enteredNumber;
            int whacks = 0;

            var top = Console.CursorTop;
            var left = Console.CursorLeft;

            // spuštění časového limitu
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (stopwatch.Elapsed < TimeSpan.FromSeconds(30))
            {
                // vygenerování náhodného čísla (krtka)
                Random generateRandomNumber = new Random();
                randomNumber = generateRandomNumber.Next(0, 10);
                Console.WriteLine($"Whack a mole: {randomNumber}");

                // načtení čísla od hráče (bouchnutí)
                ConsoleKeyInfo input = Console.ReadKey();
                bool parsed = int.TryParse(input.KeyChar.ToString(), out enteredNumber);

                // pokud se nepodařilo sparsovat (nebylo zadáno číslo), nebo se hráč netrefil (zadal špatné číslo)
                while (!parsed || enteredNumber != randomNumber)
                {
                    // vyčištění inputu od hráče
                    Console.SetCursorPosition(left, top);
                    Console.Write(new string(' ', 1));
                    Console.SetCursorPosition(left, top);

                    // načtení dalšího pokusu od hráče
                    input = Console.ReadKey();
                    parsed = int.TryParse(input.KeyChar.ToString(), out enteredNumber);
                }

                // pokud se hráč trefí
                if (enteredNumber == randomNumber)
                {
                    whacks += 1; // přičte zásah
                }

                // vyčištění konzole - příprava na další kolo
                Console.Clear();
            }
            
            // Po vypršení časového limitu konec hry a výpis počtu zásahů
            stopwatch.Stop();
            Console.WriteLine($"Game over, your whack count is {whacks}.");
        }
    }
}