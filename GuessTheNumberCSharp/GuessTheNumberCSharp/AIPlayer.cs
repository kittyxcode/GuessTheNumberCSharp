using System;
namespace GuessTheNumberCSharp
{
    public class AIPlayer : Player
    {
        //campo y propiedad que permite usar el random
        private Random random;
        public Random Random { get => random; set => random = value; }

        //campo y propiedad que almacena los intentos de adivinar el numero
        private List<int> totalGuess;
        public List<int> TotalGuess { get => totalGuess; set => totalGuess = value; }

        //constructor
        public AIPlayer(string name) : base(name)
        {
            random = new Random();
            TotalGuess = new List<int>();
        }

        //intenta adivinar un numero y lo guarda en la lista de intentos
        public override int MakeGuess()
        {
            int guessNumber = random.Next(1, 101);
            TotalGuess.Add(guessNumber);
            return guessNumber;
        }



    }
}

