﻿using System;
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




        public Game()
        {
            random = new Random();
            WinningNumber = random.Next(1, 101);
            Console.WriteLine(winningNumber);
            string humanPlayerName = AssignHumanName();
            HumanPlayer = new HumanPlayer(humanPlayerName);
            AIPlayer = new AIPlayer("Computina");
            ShiftCounter = 0;
            GameStart(HumanPlayer, AIPlayer);
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
                }
                else
                {
                    int humanPlayerNumber = humanPlayer.MakeGuess();
                    finishGame = CheckWinner(humanPlayerNumber);
                    shiftCounter++;
                    initialShift++;
                }
            }


        }


    }
}

