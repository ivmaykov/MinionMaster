using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionMaster
{
    internal readonly struct Preset
    {
        internal Preset(
            string name,
            AttackSpecification attack,
            int minionCount)
        {
            this.Name = name;
            this.Attacks = new List<AttackSpecification>(1);
            this.Attacks.Add(attack);
            this.MinionCount = minionCount;
        }

        internal Preset(
            string name,
            AttackSpecification attack1,
            AttackSpecification attack2,
            int minionCount)
        {
            this.Name = name;
            this.Attacks = new List<AttackSpecification>(2);
            this.Attacks.Add(attack1);
            this.Attacks.Add(attack2);
            this.MinionCount = minionCount;
        }

        internal Preset(
            string name,
            AttackSpecification attack1,
            AttackSpecification attack2,
            AttackSpecification attack3,
            int minionCount)
        {
            this.Name = name;
            this.Attacks = new List<AttackSpecification>(1);
            this.Attacks.Add(attack1);
            this.Attacks.Add(attack2);
            this.Attacks.Add(attack3);
            this.MinionCount = minionCount;
        }

        internal string Name { get; }
        internal List<AttackSpecification> Attacks { get; }
        internal int MinionCount { get; }
    }
}
