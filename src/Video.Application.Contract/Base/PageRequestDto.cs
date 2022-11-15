using NSwag.Annotations;

namespace Video.Application.Contract.Base;

/// <summary>
/// 
/// </summary>
public class PageRequestDto
{
    
    private int _page=1;
    private int _pageSize=20;
    /// <summary>
    /// 页码：默认1
    /// </summary>
    /// <value></value>
    public int Page{
        get=>_page;
        set=>_page=value<=0?1:value;
    }
    /// <summary>
    /// 页大小：默认20
    /// </summary>
    /// <value></value>
    public int PageSize{
        get=>_pageSize;
        set=>_pageSize=value<=0?20:value;
    }
    /// <summary>
    /// 忽略，只传page和pagesize
    /// </summary>
    /// <returns></returns>
    [OpenApiIgnore]
    public new int SkipCount => (Page-1)*MaxResultCount;
    /// <summary>
    /// 忽略
    /// </summary>
    [OpenApiIgnore]
    public new int MaxResultCount =>
        PageSize>1000
            ?1000
            :PageSize;
}
