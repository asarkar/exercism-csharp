public readonly struct CurrencyAmount(decimal amount, string currency) : IComparable<CurrencyAmount>
{
    private decimal Amount { get; } = amount;
    private string Currency { get; } = currency;

    public int CompareTo(CurrencyAmount other) =>
        Currency == other.Currency
            ? Amount.CompareTo(other.Amount)
            : throw new ArgumentException($"Cannot compare {Currency} with {other.Currency}");

    public override bool Equals(object? obj) =>
        obj is CurrencyAmount a && Amount == a.Amount;

    public override int GetHashCode() =>
        Amount.GetHashCode();

    public static bool operator ==(CurrencyAmount left, CurrencyAmount right) =>
        left.CompareTo(right) == 0;

    public static bool operator !=(CurrencyAmount left, CurrencyAmount right) =>
        !(left == right);

    public static bool operator <(CurrencyAmount left, CurrencyAmount right) =>
        left.CompareTo(right) < 0;

    public static bool operator <=(CurrencyAmount left, CurrencyAmount right) =>
        left == right || left < right;

    public static bool operator >(CurrencyAmount left, CurrencyAmount right) =>
        !(left <= right);

    public static bool operator >=(CurrencyAmount left, CurrencyAmount right) =>
        left == right || left > right;

    public static CurrencyAmount operator +(CurrencyAmount a, CurrencyAmount b) =>
        a.Currency == b.Currency
            ? new CurrencyAmount(a.Amount + b.Amount, a.Currency)
            : throw new ArgumentException($"Cannot compare {a.Currency} with {b.Currency}");

    public static CurrencyAmount operator -(CurrencyAmount a, CurrencyAmount b) =>
        a.Currency == b.Currency
            ? new CurrencyAmount(a.Amount - b.Amount, a.Currency)
            : throw new ArgumentException($"Cannot compare {a.Currency} with {b.Currency}");

    public static CurrencyAmount operator *(CurrencyAmount a, CurrencyAmount b) =>
        a.Currency == b.Currency
            ? new CurrencyAmount(a.Amount * b.Amount, a.Currency)
            : throw new ArgumentException($"Cannot compare {a.Currency} with {b.Currency}");

    public static CurrencyAmount operator /(CurrencyAmount a, CurrencyAmount b) =>
        a.Currency == b.Currency
            ? new CurrencyAmount(a.Amount / b.Amount, a.Currency)
            : throw new ArgumentException($"Cannot compare {a.Currency} with {b.Currency}");

    public static explicit operator double(CurrencyAmount a) =>
        (double)a.Amount;

    public static implicit operator decimal(CurrencyAmount a) =>
        a.Amount;
}