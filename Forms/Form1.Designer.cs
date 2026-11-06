namespace ChainConnectedOscillators
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            pictureBox_system = new PictureBox();
            groupBox2 = new GroupBox();
            formsPlot1_x_i = new ScottPlot.WinForms.FormsPlot();
            groupBox3 = new GroupBox();
            groupBox5 = new GroupBox();
            groupBox7 = new GroupBox();
            label8 = new Label();
            numericUpDown_n_i_for_graphic = new NumericUpDown();
            groupBox6 = new GroupBox();
            button_reset = new Button();
            button_stop = new Button();
            button_start = new Button();
            groupBox4 = new GroupBox();
            groupBox8 = new GroupBox();
            label12 = new Label();
            numericUpDown_startPosition_n_i = new NumericUpDown();
            label11 = new Label();
            numericUpDown_n_i_forStart = new NumericUpDown();
            label2 = new Label();
            textBox_m = new TextBox();
            label10 = new Label();
            label_scale = new Label();
            textBox_gamma = new TextBox();
            label7 = new Label();
            textBox_mu = new TextBox();
            label6 = new Label();
            textBox_alpha = new TextBox();
            textBox_k0 = new TextBox();
            comboBox_k = new ComboBox();
            numericUpDown_N = new NumericUpDown();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_system).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_n_i_for_graphic).BeginInit();
            groupBox6.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_startPosition_n_i).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_n_i_forStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_N).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox_system);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1878, 450);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Моделирование физической системы";
            // 
            // pictureBox_system
            // 
            pictureBox_system.Location = new Point(6, 26);
            pictureBox_system.Name = "pictureBox_system";
            pictureBox_system.Size = new Size(1866, 418);
            pictureBox_system.TabIndex = 0;
            pictureBox_system.TabStop = false;
            pictureBox_system.Paint += pictureBox_system_Paint;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(formsPlot1_x_i);
            groupBox2.Location = new Point(892, 468);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(998, 498);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "График координаты i-шарика";
            // 
            // formsPlot1_x_i
            // 
            formsPlot1_x_i.Location = new Point(6, 26);
            formsPlot1_x_i.Name = "formsPlot1_x_i";
            formsPlot1_x_i.Size = new Size(986, 466);
            formsPlot1_x_i.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(groupBox5);
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Location = new Point(12, 468);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(874, 498);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(groupBox7);
            groupBox5.Controls.Add(groupBox6);
            groupBox5.Location = new Point(466, 26);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(402, 466);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "Элементы управления";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(label8);
            groupBox7.Controls.Add(numericUpDown_n_i_for_graphic);
            groupBox7.Location = new Point(6, 26);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(390, 87);
            groupBox7.TabIndex = 2;
            groupBox7.TabStop = false;
            groupBox7.Text = "Управление графиком";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label8.Location = new Point(6, 38);
            label8.Name = "label8";
            label8.Size = new Size(167, 26);
            label8.TabIndex = 8;
            label8.Text = "Номер шарика: ";
            // 
            // numericUpDown_n_i_for_graphic
            // 
            numericUpDown_n_i_for_graphic.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            numericUpDown_n_i_for_graphic.Location = new Point(179, 36);
            numericUpDown_n_i_for_graphic.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_n_i_for_graphic.Name = "numericUpDown_n_i_for_graphic";
            numericUpDown_n_i_for_graphic.Size = new Size(205, 34);
            numericUpDown_n_i_for_graphic.TabIndex = 7;
            numericUpDown_n_i_for_graphic.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_n_i_for_graphic.ValueChanged += numericUpDown_n_i_for_graphic_ValueChanged;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(button_reset);
            groupBox6.Controls.Add(button_stop);
            groupBox6.Controls.Add(button_start);
            groupBox6.Location = new Point(6, 119);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(390, 341);
            groupBox6.TabIndex = 0;
            groupBox6.TabStop = false;
            groupBox6.Text = "Управление системой";
            // 
            // button_reset
            // 
            button_reset.Font = new Font("Times New Roman", 13.8F);
            button_reset.Location = new Point(6, 245);
            button_reset.Name = "button_reset";
            button_reset.Size = new Size(378, 90);
            button_reset.TabIndex = 2;
            button_reset.Text = "Сброс";
            button_reset.UseVisualStyleBackColor = true;
            button_reset.Click += button_reset_Click;
            // 
            // button_stop
            // 
            button_stop.Font = new Font("Times New Roman", 13.8F);
            button_stop.Location = new Point(6, 136);
            button_stop.Name = "button_stop";
            button_stop.Size = new Size(378, 90);
            button_stop.TabIndex = 1;
            button_stop.Text = "Пауза";
            button_stop.UseVisualStyleBackColor = true;
            button_stop.Click += button_stop_Click;
            // 
            // button_start
            // 
            button_start.Font = new Font("Times New Roman", 13.8F);
            button_start.Location = new Point(6, 26);
            button_start.Name = "button_start";
            button_start.Size = new Size(378, 90);
            button_start.TabIndex = 0;
            button_start.Text = "Пуск";
            button_start.UseVisualStyleBackColor = true;
            button_start.Click += button_start_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(groupBox8);
            groupBox4.Controls.Add(textBox_m);
            groupBox4.Controls.Add(label10);
            groupBox4.Controls.Add(label_scale);
            groupBox4.Controls.Add(textBox_gamma);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(textBox_mu);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(textBox_alpha);
            groupBox4.Controls.Add(textBox_k0);
            groupBox4.Controls.Add(comboBox_k);
            groupBox4.Controls.Add(numericUpDown_N);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(label1);
            groupBox4.Location = new Point(6, 26);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(454, 466);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "Параметры системы";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(label12);
            groupBox8.Controls.Add(numericUpDown_startPosition_n_i);
            groupBox8.Controls.Add(label11);
            groupBox8.Controls.Add(numericUpDown_n_i_forStart);
            groupBox8.Controls.Add(label2);
            groupBox8.Location = new Point(0, 313);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(448, 147);
            groupBox8.TabIndex = 18;
            groupBox8.TabStop = false;
            groupBox8.Text = "Начальные условия";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label12.Location = new Point(338, 96);
            label12.Name = "label12";
            label12.Size = new Size(33, 26);
            label12.TabIndex = 4;
            label12.Text = "м.";
            // 
            // numericUpDown_startPosition_n_i
            // 
            numericUpDown_startPosition_n_i.Font = new Font("Times New Roman", 13.8F);
            numericUpDown_startPosition_n_i.Location = new Point(186, 94);
            numericUpDown_startPosition_n_i.Name = "numericUpDown_startPosition_n_i";
            numericUpDown_startPosition_n_i.Size = new Size(146, 34);
            numericUpDown_startPosition_n_i.TabIndex = 3;
            numericUpDown_startPosition_n_i.ValueChanged += numericUpDown_startPosition_n_i_ValueChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Times New Roman", 13.8F);
            label11.Location = new Point(34, 96);
            label11.Name = "label11";
            label11.Size = new Size(141, 26);
            label11.TabIndex = 2;
            label11.Text = "Отклонение: ";
            // 
            // numericUpDown_n_i_forStart
            // 
            numericUpDown_n_i_forStart.Font = new Font("Times New Roman", 13.8F);
            numericUpDown_n_i_forStart.Location = new Point(186, 37);
            numericUpDown_n_i_forStart.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_n_i_forStart.Name = "numericUpDown_n_i_forStart";
            numericUpDown_n_i_forStart.Size = new Size(146, 34);
            numericUpDown_n_i_forStart.TabIndex = 1;
            numericUpDown_n_i_forStart.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_n_i_forStart.ValueChanged += numericUpDown_n_i_forStart_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F);
            label2.Location = new Point(13, 39);
            label2.Name = "label2";
            label2.Size = new Size(167, 26);
            label2.TabIndex = 0;
            label2.Text = "Номер шарика: ";
            // 
            // textBox_m
            // 
            textBox_m.Font = new Font("Times New Roman", 13.8F);
            textBox_m.Location = new Point(90, 73);
            textBox_m.Name = "textBox_m";
            textBox_m.Size = new Size(127, 34);
            textBox_m.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 13.8F);
            label10.Location = new Point(29, 76);
            label10.Name = "label10";
            label10.Size = new Size(55, 26);
            label10.TabIndex = 16;
            label10.Text = "m = ";
            // 
            // label_scale
            // 
            label_scale.AutoSize = true;
            label_scale.Location = new Point(353, 148);
            label_scale.Name = "label_scale";
            label_scale.Size = new Size(0, 20);
            label_scale.TabIndex = 15;
            // 
            // textBox_gamma
            // 
            textBox_gamma.Font = new Font("Times New Roman", 13.8F);
            textBox_gamma.Location = new Point(90, 273);
            textBox_gamma.Name = "textBox_gamma";
            textBox_gamma.Size = new Size(128, 34);
            textBox_gamma.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 13.8F);
            label7.Location = new Point(36, 280);
            label7.Name = "label7";
            label7.Size = new Size(49, 26);
            label7.TabIndex = 12;
            label7.Text = "ɣ = ";
            // 
            // textBox_mu
            // 
            textBox_mu.Font = new Font("Times New Roman", 13.8F);
            textBox_mu.Location = new Point(89, 233);
            textBox_mu.Name = "textBox_mu";
            textBox_mu.Size = new Size(128, 34);
            textBox_mu.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 13.8F);
            label6.Location = new Point(37, 236);
            label6.Name = "label6";
            label6.Size = new Size(49, 26);
            label6.TabIndex = 10;
            label6.Text = "μ = ";
            // 
            // textBox_alpha
            // 
            textBox_alpha.Font = new Font("Times New Roman", 13.8F);
            textBox_alpha.Location = new Point(90, 193);
            textBox_alpha.Name = "textBox_alpha";
            textBox_alpha.Size = new Size(128, 34);
            textBox_alpha.TabIndex = 9;
            // 
            // textBox_k0
            // 
            textBox_k0.Font = new Font("Times New Roman", 13.8F);
            textBox_k0.Location = new Point(90, 153);
            textBox_k0.Name = "textBox_k0";
            textBox_k0.Size = new Size(128, 34);
            textBox_k0.TabIndex = 8;
            // 
            // comboBox_k
            // 
            comboBox_k.Font = new Font("Times New Roman", 13.8F);
            comboBox_k.FormattingEnabled = true;
            comboBox_k.Items.AddRange(new object[] { "k₀ + α|x|", "k₀ + α(x*x)" });
            comboBox_k.Location = new Point(90, 113);
            comboBox_k.Name = "comboBox_k";
            comboBox_k.Size = new Size(128, 34);
            comboBox_k.TabIndex = 7;
            // 
            // numericUpDown_N
            // 
            numericUpDown_N.Font = new Font("Times New Roman", 13.8F);
            numericUpDown_N.Location = new Point(90, 33);
            numericUpDown_N.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_N.Name = "numericUpDown_N";
            numericUpDown_N.Size = new Size(127, 34);
            numericUpDown_N.TabIndex = 5;
            numericUpDown_N.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_N.ValueChanged += numericUpDown_N_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 13.8F);
            label5.Location = new Point(36, 196);
            label5.Name = "label5";
            label5.Size = new Size(49, 26);
            label5.TabIndex = 4;
            label5.Text = "α = ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 13.8F);
            label4.Location = new Point(29, 156);
            label4.Name = "label4";
            label4.Size = new Size(56, 26);
            label4.TabIndex = 3;
            label4.Text = "k₀ = ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F);
            label3.Location = new Point(11, 116);
            label3.Name = "label3";
            label3.Size = new Size(76, 26);
            label3.TabIndex = 2;
            label3.Text = "k(x) = ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.8F);
            label1.Location = new Point(31, 35);
            label1.Name = "label1";
            label1.Size = new Size(53, 26);
            label1.TabIndex = 0;
            label1.Text = "N = ";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 978);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Нелинейная диссипативная система связанных осцилляторов ";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_system).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_n_i_for_graphic).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_startPosition_n_i).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_n_i_forStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_N).EndInit();
            ResumeLayout(false);
        }





        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
        private PictureBox pictureBox_system;
        private GroupBox groupBox6;
        private Button button_reset;
        private Button button_stop;
        private Button button_start;
        private Label label3;
        private Label label1;
        private Label label5;
        private Label label4;
        private NumericUpDown numericUpDown_N;
        private ComboBox comboBox_k;
        private TextBox textBox_gamma;
        private Label label7;
        private TextBox textBox_mu;
        private Label label6;
        private TextBox textBox_alpha;
        private TextBox textBox_k0;
        private GroupBox groupBox7;
        private Label label8;
        private NumericUpDown numericUpDown_n_i_for_graphic;
        private Label label_scale;
        private TextBox textBox_m;
        private Label label10;
        private System.Windows.Forms.Timer timer1;
        private GroupBox groupBox8;
        private Label label11;
        private NumericUpDown numericUpDown_n_i_forStart;
        private Label label2;
        private NumericUpDown numericUpDown_startPosition_n_i;
        private Label label12;
        private ScottPlot.WinForms.FormsPlot formsPlot1_x_i;
    }
}
