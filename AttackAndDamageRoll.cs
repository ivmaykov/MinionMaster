using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionMaster
{
    internal readonly struct AttackAndDamageRoll
    {
        internal AttackAndDamageRoll(
            int minionIndex,
            int attackTypeIndex,
            int attackCountIndex,
            AttackRoll attackRoll,
            DamageRoll damageRoll,
            DamageRoll? extraDamageRoll)
        {
            this.MinionIndex = minionIndex; // starts at 1
            this.AttackTypeIndex = attackTypeIndex; // starts at 1
            this.AttackCountIndex = attackCountIndex; // starts at 1
            this.AttackRoll = attackRoll;
            this.DamageRoll = damageRoll;
            this.ExtraDamageRoll = extraDamageRoll;
        }

        internal int MinionIndex { get; }
        internal int AttackTypeIndex { get; }
        internal int AttackCountIndex { get; }
        internal AttackRoll AttackRoll { get; }
        internal DamageRoll DamageRoll { get; }
        internal DamageRoll? ExtraDamageRoll { get; }
    }
}
