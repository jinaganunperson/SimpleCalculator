using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        double firstNum = 0;
        double secondNum = 0;
        double result = 0;
        bool isOpClicked = false;
        string currentOp = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (txtinput.Text == "0") txtinput.Text = btn.Text;
            else txtinput.Text += btn.Text;

            if (isOpClicked)
            {
                txtresult.Text = btn.Text;
                isOpClicked = false;
            }
            else
            {
                if (txtresult.Text == "0" || txtresult.Text == "") txtresult.Text = btn.Text;
                else txtresult.Text += btn.Text;
            }
        }

        private void btnplus_Click(object sender, EventArgs e) { HandleOperator("+", "+"); }
        private void btnminus_Click(object sender, EventArgs e) { HandleOperator("-", "-"); }
        private void btnx_Click(object sender, EventArgs e) { HandleOperator("x", "x"); }
        private void btndivide_Click(object sender, EventArgs e) { HandleOperator("÷", "÷"); }

        private void HandleOperator(string opSymbol, string opName)
        {
            if (txtinput.Text == "0") return;
            if (txtinput.Text.EndsWith(" ")) return;

            firstNum = double.Parse(txtresult.Text);
            txtresult.Text = firstNum.ToString();
            txtinput.Text += " " + opSymbol + " ";

            isOpClicked = true;
            currentOp = opName;
        }

        // ⭐ [3] 결과 버튼 (연속 계산 로직으로 업그레이드)
        private void btnresult_Click(object sender, EventArgs e)
        {
            // 1. 공백을 기준으로 수식 전체를 분리 (예: "4", "x", "2", "÷", "2")
            string[] parts = txtinput.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // 2. 최소 '숫자-연산자-숫자' (3개) 이상이어야 계산 가능
            if (parts.Length < 3) return;

            try
            {
                // 3. 첫 번째 숫자를 시작 결과값으로 설정
                double tempResult = double.Parse(parts[0]);

                // 4. 반복문을 돌며 연산자(i)와 다음 숫자(i+1)를 순서대로 계산
                // i는 1, 3, 5... 위치의 연산자를 가리킵니다.
                for (int i = 1; i < parts.Length; i += 2)
                {
                    string op = parts[i];
                    double nextNum = double.Parse(parts[i + 1]);

                    if (op == "+") tempResult += nextNum;
                    else if (op == "-") tempResult -= nextNum;
                    else if (op == "x" || op == "*") tempResult *= nextNum;
                    else if (op == "÷" || op == "/")
                    {
                        if (nextNum != 0) tempResult /= nextNum;
                        else { MessageBox.Show("0으로 나눌 수 없습니다!"); return; }
                    }
                }

                // 5. 최종 결과를 정수로 변환하여 출력
                result = tempResult;
                int finalResult = (int)result;

                txtinput.Text += " = " + finalResult.ToString();
                txtresult.Text = finalResult.ToString();
                isOpClicked = true;
            }
            catch
            {
                MessageBox.Show("수식이 올바르지 않습니다.");
            }
        }

        private void btnce_Click(object sender, EventArgs e)
        {
            txtresult.Text = "0";
            string currentInput = txtinput.Text.Trim();
            string[] parts = currentInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length >= 3)
            {
                txtinput.Text = parts[0] + " " + parts[1] + " ";
            }
            else
            {
                txtinput.Text = "0";
            }
        }

        private void btnc_Click_1(object sender, EventArgs e)
        {
            firstNum = 0; secondNum = 0; result = 0;
            currentOp = ""; isOpClicked = false;
            txtinput.Text = "0"; txtresult.Text = "0";
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (txtresult.Text.Length > 1)
                txtresult.Text = txtresult.Text.Substring(0, txtresult.Text.Length - 1);
            else
                txtresult.Text = "0";

            string input = txtinput.Text;
            if (!string.IsNullOrEmpty(input))
            {
                char lastChar = input[input.Length - 1];
                if (char.IsDigit(lastChar))
                {
                    if (input.Length > 1) txtinput.Text = input.Substring(0, input.Length - 1);
                    else txtinput.Text = "0";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}