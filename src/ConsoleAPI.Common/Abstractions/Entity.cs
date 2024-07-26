namespace ConsoleAPI.Common.Abstractions;

public abstract class Entity<TKey>
{
    public TKey Id { get; set; }
}

public abstract class Entity : Entity<int>
{
    
}