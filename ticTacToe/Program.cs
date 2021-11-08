using System;

namespace ticTacToe
{
    class Program
    {
        static char[,] playField =
        {
           {'1', '2', '3' },
           {'4', '5', '6' },
           {'7', '8', '9' }
        };

        static void Main(string[] args)
        {
            int player = 2;

            do
            {
                if (player == 2)
                    player = 1;
                else
                    player = 2;

                checkWinner();
                SetField(player);
                
            } while (true);
        }

        public static void SetField(int playerNumber)
        {
            //Console.Clear();
            Console.WriteLine(" _________________");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", playField[0, 0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("|_____|_____|_____|");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("|_____|_____|_____|");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("|_____|_____|_____|");

            Console.WriteLine($"Player {playerNumber} turn: ");
            string userSelectionField = Console.ReadLine();
            bool correctInput = Int32.TryParse(userSelectionField, out int insertNumber);

            while (!correctInput || insertNumber < 1 || insertNumber > 9 || userSelectionField.Length != 1)
            {
                Console.WriteLine("Please insert number from 1 to 9");
                userSelectionField = Console.ReadLine();
                correctInput = Int32.TryParse(userSelectionField, out insertNumber);
            }

            for (int i = 0; i < playField.GetLength(0); i++)
            {
                for (int j = 0; j < playField.GetLength(1); j++)
                    if (playField[i, j].ToString() == userSelectionField)
                    {
                        playField[i, j] = SetXorO(playerNumber);
                    }
            }
        }

        public static char SetXorO(int player)
        {
            if (player == 2)
                return 'O';
            else
                return 'X';
        }

        //TODO: end the algo for winning player 
        public static void checkWinner()
        {
            char currentSign = playField[0,0];
            int signsCount = 0;
            for(int i=0; i<playField.GetLength(0); i++)
            {
                for(int j=0; j<playField.GetLength(1); j++)
                {
                    if (currentSign == playField[i, j])
                        signsCount++;
                    else signsCount = 0;

                    Console.WriteLine($"Sign: {currentSign}; count of signs: {signsCount}; i: {i}; j: {j}");

                    currentSign = playField[i, j];
                }
            }
        }
    }
}
