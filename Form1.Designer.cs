namespace Adaptive_Printing {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            splitContainer1 = new SplitContainer();
            panel2 = new Panel();
            splitter2 = new Splitter();
            panel1 = new Panel();
            textBox2 = new TextBox();
            button4 = new Button();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            comboBox2 = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            splitter1 = new Splitter();
            panel4 = new Panel();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            splitter3 = new Splitter();
            textBoxOut = new TextBox();
            panel3 = new Panel();
            button3 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(4, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(splitter2);
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(splitter1);
            splitContainer1.Panel1.Controls.Add(panel4);
            splitContainer1.Panel1.Padding = new Padding(0, 4, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBox1);
            splitContainer1.Panel2.Controls.Add(splitter3);
            splitContainer1.Panel2.Controls.Add(textBoxOut);
            splitContainer1.Panel2.Controls.Add(panel3);
            splitContainer1.Panel2.Padding = new Padding(4);
            splitContainer1.Size = new Size(636, 451);
            splitContainer1.SplitterDistance = 212;
            splitContainer1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 269);
            panel2.Name = "panel2";
            panel2.Size = new Size(212, 100);
            panel2.TabIndex = 7;
            // 
            // splitter2
            // 
            splitter2.Dock = DockStyle.Top;
            splitter2.Location = new Point(0, 265);
            splitter2.Name = "splitter2";
            splitter2.Size = new Size(212, 4);
            splitter2.TabIndex = 8;
            splitter2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 108);
            panel1.Name = "panel1";
            panel1.Size = new Size(212, 157);
            panel1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(95, 126);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(113, 23);
            textBox2.TabIndex = 4;
            textBox2.Text = "360";
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.FlatAppearance.BorderColor = Color.White;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(170, 97);
            button4.Name = "button4";
            button4.Size = new Size(38, 23);
            button4.TabIndex = 3;
            button4.Text = "px";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Location = new Point(95, 66);
            textBox3.Margin = new Padding(0);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(113, 23);
            textBox3.TabIndex = 2;
            textBox3.Text = "100";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(95, 97);
            textBox1.Margin = new Padding(0);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(72, 23);
            textBox1.TabIndex = 2;
            textBox1.Text = "600";
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Начало Rect", "Середина Rect", "Конец Rect" });
            comboBox2.Location = new Point(96, 37);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(112, 23);
            comboBox2.TabIndex = 1;
            comboBox2.Text = "Начало Rect";
            comboBox2.TextChanged += comboBox1_TextChanged;
            comboBox2.KeyPress += comboBox2_KeyPress;
            // 
            // label6
            // 
            label6.Location = new Point(4, 66);
            label6.Name = "label6";
            label6.Size = new Size(86, 23);
            label6.TabIndex = 2;
            label6.Text = "Запас хода";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Location = new Point(4, 126);
            label5.Name = "label5";
            label5.Size = new Size(86, 23);
            label5.TabIndex = 2;
            label5.Text = "DPI";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(4, 97);
            label4.Name = "label4";
            label4.Size = new Size(86, 23);
            label4.TabIndex = 2;
            label4.Text = "Ширина подслоя";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Location = new Point(4, 37);
            label3.Name = "label3";
            label3.Size = new Size(86, 23);
            label3.TabIndex = 2;
            label3.Text = "Смещение Y";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(95, 8);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(112, 23);
            comboBox1.TabIndex = 0;
            comboBox1.DropDown += comboBox1_DropDown;
            comboBox1.TextChanged += comboBox1_TextChanged;
            // 
            // label1
            // 
            label1.Location = new Point(4, 8);
            label1.Name = "label1";
            label1.Size = new Size(86, 23);
            label1.TabIndex = 2;
            label1.Text = "Изображение";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Bottom;
            button1.Location = new Point(0, 410);
            button1.Name = "button1";
            button1.Size = new Size(212, 41);
            button1.TabIndex = 5;
            button1.Text = "Отрисовка";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // splitter1
            // 
            splitter1.Dock = DockStyle.Top;
            splitter1.Location = new Point(0, 104);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(212, 4);
            splitter1.TabIndex = 5;
            splitter1.TabStop = false;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(pictureBox2);
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 4);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(4);
            panel4.Size = new Size(212, 100);
            panel4.TabIndex = 10;
            panel4.SizeChanged += panel4_SizeChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Location = new Point(4, 19);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(202, 75);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(4, 4);
            label2.Name = "label2";
            label2.Size = new Size(202, 15);
            label2.TabIndex = 11;
            label2.Text = "Предпросмотр";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(412, 261);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // splitter3
            // 
            splitter3.Dock = DockStyle.Bottom;
            splitter3.Location = new Point(4, 265);
            splitter3.Name = "splitter3";
            splitter3.Size = new Size(412, 4);
            splitter3.TabIndex = 10;
            splitter3.TabStop = false;
            // 
            // textBoxOut
            // 
            textBoxOut.BorderStyle = BorderStyle.FixedSingle;
            textBoxOut.Dock = DockStyle.Bottom;
            textBoxOut.Location = new Point(4, 269);
            textBoxOut.Multiline = true;
            textBoxOut.Name = "textBoxOut";
            textBoxOut.ReadOnly = true;
            textBoxOut.Size = new Size(412, 154);
            textBoxOut.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.Controls.Add(button3);
            panel3.Controls.Add(button2);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(4, 423);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(0, 1, 0, 0);
            panel3.Size = new Size(412, 24);
            panel3.TabIndex = 8;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Right;
            button3.Location = new Point(128, 1);
            button3.Name = "button3";
            button3.Size = new Size(133, 23);
            button3.TabIndex = 7;
            button3.Text = "Копировать в буфер";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Right;
            button2.Location = new Point(261, 1);
            button2.Name = "button2";
            button2.Size = new Size(151, 23);
            button2.TabIndex = 8;
            button2.Text = "Сохранить изображение";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 459);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Padding = new Padding(4);
            Text = "Adaptive printing";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button button1;
        private PictureBox pictureBox1;
        private ComboBox comboBox1;
        private Label label1;
        private Panel panel1;
        private Button button2;
        private Panel panel2;
        private Splitter splitter2;
        private Panel panel3;
        private Button button3;
        private Splitter splitter3;
        private TextBox textBoxOut;
        private Panel panel4;
        private PictureBox pictureBox2;
        private Label label2;
        private Splitter splitter1;
        private ComboBox comboBox2;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private Button button4;
        private TextBox textBox2;
        private Label label5;
        private TextBox textBox3;
        private Label label6;
    }
}
