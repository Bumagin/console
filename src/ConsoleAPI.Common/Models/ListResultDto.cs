namespace ConsoleAPI.Common.Dto;

public class ListResultDto<T>
{
    public IReadOnlyList<T> Items
    {
        get { return _items ?? (_items = new List<T>()); }
        set { _items = value; }
    }
    private IReadOnlyList<T> _items;
    
    public ListResultDto()
    {

    }
    
    public ListResultDto(IReadOnlyList<T> items)
    {
        Items = items;
    }
}