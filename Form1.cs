using System;
using System.Data;
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

        // ⭐ 소수점 버튼 클릭 이벤트 (btndot)
        private void btndot_Click(object sender, EventArgs e)
        {
            // 현재 결과창에 이미 점이 있다면 무시
            if (txtresult.Text.Contains(".")) return;

            txtresult.Text += ".";
            txtinput.Text += ".";
            this.ActiveControl = null;
        }

        private string FormatNumber(string input)
        {
            if (string.IsNullOrEmpty(input)) return "0";

            // 소수점이 포함된 경우, 정수 부분만 콤마 포맷팅
            if (input.Contains("."))
            {
                string[] parts = input.Split('.');
                if (double.TryParse(parts[0].Replace(",", ""), out double obj))
                {
                    return string.Format("{0:#,0}", obj) + "." + parts[1];
                }
                return input;
            }

            if (double.TryParse(input.Replace(",", ""), out double value))
            {
                return string.Format("{0:#,0}", value);
            }
            return input;
        }

        private void SimulateNumericInput(string inputVal)
        {
            if (txtinput.Text == "0") txtinput.Text = inputVal;
            else txtinput.Text += inputVal;

            if (isOpClicked)
            {
                txtresult.Text = inputVal;
                isOpClicked = false;
            }
            else
            {
                // 소수점 입력 중일 때는 단순 누적, 아닐 때는 포맷팅 적용
                if (txtresult.Text.Contains("."))
                {
                    txtresult.Text += inputVal;
                }
                else
                {
                    string currentText = txtresult.Text.Replace(",", "");
                    if (currentText == "0") currentText = inputVal;
                    else currentText += inputVal;
                    txtresult.Text = FormatNumber(currentText);
                }
            }
        }

        private void HandleOperator(string op)
        {
            // 1. 초기 상태에서 연산자 입력 방지
            if (txtinput.Text == "0" && op != "(") return;

            // 2. ⭐ 핵심: 수식의 마지막이 연산자(공백으로 끝남)라면?
            if (txtinput.Text.EndsWith(" "))
            {
                string currentInput = txtinput.Text.Trim();

                // 마지막 글자가 괄호가 아닐 때만 연산자를 교체
                if (!currentInput.EndsWith("(") && !currentInput.EndsWith(")"))
                {
                    int lastSpaceIndex = currentInput.LastIndexOf(' ');
                    if (lastSpaceIndex != -1)
                    {
                        // 기존 연산자 부분을 지우고 새 연산자로 교체
                        txtinput.Text = currentInput.Substring(0, lastSpaceIndex) + " " + op + " ";
                        return; // 교체했으므로 함수 종료
                    }
                }
            }

            // 3. 연산자가 없는 정상적인 상황일 때 추가
            txtinput.Text += " " + op + " ";
            isOpClicked = true;
            this.ActiveControl = null;
        }

        private void btnplus_Click(object sender, EventArgs e) { HandleOperator("+"); }
        private void btnminus_Click(object sender, EventArgs e) { HandleOperator("-"); }
        private void btnx_Click(object sender, EventArgs e) { HandleOperator("x"); }
        private void btndivide_Click(object sender, EventArgs e) { HandleOperator("÷"); }

        private void btnresult_Click(object sender, EventArgs e)
        {
            try
            {
                string expression = txtinput.Text.Replace(",", "").Replace("x", "*").Replace("÷", "/");
                DataTable table = new DataTable();
                var computeResult = table.Compute(expression, "");

                result = Convert.ToDouble(computeResult);

                // ⭐ (int) 변환을 제거하여 소수점 결과 유지
                // 결과가 정수면 콤마만, 실수면 소수점까지 표시
                string formattedResult = result % 1 == 0
                    ? string.Format("{0:#,0}", result)
                    : string.Format("{0:#,0.###}", result); // 최대 소수점 3자리까지

                txtinput.Text += " = " + formattedResult;
                txtresult.Text = formattedResult;
                isOpClicked = true;
            }
            catch
            {
                MessageBox.Show("수식이 올바르지 않습니다.");
            }
            this.ActiveControl = null;
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            string currentRes = txtresult.Text.Replace(",", "");
            if (currentRes.Length > 1)
            {
                currentRes = currentRes.Substring(0, currentRes.Length - 1);
                txtresult.Text = FormatNumber(currentRes);
            }
            else txtresult.Text = "0";

            string input = txtinput.Text;
            if (!string.IsNullOrEmpty(input) && input != "0")
            {
                if (input.EndsWith(" ")) txtinput.Text = input.Length > 3 ? input.Substring(0, input.Length - 3) : "0";
                else txtinput.Text = input.Length > 1 ? input.Substring(0, input.Length - 1) : "0";
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
            if (keyData == Keys.Enter) { btnresult_Click(null, null); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool isHandled = true;
            if (!e.Shift && e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                SimulateNumericInput((e.KeyCode - Keys.D0).ToString());
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                SimulateNumericInput((e.KeyCode - Keys.NumPad0).ToString());
            else isHandled = false;

            if (isHandled) { e.SuppressKeyPress = true; this.ActiveControl = null; return; }

            switch (e.KeyCode)
            {
                case Keys.Decimal: // 키패드 마침표
                case Keys.OemPeriod: // 자판 마침표
                    btndot_Click(null, null);
                    break;
                case Keys.D9: if (e.Shift) HandleOperator("("); break;
                case Keys.D0: if (e.Shift) HandleOperator(")"); break;
                case Keys.Add: HandleOperator("+"); break;
                case Keys.Oemplus: if (e.Shift) HandleOperator("+"); else btnresult_Click(null, null); break;
                case Keys.Subtract: case Keys.OemMinus: HandleOperator("-"); break;
                case Keys.Multiply: HandleOperator("x"); break;
                case Keys.D8: if (e.Shift) HandleOperator("x"); break;
                case Keys.Divide: case Keys.OemQuestion: HandleOperator("÷"); break;
                case Keys.Back: btndel_Click(null, null); e.SuppressKeyPress = true; break;
                case Keys.Escape: btnc_Click_1(null, null); e.SuppressKeyPress = true; break;
            }
            this.ActiveControl = null;
        }

        private void btnce_Click(object sender, EventArgs e)
        {
            txtresult.Text = "0";
            string currentInput = txtinput.Text.Trim();
            int lastSpaceIndex = currentInput.LastIndexOf(' ');
            if (lastSpaceIndex != -1) txtinput.Text = currentInput.Substring(0, lastSpaceIndex) + " ";
            else txtinput.Text = "0";
            this.ActiveControl = null;
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void btnplusminus_Click(object sender, EventArgs e)
        {
            string input = txtinput.Text;

            if (string.IsNullOrEmpty(input) || input == "0") return;

            // 수식을 공백 단위로 분리 (예: "10", "-", "1")
            string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2) return; // 숫자가 하나만 있거나 하면 무시

            // 뒤에서부터 보면서 가장 마지막에 나온 + 또는 - 를 찾음
            for (int i = parts.Length - 1; i >= 0; i--)
            {
                if (parts[i] == "+" || parts[i] == "-")
                {
                    // 부호 반전
                    parts[i] = (parts[i] == "+") ? "-" : "+";

                    // 다시 수식으로 합치기
                    txtinput.Text = string.Join(" ", parts);

                    // 연산자 뒤에 숫자가 없는 상태("10 + ")였다면 뒤에 공백 추가 유지
                    if (input.EndsWith(" "))
                    {
                        txtinput.Text += " ";
                    }

                    break; // 하나만 바꿨으면 종료
                }
            }

            this.ActiveControl = null;
        }
    }
}