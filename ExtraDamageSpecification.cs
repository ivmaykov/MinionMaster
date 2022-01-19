using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionMaster
{
    internal readonly struct ExtraDamageSpecification
    {
        internal ExtraDamageSpecification(
            bool isMagical,
            DamageFormula damageFormula,
            DamageType damageType,
            Resistance targetResistance,
            bool requiresSave,
            Ability saveAbility,
            int saveDC,
            DamageOnSaveFailure damageOnSaveFailure,
            string note)
        {
            this.IsMagical = isMagical;
            this.DamageFormula = damageFormula;
            this.DamageType = damageType;
            this.TargetResistance = targetResistance;
            this.RequiresSave = requiresSave;
            this.SaveAbility = saveAbility;
            this.SaveDC = saveDC;
            this.DamageOnSaveFailure = damageOnSaveFailure;
            this.Note = note;
        }
        internal bool IsMagical { get; }
        internal DamageFormula DamageFormula { get; }
        internal DamageType DamageType { get; }
        internal Resistance TargetResistance { get; }
        internal bool RequiresSave { get; }
        internal Ability SaveAbility { get; }
        internal int SaveDC { get; }
        internal DamageOnSaveFailure DamageOnSaveFailure { get; }
        internal string Note { get; }
    }
}
