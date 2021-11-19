using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<congruence> cons = new List<congruence>();
            cons.Add(new congruence(5, 2, 12));
            cons.Add(new congruence(7, 2, 8));
            cons.Add(new congruence(3, 1, 5));
            
            // cons.Add(new congruence(15, 25, 17));
            // cons.Add(new congruence(7, 5, 9));
            // cons.Add(new congruence(31, 19, 83));
            // cons.Add(new congruence(256, 179, 337));

            cons = congruence.solveList(cons);
            Console.WriteLine(congruence.solve(cons));


            tester.testAddition();
            tester.testSubtraction();
            tester.testMultiplication();
            tester.testDivision();
            tester.testPow();
            tester.testSquareRoot();
            tester.testGreater();
            tester.testLess();
            tester.testEqual();
            tester.testNotEqual();

            // tester.testAdditionModuled();
            // tester.testSubtractionModuled();
            // tester.testMultiplicationModuled();
            // tester.testDivisionModuled();
            // tester.testPowModuled();
        }
    }
}