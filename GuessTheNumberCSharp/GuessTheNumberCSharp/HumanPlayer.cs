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
            Console.WriteLine("Ingresa tu numero: ");
            var input = Console.ReadLine();
            int number = Convert.ToInt32(input);
            ListGuess.Add(number);
            return number;
        }
    }
}

