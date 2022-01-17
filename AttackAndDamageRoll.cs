using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionMaster
{
    public readonly struct AttackAndDamageRoll
    {
        public AttackAndDamageRoll(AttackRoll attackRoll, DamageRoll damageRoll)
        {
            this.AttackRoll = attackRoll;
            this.DamageRoll = damageRoll;
        }

        public AttackRoll AttackRoll { get; }
        public DamageRoll DamageRoll { get; }
    }
}
