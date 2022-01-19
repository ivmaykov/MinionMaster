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
            ComboBox damageType,
            CheckBox hasExtraDamage,
            CheckBox isExtraDamageMagical,
            TextBox extraDamageFormulaInput,
            ComboBox extraDamageType,
            ComboBox extraDamageResistance,
            CheckBox extraDamageRequiresSave,
            ComboBox extraDamageSaveAbility,
            NumericUpDown extraDamageSaveDC,
            ComboBox extraDamageOnSaveFailure,
            TextBox extraDamageNote)
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
            this.DamageTypeInput = damageType;
            this.DamageTypeInput.DataSource = Enum.GetValues(typeof(DamageType));
            this.HasExtraDamage = hasExtraDamage;
            this.IsExtraDamageMagical = isExtraDamageMagical;
            this.ExtraDamageFormulaInput = extraDamageFormulaInput;
            this.ExtraDamageType = extraDamageType;
            this.ExtraDamageType.DataSource = Enum.GetValues(typeof(DamageType));
            this.ExtraDamageResistance = extraDamageResistance;
            this.ExtraDamageResistance.DataSource = Enum.GetValues(typeof(Resistance));
            this.ExtraDamageRequiresSave = extraDamageRequiresSave;
            this.ExtraDamageSaveAbility = extraDamageSaveAbility;
            this.ExtraDamageSaveAbility.DataSource = Enum.GetValues(typeof(Ability));
            this.ExtraDamageSaveDC = extraDamageSaveDC;
            this.ExtraDamageOnSaveFailure = extraDamageOnSaveFailure;
            this.ExtraDamageOnSaveFailure.DataSource = Enum.GetValues(typeof(DamageOnSaveFailure));
            this.ExtraDamageNote = extraDamageNote;
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
            this.DamageTypeInput.Enabled = isEnabled;
            this.HasExtraDamage.Enabled = isEnabled;
            bool isExtraDamageControlEnabled = isEnabled && this.HasExtraDamage.Checked;
            this.IsExtraDamageMagical.Enabled = isExtraDamageControlEnabled;
            this.ExtraDamageFormulaInput.Enabled = isExtraDamageControlEnabled;
            this.ExtraDamageType.Enabled = isExtraDamageControlEnabled;
            this.ExtraDamageResistance.Enabled = isExtraDamageControlEnabled;
            this.ExtraDamageRequiresSave.Enabled = isExtraDamageControlEnabled;
            this.ExtraDamageNote.Enabled = isExtraDamageControlEnabled;
            bool isExtraDamageSaveControlEnabled = isExtraDamageControlEnabled && this.ExtraDamageRequiresSave.Checked;
            this.ExtraDamageSaveAbility.Enabled = isExtraDamageSaveControlEnabled;
            this.ExtraDamageSaveDC.Enabled = isExtraDamageSaveControlEnabled;
            this.ExtraDamageOnSaveFailure.Enabled = isExtraDamageSaveControlEnabled;
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
            this.DamageTypeInput.Text = attackSpec.DamageType.ToString("G");
            var extraDamageSpecNullable = attackSpec.ExtraDamageSpec;
            if (extraDamageSpecNullable is ExtraDamageSpecification extraDamageSpec)
            {
                this.HasExtraDamage.Checked = true;
                this.IsExtraDamageMagical.Checked = extraDamageSpec.IsMagical;
                this.ExtraDamageFormulaInput.Text = extraDamageSpec.DamageFormula.ToText();
                this.ExtraDamageType.Text = extraDamageSpec.DamageType.ToString("G");
                this.ExtraDamageResistance.Text = extraDamageSpec.TargetResistance.ToString("G");
                this.ExtraDamageRequiresSave.Checked = extraDamageSpec.RequiresSave;
                this.ExtraDamageSaveAbility.Text = extraDamageSpec.SaveAbility.ToString("G");
                this.ExtraDamageSaveDC.Value = extraDamageSpec.SaveDC;
                this.ExtraDamageOnSaveFailure.Text = extraDamageSpec.DamageOnSaveFailure.ToString("G");
                this.ExtraDamageNote.Text = extraDamageSpec.Note;
            } else
            {
                this.HasExtraDamage.Checked = false;
                this.IsExtraDamageMagical.Checked = false;
                this.ExtraDamageFormulaInput.Text = "";
                this.ExtraDamageType.Text = DamageType.Acid.ToString("G");
                this.ExtraDamageResistance.Text = Resistance.None.ToString("G");
                this.ExtraDamageRequiresSave.Checked = false;
                this.ExtraDamageSaveAbility.Text = Ability.STR.ToString("G");
                this.ExtraDamageSaveDC.Value = 13;
                this.ExtraDamageOnSaveFailure.Text = DamageOnSaveFailure.None.ToString("G");
                this.ExtraDamageNote.Text = "";
            }
            this.onIsEnabledToggle();
        }

        internal AttackSpecification GetAttackSpecification()
        {
            ExtraDamageSpecification? extraDamageSpecification = null;
            if (this.HasExtraDamage.Checked)
            {
                extraDamageSpecification = new ExtraDamageSpecification(
                    isMagical: this.IsExtraDamageMagical.Checked,
                    damageFormula: DamageFormula.Parse(this.ExtraDamageFormulaInput.Text),
                    damageType: getExtraDamageTypeEnum(),
                    targetResistance: getExtraDamageResistanceEnum(),
                    requiresSave: this.ExtraDamageRequiresSave.Checked,
                    saveAbility: getExtraDamageSaveAbilityEnum(),
                    saveDC: (int) this.ExtraDamageSaveDC.Value,
                    damageOnSaveFailure: getExtraDamageOnSaveFailureEnum(),
                    note: this.ExtraDamageNote.Text);
            }
            return new AttackSpecification(
                name: GetDisplayName(),
                isEnabled: this.IsEnabled.Checked,
                isMagical: this.IsMagical.Checked,
                attackCount: (int) this.AttackCount.Value,
                advantage: getAdvantageEnum(),
                hitModifier: (int) this.HitModifier.Value,
                damageFormula: ParseDamageFormula(),
                targetResistance: getTargetResistanceEnum(),
                damageType: getDamageTypeEnum(),
                extraDamageSpecification: extraDamageSpecification);
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
                throw new Exception($"Invalid Advantage string: {advantageString}");
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
            return parseTargetResistance(this.TargetResistance.Text);
        }

        internal ComboBox DamageTypeInput { get; }

        internal DamageType getDamageTypeEnum()
        {
            return parseDamageTypeString(this.DamageTypeInput.Text);
        }
        internal CheckBox HasExtraDamage { get; }
        internal CheckBox IsExtraDamageMagical { get; }
        internal TextBox ExtraDamageFormulaInput { get; }
        internal DamageFormula ParseExtraDamageFormula()
        {
            return DamageFormula.Parse(ExtraDamageFormulaInput.Text);
        }
        internal ComboBox ExtraDamageType { get; }

        internal DamageType getExtraDamageTypeEnum()
        {
            return parseDamageTypeString(this.ExtraDamageType.Text);
        }

        internal ComboBox ExtraDamageResistance { get; }

        internal Resistance getExtraDamageResistanceEnum()
        {
            return parseTargetResistance(this.ExtraDamageResistance.Text);
        }

        internal CheckBox ExtraDamageRequiresSave { get; }
        internal ComboBox ExtraDamageSaveAbility { get; }

        internal Ability getExtraDamageSaveAbilityEnum()
        {
            string abilityString = this.ExtraDamageSaveAbility.Text;
            Ability ability = (Ability) Enum.Parse(typeof(Ability), abilityString);
            if (!Enum.IsDefined(typeof(Ability), ability))
            {
                throw new Exception($"Invalid Ability string: {abilityString}");
            }
            return ability;
        }

        internal NumericUpDown ExtraDamageSaveDC { get; }
        internal ComboBox ExtraDamageOnSaveFailure { get; }

        DamageOnSaveFailure getExtraDamageOnSaveFailureEnum()
        {
            string enumString = this.ExtraDamageOnSaveFailure.Text;
            DamageOnSaveFailure enumValue = (DamageOnSaveFailure) Enum.Parse(typeof(DamageOnSaveFailure), enumString);
            if (!Enum.IsDefined(typeof(DamageOnSaveFailure), enumValue))
            {
                throw new Exception($"Invalid DamageOnSaveFailure string: {enumString}");
            }
            return enumValue;
        }

        private DamageType parseDamageTypeString(string damageTypeString)
        {
            DamageType damageType = (DamageType) Enum.Parse(typeof(DamageType), damageTypeString);
            if (!Enum.IsDefined(typeof(DamageType), damageType))
            {
                throw new Exception($"Invalid DamageType string: {damageTypeString}");
            }
            return damageType;
        }

        private Resistance parseTargetResistance(string resistanceString)
        {
            Resistance resistance = (Resistance) Enum.Parse(typeof(Resistance), resistanceString);
            if (!Enum.IsDefined(typeof(Resistance), resistance))
            {
                throw new Exception($"Invalid Resistance string: {resistanceString}");
            }
            return resistance;
        }
        internal TextBox ExtraDamageNote { get; }
    }
}
