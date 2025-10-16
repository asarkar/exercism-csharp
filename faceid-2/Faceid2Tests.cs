using Exercism.Tests;

public class Faceid2Tests
{
    [Fact]
    [Task(1)]
    public void AreSameFace_yes()
    {
        Assert.True(Authenticator.AreSameFace(new FacialFeatures("green", 0.9m),
            new FacialFeatures("green", 0.9m)));
    }

    [Fact]
    [Task(1)]
    public void AreSameFace_no()
    {
        Assert.False(Authenticator.AreSameFace(new FacialFeatures("green", 0.9m),
            new FacialFeatures("blue", 0.9m)));
    }

    [Fact]
    [Task(2)]
    public void IsAdmin_with_admin()
    {
        Authenticator authenticator = new();
        Assert.True(authenticator.IsAdmin(new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m))));
    }

    [Fact]
    [Task(2)]
    public void IsAdmin_with_wrong_email()
    {
        Authenticator authenticator = new();
        Assert.False(authenticator.IsAdmin(new Identity("admin@thecompetition.com", new FacialFeatures("green", 0.9m))));
    }

    [Fact]
    [Task(2)]
    public void IsAdmin_with_wrong_face()
    {
        Authenticator authenticator = new();
        Assert.False(authenticator.IsAdmin(new Identity("admin@exerc.ism", new FacialFeatures("blue", 0.9m))));
    }

    [Fact]
    [Task(3)]
    public void Register_new_identity()
    {
        Authenticator authenticator = new();
        Assert.True(authenticator.Register(new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m))));
    }

    [Fact]
    [Task(3)]
    public void Register_existing_identity()
    {
        Authenticator authenticator = new();
        _ = authenticator.Register(new Identity("tunde@thecompetition.com", new FacialFeatures("blue", 0.9m)));
        Assert.False(authenticator.Register(new Identity("tunde@thecompetition.com", new FacialFeatures("blue", 0.9m))));
    }

    [Fact]
    [Task(3)]
    public void IsRegistered_existing_identity()
    {
        Authenticator authenticator = new();
        _ = authenticator.Register(new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m)));
        Assert.True(authenticator.IsRegistered(new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m))));
    }

    [Fact]
    [Task(4)]
    public void IsRegistered_non_existent_identity()
    {
        Authenticator authenticator = new();
        _ = authenticator.Register(new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m)));
        Assert.False(authenticator.IsRegistered(new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.8m))));
    }

    [Fact]
    [Task(5)]
    public void AreSameObject_same_objects()
    {
        Identity identityA = new("alice@thecompetition.com", new FacialFeatures("blue", 0.9m));
        Assert.True(Authenticator.AreSameObject(identityA, identityA));
    }

    [Fact]
    [Task(5)]
    public void AreSameObject_different_objects()
    {
        Identity identityA = new("alice@thecompetition.com", new FacialFeatures("blue", 0.9m));
        Identity identityB = new("alice@thecompetition.com", new FacialFeatures("blue", 0.9m));
        Assert.False(Authenticator.AreSameObject(identityA, identityB));
    }

}