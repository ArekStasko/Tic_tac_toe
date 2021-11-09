using System;

namespace ticTacToe
{
    class Program
    {
        static char[,] templateField =
        {
           {'1', '2', '3' },
           {'4', '5', '6' },
           {'7', '8', '9' }
        };

        static char[,] playField = new char[3, 3];


        static void Main(string[] args)
        {
            int player = 2;

            Array.Copy(templateField, 0, playField, 0, templateField.Length);

            int roundsCount = 1;
            do
            {
                if (player == 2)
                    player = 1;
                else
                    player = 2;

                checkWinner();
                SetField(player);
                if (roundsCount == 9)
                {
                    resetPlayField();
                    Console.WriteLine("No winner !");
                    roundsCount = 1;
                }
                roundsCount++;

            } while (true);
        }

        public static void SetField(int playerNumber)
        {
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

        public static void resetPlayField(char winner = 'n')
        {
            Console.Clear();
            Array.Copy(templateField, 0, playField, 0, templateField.Length);
            if (winner != 'n')
                Console.WriteLine($"Player {winner} win !");
        }

        public static void checkWinner()
        {
            char[] playerChars = { 'X', 'O' };
            foreach (char playerChar in playerChars)
            {
                for (int i = 0; i < playField.GetLength(0); i++)
                {

                    if ((playField[i, 0] == playerChar) && (playField[i, 1] == playerChar) && (playField[i, 2] == playerChar))
                    {
                        resetPlayField(playerChar);
                    }
                    else if ((playField[0, i] == playerChar) && (playField[1, i] == playerChar) && (playField[2, i] == playerChar))
                    {
                        resetPlayField(playerChar);
                    }
                    else if (
                        ((playField[0, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 2] == playerChar))
                        ||
                        ((playField[0, 2] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 0] == playerChar))
                        )
                    {
                        resetPlayField(playerChar);
                    }

                }
            }

        }
    }
}
