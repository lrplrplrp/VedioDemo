using Microsoft.AspNetCore.Mvc;
using Video.Application.Contract.Code;
using Video.Application.Contract.Code.Dto;

namespace Video.HttpApi.Host.Controllers;

/// <summary>
/// 验证码服务
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CodeController : ControllerBase
{
    private readonly ICodeService _codeService;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="codeService"></param>
    public CodeController(ICodeService codeService)
    {
        _codeService = codeService;
    }
    /// <summary>
    /// 获取验证码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<string> GetAsync([FromQuery] CodeInput input){
        return await _codeService.GetAsync(input);
    }
}
