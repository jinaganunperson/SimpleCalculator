using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        double firstNum = 0;
        double result = 0;
        bool isOpClicked = false;
        string currentOp = "";

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        // [1] 마우스 클릭 이벤트
        private void btnNum_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            SimulateNumericInput(btn.Text);
            this.ActiveControl = null; // 클릭 후 포커스 제거
        }

        // [공통] 숫자 입력 로직
        private void SimulateNumericInput(string num)
        {
            if (txtinput.Text == "0") txtinput.Text = num;
            else txtinput.Text += num;

            if (isOpClicked)
            {
                txtresult.Text = num;
                isOpClicked = false;
            }
            else
            {
                if (txtresult.Text == "0" || txtresult.Text == "") txtresult.Text = num;
                else txtresult.Text += num;
            }
        }

        // [2] 연산자 버튼
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
            this.ActiveControl = null;
        }

        // [3] 결과 버튼
        private void btnresult_Click(object sender, EventArgs e)
        {
            // 1. 공백을 기준으로 수식 분리
            string[] parts = txtinput.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // 2. 최소 3개(숫자 연산자 숫자)는 있어야 계산함
            if (parts.Length < 3) return;

            try
            {
                // 3. 변수 이름 시작은 소문자, 중간 단어는 대문자 (Camel Case 방식)
                double tempResult = double.Parse(parts[0]);

                // 4. 수식 전체를 순서대로 계산
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

                // 5. 계산 결과를 전역 변수 'result'에 저장 (이름 주의!)
                result = tempResult;

                // 6. 소수점 버리고 정수로 출력
                int finalResult = (int)result;

                txtinput.Text += " = " + finalResult.ToString();
                txtresult.Text = finalResult.ToString();

                isOpClicked = true;
            }
            catch
            {
                MessageBox.Show("수식이 올바르지 않습니다.");
            }

            // 키보드 중복 입력 방지
            this.ActiveControl = null;
        }

        // [4] 삭제 및 초기화
        private void btndel_Click(object sender, EventArgs e)
        {
            if (txtresult.Text.Length > 1)
                txtresult.Text = txtresult.Text.Substring(0, txtresult.Text.Length - 1);
            else
                txtresult.Text = "0";

            string input = txtinput.Text;
            if (!string.IsNullOrEmpty(input) && char.IsDigit(input[input.Length - 1]))
            {
                if (input.Length > 1) txtinput.Text = input.Substring(0, input.Length - 1);
                else txtinput.Text = "0";
            }
            this.ActiveControl = null;
        }

        private void btnc_Click_1(object sender, EventArgs e)
        {
            txtinput.Text = "0"; txtresult.Text = "0";
            currentOp = ""; isOpClicked = false;
            this.ActiveControl = null;
        }

        private void btnce_Click(object sender, EventArgs e)
        {
            txtresult.Text = "0";
            string currentInput = txtinput.Text.Trim();
            string[] parts = currentInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length >= 2) txtinput.Text = parts[0] + " " + parts[1] + " ";
            else txtinput.Text = "0";
            this.ActiveControl = null;
        }

        // 엔터키 시스템 가로채기
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnresult_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // ⭐ [5] 키보드 입력 핵심 수정 (SuppressKeyPress 추가)
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // 1. 숫자 입력 처리
            bool isNumber = false;
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                // Shift를 누르고 숫자키를 누르면 기호가 입력되므로 숫자가 아님을 표시
                if (!e.Shift)
                {
                    SimulateNumericInput((e.KeyCode - Keys.D0).ToString());
                    isNumber = true;
                }
            }
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                SimulateNumericInput((e.KeyCode - Keys.NumPad0).ToString());
                isNumber = true;
            }

            if (isNumber)
            {
                e.SuppressKeyPress = true; // 윈도우 기본 동작 차단
                this.ActiveControl = null;
                return;
            }

            // 2. 연산자 및 기능키 처리 (자판 상단 및 키패드 공통)
            switch (e.KeyCode)
            {
                // --- 곱하기 처리 ---
                case Keys.Multiply: // 키패드 *
                    btnx_Click(null, null);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.D8: // Shift + 8 = *
                    if (e.Shift) { btnx_Click(null, null); e.SuppressKeyPress = true; }
                    break;

                // --- 나누기 처리 ---
                case Keys.Divide: // 키패드 /
                case Keys.OemQuestion: // 자판 / (슬래시)
                    btndivide_Click(null, null);
                    e.SuppressKeyPress = true;
                    break;

                // --- 더하기 처리 ---
                case Keys.Add: // 키패드 +
                    btnplus_Click(null, null);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Oemplus: // 상단 = (Shift 누르면 +)
                    if (e.Shift) btnplus_Click(null, null);
                    else btnresult_Click(null, null);
                    e.SuppressKeyPress = true;
                    break;

                // --- 빼기 처리 ---
                case Keys.Subtract: // 키패드 -
                case Keys.OemMinus: // 상단 -
                    btnminus_Click(null, null);
                    e.SuppressKeyPress = true;
                    break;

                // --- 기타 기능 ---
                case Keys.Back:
                    btndel_Click(null, null);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Escape:
                    btnc_Click_1(null, null);
                    e.SuppressKeyPress = true;
                    break;
            }

            this.ActiveControl = null;

            this.ActiveControl = null;
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}