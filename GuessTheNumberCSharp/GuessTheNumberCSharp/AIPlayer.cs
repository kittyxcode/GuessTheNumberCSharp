using System;
namespace GuessTheNumberCSharp
{
    public class AIPlayer : Player
    {
        //campo y propiedad que permite usar el random
        private Random random;
        public Random Random { get => random; set => random = value; }


        //constructor
        public AIPlayer(string name) : base(name)
        {
            random = new Random();
        }

        //intenta adivinar un numero y lo guarda en la lista de intentos
        public override int MakeGuess()
        {
            int guessNumber = random.Next(1, 5);
            ListGuess.Add(guessNumber);
            return guessNumber;
        }



    }
}

