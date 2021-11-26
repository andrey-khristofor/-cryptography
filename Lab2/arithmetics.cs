namespace Lab2
{
    class arithmetics
    {
        private string Value { get; set; }
        private string Sign { get; set; }

        public arithmetics(string s)
        {
            if (s[0] == '+') s = s.Remove(0, 1);
            if (s[0] == '-')
            {
                Sign = "-";
                s = s.Remove(0, 1);
            }
            else Sign = "+";

            int q = 0;
            while (q < s.Length && s[q] == '0')
            {
                q++;
            }
            s = s.Remove(0, q);

            Value = s;

            if (s == "")
            {
                Value = "0";
                Sign = "+";
            }
        }
        public arithmetics(long s)
        {
            if (s < 0)
            {
                Sign = "-";
                s *= (-1);
            }
            else Sign = "+";

            Value = Convert.ToString(s);


            if (s == 0)
            {
                Value = "0";
                Sign = "+";
            }
        }
        public arithmetics()
        {
            Value = "0";
            Sign = "+";
        }

        public static arithmetics operator +(arithmetics a, arithmetics b)
        {
            arithmetics toReturn = new arithmetics();
            if (a.Sign == "-")
            {
                if (b.Sign == "+") return b - (-a);
                toReturn.Sign = "-";
            }
            else
            {
                if (b.Sign == "-") return a - (-b);
                toReturn.Sign = "+";
            }
            char[] x, res;
            if (arithmetics.module(a) > arithmetics.module(b))
            {
                res = a.Value.ToCharArray();
                Array.Reverse(res);
                x = b.Value.ToCharArray();
                Array.Reverse(x);
            }
            else
            {
                x = a.Value.ToCharArray();
                Array.Reverse(x);
                res = b.Value.ToCharArray();
                Array.Reverse(res);
            }
            int digit = 0;
            int sum = 0;
            for (int i = 0; i < res.Length; i++)
            {
                if (i >= x.Length) { x = new List<char>(x) { '0' }.ToArray(); }
                sum = (res[i] - '0') + (x[i] - '0') + digit;
                res[i] = Convert.ToString(sum % 10)[0];
                digit = sum / 10;
                sum = 0;
            }
            if (digit != 0)
            {
                res = new List<char>(res) { Convert.ToString(digit)[0] }.ToArray();
            }
            Array.Reverse(res);
            toReturn.Value = new string(res);
            return toReturn;
        }

        public static arithmetics operator -(arithmetics a, arithmetics b)
        {
            arithmetics toReturn = new arithmetics();
            if (a.Sign == "-")
            {
                if (b.Sign == "-") return -b - -a;
                return a + -b;
            }
            else
            {
                if (b.Sign == "-") { return a + -b; }
            }
            if (a == b) { return new arithmetics(0); }
            if (b > a) toReturn.Sign = "-";
            char[] x, res;
            if (a > b)
            {
                res = a.Value.ToCharArray();
                Array.Reverse(res);
                x = b.Value.ToCharArray();
                Array.Reverse(x);
            }
            else
            {
                x = a.Value.ToCharArray();
                Array.Reverse(x);
                res = b.Value.ToCharArray();
                Array.Reverse(res);
            }
            int diff = 0;
            int digit = 0;
            for (int i = 0; i < res.Length; i++)
            {
                if (i >= x.Length) { x = new List<char>(x) { '0' }.ToArray(); }
                if ((res[i] - '0') - digit >= (x[i] - '0'))
                {
                    diff = (res[i] - '0') - (x[i] - '0') - digit;
                    digit = 0;
                    res[i] = Convert.ToString(diff)[0];
                }
                else
                {
                    diff = 10 + (res[i] - '0') - (x[i] - '0') - digit;
                    digit = 1;
                    res[i] = Convert.ToString(diff)[0];
                }
            }
            Array.Reverse(res);
            string r = new string(res);
            int q = 0;
            while (r[q] == '0')
            {
                q++;
            }
            r = r.Remove(0, q);

            toReturn.Value = (new arithmetics(r)).Value;
            return toReturn;
        }

        public static arithmetics operator *(arithmetics a, arithmetics b)
        {
            string sign = "-";
            if (a.Sign == "+" && b.Sign == "+") sign = "";
            if (a.Sign == "-" && b.Sign == "-") sign = "";
            char[] x, y;
            arithmetics res = new arithmetics();
            x = a.Value.ToCharArray();
            Array.Reverse(x);
            y = b.Value.ToCharArray();
            Array.Reverse(y);
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < y.Length; j++)
                {
                    res += new arithmetics(Convert.ToString((x[i] - '0') * (y[j] - '0')) + new String('0', i + j));
                }
            }
            return new arithmetics(sign + res.Value);
        }

        public static arithmetics operator /(arithmetics a, arithmetics b)
        {
            if (b.Value == "0") throw new Exception("Divided by zero");
            string sign = "-";
            if (a.Sign == "+" && b.Sign == "+") sign = "";
            if (a.Sign == "-" && b.Sign == "-") sign = "";

            arithmetics res = new arithmetics();
            if (arithmetics.module(a) < arithmetics.module(b)) return new arithmetics(0);
            arithmetics temp = new arithmetics();
            for (int i = 0; i < a.Value.Length; i++)
            {
                temp = new arithmetics(temp.Value + a.Value[i]);
                if (temp >= b) break;
            }
            int digit;
            int n = temp.Value.Length - 1;
            while (true)
            {
                digit = 0;
                temp = new arithmetics(temp.Value);
                while (arithmetics.module(b) * (new arithmetics(digit + 1)) <= temp)
                {
                    digit++;
                }
                res.Value += Convert.ToString(digit);
                temp -= arithmetics.module(b) * (new arithmetics(digit));
                n++;
                if (n == a.Value.Length) break;
                temp.Value = temp.Value + a.Value[n];
            }
            return new arithmetics(sign + res.Value);
        }

        public static arithmetics operator %(arithmetics a, arithmetics b)
        {
            return a - a / b * b;
        }

        public static arithmetics pow(arithmetics a, arithmetics b)
        {
            arithmetics res = new arithmetics(1);
            if (a.Sign == "-")
            {
                if ((b.Value[b.Value.Length - 1] - '0') % 2 == 1) res = new arithmetics(-1);
            }

            if (a.ToString() == "-1") return new arithmetics(res.Sign + "1");
            if (a.Value == "1" || a.Value == "0") return a;
            a = arithmetics.module(a);
            HashSet<int> pows = new HashSet<int>();
            int i = 0;
            int max = 0;
            while (b > new arithmetics(0))
            {
                if ((b.Value[b.Value.Length - 1] - '0') % 2 == 1)
                {
                    pows.Add(i);
                    max = i;
                }
                i++;
                b = b / new arithmetics(2);
            }
            for (int j = 0; j <= max; j++)
            {
                if (pows.Contains(j)) res *= a;
                a *= a;
            }
            return res;
        }

        public static arithmetics powModuled(arithmetics a, arithmetics b, arithmetics m)
        {
            arithmetics res = new arithmetics(1);
            for (int i = 0; i < Convert.ToInt32(b.ToString()); i++)
            {
                res = res * a;
                res = res % m;
            }
            return res;
        }

        public static arithmetics addModuled(arithmetics a, arithmetics b, arithmetics m)
        {
            return (a + b) % m;
        }

        public static arithmetics subModuled(arithmetics a, arithmetics b, arithmetics m)
        {
            return (a - b) % m;
        }

        public static arithmetics multModuled(arithmetics a, arithmetics b, arithmetics m)
        {
            return (a * b) % m;
        }

        public static arithmetics divModuled(arithmetics a, arithmetics b, arithmetics m)
        {
            return (a / b) % m;
        }

        public static arithmetics remModuled(arithmetics a, arithmetics b, arithmetics m)
        {
            return (a % b) % m;
        }

        public static arithmetics root(arithmetics a)
        {
            if (a.Sign == "-") throw new Exception("Value is less then zero");
            int n = (a.Value.Length + 1) / 2;
            arithmetics res = new arithmetics("1" + new String('0', n - 1));
            int i = 0;
            while (i < n)
            {
                res = new arithmetics(res.Value.Remove(i, 1).Insert(i, "9"));
                while (res * res > a)
                {
                    res = new arithmetics(res.Value.Insert(i + 1, Convert.ToString(res.Value[i] - '1')).Remove(i, 1));
                }
                i++;
            }
            return res;
        }

        public static bool operator >(arithmetics a, arithmetics b)
        {
            if (a.Sign == "-")
            {
                if (b.Sign == "+") return false;
                return -a < -b;
            }
            else
            {
                if (b.Sign == "-") return true;
            }
            if (a.Value.Length != b.Value.Length)
            {
                return a.Value.Length > b.Value.Length;
            }
            for (int i = 0; i < a.Value.Length; i++)
            {
                if (a.Value[i] == b.Value[i]) continue;
                return a.Value[i] > b.Value[i];
            }
            return false;
        }

        public static Tuple<arithmetics, arithmetics> congruence(List<Tuple<arithmetics, arithmetics>> list)
        {
            arithmetics a = new arithmetics();
            arithmetics b = a;
            Console.WriteLine(list[0].Item1);
            return Tuple.Create(a, b);
        }

        public static bool operator <(arithmetics a, arithmetics b)
        {
            if (a.Sign == "-")
            {
                if (b.Sign == "+") return true;
                return -a > -b;
            }
            else
            {
                if (b.Sign == "-") return false;
            }
            if (a.Value.Length != b.Value.Length)
            {
                return a.Value.Length < b.Value.Length;
            }
            for (int i = 0; i < a.Value.Length; i++)
            {
                if (a.Value[i] == b.Value[i]) continue;
                return a.Value[i] < b.Value[i];
            }
            return false;
        }

        public static bool operator >=(arithmetics a, arithmetics b)
        {
            return a == b || a > b;
        }

        public static bool operator <=(arithmetics a, arithmetics b)
        {
            return a == b || a < b;
        }

        public static bool operator ==(arithmetics a, arithmetics b)
        {
            return a.Value == b.Value && a.Sign == b.Sign;
        }

        public static bool operator !=(arithmetics a, arithmetics b)
        {
            return a.Value != b.Value || a.Sign != b.Sign;
        }

        public static arithmetics operator -(arithmetics a)
        {
            if (a.Sign == "-") a.Sign = "+";
            else a.Sign = "-";
            return a;
        }

        public static arithmetics module(arithmetics a)
        {
            arithmetics b = new arithmetics(a.Value);
            return b;
        }

        public override string ToString()
        {
            if (Sign == "-") return (Sign + Value);
            return Value;
        }

        public override bool Equals(object? obj)
        {
            return obj is arithmetics arithmetics &&
                   Value == arithmetics.Value &&
                   Sign == arithmetics.Sign;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Sign);
        }

        public static arithmetics gcd(arithmetics a, arithmetics b)
        {
            while (a * b != new arithmetics())
            {
                if (a > b) a = a % b;
                else b = b % a;
            }
            return a + b;
        }



        public static arithmetics Helper(arithmetics a, arithmetics b)
        {
            if (a.Value == "0")
                return new arithmetics(0);
            if (b.Value == "0")
                return new arithmetics(1);

            var q = a / b;
            var r = a - q * b;

            if (r.Value == "0")
                return new arithmetics(1);

            a = b;
            b = r;
            var u = new arithmetics(1);
            var u1 = new arithmetics(1);
            var u2 = new arithmetics(0);

            while (a % b != new arithmetics(0))
            {
                q = a / b;
                r = a - q * b;
                a = b;
                b = r;
                u = -q * u1 + u2;
                u2 = u1;
                u1 = u;
            }
            if (u.Sign == "+" && u.Value == "0")
                u.Sign = "-";

            return u;
        }

        public static arithmetics randArithmetics(arithmetics a)
        {
            Random r = new Random();
            int n;
            try
            {
                n = Convert.ToInt32(a.Value);
            }
            catch (Exception)
            {
                n = 1000000000;
            };
            if (n <= 1) return new arithmetics(1);
            return new arithmetics(r.Next(2, n));
        }
    }
    class congruence
    {
        private arithmetics a { get; set; }
        private arithmetics b { get; set; }
        private arithmetics m { get; set; }
        public congruence()
        {
            a = new arithmetics();
            b = new arithmetics();
            m = new arithmetics();
        }
        public congruence(arithmetics x, arithmetics y, arithmetics z)
        {
            a = x;
            b = y;
            m = z;
        }
        public congruence(string x, string y, string z)
        {
            a = new arithmetics(x);
            b = new arithmetics(y);
            m = new arithmetics(z);
        }
        public congruence(int x, int y, int z)
        {
            a = new arithmetics(x);
            b = new arithmetics(y);
            m = new arithmetics(z);
        }
        public static congruence solve(congruence x)
        {
            arithmetics d = arithmetics.gcd(x.a, x.m);
            arithmetics k = arithmetics.Helper(x.a, x.m);
            return new congruence(new arithmetics(1), (k * x.b / d + x.m / d) % (x.m / d), x.m / d);
        }

        public static List<congruence> solveList(List<congruence> con)
        {
            for (int i = 0; i < con.Count; i++)
            {
                con[i] = congruence.solve(con[i]);
            }
            return con;
        }

        public static congruence solve(List<congruence> con)
        {
            congruence c = new congruence();
            con = congruence.solveList(con);
            congruence current = con[0];
            for (int i = 1; i < con.Count; i++)
            {
                congruence x = congruence.solve(new congruence(current.m % con[i].m, (con[i].b - current.b) % con[i].m, con[i].m));

                current = new congruence(new arithmetics(1), (current.b + current.m * x.b) % (current.m * x.m), current.m * x.m);
            }
            return current;
        }

        public override string ToString()
        {
            if (a.ToString() == "1") return "x" + "=" + b.ToString() + "(mod " + m.ToString() + ")";
            return a.ToString() + "x" + "=" + b.ToString() + "(mod " + m.ToString() + ")";
        }
    }
}