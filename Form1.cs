using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        int firstNum = 0;
        int secondNum = 0;
        int result = 0;
        bool isOpClicked = false; // 연산자 클릭 여부를 저장하는 변수

        public Form1()
        {
            InitializeComponent();
        }

        // [1] 숫자 버튼 공통 이벤트 (btn0 ~ btn9)
        private void btnNum_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            // 1. txtinput 처리 (누적 기록창: 10 + 20...)
            if (txtinput.Text == "0") txtinput.Text = btn.Text;
            else txtinput.Text += btn.Text;

            // 2. txtresult 처리 (현재 입력 숫자만 표시)
            // 연산자(+)를 누른 직후라면 기존 숫자를 싹 지우고 새 숫자를 씁니다.
            if (isOpClicked)
            {
                txtresult.Text = btn.Text; // 기존 숫자 지우고 새 숫자 시작
                isOpClicked = false;       // 이제 숫자를 썼으니 다시 '거짓'으로 바꿈
            }
            else
            {
                // 평소 입력 중일 때는 숫자를 이어 붙입니다.
                if (txtresult.Text == "0") txtresult.Text = btn.Text;
                else txtresult.Text += btn.Text;
            }
        }

        // [2] 더하기 버튼 (btnplus)
        private void btnplus_Click(object sender, EventArgs e)
        {
            // 1. 현재 txtresult에 입력된 깨끗한 숫자를 첫 번째 숫자로 저장
            // (txtinput은 "10 + " 처럼 기호가 섞여있어 오류가 날 수 있기 때문)
            firstNum = int.Parse(txtresult.Text);

            // 2. txtresult에는 현재 숫자 유지 (그대로 둠)
            txtresult.Text = firstNum.ToString();

            // 3. txtinput에는 연산자 기호를 추가하여 기록을 남김
            txtinput.Text += " + ";

            // 4. ⭐ 핵심: 다음 숫자를 누를 때 txtresult를 새로 쓰도록 신호를 보냄
            isOpClicked = true;
        }

        // [3] 결과 버튼 (btnresult)
        private void btnresult_Click(object sender, EventArgs e)
        {
            // txtinput 전체 내용에서 마지막으로 입력한 숫자(두 번째 피연산자)를 찾아야 합니다.
            // "10 + 20" 형태에서 마지막 "20"을 가져오는 가장 쉬운 방법은 공백으로 자르는 것입니다.
            string[] parts = txtinput.Text.Split(' ');
            if (parts.Length >= 3)
            {
                secondNum = int.Parse(parts[parts.Length - 1]);
            }

            // 더하기 계산 수행
            result = firstNum + secondNum;

            // txtinput에는 결과 버튼 클릭 사실을 표시 (= 기호 추가)
            txtinput.Text += " = " + result.ToString();

            // ⭐ txtresult에는 최종적으로 결과값만 표시합니다.
            txtresult.Text = result.ToString();
        }

        // [4] 초기화 버튼 (btnc)
        private void btnc_Click(object sender, EventArgs e)
        {
            firstNum = 0;
            secondNum = 0;
            result = 0;
            txtinput.Text = "0";
            txtresult.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // 아무 내용도 안 적어도 됩니다. 연결 고리만 만들어주는 역할이에요.
        }
    }
}