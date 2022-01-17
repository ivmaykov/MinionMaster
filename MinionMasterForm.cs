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
                this.attack3_count_numericUpDown,
                this.advantage3_comboBox,
                this.hit_modifier3_numericUpDown,
                this.damage_die3_count_numericUpDown,
                this.damage_die3_comboBox,
                this.additional_damage3_numericUpDown,
                this.target_resistance3_comboBox,
                this.damage_type3_comboBox));
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
            int numMinions = (int)this.num_minions_numericUpDown.Value;
            int numDamageDice = (int)attackUi.DamageDieCount.Value;
            DieType damageDieType = (DieType) Enum.Parse(typeof(DieType), attackUi.DamageDieType.Text);
            if (!Enum.IsDefined(typeof(DieType), damageDieType))
            {
                throw new Exception("Invalid DieType enum: " + attackUi.DamageDieType.Text);
            }
            DamageType damageType = (DamageType)Enum.Parse(typeof(DamageType), attackUi.DamageType.Text);
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
            String outputText = $"\tAttack {attackUi.AttackTypeIndex}: {attackUi.DamageDieCount.Value}{attackUi.DamageDieType.Text}";
            if (attackUi.AdditionalDamage.Value > 0)
            {
                outputText += $"+{attackUi.AdditionalDamage.Value}";
            } else if (attackUi.AdditionalDamage.Value < 0)
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
            int numMinions = (int)this.num_minions_numericUpDown.Value;
            int targetAC = (int)this.target_ac_numericUpDown.Value;
            String outputText = $"Rolling attacks for {numMinions} minions vs AC {targetAC}{Environment.NewLine}";
            foreach (AttackUiComponents attack in attacks)
            {
                if (attack.IsEnabled.Checked)
                {
                    outputText += renderAttackHeader(attack) + Environment.NewLine;
                }
            }

            Dictionary<(DamageType, bool), int> damageTotalsByType = new Dictionary<(DamageType, bool), int>();
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
                outputText += $"Minion {r.MinionIndex}, attack type {r.AttackTypeIndex}, attack count {r.AttackCountIndex}: ";
                outputText += r.AttackRoll.describe(attackUi.getAdvantageEnum(), (int) attackUi.HitModifier.Value, targetAC);
                AttackResult attackResult = r.AttackRoll.getAttackResult(attackUi.getAdvantageEnum(), (int)attackUi.HitModifier.Value, targetAC);
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
                else {
                    totalCrits++;
                }
                int damageDone = r.DamageRoll.getDamageResult(attackResult, attackUi.getTargetResistanceEnum(), (int)attackUi.AdditionalDamage.Value);
                DamageType damageType = attackUi.getDamageTypeEnum();
                bool isMagical = attackUi.IsMagical.Checked;
                outputText += ", doing " + r.DamageRoll.describe(
                    attackResult,
                    attackUi.getTargetResistanceEnum(),
                    (int)attackUi.AdditionalDamage.Value,
                    isMagical,
                    damageType);
                outputText += Environment.NewLine;
                if (damageTotalsByType.ContainsKey((damageType, isMagical))) {
                    damageTotalsByType[(damageType, isMagical)] += damageDone;
                } else
                {
                    damageTotalsByType[(damageType, isMagical)] = damageDone;
                }
            }
            outputText += "Crits: " + totalCrits + ", hits: " + totalHits + ", misses: " + totalMisses;
            outputText += ", crit fails: " + totalCritFails;
            outputText += Environment.NewLine;
            outputText += "Total damage done by type: " + Environment.NewLine;
            outputText += damageTotalsByType.Select((k, v) => $"{k}: {v}").Aggregate((x, y) => $"{x}{Environment.NewLine}{y}");
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

        private void applyPreset(int numAttacks, int hitModifier, int damageDieCount, DieType damageDie, int additionalDamage, Advantage advantage)
        {
            this.num_minions_numericUpDown.Value = numAttacks;
            this.hit_modifier1_numericUpDown.Value = hitModifier;
            this.damage_die1_count_numericUpDown.Value = damageDieCount;
            this.damage_die1_comboBox.Text = damageDie.ToString("G");
            this.additional_damage1_numericUpDown.Value = additionalDamage;
            this.advantage1_comboBox.Text = advantage.ToString("G");
        }

        private void preset_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(preset_comboBox.Text)
            {
                case "Animate Objects: 10 Tiny":
                    applyPreset(10, 8, 1, DieType.d4, 4, Advantage.None);
                    break;
                case "Animate Objects: 10 Small":
                    applyPreset(10, 6, 1, DieType.d8, 2, Advantage.None);
                    break;
                case "Animate Objects: 5 Medium":
                    applyPreset(5, 5, 2, DieType.d6, 1, Advantage.None);
                    break;
                case "Animate Objects: 2 Large":
                    applyPreset(2, 6, 2, DieType.d10, 2, Advantage.None);
                    break;
                case "Animate Objects: 1 Huge":
                    applyPreset(1, 8, 2, DieType.d12, 4, Advantage.None);
                    break;
                case "Conjure Animals: 8 wolves":
                    applyPreset(8, 4, 2, DieType.d4, 2, Advantage.Advantage /* Pack Tactics */);
                    break;
            }
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
    }
}
