internal enum AccountType
{ Guest, User, Moderator }

[Flags]
internal enum Permission : byte
{
    None = 0x0,
    Read = 0x1,
    Write = 0x2,
    Delete = 0x4,
    All = Read | Write | Delete
}

internal static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        return accountType switch
        {
            AccountType.Guest => Permission.Read,
            AccountType.User => Permission.Read | Permission.Write,
            AccountType.Moderator => Permission.All,
            _ => Permission.None
        };
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        return current | grant;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        return current & ~revoke;
    }

    // Check if all bits in `check` are also set in `current`.
    public static bool Check(Permission current, Permission check)
    {
        return (current & check) == check;
    }
}