using System.Diagnostics.CodeAnalysis;

public readonly struct Coord(ushort x, ushort y)
{
    public ushort X { get; } = x;
    public ushort Y { get; } = y;
}

public readonly struct Plot(Coord first, Coord x, Coord y, Coord last)
{
    public Coord First { get; } = first;
    public Coord Last { get; } = last;
    // Silence CS9113: Parameter is unread.
    [SuppressMessage("CodeQuality", "IDE0052: Remove unread private member")]
    private readonly bool _ = (x, y).Equals((first, last));
}

public class ClaimsHandler
{
    private readonly HashSet<Plot> _plots = [];
    private Plot? _lastClaim;

    public void StakeClaim(Plot plot)
    {
        if (_plots.Add(plot))
        {
            _lastClaim = plot;
        }
    }

    public bool IsClaimStaked(Plot plot) => _plots.Contains(plot);

    public bool IsLastClaim(Plot plot) =>
        plot.Equals(_lastClaim);

    public Plot GetClaimWithLongestSide() =>
        _plots.MaxBy(p =>
            Math.Max(Math.Abs(p.Last.X - p.First.X), Math.Abs(p.Last.Y - p.First.Y)));
}