using System;

namespace Learning_C_
{
    internal class JogoDaVelha
    {
        static char[,] board = new char[3, 3];
        static string player1, player2;
        static char currentPlayer = 'X';
        static int cont1 = 0, cont2 = 0;
        static int gameAgain;
        static bool gameEnd = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome do Jogador1 (X):");
            player1 = Console.ReadLine();
            Console.WriteLine("Digite o nome do Jogador2 (O):");
            player2 = Console.ReadLine();

            InicializedBoard();


            while (gameEnd)
            {
                DrawBoard();
                CheckMove();
                CheckForWin();
                CheckForDraw();
                SwitchcurrentPlayer();
            }

        }

        static void InicializedBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }

            }
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("   0   1   2");
            for (int row = 0; row < 3; row++)
            {
                Console.Write(row + " ");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(" " + board[row, col] + " ");
                    if (col < 2)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
                if (row < 2)
                {
                    Console.WriteLine("  ---+---+---");
                }
            }
        }


        static string GetCurrentPlayerName()
        {
            return (currentPlayer == 'X') ? player1 : player2;
        }

        static void CheckMove()
        {
            Console.WriteLine("Vez de " + GetCurrentPlayerName());
            bool validMove = false;
            while (!validMove)
            {
                Console.WriteLine("Digite a linha que deseja jogar:");
                int row = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite a coluna que deseja jogar:");
                int col = int.Parse(Console.ReadLine());
                if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ')
                {
                    board[row, col] = currentPlayer;
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("Jogada inválida. Tente novamente:");
                }
            }
        }


        static void CheckForWin()
        {
            if (CheckRow() || CheckCol() || CheckDiagonals())
            {
                if (GetCurrentPlayerName() == player1)
                    cont1++;
                else
                    cont2++;

                DrawBoard();
                Console.WriteLine(GetCurrentPlayerName() + " ganhou!");
                Console.WriteLine("Placar:");
                Console.WriteLine($"{player1} = {cont1} X {player2} = {cont2}");
                GameEnd();
            }
        }

        static bool CheckRow()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                {
                    return true;
                }
            }
            return false;
        }

        static bool CheckCol()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                {
                    return true;
                }
            }
            return false;
        }

        static bool CheckDiagonals()
        {
            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer ||
                 board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
            {
                return true;
            }
            return false;
        }

        static void CheckForDraw()
        {
            bool hasMove = false;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == ' ')
                    {
                        hasMove = true;
                        break;
                    }
                }
                if (hasMove)
                {
                    break;
                }
            }
            if (!hasMove)
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("O jogo empatou!");
                GameEnd();
            }
        }

        static void SwitchcurrentPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        static void GameEnd()
        {
            Console.WriteLine("Deseja jogar novamente? (1 para sim, 2 para não)");
            gameAgain = int.Parse(Console.ReadLine());
            if (gameAgain != 1)
            {
                gameEnd = false;
            }
            else
            {
                InicializedBoard();
            }

        }

    }
}