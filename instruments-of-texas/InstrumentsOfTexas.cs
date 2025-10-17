using System.Diagnostics.CodeAnalysis;

public class CalculationException(int operand1, int operand2, string message, Exception inner) :
    Exception(message, inner)
{
    public int Operand1 { get; } = operand1;
    public int Operand2 { get; } = operand2;
}

public class CalculatorTestHarness(Calculator calculator)
{

    public string TestMultiplication(int x, int y)
    {
        try
        {
            Multiply(x, y);
            return "Multiply succeeded";
        }
        catch (CalculationException ex)
        {
            return ex.Message;
        }
    }

    public void Multiply(int x, int y)
    {
        try
        {
            _ = calculator.Multiply(x, y);
        }
        catch (OverflowException ex)
        {
            var msg = x < 0 && y < 0 ?
                "Multiply failed for negative operands. Arithmetic operation resulted in an overflow." :
                "Multiply failed for mixed or positive operands. Arithmetic operation resulted in an overflow.";
            throw new CalculationException(x, y, msg, ex);
        }
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    [SuppressMessage("Performance", "CA1822: Mark members as static")]
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}