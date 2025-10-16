public record FacialFeatures(string EyeColor, decimal PhiltrumWidth);

public class Identity(string email, FacialFeatures facialFeatures)
{
    public string Email { get; } = email;
    public FacialFeatures FacialFeatures { get; } = facialFeatures;

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (Identity)obj;
        return Email == other.Email && FacialFeatures == other.FacialFeatures;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    private readonly HashSet<Identity> _identities = [];
    private readonly Identity _admin = new("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA == faceB;

    public bool IsAdmin(Identity identity) => identity.Equals(_admin);

    public bool Register(Identity identity) => _identities.Add(identity);

    public bool IsRegistered(Identity identity) => _identities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) =>
        ReferenceEquals(identityA, identityB);
}