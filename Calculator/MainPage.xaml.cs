namespace Calculator;

public partial class MainPage : ContentPage
{
    private double firstNumber = 0;
    private double secondNumber = 0;
    private string currentOperator = ""; // + - * / =
    private bool isFirstNumberAfterOperator = true;
    private bool decimalPressed = false;

    private bool isFirstNumber = false;
    public MainPage()
    {
        InitializeComponent();
    }


    private void OnNumberPressed(object? sender, EventArgs e)
    {
        Button pressedButton = sender as Button;

        if (pressedButton != null)
        {
            if (isFirstNumberAfterOperator)
            {
                Display.Text = pressedButton.Text;
                isFirstNumberAfterOperator = false;
            }
            else
            {

                if (pressedButton.Text == ",") {

                    if (decimalPressed) return;

                    decimalPressed = true;
                }

                Display.Text = Display.Text + pressedButton.Text;
            }
        }
        
    }

    private void OnOperatorPressed(object? sender, EventArgs e)
    {
        Button pressedButton = sender as Button;
        double result = 0;
        switch (pressedButton.Text) {
            case "C":
                firstNumber = 0;
                secondNumber = 0;
                currentOperator = "";
                isFirstNumberAfterOperator = false;
                decimalPressed = false;
                return;

            
            case "CE":
                Display.Text = "0";
                return;


            if (isFirstNumber) {
                firstNumber = double.Parse(Display.Text);
                isFirstNumber = false;
            }

            case "²":
                result = firstNumber * firstNumber;
                break;

            case "√":
                result = Math.Pow(firstNumber, .5);
                break;


            if (!isFirstNumber){
                secondNumber = double.Parse(Display.Text);
            }

            case "+":
                result = firstNumber + secondNumber;
                break;

            case "*":
                result = firstNumber * secondNumber;
                break;

            case "-":
                result = firstNumber - secondNumber;
                break;

            case "/":
                result = firstNumber / secondNumber;
                break;

            case "=":
                Display.Text = result.ToString();
                break;
        }

    }
};