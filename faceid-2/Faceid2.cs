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

        Identity other = (Identity)obj;
        return Email == other.Email && FacialFeatures == other.FacialFeatures;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    private readonly HashSet<Identity> identities = new HashSet<Identity>();
    private readonly Identity admin = new("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA == faceB;

    public bool IsAdmin(Identity identity) => identity.Equals(admin);

    public bool Register(Identity identity) => identities.Add(identity);

    public bool IsRegistered(Identity identity) => identities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) =>
        Object.ReferenceEquals(identityA, identityB);
}
