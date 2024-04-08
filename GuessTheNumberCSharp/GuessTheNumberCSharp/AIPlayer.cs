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

        //metodo sobreescrito
        public override int MakeGuess()
        {
            return random.Next(1, 100);
        }
    }
}

