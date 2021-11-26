using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            // for (int i = 3; i < 100; i++)
            // {
            //     Console.WriteLine(i + " " + crypthography.roPollard(new arithmetics(i)));
            // }

            // arithmetics num = new arithmetics(104729);

            // Console.WriteLine(num + " " + crypthography.millerRabin(num));

            // for (int i = 3; i < 100; i++)
            // {
            //     Console.WriteLine(i + " " + crypthography.millerRabin(new arithmetics(i)));
            // }


            
            // Console.WriteLine("~~~");
            // Dictionary<arithmetics,arithmetics> ans = crypthography.factorization(new arithmetics(69));
            // foreach (var i in ans)
            // {
            //     Console.WriteLine(i.Key + " " + i.Value);
            // }

            // for (int i = 1; i < 100; i++)
            // {
            //     Console.WriteLine(i + " " + crypthography.mobius(new arithmetics(i)));
            // }

            // Console.WriteLine(crypthography.bigSmall(new arithmetics(2), new arithmetics(49), new arithmetics(101)));


            // Console.WriteLine(crypthography.legendre(new arithmetics(12345), new arithmetics(331)));
            // Console.WriteLine(crypthography.legendre(new arithmetics(2), new arithmetics(5)));
            // Console.WriteLine(crypthography.legendre(new arithmetics(3), new arithmetics(5)));
            // Console.WriteLine(crypthography.legendre(new arithmetics(5), new arithmetics(5)));
            // Console.WriteLine(crypthography.legendre(new arithmetics(7), new arithmetics(5)));
            // Console.WriteLine(crypthography.legendre(new arithmetics(11), new arithmetics(5)));

            // Console.WriteLine(crypthography.jacobi(new arithmetics(7), new arithmetics(15)));
            // Console.WriteLine(crypthography.cipolla(new arithmetics(10), new arithmetics(13)));
            ellipticCurve c = new ellipticCurve(new arithmetics(67),new arithmetics(2),new arithmetics(3),new arithmetics(4),new arithmetics(2),new arithmetics(22));
            Console.WriteLine(c);
            crypthography.ElGamal(c);
        }
    }
}