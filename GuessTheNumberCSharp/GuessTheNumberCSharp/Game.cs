using System;
namespace GuessTheNumberCSharp
{
    public class Game
    {

        private HumanPlayer humanPlayer;
        public HumanPlayer HumanPlayer { get => humanPlayer; set => humanPlayer = value; }

        private AIPlayer aIPlayer;
        public AIPlayer AIPlayer { get => aIPlayer; set => aIPlayer = value; }


        private Random random;
        public Random Random { get => random; set => random = value; }


        private int winningNumber;
        public int WinningNumber { get => winningNumber; set => winningNumber = value; }


        private int shiftCounter;
        public int ShiftCounter { get => shiftCounter; set => shiftCounter = value; }



        //constructor
        public Game()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            random = new Random();
            WinningNumber = random.Next(1, 5);
            Console.WriteLine($"Numero ganador: {WinningNumber}");
            Console.WriteLine();
            string humanPlayerName = AssignHumanName();
            HumanPlayer = new HumanPlayer(humanPlayerName);
            AIPlayer = new AIPlayer("Computina");
            ShiftCounter = 0;
            GameStart(HumanPlayer, AIPlayer);
            Console.ReadKey();
        }


        //Asigna el nombre para luego usarlo en el constructor
        private string AssignHumanName()
        {
            string name = "";
            Console.ForegroundColor = ConsoleColor.Magenta;
            try
            {

                while (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Escribe tu nombre de jugadora: ");
                    name = Console.ReadLine();
                    Console.WriteLine("\n");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                name = "La que no debe ser nombrada";
            }
            return name;
        }


        //Asigna el orden de los turnos
        //1 humano
        //2 computadora
        private int AssignTurnToPlayer()
        {
            return random.Next(1, 3);
        }


        //Compara si el numero del turno coincide con el numero ganador
        private bool CheckWinner(int number)
        {
            return (WinningNumber == number);
        }


        //muestra las estadisticas del juego
        private void PrintGameStatistics(Player player)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Estadisticas del juego:");
            Console.WriteLine($"Turnos Totales Partida: {shiftCounter}");
            if (player is AIPlayer)
            {
                Console.WriteLine($"Turnos de {((AIPlayer)player).Name}: {((AIPlayer)player).ListGuess.Count}");
                Console.WriteLine($"Nros Intentados por {((AIPlayer)player).Name}: ");
                Console.WriteLine(string.Join(", ", ((AIPlayer)player).ListGuess));
            }
            else
            {
                Console.WriteLine($"Turnos de {((HumanPlayer)player).Name}: {((HumanPlayer)player).ListGuess.Count}");
                Console.WriteLine($"Nros Intentados por {((HumanPlayer)player).Name}: ");
                Console.WriteLine(string.Join(", ", ((HumanPlayer)player).ListGuess));
            }
        }

        //muestra mensaje de ayuda para saber que tan cerca estoy del numero
        private string GetClueMessage(int number)
        {
            if (number < WinningNumber)
            {
                if (WinningNumber - number <= 5)
                    return "El numero es mas alto, estas muy cerca!";
                else
                    return "El numero es mas alto";
            }
            else
            {
                if (number - WinningNumber <= 5)
                    return "El numero es mas bajo, estas muy cerca!";
                else
                    return "El numero es mas bajo";
            }
        }


        private void GameStart(HumanPlayer humanPlayer, AIPlayer aIPlayer)
        {
            int initialShift = AssignTurnToPlayer();
            bool finishGame = false;
            while (!finishGame)
            {
                if (initialShift % 2 == 0)
                {
                    int iaPlayerNumber = aIPlayer.MakeGuess();
                    finishGame = CheckWinner(iaPlayerNumber);
                    shiftCounter++;
                    initialShift++;
                    Console.WriteLine($"{aIPlayer.Name} elije: {iaPlayerNumber}");
                    if (!finishGame)
                    {
                        Console.WriteLine(GetClueMessage(iaPlayerNumber));
                        Console.WriteLine();
                    }
                }
                else
                {
                    int humanPlayerNumber = humanPlayer.MakeGuess();
                    finishGame = CheckWinner(humanPlayerNumber);
                    shiftCounter++;
                    initialShift++;
                    if (!finishGame)
                    {
                        Console.WriteLine(GetClueMessage(humanPlayerNumber));
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("-----------------------------------");
            }
            if (initialShift % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{humanPlayer.Name} Ganaste!!!");
                PrintGameStatistics(humanPlayer);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{humanPlayer.Name} Perdiste u.u y gano {aIPlayer.Name}");
                PrintGameStatistics(aIPlayer);
            }

        }


    }
}

