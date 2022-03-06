
namespace calc
{
    public partial class Form1 : Form
    {

        float a, b, remember_a, remember_b, remember_c;
        int count;
        string remember_action;

        public bool tm = false;
        bool NewOp = true;
        int op = -1;
  


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox.Text + "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox.Text + "0";
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox.Text);
            textBox.Clear();
            count = 2;
            remember_a = a;
            remember_action = "-";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox.Text);
            textBox.Clear();
            count = 1;
            remember_a = a;
            remember_action = "+";
        }

        private void btnDevide_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox.Text);
            textBox.Clear();
            count = 4;
            remember_a = a;
            remember_action = "/";
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox.Text);
            textBox.Clear();
            count = 3;
            remember_a = a;
            remember_action = "*";
        }
        private void btnSqrt_Click(object sender, EventArgs e)
        {
            remember_action = "sqrt";
            a = float.Parse(textBox.Text);
            count = 5;
            result();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            textBox.Clear();
            a = 0;
            b = 0;
            count = 0;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (NewOp)
            {
                textBox.Text = "0";
                NewOp = false;
            }
            if (textBox.Text.IndexOf(",") == -1) textBox.Text += ',';
        }

        private void btnPlusMin_Click(object sender, EventArgs e)
        {
            textBox.Text = Convert.ToString(-(Convert.ToInt32(textBox.Text)));
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            result();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Back) || e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                if (NewOp)
                {
                    textBox.Text = "";
                    NewOp = false;
                }
                if (e.KeyChar == '.') e.KeyChar = ',';
                if (e.KeyChar == ',' && textBox.Text.IndexOf(',') > -1) e.Handled = true;
                if (e.KeyChar == '0' && textBox.Text == "0") e.Handled = true;
                if (textBox.Text == "0" && e.KeyChar >= '1' && e.KeyChar <= '9') textBox.Text = "";
            }
            else e.Handled = true;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
        }

        

        private void result()
        {
            switch (count)
            {
                case 1:
                    b = a + float.Parse(textBox.Text);
                    remember_b = Convert.ToInt32(textBox.Text);
                    remember_c = b;
                    textBox.Text = b.ToString();
                    Logs();
                    break;
                case 2:
                    b = a - float.Parse(textBox.Text);
                    remember_b = Convert.ToInt32(textBox.Text);
                    remember_c = b;
                    textBox.Text = b.ToString();
                    Logs();

                    break;
                case 3:
                    b = a * float.Parse(textBox.Text);
                    remember_b = Convert.ToInt32(textBox.Text);
                    remember_c = b;
                    textBox.Text = b.ToString();
                    Logs();

                    break;
                case 4:
                    b = a / float.Parse(textBox.Text);
                    remember_b = Convert.ToInt32(textBox.Text);
                    remember_c = b;
                    textBox.Text = b.ToString();
                    Logs();

                    break;
                case 5:
                    textBox.Text = Math.Sqrt(a).ToString();
                    break;

                default:
                    break;
            }

        }
        public static DateTime Today { get; }

        private void Logs()
        {
            DateTime dateTime = DateTime.Now;
            using (StreamWriter w = new StreamWriter("Logs.txt", true))
            {
                w.Write(Convert.ToString(dateTime));
                w.Write(": ");
                w.Write(remember_a);
                w.Write("  ");
                w.Write(remember_action);
                w.Write(" ");
                w.Write(remember_b);
                w.Write(" = ");
                w.Write(remember_c);
                w.WriteLine();
            }

        }

       
    }
}