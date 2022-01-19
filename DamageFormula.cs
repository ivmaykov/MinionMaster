using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MinionMaster
{
    internal class DamageFormula
    {
        private static Regex ConstantDamagePattern = new Regex(@"^(\d+)$");
        private static Regex DieFormulaPattern = new Regex(@"^(\d+)(d\d+)([\+|\-]\d+)?$");
        internal static DamageFormula Parse(string str)
        {
            var match = ConstantDamagePattern.Match(str);
            if (match.Success)
            {
                int additionalDamage = Int32.Parse(match.Groups[1].Value);
                return new DamageFormula(0, new Die(1), additionalDamage);
            }
            match = DieFormulaPattern.Match(str);
            if (match.Success)
            {
                int dieCount = Int32.Parse(match.Groups[1].Value);
                Die damageDie = Die.Parse(match.Groups[2].Value);
                int additionalDamage = 0;
                if (match.Groups[3].Length > 0)
                {
                    additionalDamage = Int32.Parse(match.Groups[3].Value);
                }
                return new DamageFormula(dieCount, damageDie, additionalDamage);
            }
            throw new Exception($"Could not parse damage formula: '{str}'");
        }

        internal DamageFormula(int damageDieCount, Die damageDie, int additionalDamage)
        {
            this.DamageDieCount = damageDieCount;
            this.DamageDie = damageDie;
            this.AdditionalDamage = additionalDamage;
        }

        internal string ToText()
        {
            if (this.DamageDieCount == 0)
            {
                return AdditionalDamage.ToString();
            }
            else if (this.AdditionalDamage > 0)
            {
                return $"{this.DamageDieCount}{this.DamageDie}+{this.AdditionalDamage}";

            }
            else if (this.AdditionalDamage < 0)
            {
                return $"{this.DamageDieCount}{this.DamageDie}{this.AdditionalDamage}";
            }
            else
            {
                return $"{this.DamageDieCount}{this.DamageDie}";
            }
        }

        internal int DamageDieCount { get; }
        internal Die DamageDie { get; }
        internal int AdditionalDamage { get; }
    }
}
