using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionMaster
{
    public readonly struct DamageRoll
    {
        public DamageRoll(List<int> hitDamageRolls, List<int> critDamageRolls)
        {
            this.HitDamageRolls = hitDamageRolls;
            this.CritDamageRolls = critDamageRolls;
        }

        public List<int> HitDamageRolls { get; }
        public List<int> CritDamageRolls { get; }

        public int getDamageResult(AttackResult attackResult, Resistance resistance, int additionalDamage)
        {
            if (AttackResult.Miss == attackResult || AttackResult.CritFail == attackResult)
            {
                return 0;
            }
            List<int> allDice = getAllDamageDice(attackResult);
            return computeDamage(allDice, resistance, additionalDamage);
        }

        private List<int> getAllDamageDice(AttackResult attackResult)
        {
            List<int> allDice = new List<int>();
            if (AttackResult.Miss != attackResult && AttackResult.CritFail != attackResult)
            {
                allDice.AddRange(HitDamageRolls);
                if (AttackResult.Crit == attackResult)
                {
                    allDice.AddRange(CritDamageRolls);
                }
            }
            return allDice;
        }

        private int computeDamage(List<int> allDice, Resistance resistance, int additionalDamage)
        {
            int damage = additionalDamage + allDice.Aggregate(0, (x, y) => x + y);
            if (Resistance.Resistant == resistance)
            {
                return Math.Max(1, damage / 2);
            }
            else if (Resistance.Vulnerable == resistance)
            {
                return Math.Max(1, damage) * 2;
            }
            else
            {
                return Math.Max(1, damage);
            }
        }

        public String describe(AttackResult attackResult, Resistance resistance, int additionalDamage, bool isMagical, DamageType damageType)
        {
            if (AttackResult.Miss == attackResult || AttackResult.CritFail == attackResult)
            {
                return "0";
            }
            List<int> allDice = getAllDamageDice(attackResult);
            int totalDamage = computeDamage(allDice, resistance, additionalDamage);
            String desc = totalDamage.ToString();
            if (additionalDamage != 0)
            {
                allDice.Add(additionalDamage);
            }
            String diceDetails = "";
            if (allDice.Count > 1 || Resistance.Resistant != resistance)
            {
                diceDetails = $"({allDice.Select(d => d.ToString()).Aggregate((x, y) => Int32.Parse(y) >= 0 ? (x + "+" + y) : (x + y))})";
            }
            if (Resistance.Resistant == resistance)
            {
                desc = $"{totalDamage} ({diceDetails}/2)";
            }
            else if (Resistance.Vulnerable == resistance)
            {
                desc = $"{totalDamage} ({diceDetails}*2)";
            }
            if (isMagical)
            {
                desc += " magical";
            }
            desc += $" {damageType} damage!";
            return desc;
        }
    }
}
