using System;
using System.Threading;
using System.Numerics;
using ConsoleSnake.ExtensionMethods;

namespace ConsoleSnake
{
    class Program
    {
        private static string[,] board = new string[12, 20]
        {
            { "#" ,"#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", },
            { "#" ," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
            { "#" ," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
            { "#" ," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
            { "#" ," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
            { "#" ," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
            { "#" ," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
            { "#" ," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
            { "#" ," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
            { "#" ," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
            { "#" ," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
            { "#" ,"#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", }
        };

        private static Vector2[] snake = new Vector2[] { new Vector2(1, 2), new Vector2(1, 3), new Vector2(1, 4) };
        private static int currentConsoleLine = 0;
        private static object boardLocker = new object();

        static void Main(string[] args)
        {
            ConfigureConsole();
            Thread t = new Thread(new ThreadStart(DrawGame));
            t.Start();
        }

        private static void ConfigureConsole()
        {
            Console.Clear();
            currentConsoleLine = Console.CursorTop;
            Console.CursorVisible = false;
        }

        public static void KeyStrokes()
        {
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.W)
            {
                Console.WriteLine("We made it here");
                lock (boardLocker)
                {
                    board[2, 6] = " ";
                    board[4, 5] = "O";
                }
            }
        }

        public static void DrawGame()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.W)
                    {
                        board[2, 6] = "O";
                        board[4, 5] = " ";
                    }
                    else if (key.Key == ConsoleKey.S)
                    {
                        board[2, 6] = " ";
                        board[4, 5] = "O";
                    }
                    else if (key.Key == ConsoleKey.Q)
                    {
                        break;
                    }
                }
                Console.SetCursorPosition(0, 0);

                foreach (Vector2 v in snake)
                {
                    board[v.GetX(), v.GetY()] = "O";
                }

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        Console.Write(board[i, j]);
                    }
                    Console.WriteLine("");
                }

                Thread.Sleep(100);
            }
            Console.WriteLine("Game Over");
        }
    }
}
