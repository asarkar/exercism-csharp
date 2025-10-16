using Exercism.Tests;

public class SecureMunchesterUnitedTests
{
    [Fact]
    [Task(1)]
    public void DisplaySecurityPass_manager()
    {
        SecurityPassMaker spm = new();
        Assert.Equal("Too Important for a Security Pass", spm.GetDisplayName(new Manager()));
    }

    [Fact]
    [Task(1)]
    public void DisplaySecurityPass_physio()
    {
        SecurityPassMaker spm = new();
        Assert.Equal("The Physio", spm.GetDisplayName(new Physio()));
    }

    [Fact]
    [Task(2)]
    public void DisplaySecurityPass_security()
    {
        SecurityPassMaker spm = new();
        Assert.Equal("Security Team Member Priority Personnel", spm.GetDisplayName(new Security()));
    }

    [Fact]
    [Task(3)]
    public void DisplaySecurityPass_security_junior()
    {
        SecurityPassMaker spm = new();
        Assert.Equal("Security Junior", spm.GetDisplayName(new SecurityJunior()));
    }

    [Fact]
    [Task(3)]
    public void DisplaySecurityPass_security_police_liaison()
    {
        SecurityPassMaker spm = new();
        Assert.Equal("Police Liaison Officer", spm.GetDisplayName(new PoliceLiaison()));
    }

    [Fact]
    [Task(3)]
    public void DisplaySecurityPass_security_intern()
    {
        SecurityPassMaker spm = new();
        Assert.Equal("Security Intern", spm.GetDisplayName(new SecurityIntern()));
    }
}