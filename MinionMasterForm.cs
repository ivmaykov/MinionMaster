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

        public MinionMasterForm()
        {
            InitializeComponent();
            this.advantage_comboBox.DataSource = Enum.GetValues(typeof(Advantage));
            this.target_resistance_comboBox.DataSource = Enum.GetValues(typeof(Resistance));
            this.damage_die_comboBox.DataSource = Enum.GetValues(typeof(DieType));
            this.damage_die_comboBox.Text = DieType.d4.ToString("G");
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

        private void rollTheDice()
        {
            rolls.Clear();
            int numAttackRolls = (int)this.num_minions_numericUpDown.Value;
            int numDamageDice = (int)this.damage_die_count_numericUpDown.Value;
            DieType damageDieType = (DieType) Enum.Parse(typeof(DieType), this.damage_die_comboBox.Text);
            if (!Enum.IsDefined(typeof(DieType), damageDieType))
            {
                throw new Exception("Invalid DieType enum: " + this.damage_die_comboBox.Text);
            }
            for (int i = 0; i < numAttackRolls; i++)
            {
                rolls.Add(new AttackAndDamageRoll(
                    new AttackRoll(DieType.d20.roll(), DieType.d20.roll()),
                    new DamageRoll(
                        multiRollDamageDice(numDamageDice, damageDieType),
                        multiRollDamageDice(numDamageDice, damageDieType))));
            }
        }

        Advantage stringToAdvantage(string advantageString)
        {
            Advantage advantage = (Advantage) Enum.Parse(typeof(Advantage), advantageString);
            if (!Enum.IsDefined(typeof(Advantage), advantage))
            {
                throw new Exception("Invalid Advantage enum: " + advantageString);
            }
            return advantage;
        }

        Resistance stringToResistance(string resistanceString)
        {
            Resistance resistance = (Resistance)Enum.Parse(typeof(Resistance), resistanceString);
            if (!Enum.IsDefined(typeof(Resistance), resistance))
            {
                throw new Exception("Invalid Resistance enum: " + resistanceString);
            }
            return resistance;
        }

        private void renderRollResults()
        {
            if (rolls.Count == 0)
            {
                this.output_textBox.Text = "Press the ROLL button!";
                return;
            }
            int numAttackRolls = (int)this.num_minions_numericUpDown.Value;
            int numDamageDice = (int)this.damage_die_count_numericUpDown.Value;
            String damageDieType = this.damage_die_comboBox.Text;
            int hitModifier = (int)this.hit_modifier_numericUpDown.Value;
            int targetAC = (int)this.target_ac_numericUpDown.Value;
            int additionalDamage = (int)this.additional_damage_numericUpDown.Value;
            Advantage advantage = stringToAdvantage(this.advantage_comboBox.Text);
            Resistance resistance = stringToResistance(this.target_resistance_comboBox.Text);
            String outputText = "Rollling " + numAttackRolls + " attacks at +" + hitModifier +
                " to hit vs AC " + targetAC;
            if (Advantage.None != advantage)
            {
                outputText += " with ";
                if (Advantage.Advantage == advantage)
                {
                    outputText += "advantage";
                } else
                {
                    outputText += "disadvantage";
                }
            }
            outputText += ", using " + numDamageDice + damageDieType;
            if (additionalDamage > 0)
            {
                outputText += "+" + additionalDamage;
            } else if (additionalDamage < 0)
            {
                outputText += additionalDamage;
            }
            outputText += " damage per attack";
            if (Resistance.None != resistance)
            {
                if (Resistance.Resistant == resistance)
                {
                    outputText += " vs a resistant target";
                }
                else
                {
                    outputText += " vs a vulnerable target";
                }
            }
            outputText += Environment.NewLine;
            int i = 1;
            int totalDamage = 0;
            int totalHits = 0;
            int totalCrits = 0;
            int totalMisses = 0;
            int totalCritFails = 0;
            foreach (AttackAndDamageRoll r in rolls)
            {
                outputText += "Attack " + i + "/" + numAttackRolls + ": ";
                outputText += r.AttackRoll.describe(advantage, hitModifier, targetAC);
                AttackResult attackResult = r.AttackRoll.getAttackResult(advantage, hitModifier, targetAC);
                if (AttackResult.Miss == attackResult)
                {
                    totalMisses++;
                    outputText += Environment.NewLine;
                    i++;
                    continue;
                }
                else if (AttackResult.CritFail == attackResult)
                {
                    totalCritFails++;
                    outputText += Environment.NewLine;
                    i++;
                    continue;

                }
                else if (AttackResult.Hit == attackResult)
                {
                    totalHits++;
                }
                else {
                    totalCrits++;
                }
                int damageDone = r.DamageRoll.getDamageResult(attackResult, resistance, additionalDamage);
                outputText += ", doing " + r.DamageRoll.describe(attackResult, resistance, additionalDamage) + " damage!";
                outputText += Environment.NewLine;
                totalDamage += damageDone;
                i++;
            }
            outputText += "Crits: " + totalCrits + ", hits: " + totalHits + ", misses: " + totalMisses;
            outputText += ", crit fails: " + totalCritFails;
            outputText += Environment.NewLine;
            outputText += "Total damage done: " + totalDamage + Environment.NewLine;
            this.output_textBox.Text = outputText;
        }

        private void advantage_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void damage_die_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rolls.Clear();
            renderRollResults();
        }

        private void target_resistance_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void hit_modifier_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void damage_die_count_numericUpDown_ValueChanged(object sender, EventArgs e)
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

        private void additional_damage_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            renderRollResults();
        }

        private void applyPreset(int numAttacks, int hitModifier, int damageDieCount, DieType damageDie, int additionalDamage, Advantage advantage)
        {
            this.num_minions_numericUpDown.Value = numAttacks;
            this.hit_modifier_numericUpDown.Value = hitModifier;
            this.damage_die_count_numericUpDown.Value = damageDieCount;
            this.damage_die_comboBox.Text = damageDie.ToString("G");
            this.additional_damage_numericUpDown.Value = additionalDamage;
            this.advantage_comboBox.Text = advantage.ToString("G");
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

        private void preset_label_Click(object sender, EventArgs e)
        {

        }
    }
}
