using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        // 1. 소수점 계산을 위해 모든 숫자 변수를 double로 변경
        double firstNum = 0;
        double secondNum = 0;
        double result = 0;
        bool isOpClicked = false;
        string currentOp = "";

        public Form1()
        {
            InitializeComponent();
        }

        // [1] 숫자 버튼 공통 이벤트 (btn0 ~ btn9)
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

        // [2] 더하기 버튼
        private void btnplus_Click(object sender, EventArgs e)
        {
            firstNum = double.Parse(txtresult.Text); // Parse도 double로 변경
            txtresult.Text = firstNum.ToString();
            txtinput.Text += " + ";
            isOpClicked = true;
            currentOp = "+";
        }

        // [2-1] 빼기 버튼
        private void btnminus_Click(object sender, EventArgs e)
        {
            firstNum = double.Parse(txtresult.Text);
            txtresult.Text = firstNum.ToString();
            txtinput.Text += " - ";
            isOpClicked = true;
            currentOp = "-";
        }

        // [2-2] 곱하기 버튼
        private void btnx_Click(object sender, EventArgs e)
        {
            firstNum = double.Parse(txtresult.Text);
            txtresult.Text = firstNum.ToString();
            txtinput.Text += " * ";
            isOpClicked = true;
            currentOp = "*";
        }

        // [2-3] 나누기 버튼 (기호 ÷로 변경)
        private void btndivide_Click(object sender, EventArgs e)
        {
            firstNum = double.Parse(txtresult.Text);
            txtresult.Text = firstNum.ToString();
            txtinput.Text += " ÷ "; // 요청하신 나누기 기호
            isOpClicked = true;
            currentOp = "÷";
        }

        // [3] 결과 버튼 (사칙연산 통합 및 나누기 오류 수정)
        private void btnresult_Click(object sender, EventArgs e)
        {
            string[] parts = txtinput.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 3)
            {
                secondNum = double.Parse(parts[parts.Length - 1]);
            }

            // 연산 수행 (계산은 정확도를 위해 double로 유지)
            if (currentOp == "+") result = firstNum + secondNum;
            else if (currentOp == "-") result = firstNum - secondNum;
            else if (currentOp == "*") result = firstNum * secondNum;
            else if (currentOp == "÷")
            {
                if (secondNum != 0)
                {
                    result = firstNum / secondNum;
                }
                else
                {
                    MessageBox.Show("0으로 나눌 수 없습니다!");
                    return;
                }
            }

            // ⭐ 핵심 수정: 결과를 표시할 때만 정수로 형변환 (소수점 제거)
            // (int)를 붙이면 소수점 자리가 버려집니다.
            int finalResult = (int)result;

            txtinput.Text += " = " + finalResult.ToString();
            txtresult.Text = finalResult.ToString();
            isOpClicked = true;
        }

        // [4] 초기화 버튼
        private void btnc_Click(object sender, EventArgs e)
        {
            firstNum = 0;
            secondNum = 0;
            result = 0;
            currentOp = "";
            isOpClicked = false;
            txtinput.Text = "0";
            txtresult.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}