using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesti_i_sedmi_zadatak
{
    public class Class1
    {
        public static void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = GetTheMagicNumber().Result;
            Console.WriteLine(result);
        }

        private static async Task<int> GetTheMagicNumber()
        {
            return await IKnowIGuyWhoKnowsAGuyAsync();
        }

        private static async Task<int> IKnowIGuyWhoKnowsAGuyAsync()
        {
            return await IKnowWhoKnowsThisAsync(10) + await IKnowWhoKnowsThisAsync(5);
        }

        private static async Task<int> IKnowWhoKnowsThisAsync(int n)
        {
            return await FactorialDigitSum(n);
        }
        public static async Task<int> FactorialDigitSum(int n)
        {
            var result = 1;

            for (int i = 1; i <= n; i++)
                result *= i;

            return result;
        }
    }
}
