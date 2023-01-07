using System.Data;

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
                    if (textResult.TextLength > 1)
                    {
                        textResult.Text = textResult.Text.Substring(0, textResult.TextLength - 1);
                    }                   
                    break;
                case "1/X":
                    if (!String.IsNullOrEmpty(textResult.Text))
                    {
                        textExpresion.Text = $"1/{textResult.Text}=";
                        textResult.Text = (1 / double.Parse(textResult.Text)).ToString();
                        isCalculated = true;
                    }
                    break;
                case "sqrt(x)":
                    textExpresion.Text = "sqrt(" + textResult.Text + ")=";
                    textResult.Text = Math.Sqrt(double.Parse(textResult.Text)).ToString(); 
                    isCalculated = true;
                    break;
                case "x^2":
                    textExpresion.Text = textResult.Text + "^2=";
                    textResult.Text = Math.Pow(double.Parse(textResult.Text),2).ToString();
                    isCalculated = true;
                    break;
                case "=":
                    if (!isCalculated) {
                        textExpresion.Text += "=";
                        textResult.Text = textResult.Text.Replace(',', '.');
                        if (textResult.Text.Contains("%"))
                        {
                            textResult.Text = textResult.Text.Replace('%', '/') + "100";
                        }
                        textResult.Text = new DataTable().Compute(textResult.Text, null).ToString();
                        isCalculated = true;
                    }
                    break;
                case "+/-":
                    if (!String.IsNullOrEmpty(textResult.Text))
                    {
                        textResult.Text = (-1 * double.Parse(textResult.Text)).ToString();
                    }
                    break;
                default:
                    if (isCalculated)
                    {
                        textExpresion.Text = textResult.Text;
                        isCalculated= false;
                    }
                    textExpresion.Text += buttonText;
                    textResult.Text += buttonText;
                    break;
            }

        }
    }
}