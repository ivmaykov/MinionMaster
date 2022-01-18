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
            int damageDieCount,
            DieType damageDieType,
            int additionalDamage,
            Resistance targetResistance,
            DamageType damageType)
        {
            this.Name = name;
            this.IsEnabled = isEnabled;
            this.IsMagical = isMagical;
            this.AttackCount = attackCount;
            this.Advantage = advantage;
            this.HitModifier = hitModifier;
            this.DamageDieCount = damageDieCount;
            this.DamageDieType = damageDieType;
            this.AdditionalDamage = additionalDamage;
            this.TargetResistance = targetResistance;
            this.DamageType = damageType;
        }

        internal string Name { get; }
        internal bool IsEnabled { get; }
        internal bool IsMagical { get; }
        internal int AttackCount { get; }
        internal Advantage Advantage { get; }
        internal int HitModifier { get; }
        internal int DamageDieCount { get; }
        internal DieType DamageDieType { get; }
        internal int AdditionalDamage { get; }
        internal Resistance TargetResistance { get; }
        internal DamageType DamageType { get; }

    }
}
