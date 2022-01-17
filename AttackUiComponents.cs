using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinionMaster
{
    internal class AttackUiComponents
    {
        internal AttackUiComponents(
            int attackTypeIndex,
            CheckBox isEnabled,
            CheckBox isMagical,
            NumericUpDown attackCount,
            ComboBox advantage,
            NumericUpDown hitModifier,
            NumericUpDown damageDieCount,
            ComboBox damageDieType,
            NumericUpDown additionalDamage,
            ComboBox targetResistance,
            ComboBox damageType)
        {
            this.AttackTypeIndex = attackTypeIndex;
            this.IsEnabled = isEnabled;
            this.IsMagical = isMagical;
            this.AttackCount = attackCount;
            this.Advantage = advantage;
            this.Advantage.DataSource = Enum.GetValues(typeof(Advantage));
            this.HitModifier = hitModifier;
            this.DamageDieCount = damageDieCount;
            this.DamageDieType = damageDieType;
            this.DamageDieType.DataSource = Enum.GetValues(typeof(DieType));
            this.AdditionalDamage = additionalDamage;
            this.TargetResistance = targetResistance;
            this.TargetResistance.DataSource = Enum.GetValues(typeof(Resistance));
            this.DamageType = damageType;
            this.DamageType.DataSource = Enum.GetValues(typeof(DamageType));
        }

        internal int AttackTypeIndex { get; }
        internal CheckBox IsEnabled { get; }
        internal CheckBox IsMagical { get; }
        internal NumericUpDown AttackCount { get; }
        internal ComboBox Advantage { get; }

        internal Advantage getAdvantageEnum()
        {
            string advantageString = this.Advantage.Text;
            Advantage advantage = (Advantage)Enum.Parse(typeof(Advantage), advantageString);
            if (!Enum.IsDefined(typeof(Advantage), advantage))
            {
                throw new Exception("Invalid Advantage enum: " + advantageString);
            }
            return advantage;
        }

        internal NumericUpDown HitModifier { get; }
        internal NumericUpDown DamageDieCount { get; }
        internal ComboBox DamageDieType { get; }

        internal DieType getDamageDieTypeEnum()
        {
            string damageDieTypeString = this.DamageDieType.Text;
            DieType damageDieType = (DieType)Enum.Parse(typeof(DieType), damageDieTypeString);
            if (!Enum.IsDefined(typeof(DieType), damageDieType))
            {
                throw new Exception("Invalid DieType enum: " + damageDieTypeString);
            }
            return damageDieType;
        }

        internal NumericUpDown AdditionalDamage { get; }
        internal ComboBox TargetResistance { get; }

        internal Resistance getTargetResistanceEnum()
        {
            string resistanceString = this.TargetResistance.Text;
            Resistance resistance = (Resistance)Enum.Parse(typeof(Resistance), resistanceString);
            if (!Enum.IsDefined(typeof(Resistance), resistance))
            {
                throw new Exception("Invalid Resistance enum: " + resistanceString);
            }
            return resistance;

        }
        internal ComboBox DamageType { get; }

        internal DamageType getDamageTypeEnum()
        {
            string damageTypeString = this.DamageType.Text;
            DamageType damageType = (DamageType)Enum.Parse(typeof(DamageType), damageTypeString);
            if (!Enum.IsDefined(typeof(DamageType), damageType))
            {
                throw new Exception("Invalid DamageType enum: " + damageTypeString);
            }
            return damageType;
        }
    }
}
