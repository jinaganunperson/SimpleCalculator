namespace SimpleCalculator
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
            txtinput = new TextBox();
            txtresult = new TextBox();
            lbl = new Label();
            btnce = new Button();
            btndivide = new Button();
            btndel = new Button();
            btnc = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnx = new Button();
            btn7 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btnminus = new Button();
            btn4 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btnplus = new Button();
            btn1 = new Button();
            btn0 = new Button();
            btndot = new Button();
            btnresult = new Button();
            btnplusminus = new Button();
            SuspendLayout();
            // 
            // txtinput
            // 
            txtinput.Font = new Font("맑은 고딕", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 129);
            txtinput.Location = new Point(48, 110);
            txtinput.Margin = new Padding(4, 3, 4, 3);
            txtinput.Name = "txtinput";
            txtinput.Size = new Size(596, 50);
            txtinput.TabIndex = 0;
            // 
            // txtresult
            // 
            txtresult.Font = new Font("맑은 고딕", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 129);
            txtresult.Location = new Point(48, 177);
            txtresult.Margin = new Padding(4, 3, 4, 3);
            txtresult.Name = "txtresult";
            txtresult.Size = new Size(596, 50);
            txtresult.TabIndex = 1;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Font = new Font("휴먼편지체", 28.125F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 129);
            lbl.Location = new Point(48, 20);
            lbl.Margin = new Padding(4, 0, 4, 0);
            lbl.Name = "lbl";
            lbl.Size = new Size(596, 87);
            lbl.TabIndex = 2;
            lbl.Text = "Simpel Calculator";
            // 
            // btnce
            // 
            btnce.BackColor = SystemColors.GradientActiveCaption;
            btnce.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btnce.Location = new Point(48, 250);
            btnce.Margin = new Padding(4, 3, 4, 3);
            btnce.Name = "btnce";
            btnce.Size = new Size(125, 62);
            btnce.TabIndex = 3;
            btnce.Text = "CE";
            btnce.UseVisualStyleBackColor = false;
            btnce.Click += btnce_Click;
            // 
            // btndivide
            // 
            btndivide.BackColor = SystemColors.GradientActiveCaption;
            btndivide.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btndivide.Location = new Point(532, 250);
            btndivide.Margin = new Padding(4, 3, 4, 3);
            btndivide.Name = "btndivide";
            btndivide.Size = new Size(125, 62);
            btndivide.TabIndex = 4;
            btndivide.Text = "÷";
            btndivide.UseVisualStyleBackColor = false;
            btndivide.Click += btndivide_Click;
            // 
            // btndel
            // 
            btndel.BackColor = SystemColors.GradientActiveCaption;
            btndel.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btndel.Location = new Point(368, 250);
            btndel.Margin = new Padding(4, 3, 4, 3);
            btndel.Name = "btndel";
            btndel.Size = new Size(125, 62);
            btndel.TabIndex = 5;
            btndel.Text = "del";
            btndel.UseVisualStyleBackColor = false;
            btndel.Click += btndel_Click;
            // 
            // btnc
            // 
            btnc.BackColor = SystemColors.GradientActiveCaption;
            btnc.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btnc.Location = new Point(210, 250);
            btnc.Margin = new Padding(4, 3, 4, 3);
            btnc.Name = "btnc";
            btnc.Size = new Size(125, 62);
            btnc.TabIndex = 6;
            btnc.Text = "C";
            btnc.UseVisualStyleBackColor = false;
            btnc.Click += btnc_Click_1;
            // 
            // btn8
            // 
            btn8.BackColor = SystemColors.Info;
            btn8.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btn8.Location = new Point(210, 334);
            btn8.Margin = new Padding(4, 3, 4, 3);
            btn8.Name = "btn8";
            btn8.Size = new Size(125, 62);
            btn8.TabIndex = 10;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = false;
            btn8.Click += btnNum_Click;
            // 
            // btn9
            // 
            btn9.BackColor = SystemColors.Info;
            btn9.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btn9.Location = new Point(368, 334);
            btn9.Margin = new Padding(4, 3, 4, 3);
            btn9.Name = "btn9";
            btn9.Size = new Size(125, 62);
            btn9.TabIndex = 9;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = false;
            btn9.Click += btnNum_Click;
            // 
            // btnx
            // 
            btnx.BackColor = SystemColors.GradientActiveCaption;
            btnx.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btnx.Location = new Point(532, 334);
            btnx.Margin = new Padding(4, 3, 4, 3);
            btnx.Name = "btnx";
            btnx.Size = new Size(125, 62);
            btnx.TabIndex = 8;
            btnx.Text = "x";
            btnx.UseVisualStyleBackColor = false;
            btnx.Click += btnx_Click;
            // 
            // btn7
            // 
            btn7.BackColor = SystemColors.Info;
            btn7.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btn7.Location = new Point(48, 334);
            btn7.Margin = new Padding(4, 3, 4, 3);
            btn7.Name = "btn7";
            btn7.Size = new Size(125, 62);
            btn7.TabIndex = 7;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = false;
            btn7.Click += btnNum_Click;
            // 
            // btn5
            // 
            btn5.BackColor = SystemColors.Info;
            btn5.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btn5.Location = new Point(210, 422);
            btn5.Margin = new Padding(4, 3, 4, 3);
            btn5.Name = "btn5";
            btn5.Size = new Size(125, 62);
            btn5.TabIndex = 14;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = false;
            btn5.Click += btnNum_Click;
            // 
            // btn6
            // 
            btn6.BackColor = SystemColors.Info;
            btn6.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btn6.Location = new Point(368, 422);
            btn6.Margin = new Padding(4, 3, 4, 3);
            btn6.Name = "btn6";
            btn6.Size = new Size(125, 62);
            btn6.TabIndex = 13;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = false;
            btn6.Click += btnNum_Click;
            // 
            // btnminus
            // 
            btnminus.BackColor = SystemColors.GradientActiveCaption;
            btnminus.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btnminus.Location = new Point(532, 422);
            btnminus.Margin = new Padding(4, 3, 4, 3);
            btnminus.Name = "btnminus";
            btnminus.Size = new Size(125, 62);
            btnminus.TabIndex = 12;
            btnminus.Text = "-";
            btnminus.UseVisualStyleBackColor = false;
            btnminus.Click += btnminus_Click;
            // 
            // btn4
            // 
            btn4.BackColor = SystemColors.Info;
            btn4.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btn4.Location = new Point(48, 422);
            btn4.Margin = new Padding(4, 3, 4, 3);
            btn4.Name = "btn4";
            btn4.Size = new Size(125, 62);
            btn4.TabIndex = 11;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = false;
            btn4.Click += btnNum_Click;
            // 
            // btn2
            // 
            btn2.BackColor = SystemColors.Info;
            btn2.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btn2.Location = new Point(210, 515);
            btn2.Margin = new Padding(4, 3, 4, 3);
            btn2.Name = "btn2";
            btn2.Size = new Size(125, 62);
            btn2.TabIndex = 18;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = false;
            btn2.Click += btnNum_Click;
            // 
            // btn3
            // 
            btn3.BackColor = SystemColors.Info;
            btn3.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btn3.Location = new Point(368, 515);
            btn3.Margin = new Padding(4, 3, 4, 3);
            btn3.Name = "btn3";
            btn3.Size = new Size(125, 62);
            btn3.TabIndex = 17;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = false;
            btn3.Click += btnNum_Click;
            // 
            // btnplus
            // 
            btnplus.BackColor = SystemColors.GradientActiveCaption;
            btnplus.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btnplus.Location = new Point(532, 515);
            btnplus.Margin = new Padding(4, 3, 4, 3);
            btnplus.Name = "btnplus";
            btnplus.Size = new Size(125, 62);
            btnplus.TabIndex = 16;
            btnplus.Text = "+";
            btnplus.UseVisualStyleBackColor = false;
            btnplus.Click += btnplus_Click;
            // 
            // btn1
            // 
            btn1.BackColor = SystemColors.Info;
            btn1.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btn1.Location = new Point(48, 515);
            btn1.Margin = new Padding(4, 3, 4, 3);
            btn1.Name = "btn1";
            btn1.Size = new Size(125, 62);
            btn1.TabIndex = 15;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = false;
            btn1.Click += btnNum_Click;
            // 
            // btn0
            // 
            btn0.BackColor = SystemColors.Info;
            btn0.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btn0.Location = new Point(210, 603);
            btn0.Margin = new Padding(4, 3, 4, 3);
            btn0.Name = "btn0";
            btn0.Size = new Size(125, 62);
            btn0.TabIndex = 22;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = false;
            btn0.Click += btnNum_Click;
            // 
            // btndot
            // 
            btndot.BackColor = SystemColors.GradientActiveCaption;
            btndot.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btndot.Location = new Point(368, 603);
            btndot.Margin = new Padding(4, 3, 4, 3);
            btndot.Name = "btndot";
            btndot.Size = new Size(125, 62);
            btndot.TabIndex = 21;
            btndot.Text = ".";
            btndot.UseVisualStyleBackColor = false;
            // 
            // btnresult
            // 
            btnresult.BackColor = SystemColors.GradientActiveCaption;
            btnresult.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btnresult.Location = new Point(532, 603);
            btnresult.Margin = new Padding(4, 3, 4, 3);
            btnresult.Name = "btnresult";
            btnresult.Size = new Size(125, 62);
            btnresult.TabIndex = 20;
            btnresult.Text = "=";
            btnresult.UseVisualStyleBackColor = false;
            btnresult.Click += btnresult_Click;
            // 
            // btnplusminus
            // 
            btnplusminus.BackColor = SystemColors.GradientActiveCaption;
            btnplusminus.Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            btnplusminus.Location = new Point(48, 603);
            btnplusminus.Margin = new Padding(4, 3, 4, 3);
            btnplusminus.Name = "btnplusminus";
            btnplusminus.Size = new Size(125, 62);
            btnplusminus.TabIndex = 19;
            btnplusminus.Text = "+/-";
            btnplusminus.UseVisualStyleBackColor = false;
            btnplusminus.Click += btnplusminus_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(20F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            ClientSize = new Size(707, 711);
            Controls.Add(btn0);
            Controls.Add(btndot);
            Controls.Add(btnresult);
            Controls.Add(btnplusminus);
            Controls.Add(btn2);
            Controls.Add(btn3);
            Controls.Add(btnplus);
            Controls.Add(btn1);
            Controls.Add(btn5);
            Controls.Add(btn6);
            Controls.Add(btnminus);
            Controls.Add(btn4);
            Controls.Add(btn8);
            Controls.Add(btn9);
            Controls.Add(btnx);
            Controls.Add(btn7);
            Controls.Add(btnc);
            Controls.Add(btndel);
            Controls.Add(btndivide);
            Controls.Add(btnce);
            Controls.Add(lbl);
            Controls.Add(txtresult);
            Controls.Add(txtinput);
            Font = new Font("굴림", 12F, FontStyle.Bold | FontStyle.Italic);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtinput;
        private TextBox txtresult;
        private Label lbl;
        private Button btnce;
        private Button btndivide;
        private Button btndel;
        private Button btnc;
        private Button btn8;
        private Button btn9;
        private Button btnx;
        private Button btn7;
        private Button btn5;
        private Button btn6;
        private Button btnminus;
        private Button btn4;
        private Button btn2;
        private Button btn3;
        private Button btnplus;
        private Button btn1;
        private Button btn0;
        private Button btndot;
        private Button btnresult;
        private Button btnplusminus;
    }
}
