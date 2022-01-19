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
            string presetName,
            string minionName,
            AttackSpecification attack1,
            int minionCount)
        {
            this.PresetName = presetName;
            this.MinionName = minionName;
            this.Attacks = new List<AttackSpecification>(1);
            this.Attacks.Add(attack1);
            this.AllowMultiAttack = false;
            this.MinionCount = minionCount;
        }

        internal Preset(
            string presetName,
            string minionName,
            AttackSpecification attack1,
            AttackSpecification attack2,
            bool allowMultiAttack,
            int minionCount)
        {
            this.PresetName = presetName;
            this.MinionName = minionName;
            this.Attacks = new List<AttackSpecification>(2);
            this.Attacks.Add(attack1);
            this.Attacks.Add(attack2);
            this.AllowMultiAttack = allowMultiAttack;
            this.MinionCount = minionCount;
        }

        internal Preset(
            string presetName,
            string minionName,
            AttackSpecification attack1,
            AttackSpecification attack2,
            AttackSpecification attack3,
            bool allowMultiAttack,
            int minionCount)
        {
            this.PresetName = presetName;
            this.MinionName = minionName;
            this.Attacks = new List<AttackSpecification>(3);
            this.Attacks.Add(attack1);
            this.Attacks.Add(attack2);
            this.Attacks.Add(attack3);
            this.AllowMultiAttack = allowMultiAttack;
            this.MinionCount = minionCount;
        }

        internal string PresetName { get; }
        internal string MinionName { get; }
        internal List<AttackSpecification> Attacks { get; }
        internal bool AllowMultiAttack { get; }
        internal int MinionCount { get; }
    }
}
