using Video.Domain.Shared;

namespace Video.Application.Contract.Code.Dto;

/// <summary>
/// 验证码输入
/// </summary>
public class CodeInput
{
    /// <summary>
    /// 内容
    /// </summary>
    /// <value></value>
    public string? Value { get; set; }
    /// <summary>
    /// 验证码类型
    /// </summary>
    /// <value></value>
    public CodeType Type { get; set; }
}
