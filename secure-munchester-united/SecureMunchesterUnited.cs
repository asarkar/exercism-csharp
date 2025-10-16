using System.Diagnostics.CodeAnalysis;

public class SecurityPassMaker
{
    [SuppressMessage("Performance", "CA1822: Mark members as static")]
    public string GetDisplayName(TeamSupport support) =>
        support switch
        {
            Security s when s.GetType() == typeof(Security) => "Security Team Member Priority Personnel",
            Staff => support.Title,
            _ => "Too Important for a Security Pass"
        };
}

/**** Please do not alter the code below ****/

[SuppressMessage("Style", "IDE1006:Naming rule violation")]
[SuppressMessage("Naming", "CA1715:Identifiers should have correct prefix")]
public interface TeamSupport { string Title { get; } }

public abstract class Staff : TeamSupport { public abstract string Title { get; } }

public class Manager : TeamSupport { public string Title { get; } = "The Manager"; }

public class Chairman : TeamSupport { public string Title { get; } = "The Chairman"; }

public class Physio : Staff { public override string Title { get; } = "The Physio"; }

public class OffensiveCoach : Staff { public override string Title { get; } = "Offensive Coach"; }

public class GoalKeepingCoach : Staff { public override string Title { get; } = "Goal Keeping Coach"; }

public class Security : Staff { public override string Title { get; } = "Security Team Member"; }

public class SecurityJunior : Security { public override string Title { get; } = "Security Junior"; }

public class SecurityIntern : Security { public override string Title { get; } = "Security Intern"; }

public class PoliceLiaison : Security { public override string Title { get; } = "Police Liaison Officer"; }