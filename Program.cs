using System;
using System.Collections.Generic;
namespace LB4_2
{
    abstract class TVSeries
    {
        public abstract int Nth_of_P(int a, int k, int N);
        public abstract double S_of_P(int a, int k, int N);
        
    }


    class AP : TVSeries
    {
        public override int Nth_of_P (int a, int k, int N)

        {
            return (a + (N - 1) * k);
        }


        public override double S_of_P(int a, int k, int N)
        {
            return ((2 * a + (N - 1) * k) / 2) * N;
        }

    }

    class GP : TVSeries
    {
        public override int Nth_of_P(int a, int k, int N)
        {
            return (a * (int)(Math.Pow(k, N - 1)));
        }

        public override double S_of_P(int a, int k, int N)
        {
            return (a * ((int)(Math.Pow(k, N)) - 1) / (k - 1));
        }
    }





    class Program
    {
       public static void Main()
        {
            Random rnd = new Random();
            Console.Write("Input quanty progression: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input quanty element's: ");
            int N = Convert.ToInt32(Console.ReadLine());
            TVSeries[] Pr = new TVSeries[n+1];
            int MaxN = 0;
            int ai = 0;
            int di = 0;
            int ni = 0;
            for (int i = 1; i < n+1; i++)
            {
                int a = rnd.Next(1, 10);
           
                int d = rnd.Next(1, 10);
           
                if ((i % 2) == 0)
                {
                    Pr[i] = new GP();
                }
                else
                {
                    Pr[i] = new AP();
                }
                Console.Write("P (" + a + ", " + d + ", " + N + "): ");
                for (int j = 1; j < N+1; j++)
                {
                    Console.Write(" " + Pr[i].Nth_of_P(a, d, j));
                }
                Console.WriteLine();
                if (MaxN < Pr[i].Nth_of_P(a, d, N))
                {
                    MaxN = Pr[i].Nth_of_P(a, d, N);
                    ai = a;
                    di = d;
                    ni = i;
                }
            }
            Console.Write("Input quanty element's for summ: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The summ " + m + " element's " + ni + " progression is: " + Pr[ni].S_of_P(ai, di, m));
        }
    }
}

