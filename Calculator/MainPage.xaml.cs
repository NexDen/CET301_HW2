namespace Calculator;

public partial class MainPage : ContentPage
{
    private double firstNumber = 0;
    private double secondNumber = 0;
    private string currentOperator = ""; // + - * / =
    private bool isFirstNumberAfterOperator = true;
    private bool decimalPressed = false;

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

                Display.Text += pressedButton.Text;
            }
        }
        
    }

    private void OnOperatorPressed(object? sender, EventArgs e)
    {
        Button pressedButton = sender as Button;
        double result = 0;

        if (isFirstNumberAfterOperator)
        {
            currentOperator = pressedButton.Text;
            return;
        }

        isFirstNumberAfterOperator = true;
        if (currentOperator == "")
        {
            currentOperator = pressedButton.Text;
            firstNumber = Double.Parse(Display.Text);
            switch (currentOperator)
            {
                case "²": 
                    result = firstNumber * firstNumber;
                    Display.Text = result.ToString();
                    currentOperator = pressedButton.Text;
                    if (pressedButton.Text == "=") currentOperator = "";
                    firstNumber = result;
                    break;
                case "√": 
                    result = Math.Pow(firstNumber, 0.5);
                    Display.Text = result.ToString();
                    currentOperator = pressedButton.Text;
                    if (pressedButton.Text == "=") currentOperator = "";
                    firstNumber = result;
                    break;
            }
        }
        else
        {
            secondNumber = Double.Parse(Display.Text);
            switch (currentOperator)
            {
                case "+": result = firstNumber + secondNumber; break;
                case "-": result = firstNumber - secondNumber; break;
                case "*": result = firstNumber * secondNumber; break;
                case "/": result = firstNumber / secondNumber; break;
            }

            Display.Text = result.ToString();
            currentOperator = pressedButton.Text;
            if (pressedButton.Text == "=") currentOperator = "";
            firstNumber = result;

        }
    }
    public void Clear(object? sender, EventArgs e)
    {
        firstNumber = 0;
        secondNumber = 0;
        currentOperator = "";
        isFirstNumberAfterOperator = true;
        decimalPressed = false;
        Display.Text = "0";

    }

    public void ClearEntry(object? sender, EventArgs e)
    {
        Display.Text = "0";
        if (currentOperator != "")
        {
            secondNumber = 0;
            return;
        }
        firstNumber = 0;
    }
};