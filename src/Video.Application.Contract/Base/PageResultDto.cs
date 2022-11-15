namespace Video.Application.Contract.Base;
/// <summary>
/// 分页Dto
/// </summary>
public class PageResultDto<T>
{
    /// <summary>
    /// 分页数据
    /// </summary>
    /// <value></value>
    public IReadOnlyList<T> Items { get; set; }
    /// <summary>
    /// 总数
    /// </summary>
    /// <value></value>
    public int Count { get; set; }
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="count"></param>
    /// <param name="items"></param>
    public PageResultDto(int count, IReadOnlyList<T> items)
    {
        Count = count;
        Items = items;
    }
}
