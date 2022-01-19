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
                return new DamageFormula(0, DieType.d2, additionalDamage);
            }
            match = DieFormulaPattern.Match(str);
            if (match.Success)
            {
                int dieCount = Int32.Parse(match.Groups[1].Value);
                DieType dieType = (DieType) Enum.Parse(typeof(DieType), match.Groups[2].Value);
                if (!Enum.IsDefined(typeof(DieType), dieType))
                {
                    throw new Exception($"Invalid die type in damage formula: {match.Groups[2].Value}");
                }
                int additionalDamage = 0;
                if (match.Groups[3].Length > 0)
                {
                    additionalDamage = Int32.Parse(match.Groups[3].Value);
                }
                return new DamageFormula(dieCount, dieType, additionalDamage);
            }
            throw new Exception($"Could not parse damage formula: '{str}'");
        }

        internal DamageFormula(int damageDieCount, DieType damageDieType, int additionalDamage)
        {
            this.DamageDieCount = damageDieCount;
            this.DamageDieType = damageDieType;
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
                return $"{this.DamageDieCount}{this.DamageDieType.ToString("G")}+{this.AdditionalDamage}";

            }
            else if (this.AdditionalDamage < 0)
            {
                return $"{this.DamageDieCount}{this.DamageDieType.ToString("G")}{this.AdditionalDamage}";
            }
            else
            {
                return $"{this.DamageDieCount}{this.DamageDieType.ToString("G")}";
            }
        }

        internal int DamageDieCount { get; }
        internal DieType DamageDieType { get; }
        internal int AdditionalDamage { get; }
    }
}
