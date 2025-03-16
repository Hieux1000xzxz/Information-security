using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TraoDoiKhoa
{
    public static class SharedData
    {
        public static string Data1 { get; set; }
        public static string Data2 { get; set; }

        public static (BigInteger,BigInteger)[] Banma { get; set; }
        public static (BigInteger, BigInteger)[] yc { get; set; }

    }
}
