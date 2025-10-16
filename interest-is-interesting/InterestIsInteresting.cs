internal static class SavingsAccount
{
    public static float InterestRate(decimal balance) =>
        balance switch
        {
            < 0 => 3.213f,
            < 1000 => 0.5f,
            < 5000 => 1.621f,
            _ => 2.475f
        };

    public static decimal Interest(decimal balance) => balance * ((decimal)InterestRate(balance) / 100);

    public static decimal AnnualBalanceUpdate(decimal balance) => balance + Interest(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        var numYears = 0;
        for (; balance < targetBalance; balance = AnnualBalanceUpdate(balance), numYears++)
        {
            ;
        }

        return numYears;
    }
}