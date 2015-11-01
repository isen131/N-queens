using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ферзи
{
    public class Program
    {
        public int[,] board;
        public int count = 0;
        public static List<int[,]> results = new List<int[,]>();

        public void deleteQ(int i, int j, int n)
        {
            for (int x = 0; x < n; x++)
            {
                board[x, j]--;
                board[i, x]--;
                int k;
                k = j - i + x;
                if (k >= 0 && k < n)
                    board[x, k]--;
                k = j + i - x;
                if (k >= 0 && k < n)
                    board[x, k]--;
            }
            board[i, j] = 0;
        }

        public bool Check(int i, int n)
        {
            bool result = false;
            for (int j = 0; j < n; j++)
            {
                if (board[i, j] == 0)
                {
                    setQ(i, j, n);
                    if (i == n - 1)
                        result = true;
                    else
                    {
                        if (!(result = Check(i + 1, n)))
                            deleteQ(i, j, n);
                    }
                }
                if (result)
                {
                    results.Add(board);
                    deleteQ(i, j, n);
                    result = false;
                    break;
                }
            }
            return result;
        }

        public void setQ(int i, int j, int n)
        {
            for (int x = 0; x < n; x++)
            {
                board[x, j]++;
                board[i, x]++;
                int k;
                k = j - i + x;
                if (k >= 0 && k < n)
                    board[x, k]++;
                k = j + i - x;
                if (k >= 0 && k < n)
                    board[x, k]++;
            }
            board[i, j] = -1;
        }


        public static void Main(string[] args)
        {
            Program p = new Program();
            int n = int.Parse(Console.ReadLine());
            p.board = new int[n,n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    p.board[i, j] = 0;
            p.Check(0, n);
            Console.WriteLine(results.Count);
            Console.ReadKey();
        }
    }
}
