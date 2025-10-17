using System.Diagnostics.CodeAnalysis;
using System.Globalization;

internal sealed class WeighingMachine(int precision)
{
    // C# 14 introduced `field` keyword.
    // https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-14#the-field-keyword
    [SuppressMessage("Style", "IDE0032: Use auto-implemented property")]
    private double _weight;
    public int Precision { get; } = precision;

    public double Weight
    {
        get => _weight;
        set
        {
            if (value < 0)
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value, "Weight cannot be negative.");

            }
            _weight = value;
        }
    }

    public double TareAdjustment { get; set; } = 5.0;

    public string DisplayWeight
    {
        get
        {
            var w = (Weight - TareAdjustment).ToString($"F{Precision}", CultureInfo.InvariantCulture);
            return $"{w} kg";
        }
    }
}