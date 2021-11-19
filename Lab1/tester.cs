namespace Lab1
{
    static class tester
    {
        public static void testAddition()
        {
            try
            {
                for (long i = -1000; i < 1000; i++)
                {
                    for (long j = -1000; j < 1000; j++)
                    {
                        arithmetics iA = new arithmetics(i);
                        arithmetics jA = new arithmetics(j);
                        arithmetics sumA = iA + jA;
                        if (Convert.ToString(i + j) != sumA.ToString()) { throw new Exception(i + "+" + j + "=" + (i + j) + ", not " + sumA.ToString()); }
                    }
                }
                Console.WriteLine("Addition Worked Correctly!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void testSubtraction()
        {
            try
            {
                for (long i = -1000; i < 1000; i++)
                {
                    for (long j = -1000; j < i; j++)
                    {
                        arithmetics iA = new arithmetics(i);
                        arithmetics jA = new arithmetics(j);
                        arithmetics subA = iA - jA;
                        if (Convert.ToString(i - j) != subA.ToString()) { throw new Exception(i + "-" + j + "=" + (i - j) + ", not " + subA.ToString()); }
                    }
                }
                Console.WriteLine("Subtraction Worked Correctly!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void testMultiplication()
        {
            try
            {
                for (long i = -100; i < 100; i++)
                {
                    for (long j = -100; j < 100; j++)
                    {
                        arithmetics iA = new arithmetics(i);
                        arithmetics jA = new arithmetics(j);
                        arithmetics mulA = iA * jA;
                        if (Convert.ToString(i * j) != mulA.ToString()) { throw new Exception(i + "*" + j + "=" + (i * j) + ", not " + mulA.ToString()); }
                    }
                }
                Console.WriteLine("Multiplication Worked Correctly!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void testDivision()
        {
            try
            {
                for (long i = -100; i < 100; i++)
                {
                    for (long j = -100; j < 100; j++)
                    {
                        if (j == 0) continue;
                        arithmetics iA = new arithmetics(i);
                        arithmetics jA = new arithmetics(j);
                        arithmetics divA = iA / jA;
                        arithmetics remA = iA % jA;
                        if (Convert.ToString(i / j) != divA.ToString()) { throw new Exception(i + "/" + j + "=" + (i / j) + ", not " + divA.ToString()); }
                        if (Convert.ToString(i % j) != remA.ToString()) { throw new Exception(i + "%" + j + "=" + (i % j) + ", not " + remA.ToString()); }
                    }
                }
                Console.WriteLine("Division Worked Correctly!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void testPow()
        {
            try
            {
                for (long i = -10; i < 10; i++)
                {
                    for (long j = 1; j < 10; j++)
                    {
                        arithmetics iA = new arithmetics(i);
                        arithmetics jA = new arithmetics(j);
                        arithmetics powA = arithmetics.pow(iA, jA);
                        if (Convert.ToString(Math.Pow(i, j)) != powA.ToString()) { throw new Exception(i + "^" + j + "=" + Math.Pow(i, j) + ", not " + powA.ToString()); }
                    }
                }
                Console.WriteLine("Pows Worked Correctly!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void testAdditionModuled()
        {
            try
            {
                for (long i = -100; i < 100; i++)
                {
                    for (long j = -100; j < 100; j++)
                    {
                        for (int q = 2; q < 100; q++)
                        {
                            arithmetics iA = new arithmetics(i);
                            arithmetics jA = new arithmetics(j);
                            arithmetics qA = new arithmetics(q);
                            arithmetics sumModA = arithmetics.addModuled(iA, jA, qA);
                            if (Convert.ToString((i + j) % q) != sumModA.ToString()) { throw new Exception("(" + i + "+" + j + ")%" + q + "=" + ((i + j) % q) + ", not " + sumModA.ToString()); }

                        }
                    }
                }
                Console.WriteLine("Moduled Addition Worked Correctly!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void testSubtractionModuled()
        {
            try
            {
                for (long i = -100; i < 100; i++)
                {
                    for (long j = -100; j < 100; j++)
                    {
                        for (int q = 2; q < 100; q++)
                        {
                            arithmetics iA = new arithmetics(i);
                            arithmetics jA = new arithmetics(j);
                            arithmetics qA = new arithmetics(q);
                            arithmetics subModA = arithmetics.subModuled(iA, jA, qA);
                            if (Convert.ToString((i - j) % q) != subModA.ToString()) { throw new Exception("(" + i + "-" + j + ")%" + q + "=" + ((i - j) % q) + ", not " + subModA.ToString()); }

                        }
                    }
                }
                Console.WriteLine("Moduled Addition Worked Correctly!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void testMultiplicationModuled()
        {
            try
            {
                for (long i = -100; i < 100; i++)
                {
                    for (long j = -100; j < 100; j++)
                    {
                        for (int q = 2; q < 100; q++)
                        {
                            arithmetics iA = new arithmetics(i);
                            arithmetics jA = new arithmetics(j);
                            arithmetics qA = new arithmetics(q);
                            arithmetics mulModA = arithmetics.multModuled(iA, jA, qA);
                            if (Convert.ToString((i * j) % q) != mulModA.ToString()) { throw new Exception("(" + i + "*" + j + ")%" + q + "=" + ((i * j) % q) + ", not " + mulModA.ToString()); }

                        }
                    }
                }
                Console.WriteLine("Moduled Addition Worked Correctly!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void testDivisionModuled()
        {
            try
            {
                for (long i = -100; i < 100; i++)
                {
                    for (long j = -100; j < 100; j++)
                    {
                        for (int q = 2; q < 100; q++)
                        {
                            arithmetics iA = new arithmetics(i);
                            arithmetics jA = new arithmetics(j);
                            arithmetics qA = new arithmetics(q);
                            arithmetics divModA = arithmetics.divModuled(iA, jA, qA);
                            arithmetics remModA = arithmetics.remModuled(iA, jA, qA);
                            if (Convert.ToString((i / j) % q) != divModA.ToString()) { throw new Exception("(" + i + "/" + j + ")%" + q + "=" + ((i / j) % q) + ", not " + divModA.ToString()); }
                            if (Convert.ToString((i % j) % q) != remModA.ToString()) { throw new Exception("(" + i + "%" + j + ")%" + q + "=" + ((i % j) % q) + ", not " + remModA.ToString()); }
                        }
                    }
                }
                Console.WriteLine("Moduled Addition Worked Correctly!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void testPowModuled()
        {
            try
            {
                for (long i = -100; i < 100; i++)
                {
                    for (long j = -100; j < 100; j++)
                    {
                        for (int q = 2; q < 100; q++)
                        {
                            arithmetics iA = new arithmetics(i);
                            arithmetics jA = new arithmetics(j);
                            arithmetics qA = new arithmetics(q);
                            arithmetics sumModA = arithmetics.addModuled(iA, jA, qA);
                            if (Convert.ToString((i + j) % q) != sumModA.ToString()) { throw new Exception("(" + i + "+" + j + ")%" + q + "=" + ((i + j) % q) + ", not " + sumModA.ToString()); }

                        }
                    }
                }
                Console.WriteLine("Moduled Addition Worked Correctly!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void testSquareRoot()
        {
            try
            {
                for (long i = 0; i < 10000; i++)
                {
                    arithmetics iA = new arithmetics(i);
                    arithmetics sqrA = arithmetics.root(iA);
                    if (Convert.ToString(Math.Floor(Math.Sqrt(i))) != sqrA.ToString()) { throw new Exception("sqrt(" + i + ")" + "=" + (Math.Sqrt(i)) + ", not " + sqrA.ToString()); }

                }
                Console.WriteLine("SquareRoot Worked Correctly!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void testGreater()
        {
            try
            {
                for (long i = -1000; i < 1000; i++)
                {
                    for (long j = -1000; j < 1000; j++)
                    {
                        arithmetics iA = new arithmetics(i);
                        arithmetics jA = new arithmetics(j);
                        bool greaterA = iA > jA;
                        if (greaterA != (i > j)) { throw new Exception(i + ">" + j + "=" + (i > j) + ", not " + greaterA.ToString()); }
                    }
                }
                Console.WriteLine("Greater Comparison Worked Correctly!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void testLess()
        {
            try
            {
                for (long i = -1000; i < 1000; i++)
                {
                    for (long j = -1000; j < 1000; j++)
                    {
                        arithmetics iA = new arithmetics(i);
                        arithmetics jA = new arithmetics(j);
                        bool lessA = iA < jA;
                        if (lessA != (i < j)) { throw new Exception(i + "<" + j + "=" + (i < j) + ", not " + lessA.ToString()); }
                    }
                }
                Console.WriteLine("Less Comparison Worked Correctly!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void testEqual()
        {
            try
            {
                for (long i = -1000; i < 1000; i++)
                {
                    for (long j = -1000; j < 1000; j++)
                    {
                        arithmetics iA = new arithmetics(i);
                        arithmetics jA = new arithmetics(j);
                        bool equalA = iA == jA;
                        if (equalA != (i == j)) { throw new Exception(i + "==" + j + "=" + (i == j) + ", not " + equalA.ToString()); }
                    }
                }
                Console.WriteLine("Equal Comparison Worked Correctly!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void testNotEqual()
        {
            try
            {
                for (long i = -1000; i < 1000; i++)
                {
                    for (long j = -1000; j < 1000; j++)
                    {
                        arithmetics iA = new arithmetics(i);
                        arithmetics jA = new arithmetics(j);
                        bool notEqualA = iA != jA;
                        if (notEqualA != (i != j)) { throw new Exception(i + "!=" + j + "=" + (i == j) + ", not " + notEqualA.ToString()); }
                    }
                }
                Console.WriteLine("NotEqual Comparison Worked Correctly!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}