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

        // [1] 결과 버튼 - 계산 완료 시 기록 추가
        private void btnresult_Click(object sender, EventArgs e)
        {
            try
            {
                // 이미 결과가 나온 상태면 중복 계산 방지
                if (txtinput.Text.Contains("=")) return;

                string expression = txtinput.Text.Replace(",", "").Replace("x", "*").Replace("÷", "/");
                DataTable table = new DataTable();
                var computeResult = table.Compute(expression, "");

                result = Convert.ToDouble(computeResult);

                string formattedResult = result % 1 == 0
                    ? string.Format("{0:#,0}", result)
                    : string.Format("{0:#,0.###}", result);

                // ⭐ 기록 저장용 변수 (수식 = 결과)
                string fullRecord = txtinput.Text + " = " + formattedResult;

                txtinput.Text = fullRecord;
                txtresult.Text = formattedResult;
                isOpClicked = true;

                // ⭐ ListBox(history)에 계산 기록 추가 및 자동 스크롤
                history.Items.Add(fullRecord);
                history.SelectedIndex = history.Items.Count - 1;
            }
            catch
            {
                MessageBox.Show("수식이 올바르지 않습니다.");
            }
            this.ActiveControl = null;
        }

        // ⭐ [NEW] 기록 리스트 더블 클릭 시 결과값 불러오기
        private void history_DoubleClick(object sender, EventArgs e)
        {
            if (history.SelectedItem == null) return;

            // 선택된 줄에서 '=' 이후의 결과값만 추출
            string selectedLine = history.SelectedItem.ToString();
            string[] parts = selectedLine.Split('=');

            if (parts.Length > 1)
            {
                string lastResult = parts[1].Trim();

                // 현재 입력창 초기화 후 결과값 붙여넣기
                txtresult.Text = lastResult;
                txtinput.Text = lastResult;
                isOpClicked = false;
            }
            this.ActiveControl = null;
        }

        // [2] 초기화 버튼 - 기록도 지우고 싶을 때를 위해 수정
        private void btnc_Click_1(object sender, EventArgs e)
        {
            txtinput.Text = "0";
            txtresult.Text = "0";
            isOpClicked = false;

            // 선택 사항: C 버튼을 아주 길게 누르거나 별도 버튼으로 기록 삭제 가능
            // history.Items.Clear(); // 기록까지 다 지우고 싶다면 이 코드 사용
            this.ActiveControl = null;
        }

        // --- 기존 기능 유지 (숫자 입력, 연산자, 부호 반전 등) ---

        private void btnNum_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            SimulateNumericInput(btn.Text);
            this.ActiveControl = null;
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            if (txtresult.Text.Contains(".")) return;
            txtresult.Text += ".";
            txtinput.Text += ".";
            this.ActiveControl = null;
        }

        private string FormatNumber(string input)
        {
            if (string.IsNullOrEmpty(input)) return "0";
            if (input.Contains("."))
            {
                string[] parts = input.Split('.');
                if (double.TryParse(parts[0].Replace(",", ""), out double obj))
                    return string.Format("{0:#,0}", obj) + "." + parts[1];
                return input;
            }
            if (double.TryParse(input.Replace(",", ""), out double value))
                return string.Format("{0:#,0}", value);
            return input;
        }

        private void SimulateNumericInput(string inputVal)
        {
            if (txtinput.Text == "0" || txtinput.Text.Contains("=")) txtinput.Text = inputVal;
            else txtinput.Text += inputVal;

            if (isOpClicked)
            {
                txtresult.Text = inputVal;
                isOpClicked = false;
            }
            else
            {
                if (txtresult.Text.Contains(".")) txtresult.Text += inputVal;
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
            if (txtinput.Text.Contains("=")) // 결과가 나온 상태에서 연산자 누르면 결과값에 이어서 계산
            {
                txtinput.Text = txtresult.Text;
            }

            if (txtinput.Text == "0" && op != "(") return;
            if (txtinput.Text.EndsWith(" "))
            {
                string currentInput = txtinput.Text.Trim();
                if (!currentInput.EndsWith("(") && !currentInput.EndsWith(")"))
                {
                    int lastSpaceIndex = currentInput.LastIndexOf(' ');
                    if (lastSpaceIndex != -1)
                    {
                        txtinput.Text = currentInput.Substring(0, lastSpaceIndex) + " " + op + " ";
                        return;
                    }
                }
            }
            txtinput.Text += " " + op + " ";
            isOpClicked = true;
            this.ActiveControl = null;
        }

        private void btnplus_Click(object sender, EventArgs e) { HandleOperator("+"); }
        private void btnminus_Click(object sender, EventArgs e) { HandleOperator("-"); }
        private void btnx_Click(object sender, EventArgs e) { HandleOperator("x"); }
        private void btndivide_Click(object sender, EventArgs e) { HandleOperator("÷"); }

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
                case Keys.Decimal: case Keys.OemPeriod: btndot_Click(null, null); break;
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

        private void btnplusminus_Click(object sender, EventArgs e)
        {
            string input = txtinput.Text;
            if (string.IsNullOrEmpty(input) || input == "0") return;
            string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) return;
            for (int i = parts.Length - 1; i >= 0; i--)
            {
                if (parts[i] == "+" || parts[i] == "-")
                {
                    parts[i] = (parts[i] == "+") ? "-" : "+";
                    txtinput.Text = string.Join(" ", parts);
                    if (input.EndsWith(" ")) txtinput.Text += " ";
                    break;
                }
            }
            this.ActiveControl = null;
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void history_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void history_DoubleClick_1(object sender, EventArgs e)
        {
            if (history.SelectedItem == null) return;

            // 선택된 줄에서 '=' 이후의 결과값만 추출
            string selectedLine = history.SelectedItem.ToString();
            string[] parts = selectedLine.Split('=');

            if (parts.Length > 1)
            {
                string lastResult = parts[1].Trim();

                // 현재 입력창 초기화 후 결과값 붙여넣기
                txtresult.Text = lastResult;
                txtinput.Text = lastResult;
                isOpClicked = false;
            }
            this.ActiveControl = null;
        }
    }
}