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

        // ⭐ 숫자를 포맷팅하는 보조 함수 추가
        private string FormatNumber(string input)
        {
            // 콤마를 모두 제거하고 숫자로 변환 후 다시 천 단위 콤마 적용
            if (double.TryParse(input.Replace(",", ""), out double value))
            {
                return string.Format("{0:#,0}", value);
            }
            return input;
        }

        private void SimulateNumericInput(string inputVal)
        {
            // 1. txtinput (수식창) 업데이트
            if (txtinput.Text == "0") txtinput.Text = inputVal;
            else txtinput.Text += inputVal;

            // 2. txtresult (현재 숫자창) 업데이트 및 콤마 적용
            if (isOpClicked)
            {
                txtresult.Text = inputVal;
                isOpClicked = false;
            }
            else
            {
                string currentText = txtresult.Text.Replace(",", ""); // 기존 콤마 제거
                if (currentText == "0") currentText = inputVal;
                else currentText += inputVal;

                txtresult.Text = FormatNumber(currentText); // 콤마 찍어서 표시
            }
        }

        private void HandleOperator(string op)
        {
            if (txtinput.Text == "0" && op != "(") return;
            txtinput.Text += " " + op + " ";
            isOpClicked = true;
            this.ActiveControl = null;
        }

        private void btnplus_Click(object sender, EventArgs e) { HandleOperator("+"); }
        private void btnminus_Click(object sender, EventArgs e) { HandleOperator("-"); }
        private void btnx_Click(object sender, EventArgs e) { HandleOperator("x"); }
        private void btndivide_Click(object sender, EventArgs e) { HandleOperator("÷"); }

        // [3] 결과 버튼
        private void btnresult_Click(object sender, EventArgs e)
        {
            try
            {
                // ⭐ 계산 전 수식에서 콤마(,)를 모두 제거해야 오류가 나지 않음
                string expression = txtinput.Text.Replace(",", "").Replace("x", "*").Replace("÷", "/");

                DataTable table = new DataTable();
                var computeResult = table.Compute(expression, "");

                result = Convert.ToDouble(computeResult);

                // 결과 표시 (콤마 적용)
                string formattedResult = string.Format("{0:#,0}", result);
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

        // [6] 한 글자씩 지우기 (콤마 대응)
        private void btndel_Click(object sender, EventArgs e)
        {
            // txtresult 지우기 (콤마 제거 후 지우고 다시 콤마 적용)
            string currentRes = txtresult.Text.Replace(",", "");
            if (currentRes.Length > 1)
            {
                currentRes = currentRes.Substring(0, currentRes.Length - 1);
                txtresult.Text = FormatNumber(currentRes);
            }
            else
            {
                txtresult.Text = "0";
            }

            // txtinput 지우기
            string input = txtinput.Text;
            if (!string.IsNullOrEmpty(input) && input != "0")
            {
                if (input.EndsWith(" "))
                {
                    txtinput.Text = input.Length > 3 ? input.Substring(0, input.Length - 3) : "0";
                }
                else
                {
                    txtinput.Text = input.Length > 1 ? input.Substring(0, input.Length - 1) : "0";
                }
            }
            this.ActiveControl = null;
        }

        // --- 이하 중략 (btnc, btnce, ProcessCmdKey, KeyDown 등은 기존과 동일) ---
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
    }
}