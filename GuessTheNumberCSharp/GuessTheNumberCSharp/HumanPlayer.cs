using System;
namespace GuessTheNumberCSharp
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name) : base(name)
        {
        }

        public override int MakeGuess()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            bool validate = true;
            int number = 0;

            while (validate)
            {
                Console.WriteLine("Ingresa tu numero: ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out number) && number >= 1 && number <= 100)
                {
                    ListGuess.Add(number);
                    validate = false;
                }
            }
            return number;
        }
    }
}

