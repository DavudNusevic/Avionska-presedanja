using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static Dictionary<string, int> mapa;
        static List<List<int>> adj;
        static Tuple<int, int>[] putnik;

        static int NajkraciPut(int at, int end)
        {
            if (at == end)
                return 0;

            int min = int.MaxValue;
            foreach(int d in adj[at])
                if(NajkraciPut(d,end) != int.MaxValue)
                    min = Math.Min(min, NajkraciPut(d, end) + 1);
            
            return min;
        }

        static void Main(string[] args)
        {
            int i, n, m, br = 0;
            n = int.Parse(Console.ReadLine());

            mapa = new Dictionary<string, int>();
            adj = new List<List<int>>(); 
           
            for(i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (!mapa.ContainsKey(input[0]))
                {
                    mapa.Add(input[0], br++);
                    adj.Add(new List<int>());
                }
                if (!mapa.ContainsKey(input[1]))
                {
                    mapa.Add(input[1], br++);
                    adj.Add(new List<int>());
                }

                adj[mapa[input[0]]].Add(mapa[input[1]]);
            }

            m = int.Parse(Console.ReadLine());
            putnik = new Tuple<int, int>[m];
            for(i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split();
                putnik[i] = new Tuple<int, int>(mapa[input[0]], mapa[input[1]]);
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine();

            for (i = 0; i < m; i++)
                if (NajkraciPut(putnik[i].Item1, putnik[i].Item2) != int.MaxValue)
                    Console.WriteLine(NajkraciPut(putnik[i].Item1, putnik[i].Item2));
                else
                    Console.WriteLine("ne");
        
            Console.ReadKey();

        }
    }
}
