using System.Collections.Generic;

public interface IRepository<TKey, Tvalue>
{
    IReadOnlyDictionary<TKey, Tvalue> Collection { get; }
}
