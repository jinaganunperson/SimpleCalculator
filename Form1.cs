using System;
using System.Data; // DataTable 사용을 위해 추가
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        double result = 0;
        bool isOpClicked = false;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            SimulateNumericInput(btn.Text);
            this.ActiveControl = null;
        }

        private void SimulateNumericInput(string inputVal)
        {
            // 수식창 업데이트 (0일 때는 교체, 아니면 누적)
            if (txtinput.Text == "0") txtinput.Text = inputVal;
            else txtinput.Text += inputVal;

            // 결과창(현재 입력값) 업데이트
            if (isOpClicked)
            {
                txtresult.Text = inputVal;
                isOpClicked = false;
            }
            else
            {
                if (txtresult.Text == "0" || txtresult.Text == "") txtresult.Text = inputVal;
                else txtresult.Text += inputVal;
            }
        }

        // 연산자 및 괄호 처리 공통 함수
        private void HandleOperator(string op)
        {
            if (txtinput.Text == "0" && op != "(") return;

            // 괄호는 앞뒤 공백을 넣어 구분하기 쉽게 함
            if (op == "(" || op == ")") txtinput.Text += " " + op + " ";
            else txtinput.Text += " " + op + " ";

            isOpClicked = true;
            this.ActiveControl = null;
        }

        private void btnplus_Click(object sender, EventArgs e) { HandleOperator("+"); }
        private void btnminus_Click(object sender, EventArgs e) { HandleOperator("-"); }
        private void btnx_Click(object sender, EventArgs e) { HandleOperator("*"); } // 내부적으론 * 사용
        private void btndivide_Click(object sender, EventArgs e) { HandleOperator("/"); } // 내부적으론 / 사용

        // [3] 결과 버튼 (괄호 및 우선순위 계산 로직)
        private void btnresult_Click(object sender, EventArgs e)
        {
            try
            {
                // 표시용 기호(x, ÷)를 계산용 기호(*, /)로 변경
                string expression = txtinput.Text.Replace("x", "*").Replace("÷", "/");

                // DataTable의 Compute 메서드는 괄호 우선순위를 완벽히 지원함
                DataTable table = new DataTable();
                var computeResult = table.Compute(expression, "");

                result = Convert.ToDouble(computeResult);
                int finalResult = (int)result;

                txtinput.Text += " = " + finalResult.ToString();
                txtresult.Text = finalResult.ToString();
                isOpClicked = true;
            }
            catch (Exception)
            {
                MessageBox.Show("수식이 올바르지 않습니다. (괄호 짝을 확인하세요)");
            }
            this.ActiveControl = null;
        }

        // [6] 한 글자씩 지우기 버튼 (btndel)
        private void btndel_Click(object sender, EventArgs e)
        {
            // 1. txtresult (결과창) 지우기
            if (txtresult.Text.Length > 1)
            {
                txtresult.Text = txtresult.Text.Substring(0, txtresult.Text.Length - 1);
            }
            else
            {
                txtresult.Text = "0";
            }

            // 2. txtinput (수식창) 지우기
            string input = txtinput.Text;

            if (!string.IsNullOrEmpty(input) && input != "0")
            {
                // 마지막이 공백이면 연산자 구역이므로 " + " 전체(3글자)를 지움
                if (input.EndsWith(" "))
                {
                    // 연산자는 앞뒤 공백 포함 3글자 (예: " + ")
                    if (input.Length > 3)
                        txtinput.Text = input.Substring(0, input.Length - 3);
                    else
                        txtinput.Text = "0";
                }
                else
                {
                    // 마지막이 숫자면 1글자만 지움
                    if (input.Length > 1)
                        txtinput.Text = input.Substring(0, input.Length - 1);
                    else
                        txtinput.Text = "0";
                }
            }

            this.ActiveControl = null;
        }

        private void btnc_Click_1(object sender, EventArgs e)
        {
            txtinput.Text = "0"; txtresult.Text = "0";
            isOpClicked = false;
            this.ActiveControl = null;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnresult_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool isHandled = true;

            // 1. 숫자 입력 처리 (Shift가 눌리지 않은 상태의 상단 숫자키 또는 키패드 숫자키)
            if (!e.Shift && e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                SimulateNumericInput((e.KeyCode - Keys.D0).ToString());
            }
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                SimulateNumericInput((e.KeyCode - Keys.NumPad0).ToString());
            }
            else
            {
                isHandled = false;
            }

            // 숫자가 입력되었다면 여기서 처리 종료
            if (isHandled)
            {
                e.SuppressKeyPress = true;
                this.ActiveControl = null;
                return;
            }

            // 2. 기호 및 기능키 처리
            switch (e.KeyCode)
            {
                case Keys.D9: // ( 괄호 열기 (Shift + 9)
                    if (e.Shift) HandleOperator("(");
                    break;

                case Keys.D0: // ) 괄호 닫기 (Shift + 0)
                    if (e.Shift) HandleOperator(")");
                    break;

                case Keys.Add: // 키패드 +
                    HandleOperator("+");
                    break;

                case Keys.Oemplus: // 상단 =/+ 키
                    if (e.Shift) HandleOperator("+"); // Shift 누르면 +
                    else btnresult_Click(null, null);    // 그냥 누르면 =
                    break;

                case Keys.Subtract: // 키패드 -
                case Keys.OemMinus: // 상단 -
                    HandleOperator("-");
                    break;

                case Keys.Multiply: // 키패드 *
                    HandleOperator("x");
                    break;

                case Keys.D8: // 상단 8 (Shift 누르면 *)
                    if (e.Shift) HandleOperator("x");
                    break;

                case Keys.Divide: // 키패드 /
                case Keys.OemQuestion: // 자판 / (슬래시)
                    HandleOperator("÷");
                    break;

                case Keys.Back: // ⭐ 백스페이스 (지우기)
                    btndel_Click(null, null);
                    e.SuppressKeyPress = true; // 윈도우 기본 백스페이스 동작(소리 등) 방지
                    break;

                case Keys.Escape: // ESC (전체 초기화)
                    btnc_Click_1(null, null);
                    e.SuppressKeyPress = true;
                    break;
            }

            // 입력 후 버튼에 포커스가 남지 않도록 해제
            this.ActiveControl = null;
        }
        // [CE 버튼] 현재 입력된 숫자만 0으로 초기화
        private void btnce_Click(object sender, EventArgs e)
        {
            txtresult.Text = "0";

            // txtinput에서 마지막 숫자/기호 구역 하나를 제거
            string currentInput = txtinput.Text.Trim();
            int lastSpaceIndex = currentInput.LastIndexOf(' ');

            if (lastSpaceIndex != -1)
            {
                txtinput.Text = currentInput.Substring(0, lastSpaceIndex) + " ";
            }
            else
            {
                txtinput.Text = "0";
            }
            this.ActiveControl = null;
        }

        // [Form Load] 폼이 처음 켜질 때 실행되는 부분 (비어 있어도 이름은 있어야 함)
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}