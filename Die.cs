using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MinionMaster
{
    internal readonly struct Die
    {
        private static Random random = new Random();
        private static Regex DiePattern = new Regex(@"^d(\d+)$");

        internal static Die d20 = new Die(20);

        internal Die(int numFaces)
        {
            this.NumFaces = numFaces;
        }
        internal static Die Parse(string str)
        {
            var match = DiePattern.Match(str);
            if (match.Success)
            {
                int numFaces = Int32.Parse(match.Groups[1].Value);
                return new Die(numFaces);
            }
            throw new Exception($"Error parsing die string: '{str}' with regex '{DiePattern}'");
        }

        public override string ToString()
        {
            return $"d{this.NumFaces}";
        }

        internal int roll()
        {
            return random.Next(1, this.NumFaces + 1);
        }
        private int NumFaces { get; }
    }
}
