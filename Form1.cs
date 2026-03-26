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

        private void btnplus_Click(object sender, EventArgs e)
        {
            firstNum = double.Parse(txtresult.Text);
            txtresult.Text = firstNum.ToString();
            txtinput.Text += " + ";
            isOpClicked = true;
            currentOp = "+";
        }

        private void btnminus_Click(object sender, EventArgs e)
        {
            firstNum = double.Parse(txtresult.Text);
            txtresult.Text = firstNum.ToString();
            txtinput.Text += " - ";
            isOpClicked = true;
            currentOp = "-";
        }

        // ⭐ [2-2] 곱하기 버튼 기호 변경 (x)
        private void btnx_Click(object sender, EventArgs e)
        {
            firstNum = double.Parse(txtresult.Text);
            txtresult.Text = firstNum.ToString();
            txtinput.Text += " x "; // * 대신 x 표시
            isOpClicked = true;
            currentOp = "x";
        }

        // ⭐ [2-3] 나누기 버튼 기호 변경 (÷)
        private void btndivide_Click(object sender, EventArgs e)
        {
            firstNum = double.Parse(txtresult.Text);
            txtresult.Text = firstNum.ToString();
            txtinput.Text += " ÷ "; // / 대신 ÷ 표시
            isOpClicked = true;
            currentOp = "÷";
        }

        private void btnresult_Click(object sender, EventArgs e)
        {
            // 1. 공백을 기준으로 수식 분리
            string[] parts = txtinput.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // 2. 안전장치: 최소한 '숫자 연산자 숫자' (3개)는 있어야 계산 가능
            if (parts.Length < 3) return;

            try
            {
                // 3. 수식의 구성 요소를 직접 추출 (전역 변수에 의존하지 않음)
                double n1 = double.Parse(parts[0]);   // 첫 번째 숫자
                string op = parts[1];                 // 연산자 (x, ÷, +, -)
                double n2 = double.Parse(parts[2]);   // 두 번째 숫자

                // 4. 연산 기호에 따른 실제 계산
                if (op == "+") result = n1 + n2;
                else if (op == "-") result = n1 - n2;
                else if (op == "x" || op == "*") result = n1 * n2;
                else if (op == "÷" || op == "/")
                {
                    if (n2 != 0) result = n1 / n2;
                    else { MessageBox.Show("0으로 나눌 수 없습니다!"); return; }
                }

                // 5. 정수 결과 출력 (소수점 버림)
                int finalResult = (int)result;

                // 화면 표시 업데이트
                txtinput.Text += " = " + finalResult.ToString();
                txtresult.Text = finalResult.ToString();

                // 다음 입력을 위한 상태 설정
                isOpClicked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("수식이 올바르지 않습니다.");
            }
        }

        // ⭐ [5] CE 버튼: 바뀐 기호 포맷 유지
        private void btnce_Click(object sender, EventArgs e)
        {
            txtresult.Text = "0";
            string currentInput = txtinput.Text.Trim();
            string[] parts = currentInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length >= 3)
            {
                // 앞의 숫자와 기호(parts[1])만 다시 합쳐서 수식 유지
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

        private void Form1_Load(object sender, EventArgs e) { }

        private void btndel_Click(object sender, EventArgs e)
        {
            // 1. 현재 입력창(txtresult) 지우기
            if (txtresult.Text.Length > 1)
            {
                // 글자가 2개 이상이면 마지막 글자 하나만 삭제
                txtresult.Text = txtresult.Text.Substring(0, txtresult.Text.Length - 1);
            }
            else
            {
                // 글자가 1개뿐이라면 지웠을 때 0으로 변경
                txtresult.Text = "0";
            }

            // 2. 전체 수식창(txtinput) 지우기
            // 주의: 연산자 기호나 공백을 지우면 오류가 날 수 있으므로, 
            // 마지막 글자가 숫자일 때만 지우도록 안전장치를 둡니다.
            string input = txtinput.Text;
            if (!string.IsNullOrEmpty(input))
            {
                // 마지막 글자가 숫자인지 확인
                char lastChar = input[input.Length - 1];
                if (char.IsDigit(lastChar))
                {
                    if (input.Length > 1)
                    {
                        txtinput.Text = input.Substring(0, input.Length - 1);
                    }
                    else
                    {
                        txtinput.Text = "0";
                    }
                }
                // 만약 마지막이 공백(' ')이라면 연산자 구간이므로 지우지 않습니다.
            }
        }
    }
}