using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalculatorApp.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private double _memory = 0;
    private double _operand = 0;
    private string _pendingOperator = "";
    private bool _newEntry = true;

    public MainWindow()
    {
        InitializeComponent();
    }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        this.Focus(); 
    }

    private void Number_Click(object sender, RoutedEventArgs e)
    {
        string num = (string)((Button)sender).Content;
        if (_newEntry || DisplayTextBox.Text == "0")
        {
            if (num == "0" || num == "00")
                return;
            DisplayTextBox.Text = num;
        }
        else if (DisplayTextBox.Text.Length < 20)
        {
            DisplayTextBox.Text += num;
        }
        _newEntry = false;
    }

    private void Decimal_Click(object sender, RoutedEventArgs e)
    {
        if (_newEntry)
        {
            DisplayTextBox.Text = "0.";
        }
        else if (!DisplayTextBox.Text.Contains("."))
        {
            DisplayTextBox.Text += ".";
        }
        _newEntry = false;
    }

    private void Operator_Click(object sender, RoutedEventArgs e)
    {
        string op = (string)((Button)sender).Content;
        double currentValue = double.Parse(DisplayTextBox.Text);

        if (!_newEntry)
        {
            Calculate(currentValue);
        }

        _pendingOperator = op;
        _operand = double.Parse(DisplayTextBox.Text);
        _newEntry = true;
    }

    private void Equals_Click(object sender, RoutedEventArgs e)
    {
        double currentValue = double.Parse(DisplayTextBox.Text);
        Calculate(currentValue);
        _pendingOperator = "";
        _operand = 0;
        _newEntry = true;
    }
    private void Calculate(double currentValue)
    {
        switch (_pendingOperator)
        {
            case "+":
                DisplayTextBox.Text = (_operand + currentValue).ToString();
                break;
            case "-":
                DisplayTextBox.Text = (_operand - currentValue).ToString();
                break;
            case "x":
                DisplayTextBox.Text = (_operand * currentValue).ToString();
                break;
            case "÷":
                if (currentValue == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }
                DisplayTextBox.Text = (_operand / currentValue).ToString();
                break;
            case "%":
                DisplayTextBox.Text = (currentValue / 100).ToString();
                break;
        }
    }

    private void Backspace_Click(object sender, RoutedEventArgs e)
    {
        if (DisplayTextBox.Text.Length > 1)
        {
            DisplayTextBox.Text = DisplayTextBox.Text[..^1];
        }
        else
        {
            DisplayTextBox.Text = "0";
        }
    }

    private void AllClear_Click(object sender, RoutedEventArgs e)
    {
        _memory = 0;
        DisplayTextBox.Text = "0";
        _operand = 0;
        _pendingOperator = "";
        _newEntry = true;
    }

    private void MemoryAdd_Click(object sender, RoutedEventArgs e)
    {
        string currentValue = DisplayTextBox.Text;

        if (!_newEntry && !string.IsNullOrEmpty(_pendingOperator))
        {
            Equals_Click(null, null);
        }

        if (double.TryParse(DisplayTextBox.Text, out double result))
        {
            _memory += result;
        }

        DisplayTextBox.Text = currentValue;

        _newEntry = true;
    }

    private void MemorySub_Click(object sender, RoutedEventArgs e)
    {
        string currentValue = DisplayTextBox.Text;

        if (!_newEntry && !string.IsNullOrEmpty(_pendingOperator))
        {
            Equals_Click(null, null);
        }

        if (double.TryParse(DisplayTextBox.Text, out double result))
        {
            _memory -= result;
        }

        DisplayTextBox.Text = currentValue;

        _newEntry = true;
    }

    private void MemoryRecall_Click(object sender, RoutedEventArgs e)
    {
        DisplayTextBox.Text = _memory.ToString();
        _newEntry = true;
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key >= Key.D0 && e.Key <= Key.D9)
            Number_ClickFromKeyboard(e.Key - Key.D0);
        else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            Number_ClickFromKeyboard(e.Key - Key.NumPad0);
        else if (e.Key == Key.Add || e.Key == Key.OemPlus)
            Operator_ClickFromKeyboard("+");
        else if (e.Key == Key.Subtract || e.Key == Key.OemMinus)
            Operator_ClickFromKeyboard("-");
        else if (e.Key == Key.Multiply)
            Operator_ClickFromKeyboard("x");
        else if (e.Key == Key.Divide || e.Key == Key.Oem2)
            Operator_ClickFromKeyboard("÷");
        else if (e.Key == Key.Decimal || e.Key == Key.OemPeriod)
            Decimal_Click(null, null);
        else if (e.Key == Key.Enter || e.Key == Key.Return)
            Equals_Click(null, null);
        else if (e.Key == Key.Back)
            Backspace_Click(null, null);
    }

    private void Number_ClickFromKeyboard(int num)
    {
        Button fake = new() { Content = num.ToString() };
        Number_Click(fake, null);
    }

    private void Operator_ClickFromKeyboard(string op)
    {
        Button fake = new() { Content = op };
        Operator_Click(fake, null);
    }
}