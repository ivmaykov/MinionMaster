namespace MinionMaster
{
    partial class MinionMasterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.hit_modifier_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.advantage_comboBox = new System.Windows.Forms.ComboBox();
            this.advantage_label = new System.Windows.Forms.Label();
            this.hit_modifier_label = new System.Windows.Forms.Label();
            this.damage_dice_label = new System.Windows.Forms.Label();
            this.damage_die_comboBox = new System.Windows.Forms.ComboBox();
            this.damage_die_count_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.additional_damage_label = new System.Windows.Forms.Label();
            this.additional_damage_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.target_ac_label = new System.Windows.Forms.Label();
            this.target_ac_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.target_resistance_label = new System.Windows.Forms.Label();
            this.target_resistance_comboBox = new System.Windows.Forms.ComboBox();
            this.roll_button = new System.Windows.Forms.Button();
            this.output_textBox = new System.Windows.Forms.TextBox();
            this.numer_of_minions_label = new System.Windows.Forms.Label();
            this.num_minions_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.preset_label = new System.Windows.Forms.Label();
            this.preset_comboBox = new System.Windows.Forms.ComboBox();
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.hit_modifier_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damage_die_count_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.additional_damage_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.target_ac_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_minions_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // hit_modifier_numericUpDown
            // 
            this.hit_modifier_numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hit_modifier_numericUpDown.Location = new System.Drawing.Point(243, 150);
            this.hit_modifier_numericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.hit_modifier_numericUpDown.Name = "hit_modifier_numericUpDown";
            this.hit_modifier_numericUpDown.Size = new System.Drawing.Size(162, 30);
            this.hit_modifier_numericUpDown.TabIndex = 1;
            this.hit_modifier_numericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.hit_modifier_numericUpDown.ValueChanged += new System.EventHandler(this.hit_modifier_numericUpDown_ValueChanged);
            // 
            // advantage_comboBox
            // 
            this.advantage_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advantage_comboBox.FormattingEnabled = true;
            this.advantage_comboBox.Location = new System.Drawing.Point(243, 111);
            this.advantage_comboBox.Name = "advantage_comboBox";
            this.advantage_comboBox.Size = new System.Drawing.Size(162, 33);
            this.advantage_comboBox.TabIndex = 7;
            this.advantage_comboBox.SelectedIndexChanged += new System.EventHandler(this.advantage_comboBox_SelectedIndexChanged);
            // 
            // advantage_label
            // 
            this.advantage_label.AutoSize = true;
            this.advantage_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advantage_label.Location = new System.Drawing.Point(48, 114);
            this.advantage_label.Name = "advantage_label";
            this.advantage_label.Size = new System.Drawing.Size(107, 25);
            this.advantage_label.TabIndex = 8;
            this.advantage_label.Text = "Advantage";
            // 
            // hit_modifier_label
            // 
            this.hit_modifier_label.AutoSize = true;
            this.hit_modifier_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hit_modifier_label.Location = new System.Drawing.Point(48, 152);
            this.hit_modifier_label.Name = "hit_modifier_label";
            this.hit_modifier_label.Size = new System.Drawing.Size(108, 25);
            this.hit_modifier_label.TabIndex = 9;
            this.hit_modifier_label.Text = "Hit modifier";
            // 
            // damage_dice_label
            // 
            this.damage_dice_label.AutoSize = true;
            this.damage_dice_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.damage_dice_label.Location = new System.Drawing.Point(48, 189);
            this.damage_dice_label.Name = "damage_dice_label";
            this.damage_dice_label.Size = new System.Drawing.Size(127, 25);
            this.damage_dice_label.TabIndex = 10;
            this.damage_dice_label.Text = "Damage dice";
            // 
            // damage_die_comboBox
            // 
            this.damage_die_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.damage_die_comboBox.FormattingEnabled = true;
            this.damage_die_comboBox.Location = new System.Drawing.Point(243, 186);
            this.damage_die_comboBox.Name = "damage_die_comboBox";
            this.damage_die_comboBox.Size = new System.Drawing.Size(161, 33);
            this.damage_die_comboBox.TabIndex = 11;
            this.damage_die_comboBox.SelectedIndexChanged += new System.EventHandler(this.damage_die_comboBox_SelectedIndexChanged);
            // 
            // damage_die_count_numericUpDown
            // 
            this.damage_die_count_numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.damage_die_count_numericUpDown.Location = new System.Drawing.Point(190, 186);
            this.damage_die_count_numericUpDown.Name = "damage_die_count_numericUpDown";
            this.damage_die_count_numericUpDown.Size = new System.Drawing.Size(47, 30);
            this.damage_die_count_numericUpDown.TabIndex = 13;
            this.damage_die_count_numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.damage_die_count_numericUpDown.ValueChanged += new System.EventHandler(this.damage_die_count_numericUpDown_ValueChanged);
            // 
            // additional_damage_label
            // 
            this.additional_damage_label.AutoSize = true;
            this.additional_damage_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.additional_damage_label.Location = new System.Drawing.Point(48, 227);
            this.additional_damage_label.Name = "additional_damage_label";
            this.additional_damage_label.Size = new System.Drawing.Size(174, 25);
            this.additional_damage_label.TabIndex = 15;
            this.additional_damage_label.Text = "Additional damage";
            // 
            // additional_damage_numericUpDown
            // 
            this.additional_damage_numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.additional_damage_numericUpDown.Location = new System.Drawing.Point(243, 225);
            this.additional_damage_numericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.additional_damage_numericUpDown.Name = "additional_damage_numericUpDown";
            this.additional_damage_numericUpDown.Size = new System.Drawing.Size(162, 30);
            this.additional_damage_numericUpDown.TabIndex = 16;
            this.additional_damage_numericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.additional_damage_numericUpDown.ValueChanged += new System.EventHandler(this.additional_damage_numericUpDown_ValueChanged);
            // 
            // target_ac_label
            // 
            this.target_ac_label.AutoSize = true;
            this.target_ac_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.target_ac_label.Location = new System.Drawing.Point(12, 15);
            this.target_ac_label.Name = "target_ac_label";
            this.target_ac_label.Size = new System.Drawing.Size(103, 25);
            this.target_ac_label.TabIndex = 17;
            this.target_ac_label.Text = "Target AC";
            // 
            // target_ac_numericUpDown
            // 
            this.target_ac_numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.target_ac_numericUpDown.Location = new System.Drawing.Point(206, 13);
            this.target_ac_numericUpDown.Name = "target_ac_numericUpDown";
            this.target_ac_numericUpDown.Size = new System.Drawing.Size(162, 30);
            this.target_ac_numericUpDown.TabIndex = 18;
            this.target_ac_numericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.target_ac_numericUpDown.ValueChanged += new System.EventHandler(this.target_ac_numericUpDown_ValueChanged);
            // 
            // target_resistance_label
            // 
            this.target_resistance_label.AutoSize = true;
            this.target_resistance_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.target_resistance_label.Location = new System.Drawing.Point(12, 52);
            this.target_resistance_label.Name = "target_resistance_label";
            this.target_resistance_label.Size = new System.Drawing.Size(163, 25);
            this.target_resistance_label.TabIndex = 19;
            this.target_resistance_label.Text = "Target resistance";
            // 
            // target_resistance_comboBox
            // 
            this.target_resistance_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.target_resistance_comboBox.FormattingEnabled = true;
            this.target_resistance_comboBox.Location = new System.Drawing.Point(206, 49);
            this.target_resistance_comboBox.Name = "target_resistance_comboBox";
            this.target_resistance_comboBox.Size = new System.Drawing.Size(162, 33);
            this.target_resistance_comboBox.TabIndex = 20;
            this.target_resistance_comboBox.SelectedIndexChanged += new System.EventHandler(this.target_resistance_comboBox_SelectedIndexChanged);
            // 
            // roll_button
            // 
            this.roll_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roll_button.Location = new System.Drawing.Point(78, 834);
            this.roll_button.Name = "roll_button";
            this.roll_button.Size = new System.Drawing.Size(220, 56);
            this.roll_button.TabIndex = 21;
            this.roll_button.Text = "ROLL";
            this.roll_button.UseVisualStyleBackColor = true;
            this.roll_button.Click += new System.EventHandler(this.roll_button_Click);
            // 
            // output_textBox
            // 
            this.output_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output_textBox.Location = new System.Drawing.Point(469, 5);
            this.output_textBox.Multiline = true;
            this.output_textBox.Name = "output_textBox";
            this.output_textBox.ReadOnly = true;
            this.output_textBox.Size = new System.Drawing.Size(951, 921);
            this.output_textBox.TabIndex = 22;
            this.output_textBox.TextChanged += new System.EventHandler(this.output_textBox_TextChanged);
            // 
            // numer_of_minions_label
            // 
            this.numer_of_minions_label.AutoSize = true;
            this.numer_of_minions_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numer_of_minions_label.Location = new System.Drawing.Point(12, 702);
            this.numer_of_minions_label.Name = "numer_of_minions_label";
            this.numer_of_minions_label.Size = new System.Drawing.Size(174, 25);
            this.numer_of_minions_label.TabIndex = 23;
            this.numer_of_minions_label.Text = "Number of minions";
            // 
            // num_minions_numericUpDown
            // 
            this.num_minions_numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_minions_numericUpDown.Location = new System.Drawing.Point(207, 700);
            this.num_minions_numericUpDown.Name = "num_minions_numericUpDown";
            this.num_minions_numericUpDown.Size = new System.Drawing.Size(162, 30);
            this.num_minions_numericUpDown.TabIndex = 24;
            this.num_minions_numericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_minions_numericUpDown.ValueChanged += new System.EventHandler(this.num_minions_numericUpDown_ValueChanged);
            // 
            // preset_label
            // 
            this.preset_label.AutoSize = true;
            this.preset_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preset_label.Location = new System.Drawing.Point(12, 739);
            this.preset_label.Name = "preset_label";
            this.preset_label.Size = new System.Drawing.Size(68, 25);
            this.preset_label.TabIndex = 25;
            this.preset_label.Text = "Preset";
            this.preset_label.Click += new System.EventHandler(this.preset_label_Click);
            // 
            // preset_comboBox
            // 
            this.preset_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preset_comboBox.FormattingEnabled = true;
            this.preset_comboBox.Items.AddRange(new object[] {
            "Animate Objects: 1 Huge",
            "Animate Objects: 2 Large",
            "Animate Objects: 5 Medium",
            "Animate Objects: 10 Small",
            "Animate Objects: 10 Tiny",
            "Conjure Animals: 8 wolves",
            "Conjure Animals: 8 panthers"});
            this.preset_comboBox.Location = new System.Drawing.Point(91, 736);
            this.preset_comboBox.Name = "preset_comboBox";
            this.preset_comboBox.Size = new System.Drawing.Size(277, 33);
            this.preset_comboBox.TabIndex = 26;
            this.preset_comboBox.Text = "Animate Objects: Tiny";
            this.preset_comboBox.SelectedIndexChanged += new System.EventHandler(this.preset_comboBox_SelectedIndexChanged);
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataSource = typeof(MinionMaster.Program);
            // 
            // MinionMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 938);
            this.Controls.Add(this.preset_comboBox);
            this.Controls.Add(this.preset_label);
            this.Controls.Add(this.num_minions_numericUpDown);
            this.Controls.Add(this.numer_of_minions_label);
            this.Controls.Add(this.output_textBox);
            this.Controls.Add(this.roll_button);
            this.Controls.Add(this.target_resistance_comboBox);
            this.Controls.Add(this.target_resistance_label);
            this.Controls.Add(this.target_ac_numericUpDown);
            this.Controls.Add(this.target_ac_label);
            this.Controls.Add(this.additional_damage_numericUpDown);
            this.Controls.Add(this.additional_damage_label);
            this.Controls.Add(this.damage_die_count_numericUpDown);
            this.Controls.Add(this.damage_die_comboBox);
            this.Controls.Add(this.damage_dice_label);
            this.Controls.Add(this.hit_modifier_label);
            this.Controls.Add(this.advantage_label);
            this.Controls.Add(this.advantage_comboBox);
            this.Controls.Add(this.hit_modifier_numericUpDown);
            this.Name = "MinionMasterForm";
            this.Text = "Minion Master";
            ((System.ComponentModel.ISupportInitialize)(this.hit_modifier_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damage_die_count_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.additional_damage_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.target_ac_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_minions_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown hit_modifier_numericUpDown;
        private System.Windows.Forms.ComboBox advantage_comboBox;
        private System.Windows.Forms.Label advantage_label;
        private System.Windows.Forms.Label hit_modifier_label;
        private System.Windows.Forms.Label damage_dice_label;
        private System.Windows.Forms.ComboBox damage_die_comboBox;
        private System.Windows.Forms.NumericUpDown damage_die_count_numericUpDown;
        private System.Windows.Forms.Label additional_damage_label;
        private System.Windows.Forms.NumericUpDown additional_damage_numericUpDown;
        private System.Windows.Forms.Label target_ac_label;
        private System.Windows.Forms.NumericUpDown target_ac_numericUpDown;
        private System.Windows.Forms.Label target_resistance_label;
        private System.Windows.Forms.ComboBox target_resistance_comboBox;
        private System.Windows.Forms.Button roll_button;
        private System.Windows.Forms.TextBox output_textBox;
        private System.Windows.Forms.Label numer_of_minions_label;
        private System.Windows.Forms.NumericUpDown num_minions_numericUpDown;
        private System.Windows.Forms.Label preset_label;
        private System.Windows.Forms.ComboBox preset_comboBox;
        private System.Windows.Forms.BindingSource programBindingSource;
    }
}

