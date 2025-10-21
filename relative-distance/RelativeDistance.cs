internal sealed class RelativeDistance
{
    private readonly Dictionary<string, HashSet<string>> _familyTree = [];

    public RelativeDistance(Dictionary<string, string[]> familyTree)
    {
        foreach (KeyValuePair<string, string[]> item in familyTree)
        {
            var parent = item.Key;
            var children = item.Value;
            for (var i = 0; i < children.Length; i++)
            {
                _ = _familyTree.GetOrAddNew(children[i]).Add(parent);
                _ = _familyTree.GetOrAddNew(parent).Add(children[i]);
                for (var j = 0; j < i; j++)
                {
                    _ = _familyTree.GetOrAddNew(children[i]).Add(children[j]);
                    _ = _familyTree.GetOrAddNew(children[j]).Add(children[i]);
                }
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