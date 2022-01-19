using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionMaster
{
    internal readonly struct AttackSpecification
    {
        internal AttackSpecification(
            string name,
            bool isEnabled,
            bool isMagical,
            int attackCount,
            Advantage advantage,
            int hitModifier,
            DamageFormula damageFormula,
            Resistance targetResistance,
            DamageType damageType,
            ExtraDamageSpecification? extraDamageSpecification)
        {
            this.Name = name;
            this.IsEnabled = isEnabled;
            this.IsMagical = isMagical;
            this.AttackCount = attackCount;
            this.Advantage = advantage;
            this.HitModifier = hitModifier;
            this.DamageFormula = damageFormula;
            this.TargetResistance = targetResistance;
            this.DamageType = damageType;
            this.ExtraDamageSpec = extraDamageSpecification;
        }

        internal string Name { get; }
        internal bool IsEnabled { get; }
        internal bool IsMagical { get; }
        internal int AttackCount { get; }
        internal Advantage Advantage { get; }
        internal int HitModifier { get; }

        internal DamageFormula DamageFormula { get; }
        internal Resistance TargetResistance { get; }
        internal DamageType DamageType { get; }
        internal ExtraDamageSpecification? ExtraDamageSpec { get; }
    }
}
