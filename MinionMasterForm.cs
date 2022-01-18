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
                this.damage_die1_count_numericUpDown,
                this.damage_die1_comboBox,
                this.additional_damage1_numericUpDown,
                this.target_resistance1_comboBox,
                this.damage_type1_comboBox));
            attacks.Add(new AttackUiComponents(
                2,
                this.attack2_enabled_checkBox,
                this.attack2_magical_checkBox,
                this.attack2_name_textBox,
                this.attack2_count_numericUpDown,
                this.advantage2_comboBox,
                this.hit_modifier2_numericUpDown,
                this.damage_die2_count_numericUpDown,
                this.damage_die2_comboBox,
                this.additional_damage2_numericUpDown,
                this.target_resistance2_comboBox,
                this.damage_type2_comboBox));
            attacks.Add(new AttackUiComponents(
                3,
                this.attack3_enabled_checkBox,
                this.attack3_magical_checkBox,
                this.attack3_name_textBox,
                this.attack3_count_numericUpDown,
                this.advantage3_comboBox,
                this.hit_modifier3_numericUpDown,
                this.damage_die3_count_numericUpDown,
                this.damage_die3_comboBox,
                this.additional_damage3_numericUpDown,
                this.target_resistance3_comboBox,
                this.damage_type3_comboBox));
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
            rollTheDice();
            renderRollResults();
        }

        private void rollTheDiceForAttack(AttackUiComponents attackUi)
        {
            int numMinions = (int) this.num_minions_numericUpDown.Value;
            int numDamageDice = (int) attackUi.DamageDieCount.Value;
            DieType damageDieType = (DieType) Enum.Parse(typeof(DieType), attackUi.DamageDieType.Text);
            if (!Enum.IsDefined(typeof(DieType), damageDieType))
            {
                throw new Exception("Invalid DieType enum: " + attackUi.DamageDieType.Text);
            }
            DamageType damageType = (DamageType) Enum.Parse(typeof(DamageType), attackUi.DamageType.Text);
            if (!Enum.IsDefined(typeof(DamageType), damageType))
            {
                throw new Exception("Invalid DamageType enum: " + attackUi.DamageType.Text);
            }

            for (int m = 1; m <= numMinions; m++)
            {
                for (int a = 1; a <= attackUi.AttackCount.Value; a++)
                {
                    rolls.Add(new AttackAndDamageRoll(
                        m,
                        attackUi.AttackTypeIndex,
                        a,
                        new AttackRoll(DieType.d20.roll(), DieType.d20.roll()),
                        new DamageRoll(
                            multiRollDamageDice(numDamageDice, damageDieType),
                            multiRollDamageDice(numDamageDice, damageDieType))));
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
            string outputText = $"\t{attackUi.GetDisplayName()}: {attackUi.DamageDieCount.Value}{attackUi.DamageDieType.Text}";
            if (attackUi.AdditionalDamage.Value > 0)
            {
                outputText += $"+{attackUi.AdditionalDamage.Value}";
            }
            else if (attackUi.AdditionalDamage.Value < 0)
            {
                outputText += $"{attackUi.AdditionalDamage.Value}";
            }
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

        private void renderRollResults()
        {
            if (rolls.Count == 0)
            {
                this.output_textBox.Text = "Press the ROLL button!";
                return;
            }
            int numMinions = (int) this.num_minions_numericUpDown.Value;
            int targetAC = (int) this.target_ac_numericUpDown.Value;
            String outputText = $"Rolling attacks for {numMinions} minions vs AC {targetAC}{Environment.NewLine}";
            foreach (AttackUiComponents attack in attacks)
            {
                if (attack.IsEnabled.Checked)
                {
                    outputText += renderAttackHeader(attack) + Environment.NewLine;
                }
            }

            Dictionary<string, int> damageTotalsByType = new Dictionary<string, int>();
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
                outputText += $"Minion {r.MinionIndex} {attackUi.GetDisplayName()}, attack #{r.AttackCountIndex}: ";
                outputText += r.AttackRoll.describe(attackUi.getAdvantageEnum(), (int) attackUi.HitModifier.Value, targetAC);
                AttackResult attackResult = r.AttackRoll.getAttackResult(attackUi.getAdvantageEnum(), (int) attackUi.HitModifier.Value, targetAC);
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
                int damageDone = r.DamageRoll.getDamageResult(attackResult, attackUi.getTargetResistanceEnum(), (int) attackUi.AdditionalDamage.Value);
                DamageType damageType = attackUi.getDamageTypeEnum();
                bool isMagical = attackUi.IsMagical.Checked;
                outputText += ", doing " + r.DamageRoll.describe(
                    attackResult,
                    attackUi.getTargetResistanceEnum(),
                    (int) attackUi.AdditionalDamage.Value,
                    isMagical,
                    damageType);
                outputText += Environment.NewLine;
                string damageTypeDesc = "";
                if (isMagical)
                {
                    damageTypeDesc = $"Magical {damageType}";
                }
                else
                {
                    damageTypeDesc = damageType.ToString();
                }
                if (damageTotalsByType.ContainsKey(damageTypeDesc))
                {
                    damageTotalsByType[damageTypeDesc] += damageDone;
                }
                else
                {
                    damageTotalsByType[damageTypeDesc] = damageDone;
                }
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
            this.output_textBox.Text = outputText;
        }

        private void advantage1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void damage_die1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rolls.Clear();
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

        private void damage_die1_count_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rolls.Clear();
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

        private void additional_damage1_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void applyPreset(Preset preset)
        {
            int i = 0;
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
            this.num_minions_numericUpDown.Value = preset.MinionCount;
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
            rolls.Clear();
            renderRollResults();
        }

        private void attack2_enabled_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            attacks.ElementAt(1).onIsEnabledToggle();
            rolls.Clear();
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

        private void damage_die2_count_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rolls.Clear();
            renderRollResults();
        }

        private void damage_die2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rolls.Clear();
            renderRollResults();
        }

        private void additional_damage2_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void target_resistance2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void attack3_enabled_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            attacks.ElementAt(2).onIsEnabledToggle();
            rolls.Clear();
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

        private void damage_die3_count_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rolls.Clear();
            renderRollResults();
        }

        private void damage_die3_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rolls.Clear();
            renderRollResults();
        }
        private void additional_damage3_numericUpDown_ValueChanged(object sender, EventArgs e)
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
    }
}
