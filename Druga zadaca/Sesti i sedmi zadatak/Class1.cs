using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesti_i_sedmi_zadatak
{
    public class Class1
    {

        public static async Task<int> FactorialDigitSum(int n)
        {
            var result = 1;

            for (int i = 1; i <= n; i++)
                result *= i;

            return result;
        }
    }
}
