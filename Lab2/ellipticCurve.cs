using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2 {
    class ellipticCurve {
        // y^2 = x^3 + Ax + B (mod P)
        public arithmetics P { get; set; }
        public arithmetics A { get; set; }
        public arithmetics B { get; set; }
        public arithmetics N { get; set; }                     // Order of the curve
        public (arithmetics x, arithmetics y) G { get; set; }   // Generator (base point)


        public ellipticCurve(arithmetics p, arithmetics a, arithmetics b, arithmetics n, arithmetics gx, arithmetics gy) {
            P = p;
            A = a;
            B = b;
            G = (gx, gy);
            N = n;
        }

        public (arithmetics, arithmetics) AddPoints(arithmetics x1, arithmetics y1, arithmetics x2, arithmetics y2) {
            // if (!IsPointOnCurve(x1, y1) || !IsPointOnCurve(x2, y2)) {
            //     return (null, null);
            // }

            if (PointsEqual(ref x1, ref y1, ref x2, ref y2)) {
                if (y1 == new arithmetics() || y1 == new arithmetics(-1)) {
                    return (new arithmetics(-1), new arithmetics(-1));
                }

                var m = arithmetics.multModuled(new arithmetics(3) * x1 * x1 + A, arithmetics.Helper(new arithmetics(2) * y1, P), P);
                var x3 = (m * m - new arithmetics(2) * x1) % P;
                return (x3, (-y1 + m * (x1 - x3)) % P);
            }
            else {
                if (x1 == x2) {
                    return (new arithmetics(-1), new arithmetics(1));
                }

                if (x1 == new arithmetics(-1)) {
                    return (x2, y2);
                } 

                if (x2 == new arithmetics(-1)) {
                    return (x1, y1);
                }

                var m = arithmetics.multModuled(y2 - y1, arithmetics.Helper(x2 - x1, P), P);
                var x3 = (m * m - x1 - x2) % P;
                return (x3, (-y1 + m * (x1 - x3)) % P);
            }
        }

        public (arithmetics, arithmetics) AddPoints((arithmetics, arithmetics) p1, (arithmetics, arithmetics) p2) {
            return AddPoints(p1.Item1, p1.Item2, p2.Item1, p2.Item2);
        }

        private bool IsPointOnCurve(arithmetics x, arithmetics y) {
            return x == new arithmetics(-1) && y == new arithmetics(-1) ||
                   x >= new arithmetics(0) && y >= new arithmetics(0) && x < P && y < P &&
                   (y * y) % P == (arithmetics.pow(x, new arithmetics(3)) + A * x + B) % P;
        }

        private bool PointsEqual(ref arithmetics x1, ref arithmetics y1, ref arithmetics x2, ref arithmetics y2) {
            return x1 == x2 && y1 == y2;
        }

        public (arithmetics, arithmetics) PointSelfSum(arithmetics k, (arithmetics, arithmetics) p) {
            var res = p;
            
            for (arithmetics i = new arithmetics(1); i < k; i = i + new arithmetics(1)) {
                
                res = AddPoints(res, p);
            }
            return res;
        }

        public override string ToString() {
            var aStr = A == new arithmetics() ? "" : A == new arithmetics(1) ? " + x" : " + " + A.ToString() + "x";
            var bStr = B == new arithmetics(0) ? "" : " + " + B.ToString();
            return "y^2 = x^3" + aStr + bStr + " (mod " + P + ")";
        }
    }
}