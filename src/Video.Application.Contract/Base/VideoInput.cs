namespace Video.Application.Contract.Base;

public class VideoInput:PageRequestDto
{
    /// <summary>
    /// 关键字
    /// </summary>
    /// <value></value>
    public string? Keywords { get; set; }
    /// <summary>
    /// 开始时间
    /// </summary>
    /// <value></value>
    public DateTime? StartTime { get; set; }
    /// <summary>
    /// 结束时间
    /// </summary>
    /// <value></value>
    public DateTime? EndTime { get; set; }
}
