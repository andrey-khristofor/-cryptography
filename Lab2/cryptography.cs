namespace Lab2
{
    class crypthography
    {
        delegate arithmetics Function(arithmetics x);
        public static arithmetics roPollard(arithmetics n)
        {
            if (n == new arithmetics(1)) return n;
            if (millerRabin(n)) { return n; }
            Function f = (x) => x * x - new arithmetics(1);
            arithmetics x = arithmetics.randArithmetics(n - new arithmetics(2));
            arithmetics y = new arithmetics(1);
            arithmetics i = new arithmetics();
            arithmetics stage = new arithmetics(2);
            while (arithmetics.gcd(n, arithmetics.module(x - y)) == new arithmetics(1))
            {
                if (i == stage)
                {
                    y = x;
                    stage = stage * new arithmetics(2);
                }
                x = f(x) % n;
                i = i + new arithmetics(1);
            }
            return arithmetics.gcd(n, arithmetics.module(x - y));
        }
        public static Dictionary<arithmetics, arithmetics> factorization(arithmetics num)
        {
            Dictionary<arithmetics, arithmetics> dict = new Dictionary<arithmetics, arithmetics>();
            arithmetics n;
            do
            {
                n = roPollard(num);
                if (n.ToString() == "1") continue;
                if (dict.ContainsKey(n))
                {
                    dict[n] = dict[n] + new arithmetics(1);
                    num = num / n;
                }
                else
                {
                    if (millerRabin(n))
                    {
                        dict.Add(n, new arithmetics(1));
                        num = num / n;
                    }
                }
            }
            while (num != new arithmetics(1));
            return dict;
        }
        public static arithmetics bigSmall(arithmetics a, arithmetics b, arithmetics n)
        {
            arithmetics m = arithmetics.root(n);
            arithmetics p = arithmetics.pow(a, m) % n;
            arithmetics q = p;
            Dictionary<arithmetics, arithmetics> dict = new Dictionary<arithmetics, arithmetics>();
            for (arithmetics i = new arithmetics(1); i <= m; i = i + new arithmetics(1))
            {
                dict.Add(i, q);
                q = (q * p) % n;
            }
            for (arithmetics j = new arithmetics(); j < m; j = j + new arithmetics(1))
            {
                arithmetics temp = b * arithmetics.pow(a, j) % n;
                if (dict.ContainsValue(temp))
                {
                    foreach (var i in dict)
                    {
                        if (i.Value == temp)
                        {
                            return i.Key * m - j;
                        }
                    }
                }
            }
            return a;
        }
        public static arithmetics eiler(arithmetics n)
        {
            arithmetics res = new arithmetics(n.ToString());
            Dictionary<arithmetics, arithmetics> fact = factorization(n);
            foreach (var i in fact)
            {
                res = res * (i.Key - new arithmetics(1));
                res = res / i.Key;
            }

            return res;
        }
        public static arithmetics mobius(arithmetics n)
        {
            if (n.ToString() == "1") return n;
            var fact = factorization(n);
            foreach (var i in fact)
            {
                if (i.Value > new arithmetics(1)) return new arithmetics();
            }
            if (fact.Count % 2 == 0) return new arithmetics(1);
            else return new arithmetics(-1);
        }
        public static arithmetics legendre(arithmetics a, arithmetics p)
        {
            if (a % p == new arithmetics(0)) return new arithmetics(0);
            a = a % p;

            if (arithmetics.pow(a, (p - new arithmetics(1)) / new arithmetics(2)) % p == new arithmetics(-1) || arithmetics.pow(a, (p - new arithmetics(1)) / new arithmetics(2)) % p == p - new arithmetics(1))
                return new arithmetics(-1);

            if (arithmetics.pow(a, (p - new arithmetics(1)) / new arithmetics(2)) % p == new arithmetics(1))
                return new arithmetics(1);

            return new arithmetics(2);
        }
        public static arithmetics jacobi(arithmetics a, arithmetics p)
        {
            arithmetics res = new arithmetics(1);

            var fact = factorization(p);
            foreach (var i in fact)
            {
                if (i.Value % new arithmetics(2) != new arithmetics())
                {
                    if (legendre(a, i.Key) == new arithmetics(2)) return new arithmetics(2);
                    res = res * legendre(a, i.Key);
                }
            }
            return res;
        }
        public static (arithmetics, arithmetics) cipolla(arithmetics n, arithmetics p)
        {
            arithmetics a = new arithmetics();
            arithmetics e;
            while (true)
            {
                e = ((a * a - n) % p + p) % p;
                if (legendre(e, p) != new arithmetics(1)) break;
                a = a + new arithmetics(1);
            }

            var finalW = e;
            (arithmetics, arithmetics) MulExtended((arithmetics, arithmetics) aa, (arithmetics, arithmetics) bb)
            {
                return ((aa.Item1 * bb.Item1 + aa.Item2 * bb.Item2 * finalW) % p,
                        (aa.Item1 * bb.Item2 + bb.Item1 * aa.Item2) % p);
            }

            var r = (new arithmetics(1), new arithmetics(0));
            var s = (a, new arithmetics(1));
            var nn = (p + new arithmetics(1)) / new arithmetics(2);
            while (nn > new arithmetics())
            {
                if (nn % new arithmetics(2) != new arithmetics())
                {
                    r = MulExtended(r, s);
                }
                s = MulExtended(s, s);
                nn = nn / new arithmetics(2);
            }

            if (r.Item2 != new arithmetics(0) || r.Item1 * r.Item1 % p != n)
            {
                return (new arithmetics(), new arithmetics("100000000000000000000000000000000"));
            }

            return (r.Item1, p - r.Item1);
        }
        public static bool millerRabin(arithmetics n)
        {
            if (n.ToString() == "2") return true;
            if (n % new arithmetics(2) == new arithmetics()) return false;
            arithmetics m = (n - new arithmetics(1)) / new arithmetics(2);
            arithmetics t = new arithmetics(1);
            while (m % new arithmetics(2) == new arithmetics())
            {
                m = m / new arithmetics(2);
                t = t + new arithmetics(1);
            }
            for (int i = 0; i < 10; i++)
            {
                arithmetics a = arithmetics.randArithmetics(arithmetics.root(n));
                arithmetics u = arithmetics.powModuled(a, m, n);
                if (u != new arithmetics(1))
                {
                    arithmetics j = new arithmetics(1);
                    while (u != new arithmetics(-1) && u != n - new arithmetics(1) && j < t)
                    {
                        u = (u * u) % n;
                        j = j + new arithmetics(1);
                    }
                    if (u != new arithmetics(-1) && u != n - new arithmetics(1)) return false;
                }
            }
            return true;
        }





        private static arithmetics ALPH_BASE = new arithmetics(28);
        private static arithmetics ALPH_DIFF = new arithmetics(64);

        public static void ElGamal(ellipticCurve curve)
        {
            // Step 1. Bob chooses a random number k = 1, ..., N-1.
            var k = arithmetics.randArithmetics(curve.N);
            Console.WriteLine("Bob's private key: " + k.ToString());
            var Y = curve.PointSelfSum(k, curve.G);

            // Step 2. Alice's message
            (arithmetics x, arithmetics y) M;

            // If there was a way to quickly compute Y-s on my computer,
            // here would've been the encoding of message as the elliptic curve point.

            /*Console.Write("Enter Alice's message: ");
            M.x = MessageToarithmetics(Console.ReadLine());
            M.y = SqrtCipolla(Pow(M.x, 3) + curve.A * M.x + curve.B, curve.P).Item1;*/

            Console.Write("Enter point's x coordinate: ");
            M.x = new arithmetics(Console.ReadLine());
            Console.Write("Enter point's y coordinate: ");
            M.y = new arithmetics(Console.ReadLine());

            // Step 3. Encryption
            var r = arithmetics.randArithmetics(curve.N);
            var D = curve.PointSelfSum(r, Y);
            var G = curve.PointSelfSum(r, curve.G);
            var H = curve.AddPoints(M, D);


            // Step 4. Decryption
            var S = curve.PointSelfSum(k, G);
            var S1 = (S.Item1, (S.Item1 + S.Item2) % curve.P);
            var M1 = curve.AddPoints(S1, H);
            Console.WriteLine("Point decrypted: (" + M1.Item1.ToString() + "," + M1.Item2.ToString() + ")");

            // Message processing again
            /*var res = arithmeticsToMessage(M1.Item1);
            Console.WriteLine("Message decrypted: " + res);*/
        }
    }
}