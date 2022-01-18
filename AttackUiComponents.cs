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
            TextBox name,
            NumericUpDown attackCount,
            ComboBox advantage,
            NumericUpDown hitModifier,
            TextBox damageFormulaInput,
            ComboBox targetResistance,
            ComboBox damageType)
        {
            this.AttackTypeIndex = attackTypeIndex;
            this.IsEnabled = isEnabled;
            this.IsMagical = isMagical;
            this.Name = name;
            this.AttackCount = attackCount;
            this.Advantage = advantage;
            this.Advantage.DataSource = Enum.GetValues(typeof(Advantage));
            this.HitModifier = hitModifier;
            this.DamageFormulaInput = damageFormulaInput;
            this.TargetResistance = targetResistance;
            this.TargetResistance.DataSource = Enum.GetValues(typeof(Resistance));
            this.DamageType = damageType;
            this.DamageType.DataSource = Enum.GetValues(typeof(DamageType));
        }

        internal void onIsEnabledToggle()
        {
            bool isEnabled = this.IsEnabled.Checked;
            this.IsMagical.Enabled = isEnabled;
            this.Name.Enabled = isEnabled;
            this.AttackCount.Enabled = isEnabled;
            this.Advantage.Enabled = isEnabled;
            this.HitModifier.Enabled = isEnabled;
            this.DamageFormulaInput.Enabled = isEnabled;
            this.TargetResistance.Enabled = isEnabled;
            this.DamageType.Enabled = isEnabled;
        }

        internal void populateFromSpecification(AttackSpecification attackSpec)
        {
            this.IsEnabled.Checked = attackSpec.IsEnabled;
            this.IsMagical.Checked = attackSpec.IsMagical;
            this.Name.Text = attackSpec.Name;
            this.AttackCount.Value = attackSpec.AttackCount;
            this.Advantage.Text = attackSpec.Advantage.ToString("G");
            this.HitModifier.Value = attackSpec.HitModifier;
            this.DamageFormulaInput.Text = attackSpec.DamageFormula.ToText();
            this.TargetResistance.Text = attackSpec.TargetResistance.ToString("G");
            this.DamageType.Text = attackSpec.DamageType.ToString("G");
            this.onIsEnabledToggle();
        }

        internal int AttackTypeIndex { get; }
        internal CheckBox IsEnabled { get; }
        internal CheckBox IsMagical { get; }
        internal TextBox Name { get; }
        internal string GetDisplayName()
        {
            if (this.Name.Text.Length == 0)
            {
                return $"attack type {this.AttackTypeIndex}";
            } else
            {
                return this.Name.Text;
            }
        }
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
        internal TextBox DamageFormulaInput { get; }
        internal DamageFormula ParseDamageFormula()
        {
            return DamageFormula.Parse(DamageFormulaInput.Text);
        }

        internal DieType getDamageDieTypeEnum()
        {
            var damageFormula = ParseDamageFormula();
            return damageFormula.DamageDieType;
        }

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
