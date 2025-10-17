public class Orm(Database database)
{
    public void Write(string data)
    {
        using Database db = database;
        db.BeginTransaction();
        db.Write(data);
        db.EndTransaction();
    }

    public bool WriteSafely(string data)
    {
        try
        {
            Write(data);
            return true;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
    }
}