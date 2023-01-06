namespace Calculator
{
    public partial class Calculator : Form
    {
        bool isCalculated = false;
        public Calculator()
        {
            InitializeComponent();
            foreach (Control el in this.Controls)
            {
                if (el is Button button)
                {
                    button.Click += buttonCE_Click;
                }
            }
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            string buttonText = ((Button)sender).Text;
            switch(buttonText)
            {
                case "C":
                    textExpresion.Clear();
                    textResult.Clear();
                    break;
                case "CE\r\n":
                    textResult.Text = "0";
                    break;
                case "X":
                    for (int i = textExpresion.TextLength; i > 0; i--)
                    {
                        textExpresion.Text = textExpresion.Text.Substring(textExpresion.TextLength - 1);
                    }
                    break;
                case "1/X":
                    textExpresion.Text = $"1/{textResult.Text}=";
                    textResult.Text = (1 / double.Parse(textExpresion.Text)).ToString();
                    break;
            }

        }
    }
}