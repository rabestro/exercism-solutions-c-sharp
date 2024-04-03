using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation) => operation switch
    {
        "+" => $"{operand1} + {operand2} = {operand1 + operand2}",
        "*" => $"{operand1} * {operand2} = {operand1 * operand2}",
        "/" => operand2 == 0
            ? "Division by zero is not allowed."
            : $"{operand1} / {operand2} = {operand1 / operand2}",
        null => throw new ArgumentNullException(nameof(operation)),
        "" => throw new ArgumentException("Operation is empty"),
        _ => throw new ArgumentOutOfRangeException(nameof(operation))
    };
}
