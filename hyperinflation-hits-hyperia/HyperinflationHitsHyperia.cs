using System.Globalization;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            return $"{checked(@base * multiplier)}";
        }
        catch (OverflowException)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        var gdp = @base * multiplier;
        return gdp is < float.PositiveInfinity and > float.NegativeInfinity ?
            gdp.ToString(CultureInfo.InvariantCulture)
            : "*** Too Big ***";
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            return $"{checked(salaryBase * multiplier)}";
        }
        catch (OverflowException)
        {
            return "*** Much Too Big ***";
        }
    }
}