using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionMaster
{
    internal readonly struct DamageRoll
    {
        internal DamageRoll(List<int> hitDamageRolls, List<int> critDamageRolls)
        {
            this.HitDamageRolls = hitDamageRolls;
            this.CritDamageRolls = critDamageRolls;
        }

        internal List<int> HitDamageRolls { get; }
        internal List<int> CritDamageRolls { get; }

        internal int getDamageResult(AttackResult attackResult, Resistance resistance, int additionalDamage)
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
            if (Resistance.Immune == resistance)
            {
                return 0;
            }
            if (allDice.Count == 0 && additionalDamage == 0)
            {
                return 0;
            }
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

        internal String describe(AttackResult attackResult, Resistance resistance, int additionalDamage, bool isMagical, DamageType damageType)
        {
            if (AttackResult.Miss == attackResult || AttackResult.CritFail == attackResult)
            {
                return "";
            }
            string damageTypeString = "";
            if (isMagical)
            {
                damageTypeString += "magical ";
            }
            damageTypeString += $"{damageType}";
            if (Resistance.Immune == resistance)
            {
                return $"0 {damageTypeString} damage (target is immune)";
            }
            List<int> allDice = getAllDamageDice(attackResult);
            int totalDamage = computeDamage(allDice, resistance, additionalDamage);
            String desc = "";
            if (additionalDamage != 0)
            {
                allDice.Add(additionalDamage);
            }
            String diceDetails = "";
            if (allDice.Count > 1 || Resistance.None != resistance)
            {
                diceDetails = $"({allDice.Select(d => d.ToString()).Aggregate((x, y) => Int32.Parse(y) >= 0 ? (x + "+" + y) : (x + y))})";
            }
            if (Resistance.Resistant == resistance)
            {
                desc = $"{totalDamage} ({diceDetails}/2) {damageTypeString} damage";
            }
            else if (Resistance.Vulnerable == resistance)
            {
                desc = $"{totalDamage} ({diceDetails}*2) {damageTypeString} damage";
            }
            else
            {
                desc = $"{totalDamage} {diceDetails} {damageTypeString} damage";
            }
            return desc;
        }

        internal string describeExtraDamage(AttackResult attackResult, ExtraDamageSpecification spec)
        {
            if (AttackResult.Miss == attackResult || AttackResult.CritFail == attackResult)
            {
                return "";
            }
            string damageTypeString = "";
            if (spec.IsMagical)
            {
                damageTypeString += "magical ";
            }
            damageTypeString += $"{spec.DamageType}";
            if (Resistance.Immune == spec.TargetResistance)
            {
                return $"0 extra {damageTypeString} damage (target is immune)";
            }
            List<int> allDice = getAllDamageDice(attackResult);
            int totalDamage = computeDamage(allDice, spec.TargetResistance, spec.DamageFormula.AdditionalDamage);
            int totalDamageOnSave = 0;
            if (spec.RequiresSave)
            {
                if (DamageOnSaveFailure.Half == spec.DamageOnSaveFailure)
                {
                    totalDamageOnSave = totalDamage / 2;
                }
                else if (DamageOnSaveFailure.Full == spec.DamageOnSaveFailure)
                {
                    totalDamageOnSave = totalDamage;
                }
            }
            String desc = "";
            if (spec.DamageFormula.AdditionalDamage != 0)
            {
                allDice.Add(spec.DamageFormula.AdditionalDamage);
            }
            String diceDetails = "";
            if (allDice.Count > 1 || Resistance.None != spec.TargetResistance)
            {
                diceDetails = $"({allDice.Select(d => d.ToString()).Aggregate((x, y) => Int32.Parse(y) >= 0 ? (x + "+" + y) : (x + y))})";
            }
            if (Resistance.Resistant == spec.TargetResistance)
            {
                desc = $"{totalDamage} ({diceDetails}/2) {damageTypeString} damage";
            }
            else if (Resistance.Vulnerable == spec.TargetResistance)
            {
                desc = $"{totalDamage} ({diceDetails}*2) {damageTypeString} damage";
            }
            else
            {
                desc = $"{totalDamage} {diceDetails} {damageTypeString} damage";
            }
            if (spec.RequiresSave)
            {
                desc += $" on {spec.SaveAbility} save failure (DC {spec.SaveDC})";
                if (totalDamage > 0 || totalDamageOnSave > 0) {
                    desc += $", or {totalDamageOnSave} damage on save success";
                }
            }
            return desc;
        }
        internal int getExtraDamageResult(AttackResult attackResult, ExtraDamageSpecification spec)
        {
            if (AttackResult.Miss == attackResult || AttackResult.CritFail == attackResult)
            {
                return 0;
            }
            List<int> allDice = getAllDamageDice(attackResult);
            return computeDamage(allDice, spec.TargetResistance, spec.DamageFormula.AdditionalDamage);
        }
    }
}
