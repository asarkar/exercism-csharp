public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        return operation switch
        {
            "+" => Eval((x, y) => x + y),
            "*" => Eval((x, y) => x * y),
            "/" when operand2 != 0 => Eval((x, y) => x / y),
            "/" => "Division by zero is not allowed.",
            "" => throw new ArgumentException("operation must not be empty"),
            { } => throw new ArgumentOutOfRangeException($"unknown operation: {operation}"),
            _ => throw new ArgumentNullException(nameof(operation), (string?)null)
        };


        string Eval(Func<int, int, int> op) => $"{operand1} {operation} {operand2} = {checked(op(operand1, operand2))}";
    }
}