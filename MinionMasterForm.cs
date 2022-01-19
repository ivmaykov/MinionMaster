using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace MinionMaster
{
    public partial class MinionMasterForm : Form
    {
        List<AttackAndDamageRoll> rolls = new List<AttackAndDamageRoll>();
        List<AttackUiComponents> attacks = new List<AttackUiComponents>();

        public MinionMasterForm()
        {
            InitializeComponent();
            attacks.Add(new AttackUiComponents(
                1,
                this.attack1_enabled_checkBox,
                this.attack1_magical_checkBox,
                this.attack1_name_textBox,
                this.attack1_count_numericUpDown,
                this.advantage1_comboBox,
                this.hit_modifier1_numericUpDown,
                this.attack1_damage_formula_textBox,
                this.target_resistance1_comboBox,
                this.damage_type1_comboBox,
                this.extra_damage1_checkBox,
                this.extra_damage_magical1_checkBox,
                this.attack1_extra_damage_formula_textBox,
                this.extra_damage_type1_comboBox,
                this.extra_target_resistance1_comboBox,
                this.extra_damage_save1_checkBox,
                this.extra_damage_save_ability1_comboBox,
                this.extra_damage_save_dc1_numericUpDown,
                this.extra_damage_save_on_failure1_comboBox,
                this.extra_damage_note1_textBox));
            attacks.Add(new AttackUiComponents(
                2,
                this.attack2_enabled_checkBox,
                this.attack2_magical_checkBox,
                this.attack2_name_textBox,
                this.attack2_count_numericUpDown,
                this.advantage2_comboBox,
                this.hit_modifier2_numericUpDown,
                this.attack2_damage_formula_textBox,
                this.target_resistance2_comboBox,
                this.damage_type2_comboBox,
                this.extra_damage2_checkBox,
                this.extra_damage_magical2_checkBox,
                this.attack2_extra_damage_formula_textBox,
                this.extra_damage_type2_comboBox,
                this.extra_target_resistance2_comboBox,
                this.extra_damage_save2_checkBox,
                this.extra_damage_save_ability2_comboBox,
                this.extra_damage_save_dc2_numericUpDown,
                this.extra_damage_save_on_failure2_comboBox,
                this.extra_damage_note2_textBox));
            attacks.Add(new AttackUiComponents(
                3,
                this.attack3_enabled_checkBox,
                this.attack3_magical_checkBox,
                this.attack3_name_textBox,
                this.attack3_count_numericUpDown,
                this.advantage3_comboBox,
                this.hit_modifier3_numericUpDown,
                this.attack3_damage_formula_textBox,
                this.target_resistance3_comboBox,
                this.damage_type3_comboBox,
                this.extra_damage3_checkBox,
                this.extra_damage_magical3_checkBox,
                this.attack3_extra_damage_formula_textBox,
                this.extra_damage_type3_comboBox,
                this.extra_target_resistance3_comboBox,
                this.extra_damage_save3_checkBox,
                this.extra_damage_save_ability3_comboBox,
                this.extra_damage_save_dc3_numericUpDown,
                this.extra_damage_save_on_failure3_comboBox,
                this.extra_damage_note3_textBox));
            this.preset_comboBox.DataSource = Presets.Values.Keys.ToList();
            this.output_textBox.Text = "Press the ROLL button!";
        }

        private List<int> multiRollDamageDice(int dieCount, DieType dieType)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < dieCount; i++)
            {
                result.Add(dieType.roll());
            }
            return result;
        }

        private void roll_button_Click(object sender, EventArgs e)
        {
            try
            {
                rollTheDice();
                renderRollResults();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rolls.Clear();
            }
        }

        private void rollTheDiceForAttack(AttackUiComponents attackUi)
        {
            if (!attackUi.IsEnabled.Checked)
            {
                return;
            }
            int numMinions = (int) this.num_minions_numericUpDown.Value;
            int numDamageDice = (int) attackUi.ParseDamageFormula().DamageDieCount;
            DieType damageDieType = attackUi.ParseDamageFormula().DamageDieType;

            for (int m = 1; m <= numMinions; m++)
            {
                for (int a = 1; a <= attackUi.AttackCount.Value; a++)
                {
                    DamageRoll? extraDamageRoll = null;
                    if (attackUi.HasExtraDamage.Checked)
                    {
                        int numExtraDamageDice = (int) attackUi.ParseExtraDamageFormula().DamageDieCount;
                        DieType extraDamageDieType = attackUi.ParseExtraDamageFormula().DamageDieType;
                        extraDamageRoll = new DamageRoll(
                            multiRollDamageDice(numExtraDamageDice, extraDamageDieType),
                            multiRollDamageDice(numExtraDamageDice, extraDamageDieType));
                    }
                    rolls.Add(new AttackAndDamageRoll(
                        m,
                        attackUi.AttackTypeIndex,
                        a,
                        new AttackRoll(DieType.d20.roll(), DieType.d20.roll()),
                        new DamageRoll(
                            multiRollDamageDice(numDamageDice, damageDieType),
                            multiRollDamageDice(numDamageDice, damageDieType)),
                        extraDamageRoll));
                }
            }
        }

        private void rollTheDice()
        {
            rolls.Clear();
            foreach (AttackUiComponents attack in attacks)
            {
                rollTheDiceForAttack(attack);
            }
        }

        private string renderAttackHeader(AttackUiComponents attackUi)
        {
            string outputText = $"\t{attackUi.GetDisplayName()}: {attackUi.DamageFormulaInput.Text}";
            if (attackUi.IsMagical.Checked)
            {
                outputText += " magical";
            }
            outputText += $" {attackUi.getDamageTypeEnum()}";
            if (attackUi.AttackCount.Value > 1)
            {
                outputText += $" {attackUi.AttackCount.Value} times";
            }
            if (attackUi.getAdvantageEnum() != Advantage.None)
            {
                outputText += $" with {attackUi.getAdvantageEnum()}";
            }
            if (attackUi.getTargetResistanceEnum() != Resistance.None)
            {
                outputText += $" vs a {attackUi.getTargetResistanceEnum()} target";
            }
            return outputText;
        }

        private string pluralize(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return str;
            }
            else if (str.EndsWith("Wolf"))
            {
                return str.Substring(0, str.Length - 1) + "ves";
            }
            else if (str.EndsWith("y") && str.Length >= 1)
            {
                return str.Substring(0, str.Length - 1) + "ies";
            }
            else if (str.EndsWith("s"))
            {
                return str + "es";
            }
            else
            {
                return str + "s";
            }
        }

        private void renderRollResults()
        {
            if (rolls.Count == 0)
            {
                this.output_textBox.Text = "Press the ROLL button!";
                return;
            }
            int numMinions = (int) this.num_minions_numericUpDown.Value;
            int targetAC = (int) this.target_ac_numericUpDown.Value;
            String minionName = this.minion_name_textBox.Text;
            if (minionName.Length == 0)
            {
                minionName = "minion";
            }
            String outputText = $"Rolling attacks for {numMinions} {pluralize(minionName)} vs AC {targetAC}{Environment.NewLine}";
            foreach (AttackUiComponents attack in attacks)
            {
                if (attack.IsEnabled.Checked)
                {
                    outputText += renderAttackHeader(attack) + Environment.NewLine;
                }
            }

            Dictionary<string, int> damageTotalsByType = new Dictionary<string, int>();
            Dictionary<string, int> extraDamageTotalsByType = new Dictionary<string, int>();
            int totalHits = 0;
            int totalCrits = 0;
            int totalMisses = 0;
            int totalCritFails = 0;

            foreach (AttackAndDamageRoll r in rolls)
            {
                AttackUiComponents attackUi = attacks.ElementAt(r.AttackTypeIndex - 1);
                if (!attackUi.IsEnabled.Checked)
                {
                    continue;
                }
                AttackSpecification spec = attackUi.GetAttackSpecification();
                outputText += $"{minionName} {r.MinionIndex} {spec.Name} #{r.AttackCountIndex}: ";
                outputText += r.AttackRoll.describe(spec.Advantage, spec.HitModifier, targetAC);
                AttackResult attackResult = r.AttackRoll.getAttackResult(spec.Advantage, spec.HitModifier, targetAC);
                if (AttackResult.Miss == attackResult)
                {
                    totalMisses++;
                    outputText += Environment.NewLine;
                    continue;
                }
                else if (AttackResult.CritFail == attackResult)
                {
                    totalCritFails++;
                    outputText += Environment.NewLine;
                    continue;

                }
                else if (AttackResult.Hit == attackResult)
                {
                    totalHits++;
                }
                else
                {
                    totalCrits++;
                }
                int damageDone = r.DamageRoll.getDamageResult(attackResult, spec.TargetResistance, spec.DamageFormula.AdditionalDamage);
                string damageTypeDesc = "";
                if (spec.IsMagical)
                {
                    damageTypeDesc = $"Magical {spec.DamageType}";
                }
                else
                {
                    damageTypeDesc = spec.DamageType.ToString("G");
                }
                if (damageTotalsByType.ContainsKey(damageTypeDesc))
                {
                    damageTotalsByType[damageTypeDesc] += damageDone;
                }
                else
                {
                    damageTotalsByType[damageTypeDesc] = damageDone;
                }
                outputText += $",{Environment.NewLine}\t doing " + r.DamageRoll.describe(
                    attackResult,
                    spec.TargetResistance,
                    spec.DamageFormula.AdditionalDamage,
                    spec.IsMagical,
                    spec.DamageType);
                if (spec.ExtraDamageSpec is ExtraDamageSpecification extraDamageSpec)
                {
                    if (r.ExtraDamageRoll is DamageRoll extraDamageRoll)
                    {
                        outputText += $",{Environment.NewLine}\t and {extraDamageRoll.describeExtraDamage(attackResult, extraDamageSpec)}!";
                        if (extraDamageSpec.Note.Length > 0)
                        {
                            outputText += $" (Note: {extraDamageSpec.Note})";
                        }
                        int extraDamageDone = extraDamageRoll.getExtraDamageResult(attackResult, extraDamageSpec);
                        string extraDamageTypeDesc = "";
                        if (extraDamageSpec.IsMagical)
                        {
                            extraDamageTypeDesc = $"Magical {extraDamageSpec.DamageType}";
                        }
                        else
                        {
                            extraDamageTypeDesc = extraDamageSpec.DamageType.ToString("G");
                        }
                        if (extraDamageTotalsByType.ContainsKey(extraDamageTypeDesc))
                        {
                            extraDamageTotalsByType[extraDamageTypeDesc] += extraDamageDone;
                        }
                        else
                        {
                            extraDamageTotalsByType[extraDamageTypeDesc] = extraDamageDone;
                        }
                    }
                }
                outputText += Environment.NewLine;
            }
            outputText += "Crits: " + totalCrits + ", hits: " + totalHits + ", misses: " + totalMisses;
            outputText += ", crit fails: " + totalCritFails;
            outputText += Environment.NewLine;
            if (damageTotalsByType.Count > 0)
            {
                outputText += "Total damage done by type: " + Environment.NewLine;
                outputText += damageTotalsByType.Select((entry) => $"{entry.Key}: {entry.Value}").Aggregate((x, y) => $"{x}{Environment.NewLine}{y}");
            }
            else
            {
                outputText += "Total damage done: 0" + Environment.NewLine;
            }
            outputText += Environment.NewLine;
            if (extraDamageTotalsByType.Count > 0)
            {
                outputText += "Max extra damage done by type (might depend on saves): " + Environment.NewLine;
                outputText += extraDamageTotalsByType.Select((entry) => $"{entry.Key}: {entry.Value}").Aggregate((x, y) => $"{x}{Environment.NewLine}{y}");
            }
            outputText += Environment.NewLine;
            this.output_textBox.Text = outputText;
        }

        private void advantage1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void target_resistance1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void hit_modifier1_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void target_ac_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void output_textBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void num_minions_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rolls.Clear();
            renderRollResults();
        }

        private void applyPreset(Preset preset)
        {
            int i = 0;
            this.allow_multi_attack_checkBox.Checked = preset.AllowMultiAttack;
            this.num_minions_numericUpDown.Value = preset.MinionCount;
            this.minion_name_textBox.Text = preset.MinionName;
            foreach (AttackSpecification attackSpec in preset.Attacks)
            {
                this.attacks.ElementAt(i).populateFromSpecification(attackSpec);
                i++;
            }
            for (; i < this.attacks.Count; i++)
            {
                this.attacks.ElementAt(i).IsEnabled.Checked = false;
                this.attacks.ElementAt(i).onIsEnabledToggle();
            }
        }

        private void preset_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Preset preset = Presets.Values[preset_comboBox.Text];
            applyPreset(preset);
            rolls.Clear();
            renderRollResults();
        }

        private void attack1_enabled_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.attacks.ElementAt(0).onIsEnabledToggle();
            if (!this.allow_multi_attack_checkBox.Checked && this.attacks.ElementAt(0).IsEnabled.Checked)
            {
                // If multi-attack is not allowed, and we just enabled attack 1, disable all other attacks
                this.attacks.ElementAt(1).IsEnabled.Checked = false;
                this.attacks.ElementAt(1).onIsEnabledToggle();
                this.attacks.ElementAt(2).IsEnabled.Checked = false;
                this.attacks.ElementAt(2).onIsEnabledToggle();
            }
            rolls.Clear();
            renderRollResults();
        }

        private void attack2_enabled_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.attacks.ElementAt(1).onIsEnabledToggle();
            if (!this.allow_multi_attack_checkBox.Checked && this.attacks.ElementAt(1).IsEnabled.Checked)
            {
                // If multi-attack is not allowed, and we just enabled attack 2, disable all other attacks
                this.attacks.ElementAt(0).IsEnabled.Checked = false;
                this.attacks.ElementAt(0).onIsEnabledToggle();
                this.attacks.ElementAt(2).IsEnabled.Checked = false;
                this.attacks.ElementAt(2).onIsEnabledToggle();
            }
            this.rolls.Clear();
            renderRollResults();
        }

        private void advantage2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void hit_modifier2_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void target_resistance2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void attack3_enabled_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.attacks.ElementAt(2).onIsEnabledToggle();
            if (!this.allow_multi_attack_checkBox.Checked && this.attacks.ElementAt(2).IsEnabled.Checked)
            {
                // If multi-attack is not allowed, and we just enabled attack 3, disable all other attacks
                this.attacks.ElementAt(0).IsEnabled.Checked = false;
                this.attacks.ElementAt(0).onIsEnabledToggle();
                this.attacks.ElementAt(1).IsEnabled.Checked = false;
                this.attacks.ElementAt(1).onIsEnabledToggle();
            }
            this.rolls.Clear();
            renderRollResults();
        }

        private void advantage3_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void hit_modifier3_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void target_resistance3_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void attack1_count_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rolls.Clear();
            renderRollResults();
        }

        private void attack2_count_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rolls.Clear();
            renderRollResults();
        }

        private void attack3_count_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rolls.Clear();
            renderRollResults();
        }

        private void damage_type1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void damage_type2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void damage_type3_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void attack1_magical_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void attack2_magical_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void attack3_magical_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void attack1_name_textBox_TextChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void attack2_name_textBox_TextChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void attack3_name_textBox_TextChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void attack1_damage_formula_textBox_TextChanged(object sender, EventArgs e)
        {
            rolls.Clear();
            renderRollResults();
        }

        private void attack2_damage_formula_textBox_TextChanged(object sender, EventArgs e)
        {
            rolls.Clear();
            renderRollResults();
        }

        private void attack3_damage_formula_textBox_TextChanged(object sender, EventArgs e)
        {
            rolls.Clear();
            renderRollResults();
        }

        private void attack1_extra_damage_formula_textBox_TextChanged(object sender, EventArgs e)
        {
            rolls.Clear();
            renderRollResults();
        }

        private void extra_damage_type1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_damage_magical1_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_damage1_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.attacks.ElementAt(0).onIsEnabledToggle();
            rolls.Clear();
            renderRollResults();
        }

        private void extra_target_resistance1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_damage_save1_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.attacks.ElementAt(0).onIsEnabledToggle();
            renderRollResults();
        }

        private void extra_damage_save_ability1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_damage_save_on_failure1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_damage2_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.attacks.ElementAt(1).onIsEnabledToggle();
            rolls.Clear();
            renderRollResults();
        }

        private void extra_damage_magical2_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void attack2_extra_damage_formula_textBox_TextChanged(object sender, EventArgs e)
        {
            rolls.Clear();
            renderRollResults();
        }

        private void extra_damage_type2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_target_resistance2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_damage_save2_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.attacks.ElementAt(1).onIsEnabledToggle();
            renderRollResults();
        }

        private void extra_damage_save_ability2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_damage_save_dc2_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_damage_save_on_failure2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_damage3_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.attacks.ElementAt(2).onIsEnabledToggle();
            rolls.Clear();
            renderRollResults();
        }

        private void extra_damage_magical3_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void attack3_extra_damage_formula_textBox_TextChanged(object sender, EventArgs e)
        {
            this.rolls.Clear();
            renderRollResults();
        }

        private void extra_damage_type3_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_target_resistance3_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_damage_save3_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.attacks.ElementAt(0).onIsEnabledToggle();
            renderRollResults();
        }

        private void extra_damage_save_ability3_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_damage_save_dc3_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_damage_save_on_failure3_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void allow_multi_attack_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            rolls.Clear();
            renderRollResults();
        }

        private void minion_name_textBox_TextChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_damage_note1_textBox_TextChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_damage_note2_textBox_TextChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void extra_damage_note3_textBox_TextChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }
    }
}
