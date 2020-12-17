using System;

namespace TicTacToeApp
{
    class Program
    {
        public static int countMoves = 0;
        public static bool status = false;
        static void Main(string[] args)
        {
            
            char[] board = new char[9];
            GameBoard(board);
            do
            {
                //Users Turn:  
                PositionInput(board);
                GameBoard(board);
                WinnerCheck(board);
                Console.Clear();
                //Cpu Turn:
                CpuPosition(board);
                GameBoard(board);
                WinnerCheck(board);   
            }
            while (countMoves<=9);
        }

        /// <summary>
        /// TicTacToe Game Board.
        /// </summary>
        /// <param name="board"></param>
        public static void GameBoard(char[] board)
        {
            //Console.Clear();
            Console.WriteLine("--Welcome_To_TIC-TAC-TOE_Game--");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine(" --+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine(" --+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]}");
            Console.WriteLine("-------------------------------");
        }

        /// <summary>
        /// User Input for position.
        /// </summary>
        /// <param name="board"></param>
        public static void PositionInput(char[] board)
        {
            bool loop = true;
            ++countMoves;
            while (loop)
            {
                Console.Write("Enter ur position 1-9 : ");
                int pos = Convert.ToInt32(Console.ReadLine());
                pos -= 1;
                bool flag = board[pos] == 0;
                if (flag)
                {
                    board[pos] = 'X';
                    loop = false;
                }
                else
                    Console.WriteLine("position alerady taken...pls Enter another position");
            }
        }

        /// <summary>
        /// oponent is CPU peek position randomly.
        /// </summary>
        /// <param name="board"></param>
        public static void CpuPosition(char[] board)
        {
            ++countMoves;
            Random rand = new Random();
            bool loop = true;
            if (countMoves <= 9)
            {
                while (loop)
                {
                    int cpuPos = rand.Next(0, 9);
                    bool flag = board[cpuPos] == 0;
                    if (flag)
                    {
                        board[cpuPos] = 'O';
                        loop = false;
                    }
                }
            }
        }

        /// <summary>
        /// Checking Winner. 
        /// </summary>
        /// <param name="board"></param>
        public static void WinnerCheck(char[] board)
        {
            char win='w';
            
            if (board[0].Equals(board[1]) && board[0].Equals(board[2]))
            {
                status = true;
                win = board[0];
            }
            if (board[3].Equals(board[4]) && board[3].Equals(board[5]))
            {
                status = true;
                win = board[3];
            }
            if (board[6].Equals(board[7]) && board[6].Equals(board[8]))
            {
                status = true;
                win = board[6];
            }
            if (board[0].Equals(board[3]) && board[0].Equals(board[6]))
            {
                status = true;
                win = board[0];
            }
            if (board[1].Equals(board[4]) && board[1].Equals(board[7]))
            {
                status = true;
                win = board[1];
            }
            if (board[2].Equals(board[5]) && board[2].Equals(board[8]))
            {
                status = true;
                win = board[2];
            }
            if (board[0].Equals(board[4]) && board[0].Equals(board[8]))
            {
                status = true;
                win = board[0];
            }
            if (board[2].Equals(board[4]) && board[2].Equals(board[6]))
            {
                status = true;
                win = board[2];
            }
            if (status)
            {
                if (win.Equals('X'))
                {
                    countMoves += 10;
                    Console.WriteLine("You are winner...!!!!!!!!");
                }
                else if (win.Equals('O'))
                {
                    countMoves += 10;
                    Console.WriteLine("Sorry you loose CPU win...!!!");
                }
                else if(countMoves >= 9)
                    Console.WriteLine("Match Draw..!!!!");
            }              
        }
    }
}