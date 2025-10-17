public sealed class Orm(Database db) : IDisposable
{
    public void Begin() => Invoke(db.BeginTransaction);

    public void Write(string data) => Invoke(db.Write, data);

    public void Commit() => Invoke(db.EndTransaction);

    public void Dispose() => db.Dispose();

    private void Invoke(Action axn)
    {
        try
        {
            axn();
        }
        catch (InvalidOperationException)
        {
            Dispose();
        }
    }
    private void Invoke(Action<string> axn, string data)
    {
        try
        {
            axn(data);
        }
        catch (InvalidOperationException)
        {
            Dispose();
        }
    }
}