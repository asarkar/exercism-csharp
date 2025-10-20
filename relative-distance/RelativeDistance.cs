internal sealed class RelativeDistance
{
    private readonly Dictionary<string, HashSet<string>> _familyTree = [];

    public RelativeDistance(Dictionary<string, string[]> familyTree)
    {
        foreach (KeyValuePair<string, string[]> item in familyTree)
        {
            var parent = item.Key;
            var children = item.Value;
            if (children.Length > 0)
            {
                _ = _familyTree.GetOrAddNew(children[0]).Add(parent);
                _ = _familyTree.GetOrAddNew(parent).Add(children[0]);
            }
            for (var i = 1; i < children.Length; i++)
            {
                _ = _familyTree.GetOrAddNew(children[i]).Add(parent);
                _ = _familyTree.GetOrAddNew(parent).Add(children[i]);
                _ = _familyTree.GetOrAddNew(children[i]).Add(children[i - 1]);
                _ = _familyTree.GetOrAddNew(children[i - 1]).Add(children[i]);
            }
        }
    }

    public int DegreeOfSeparation(string personA, string personB)
    {
        var queue = new Queue<ValueTuple<string, int>>();
        queue.Enqueue((personA, 0));

        while (queue.Count > 0)
        {
            (var u, var d) = queue.Dequeue();
            if (u == personB)
            {
                return d;
            }
            if (_familyTree.Pop(u, out HashSet<string>? relatives))
            {
                foreach (var relative in relatives!)
                {
                    if (_familyTree.ContainsKey(relative))
                    {
                        queue.Enqueue((relative, d + 1));
                    }
                }
            }
        }
        return -1;
    }
}