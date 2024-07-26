namespace ConsoleAPI.Common.Abstractions;

public abstract class EntityDto<TKey>
{
    public TKey Id { get; set; }
}

public abstract class EntityDto : Entity<int>
{
    
}