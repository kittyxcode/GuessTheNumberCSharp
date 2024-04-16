using System;
namespace GuessTheNumberCSharp
{
    public class AIPlayer : Player
    {
        //campo y propiedad que permite usar el random
        private Random random;
        public Random Random { get => random; set => random = value; }

        //determina la dificultad
        private int level;
        public int Level { get => level; set => level = value; }

        //Registro de intentos de la compu y el rival
        private List<int> listTotalGuess;
        public List<int> ListTotalGuess { get => listTotalGuess; set => listTotalGuess = value; }


        //copia del numero ganador
        int cheatNumber;
        public int CheatNumber { get => cheatNumber; set => cheatNumber = value; }

        //constructor
        public AIPlayer(string name) : base(name)
        {
            random = new Random();
            listTotalGuess = new List<int>();
            level = 0;
        }

        //intenta adivinar un numero y lo guarda en la lista de intentos
        public override int MakeGuess()
        {
            int guessNumber = 0;
            if (level == 1)
            {
                guessNumber = random.Next(1, 101);
                ListGuess.Add(guessNumber);
                return guessNumber;
            }
            if (level == 2)
            {
                do
                {
                    guessNumber = random.Next(1, 101);
                } while (ListTotalGuess.Contains(guessNumber));
                ListGuess.Add(guessNumber);
                return guessNumber;
            }
            if (level == 3)
            {
                if (listTotalGuess.Count == 0)
                {
                    guessNumber = random.Next(1, 101);
                }
                else
                {
                    guessNumber = CheatMethod(listTotalGuess, cheatNumber);
                    if (ListTotalGuess.Contains(guessNumber))
                    {
                        if (guessNumber < cheatNumber)
                        {
                            ListGuess.Add(guessNumber + 1);
                            return guessNumber + 1;
                        }
                        else
                        {
                            ListGuess.Add(guessNumber - 1);
                            return guessNumber - 1;
                        }

                    }
                    else
                    {
                        ListGuess.Add(guessNumber);
                        return guessNumber;
                    }
                }
                return guessNumber;
            }
            return guessNumber;
        }

        //devuelve el numero mas cercano al numero ganador
        //se basa en los numeros del rival y los de la compu
        private int CheatMethod(List<int> listOfNumber, int winnerNumber)
        {
            // Filtrar los números dentro del rango de 5 unidades del número ganador
            var nearsNumbers = listOfNumber.Where(x => Math.Abs(x - winnerNumber) <= 5);
            int nearNumber = 0;

            if (nearsNumbers.Any())
            {
                nearNumber = nearsNumbers.OrderBy(x => Math.Abs(x - winnerNumber)).First();
            }
            else
            {
                do
                {
                    nearNumber = random.Next(1, 101);
                } while (ListTotalGuess.Contains(nearNumber));
            }
            return nearNumber;
        }
    }
}
