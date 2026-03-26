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
            txtinput.Location = new Point(70, 124);
            txtinput.Name = "txtinput";
            txtinput.Size = new Size(512, 42);
            txtinput.TabIndex = 0;
            // 
            // txtresult
            // 
            txtresult.Location = new Point(70, 193);
            txtresult.Name = "txtresult";
            txtresult.Size = new Size(512, 42);
            txtresult.TabIndex = 1;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Font = new Font("휴먼편지체", 28.125F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 129);
            lbl.Location = new Point(41, 22);
            lbl.Name = "lbl";
            lbl.Size = new Size(596, 87);
            lbl.TabIndex = 2;
            lbl.Text = "Simpel Calculator";
            // 
            // btnce
            // 
            btnce.Location = new Point(70, 281);
            btnce.Name = "btnce";
            btnce.Size = new Size(124, 70);
            btnce.TabIndex = 3;
            btnce.Text = "CE";
            btnce.UseVisualStyleBackColor = true;
            // 
            // btndivide
            // 
            btndivide.Location = new Point(458, 281);
            btndivide.Name = "btndivide";
            btndivide.Size = new Size(124, 70);
            btndivide.TabIndex = 4;
            btndivide.Text = "÷";
            btndivide.UseVisualStyleBackColor = true;
            // 
            // btndel
            // 
            btndel.Location = new Point(328, 281);
            btndel.Name = "btndel";
            btndel.Size = new Size(124, 70);
            btndel.TabIndex = 5;
            btndel.Text = "del";
            btndel.UseVisualStyleBackColor = true;
            // 
            // btnc
            // 
            btnc.Location = new Point(200, 281);
            btnc.Name = "btnc";
            btnc.Size = new Size(124, 70);
            btnc.TabIndex = 6;
            btnc.Text = "C";
            btnc.UseVisualStyleBackColor = true;
            // 
            // btn8
            // 
            btn8.Location = new Point(200, 376);
            btn8.Name = "btn8";
            btn8.Size = new Size(124, 70);
            btn8.TabIndex = 10;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            // 
            // btn9
            // 
            btn9.Location = new Point(328, 376);
            btn9.Name = "btn9";
            btn9.Size = new Size(124, 70);
            btn9.TabIndex = 9;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            // 
            // btnx
            // 
            btnx.Location = new Point(458, 376);
            btnx.Name = "btnx";
            btnx.Size = new Size(124, 70);
            btnx.TabIndex = 8;
            btnx.Text = "x";
            btnx.UseVisualStyleBackColor = true;
            // 
            // btn7
            // 
            btn7.Location = new Point(70, 376);
            btn7.Name = "btn7";
            btn7.Size = new Size(124, 70);
            btn7.TabIndex = 7;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            // 
            // btn5
            // 
            btn5.Location = new Point(200, 475);
            btn5.Name = "btn5";
            btn5.Size = new Size(124, 70);
            btn5.TabIndex = 14;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            // 
            // btn6
            // 
            btn6.Location = new Point(328, 475);
            btn6.Name = "btn6";
            btn6.Size = new Size(124, 70);
            btn6.TabIndex = 13;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            // 
            // btnminus
            // 
            btnminus.Location = new Point(458, 475);
            btnminus.Name = "btnminus";
            btnminus.Size = new Size(124, 70);
            btnminus.TabIndex = 12;
            btnminus.Text = "-";
            btnminus.UseVisualStyleBackColor = true;
            // 
            // btn4
            // 
            btn4.Location = new Point(70, 475);
            btn4.Name = "btn4";
            btn4.Size = new Size(124, 70);
            btn4.TabIndex = 11;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            // 
            // btn2
            // 
            btn2.Location = new Point(200, 579);
            btn2.Name = "btn2";
            btn2.Size = new Size(124, 70);
            btn2.TabIndex = 18;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            // 
            // btn3
            // 
            btn3.Location = new Point(328, 579);
            btn3.Name = "btn3";
            btn3.Size = new Size(124, 70);
            btn3.TabIndex = 17;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            // 
            // btnplus
            // 
            btnplus.Location = new Point(458, 579);
            btnplus.Name = "btnplus";
            btnplus.Size = new Size(124, 70);
            btnplus.TabIndex = 16;
            btnplus.Text = "+";
            btnplus.UseVisualStyleBackColor = true;
            // 
            // btn1
            // 
            btn1.Location = new Point(70, 579);
            btn1.Name = "btn1";
            btn1.Size = new Size(124, 70);
            btn1.TabIndex = 15;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            // 
            // btn0
            // 
            btn0.Location = new Point(200, 678);
            btn0.Name = "btn0";
            btn0.Size = new Size(124, 70);
            btn0.TabIndex = 22;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            // 
            // btndot
            // 
            btndot.Location = new Point(328, 678);
            btndot.Name = "btndot";
            btndot.Size = new Size(124, 70);
            btndot.TabIndex = 21;
            btndot.Text = ".";
            btndot.UseVisualStyleBackColor = true;
            // 
            // btnresult
            // 
            btnresult.Location = new Point(458, 678);
            btnresult.Name = "btnresult";
            btnresult.Size = new Size(124, 70);
            btnresult.TabIndex = 20;
            btnresult.Text = "=";
            btnresult.UseVisualStyleBackColor = true;
            // 
            // btnplusminus
            // 
            btnplusminus.Location = new Point(70, 678);
            btnplusminus.Name = "btnplusminus";
            btnplusminus.Size = new Size(124, 70);
            btnplusminus.TabIndex = 19;
            btnplusminus.Text = "+/-";
            btnplusminus.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(15F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 800);
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
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
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
